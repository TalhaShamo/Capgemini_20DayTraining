using System;
namespace D1_Training.Day1;
public class SecondLargest
{
    public static void Run()
    {
        int[] arrVar = { 2, 4, 3, 6, 5, 9 };
        Array.Sort(arrVar);
        
        // Note: Array.Sort sorts ascending (smallest to largest).
        // arrVar[1] gives the second smallest. 
        // To get the second largest, you count from the end using the ^ operator:
        Console.WriteLine($"Second Largest element : {arrVar[^2]}");
    }
}