using System;

namespace D1_Training.Day1;

public class MergeArrays
{
    public static void Run()
    {
        int[] arr1 = { 1, 2, 3 };
        int[] arr2 = { 4, 5, 6 };
        int[] merged = new int[arr1.Length + arr2.Length];

        for (int i = 0; i < arr1.Length; i++)
        {
            merged[i] = arr1[i];
        }
        for (int i = 0; i < arr2.Length; i++)
        {
            merged[arr1.Length + i] = arr2[i];
        }
        
        Console.WriteLine("Merged Array:");
        for (int i = 0; i < merged.Length; i++)
        {
            Console.Write(merged[i] + " ");
        }
        Console.WriteLine(); // Add a new line at the end for clean terminal output
    }
}