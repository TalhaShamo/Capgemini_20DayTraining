using System;
using System.Collections.Generic;

public class BTreeNode
{
    public List<int> Keys { get; set; }
    public List<BTreeNode> Children { get; set; }
    public bool IsLeaf { get; set; }
    public int MinDegree { get; private set; } // Minimum degree (defines the range for number of keys)

    public BTreeNode(int minDegree, bool isLeaf)
    {
        MinDegree = minDegree;
        IsLeaf = isLeaf;
        Keys = new List<int>();
        Children = new List<BTreeNode>();
    }

    // Traverse all nodes in a subtree rooted with this node
    public void Traverse()
    {
        int i;
        for (i = 0; i < Keys.Count; i++)
        {
            if (!IsLeaf)
            {
                Children[i].Traverse();
            }
            Console.Write(Keys[i] + " ");
        }

        if (!IsLeaf)
        {
            Children[i].Traverse();
        }
    }

    // Search key k in subtree rooted with this node
    public BTreeNode Search(int k)
    {
        int i = 0;
        while (i < Keys.Count && k > Keys[i])
        {
            i++;
        }

        if (i < Keys.Count && Keys[i] == k)
        {
            return this;
        }

        if (IsLeaf)
        {
            return null;
        }

        return Children[i].Search(k);
    }

    // Insert a new key in this node (when the node is not full)
    public void InsertNonFull(int k)
    {
        int i = Keys.Count - 1;

        if (IsLeaf)
        {
            // Find location and insert key into the sorted list
            Keys.Add(0);
            while (i >= 0 && Keys[i] > k)
            {
                Keys[i + 1] = Keys[i];
                i--;
            }
            Keys[i + 1] = k;
        }
        else
        {
            while (i >= 0 && Keys[i] > k)
            {
                i--;
            }
            i++;

            // If the child is full, split it
            if (Children[i].Keys.Count == (2 * MinDegree) - 1)
            {
                SplitChild(i, Children[i]);

                if (Keys[i] < k)
                {
                    i++;
                }
            }
            Children[i].InsertNonFull(k);
        }
    }

    // Split child y of this node at index i
    public void SplitChild(int i, BTreeNode y)
    {
        BTreeNode z = new BTreeNode(y.MinDegree, y.IsLeaf);

        // Copy the last (MinDegree - 1) keys of y to z
        for (int j = 0; j < MinDegree - 1; j++)
        {
            z.Keys.Add(y.Keys[j + MinDegree]);
        }

        // Copy the last MinDegree children of y to z
        if (!y.IsLeaf)
        {
            for (int j = 0; j < MinDegree; j++)
            {
                z.Children.Add(y.Children[j + MinDegree]);
            }
        }

        // Reduce the number of keys in y
        int middleKey = y.Keys[MinDegree - 1];
        y.Keys.RemoveRange(MinDegree - 1, y.Keys.Count - (MinDegree - 1));
        if (!y.IsLeaf)
        {
            y.Children.RemoveRange(MinDegree, y.Children.Count - MinDegree);
        }

        // Insert new child into this node
        Children.Insert(i + 1, z);
        Keys.Insert(i, middleKey);
    }

    // Remove key k from subtree rooted with this node
    public void Remove(int k)
    {
        int idx = FindKey(k);

        // The key to be removed is present in this node
        if (idx < Keys.Count && Keys[idx] == k)
        {
            if (IsLeaf)
            {
                RemoveFromLeaf(idx);
            }
            else
            {
                RemoveFromNonLeaf(idx);
            }
        }
        else
        {
            if (IsLeaf)
            {
                Console.WriteLine($"The key {k} does not exist in the tree.");
                return;
            }

            bool flag = (idx == Keys.Count);

            // Fill child if it has less than MinDegree keys
            if (Children[idx].Keys.Count < MinDegree)
            {
                Fill(idx);
            }

            if (flag && idx > Keys.Count)
            {
                Children[idx - 1].Remove(k);
            }
            else
            {
                Children[idx].Remove(k);
            }
        }
    }

    private int FindKey(int k)
    {
        int idx = 0;
        while (idx < Keys.Count && Keys[idx] < k)
        {
            idx++;
        }
        return idx;
    }

    private void RemoveFromLeaf(int idx)
    {
        Keys.RemoveAt(idx);
    }

    private void RemoveFromNonLeaf(int idx)
    {
        int k = Keys[idx];

        if (Children[idx].Keys.Count >= MinDegree)
        {
            int pred = GetPredecessor(idx);
            Keys[idx] = pred;
            Children[idx].Remove(pred);
        }
        else if (Children[idx + 1].Keys.Count >= MinDegree)
        {
            int succ = GetSuccessor(idx);
            Keys[idx] = succ;
            Children[idx + 1].Remove(succ);
        }
        else
        {
            Merge(idx);
            Children[idx].Remove(k);
        }
    }

    private int GetPredecessor(int idx)
    {
        BTreeNode cur = Children[idx];
        while (!cur.IsLeaf)
        {
            cur = cur.Children[cur.Keys.Count];
        }
        return cur.Keys[cur.Keys.Count - 1];
    }

    private int GetSuccessor(int idx)
    {
        BTreeNode cur = Children[idx + 1];
        while (!cur.IsLeaf)
        {
            cur = cur.Children[0];
        }
        return cur.Keys[0];
    }

    private void Fill(int idx)
    {
        if (idx != 0 && Children[idx - 1].Keys.Count >= MinDegree)
        {
            BorrowFromPrev(idx);
        }
        else if (idx != Keys.Count && Children[idx + 1].Keys.Count >= MinDegree)
        {
            BorrowFromNext(idx);
        }
        else
        {
            if (idx != Keys.Count)
            {
                Merge(idx);
            }
            else
            {
                Merge(idx - 1);
            }
        }
    }

    private void BorrowFromPrev(int idx)
    {
        BTreeNode child = Children[idx];
        BTreeNode sibling = Children[idx - 1];

        child.Keys.Insert(0, Keys[idx - 1]);

        if (!child.IsLeaf)
        {
            child.Children.Insert(0, sibling.Children[sibling.Children.Count - 1]);
            sibling.Children.RemoveAt(sibling.Children.Count - 1);
        }

        Keys[idx - 1] = sibling.Keys[sibling.Keys.Count - 1];
        sibling.Keys.RemoveAt(sibling.Keys.Count - 1);
    }

    private void BorrowFromNext(int idx)
    {
        BTreeNode child = Children[idx];
        BTreeNode sibling = Children[idx + 1];

        child.Keys.Add(Keys[idx]);

        if (!child.IsLeaf)
        {
            child.Children.Add(sibling.Children[0]);
            sibling.Children.RemoveAt(0);
        }

        Keys[idx] = sibling.Keys[0];
        sibling.Keys.RemoveAt(0);
    }

    private void Merge(int idx)
    {
        BTreeNode child = Children[idx];
        BTreeNode sibling = Children[idx + 1];

        child.Keys.Add(Keys[idx]);

        for (int i = 0; i < sibling.Keys.Count; i++)
        {
            child.Keys.Add(sibling.Keys[i]);
        }

        if (!child.IsLeaf)
        {
            for (int i = 0; i < sibling.Children.Count; i++)
            {
                child.Children.Add(sibling.Children[i]);
            }
        }

        Keys.RemoveAt(idx);
        Children.RemoveAt(idx + 1);
    }
}

public class BTree
{
    private BTreeNode root;
    public int MinDegree { get; private set; }

    public BTree(int minDegree)
    {
        if (minDegree < 2)
            throw new ArgumentException("B-Tree minimum degree must be at least 2.");

        root = null;
        MinDegree = minDegree;
    }

    public void Traverse()
    {
        if (root != null)
        {
            root.Traverse();
            Console.WriteLine();
        }
    }

    public BTreeNode Search(int k)
    {
        return root?.Search(k);
    }

    public void Insert(int k)
    {
        if (root == null)
        {
            root = new BTreeNode(MinDegree, true);
            root.Keys.Add(k);
        }
        else
        {
            // If root is full, tree grows in height
            if (root.Keys.Count == (2 * MinDegree) - 1)
            {
                BTreeNode s = new BTreeNode(MinDegree, false);
                s.Children.Add(root);
                s.SplitChild(0, root);

                int i = 0;
                if (s.Keys[0] < k)
                {
                    i++;
                }
                s.Children[i].InsertNonFull(k);

                root = s;
            }
            else
            {
                root.InsertNonFull(k);
            }
        }
    }

    public void Delete(int k)
    {
        if (root == null)
        {
            Console.WriteLine("The tree is empty.");
            return;
        }

        root.Remove(k);

        // If root becomes empty, make its first child the new root
        if (root.Keys.Count == 0)
        {
            if (root.IsLeaf)
            {
                root = null;
            }
            else
            {
                root = root.Children[0];
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BTree tree = new BTree(3); // Minimum degree 3

        Console.WriteLine("Inserting keys: 10, 20, 5, 6, 12, 30, 7, 17");
        int[] keysToInsert = { 10, 20, 5, 6, 12, 30, 7, 17 };
        foreach (int key in keysToInsert)
        {
            tree.Insert(key);
        }

        Console.Write("Traversal of tree constructed is: ");
        tree.Traverse();

        int searchKey = 6;
        Console.WriteLine($"\nSearching for key {searchKey}...");
        BTreeNode result = tree.Search(searchKey);
        Console.WriteLine(result != null ? $"Key {searchKey} found!" : $"Key {searchKey} not found.");

        Console.WriteLine("\nDeleting key 6...");
        tree.Delete(6);

        Console.Write("Traversal after deleting 6: ");
        tree.Traverse();
    }
}