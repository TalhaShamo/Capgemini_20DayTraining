using System;
using System.Collections.Generic;
namespace D1_Training.Day1;

public class DuplicateCount
{
    public static void Run()
    {
        int[] arrVar = { 2, 3, 1, 5, 6, 9, 7, 9, 7 };
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        foreach (int num in arrVar)
        {
            if (frequency.ContainsKey(num))
            {
                frequency[num]++;
            }
            else
            {
                frequency[num] = 1;
            }
        }
        Console.WriteLine("Elements with their duplicate count: ");
        foreach (var v in frequency)
        {
            if (v.Value > 1)
            {
                Console.WriteLine($"{v.Key} : {v.Value}");
            }
        }
    }
}