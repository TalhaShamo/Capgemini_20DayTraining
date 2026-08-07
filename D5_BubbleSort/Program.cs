using System;
namespace D5_BubbleSort
{
    class Program
    {
        static void Main()
        {
            int[] arrVar = {2, 4, 3, 1, 6, 7};
            int n = arrVar.Length;

            for(int i=0; i<n - 1; i++)
            {
                for(int j=0; j<n - 1 - i; j++)
                {
                    if(arrVar[j] > arrVar[j + 1])
                    {
                        int temp = arrVar[j+1];
                        arrVar[j + 1] = arrVar[j];
                        arrVar[j] = temp;
                    }
                }
            }

            foreach(var v in arrVar)
            {
                Console.Write($"{v} ");
            }
        }
    }
}