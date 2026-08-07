using System;

namespace MutualRecursionDemo
{
    class Program
    {
        static bool IsPositiveChain(int n)
        {
            Console.WriteLine($"IsPositiveChain({n}) -> applying -1");

            if (n == 0) return true;

            if (n < 0 || n > 1) return false;

            // Mutual Recursive Call
            return IsNegativeChain(n - 1);
        }
        static bool IsNegativeChain(int n)
        {
            Console.WriteLine($"IsNegativeChain({n}) -> applying +1");

            if (n == 0) return true;

            if (n > 0 || n < -1) return false;

            return IsPositiveChain(n + 1);
        }

        static void Main()
        {
            Console.WriteLine("--- Testing n = 1 in PositiveChain ---");
            bool result1 = IsPositiveChain(1);
            Console.WriteLine($"Result: {result1}\n");

            Console.WriteLine("--- Testing n = 2 in PositiveChain ---");
            bool result2 = IsPositiveChain(2);
            Console.WriteLine($"Result: {result2}");
        }
    }
}