using System;

namespace TreeRecursionDemo
{
    class Program
    {
        // Tree Recursive Function: Calls itself TWICE per run
        static void PrintTree(int n, string indent = "")
        {
            // Base Case: Stop branching when we reach 0
            if (n <= 0) return;

            Console.WriteLine($"{indent}├── Branch({n})");

            // 1st Recursive Call (Left Branch)
            PrintTree(n - 1, indent + "│   ");

            // 2nd Recursive Call (Right Branch)
            PrintTree(n - 1, indent + "│   ");
        }

        static void Main()
        {
            Console.WriteLine("Root");
            PrintTree(3);
        }
    }
}