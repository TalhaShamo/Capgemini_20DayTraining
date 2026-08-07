using System;

class Program
{
    static void SumDigitsReversed(int n)
    {
        if (n == 0)
            return;

        SumDigitsReversed(n / 10);
        Console.Write(n % 10);
    }

    static void Main()
    {
        SumDigitsReversed(12345);
    }
}