using System;
using System.Collections.Generic;
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
    public static void inOrder(Node root)
    {
        if (root == null)
            return;

        inOrder(root.left);
        Console.Write(root.data + " ");
        inOrder(root.right);
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

        inOrder(root);
    }
}