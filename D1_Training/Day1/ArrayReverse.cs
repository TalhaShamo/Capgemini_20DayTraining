using System;

namespace D1_Training.Day1;

public class ArrayReverse
{
    public static void Run()
    {
        int[] array = { 3, 5, 7, 9 };
        Array.Reverse(array);
        
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
        }
    }
}