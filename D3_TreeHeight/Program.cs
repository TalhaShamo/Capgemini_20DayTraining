using System;
using System.IO;

class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int data)
    {
        this.data = data;
        left = null;
        right = null;
    }
}

class Solution
{
    static int getHeight(Node root)
    {
        if (root == null)
        {
            return -1;
        }

        int leftHeight = getHeight(root.left);
        int rightHeight = getHeight(root.right);

        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public static Node insert(Node root, int data)
    {
        if (root == null)
        {
            return new Node(data);
        }
        else
        {
            Node cur;
            if (data <= root.data)
            {
                cur = insert(root.left, data);
                root.left = cur;
            }
            else
            {
                cur = insert(root.right, data);
                root.right = cur;
            }
            return root;
        }
    }

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        string[] values = Console.ReadLine().Split(' ');
        Node root = null;

        for (int i = 0; i < t; i++)
        {
            int data = Convert.ToInt32(values[i]);
            root = insert(root, data);
        }

        int height = getHeight(root);
        Console.WriteLine(height);
    }
}