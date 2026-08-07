// // using System;
// // using System.Collections.Generic;

// // namespace D5_SelectionSortList
// // {
// //     class Program
// //     {
// //         static void Main()
// //         {
// //             List<int> listVar = new List<int> { 2, 4, 3, 1, 6, 7 };
// //             int n = listVar.Count;

// //             for (int i = 0; i < n - 1; i++)
// //             {
// //                 int minIndex = i;

// //                 for (int j = i + 1; j < n; j++)
// //                 {
// //                     if (listVar[j] < listVar[minIndex])
// //                     {
// //                         minIndex = j;
// //                     }
// //                 }

// //                 int temp = listVar[minIndex];
// //                 listVar[minIndex] = listVar[i];
// //                 listVar[i] = temp;
// //             }

// //             foreach (var v in listVar)
// //             {
// //                 Console.Write($"{v} ");
// //             }
// //         }
// //     }
// // }

// using System;
// using System.Collections.Generic;

// namespace SortingDemo
// {
//     class InsertionSortProgram
//     {
//         static void Main()
//         {
//             List<int> listVar = new List<int> { 2, 4, 3, 1, 6, 7 };

//             for (int i = 1; i < listVar.Count; i++)
//             {
//                 int key = listVar[i];
//                 int j = i - 1;

//                 while (j >= 0 && listVar[j] > key)
//                 {
//                     listVar[j + 1] = listVar[j];
//                     j--;
//                 }

//                 listVar[j + 1] = key;
//             }

//             foreach (var v in listVar)
//             {
//                 Console.Write($"{v} ");
//             }
//         }
//     }
// }

// using System;
// using System.Collections.Generic;

// namespace SortingDemo
// {
//     class QuickSortProgram
//     {
//         static void QuickSort(List<int> list, int low, int high)
//         {
//             if (low < high)
//             {
//                 int pivotIndex = Partition(list, low, high);
//                 QuickSort(list, low, pivotIndex - 1);
//                 QuickSort(list, pivotIndex + 1, high);
//             }
//         }

//         static int Partition(List<int> list, int low, int high)
//         {
//             int pivot = list[high];
//             int i = low - 1;

//             for (int j = low; j < high; j++)
//             {
//                 if (list[j] < pivot)
//                 {
//                     i++;
//                     (list[i], list[j]) = (list[j], list[i]);
//                 }
//             }

//             (list[i + 1], list[high]) = (list[high], list[i + 1]);
//             return i + 1;
//         }

//         static void Main()
//         {
//             List<int> listVar = new List<int> { 2, 4, 3, 1, 6, 7 };

//             QuickSort(listVar, 0, listVar.Count - 1);

//             foreach (var v in listVar)
//             {
//                 Console.Write($"{v} ");
//             }
//         }
//     }
// }

using System;
using System.Collections.Generic;

namespace SortingDemo
{
    class MergeSortProgram
    {
        static void MergeSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                MergeSort(list, left, mid);
                MergeSort(list, mid + 1, right);

                Merge(list, left, mid, right);
            }
        }

        static void Merge(List<int> list, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            List<int> leftList = new List<int>(n1);
            List<int> rightList = new List<int>(n2);

            for (int i = 0; i < n1; i++)
                leftList.Add(list[left + i]);
            for (int j = 0; j < n2; j++)
                rightList.Add(list[mid + 1 + j]);

            int iLeft = 0, iRight = 0;
            int k = left;

            while (iLeft < n1 && iRight < n2)
            {
                if (leftList[iLeft] <= rightList[iRight])
                {
                    list[k] = leftList[iLeft];
                    iLeft++;
                }
                else
                {
                    list[k] = rightList[iRight];
                    iRight++;
                }
                k++;
            }

            while (iLeft < n1)
            {
                list[k] = leftList[iLeft];
                iLeft++;
                k++;
            }

            while (iRight < n2)
            {
                list[k] = rightList[iRight];
                iRight++;
                k++;
            }
        }

        static void Main()
        {
            List<int> listVar = new List<int> { 2, 4, 3, 1, 6, 7 };

            MergeSort(listVar, 0, listVar.Count - 1);

            foreach (var v in listVar)
            {
                Console.Write($"{v} ");
            }
        }
    }
}