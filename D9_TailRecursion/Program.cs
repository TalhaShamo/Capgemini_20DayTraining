using System;

class Program
{
    static int Factorial(int n, int accumulator = 1)
    {
        if (n <= 1)
            return accumulator;

        return Factorial(n - 1, n * accumulator);
    }

    static void Main()
    {
        Console.WriteLine(Factorial(5));
    }
}