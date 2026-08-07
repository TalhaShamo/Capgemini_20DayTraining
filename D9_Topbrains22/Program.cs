using System;

class Program
{
    static int CountPaths(int rows, int cols)
    {
        if (rows == 1 || cols == 1)
            return 1;

        return CountPaths(rows - 1, cols) + CountPaths(rows, cols - 1);
    }

    static void Main()
    {
        Console.WriteLine(CountPaths(3, 3));
    }
}