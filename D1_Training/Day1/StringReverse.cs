using System;

namespace D1_Training.Day1;

public class StringReverse
{
    public static void Run()
    {
        string str = "Welcome to Capgemini";
        char[] arrVar = str.ToCharArray();

        Array.Reverse(arrVar);

        string reversed = new string(arrVar);

        Console.WriteLine(reversed);
    }
}