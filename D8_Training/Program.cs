using System;
class IndirectRecursionDemo
{
    static int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    static bool IsEven(int n)
    {
        if (n == 0)
            return true;

        return IsOdd(n - 1);
    }

    static bool IsOdd(int n)
    {
        if (n == 0)
            return false; 

        return IsEven(n - 1);
    }

    static void Main()
    {
        Console.WriteLine("1. Direct Recursion (Fibonacci)");
        Console.WriteLine("2. Indirect Recursion (Odd/Even)");

        int n = int.Parse(Console.ReadLine());

        if(n == 1)
        {
            int terms = 10;

            Console.WriteLine($"First {terms} terms of the Fibonacci Series:");

            for (int i = 0; i < terms; i++)
            {
                Console.Write($"{Fibonacci(i)} ");
            }
        }
        else if(n == 2)
        {
            Console.WriteLine("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            bool result = IsEven(num);
            if (result)
            {
                Console.WriteLine($"{num} is Even!");
            }
            else
            {
                Console.WriteLine($"{num} is Odd");
            }
        }
        else
        {
            Console.WriteLine("Enter the right option!");
        }
    }
}
