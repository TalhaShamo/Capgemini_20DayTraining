using System;
namespace D1_Training.Day1;
public class EvenOddCount
{
    public static void Run()
    {
        int[] oddEvenCount = { 3, 5, 3, 2, 6, 5, 8 };
        int evenCount = 0;
        int oddCount = 0;
        
        for (int i = 0; i < oddEvenCount.Length; i++)
        {
            if (oddEvenCount[i] % 2 == 0)
            {
                evenCount++;
            }
            else
            {
                oddCount++;
            }
        }
        Console.WriteLine($"Even count: {evenCount}");
        Console.WriteLine($"Odd count: {oddCount}");
    }
}