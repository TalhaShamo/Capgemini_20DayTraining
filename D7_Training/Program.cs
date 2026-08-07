// // // using System;
// // // using System.Collections.Generic;

// // // namespace SortingDemo
// // // {
// // //     class HeapSortProgram
// // //     {
// // //         static void HeapSort(List<int> list)
// // //         {
// // //             int n = list.Count;

// // //             for (int i = n / 2 - 1; i >= 0; i--)
// // //             {
// // //                 Heapify(list, n, i);
// // //             }

// // //             for (int i = n - 1; i > 0; i--)
// // //             {
// // //                 (list[0], list[i]) = (list[i], list[0]);
// // //                 Heapify(list, i, 0);
// // //             }
// // //         }

// // //         static void Heapify(List<int> list, int n, int i)
// // //         {
// // //             int largest = i;
// // //             int left = 2 * i + 1;
// // //             int right = 2 * i + 2;

// // //             if (left < n && list[left] > list[largest])
// // //             {
// // //                 largest = left;
// // //             }

// // //             if (right < n && list[right] > list[largest])
// // //             {
// // //                 largest = right;
// // //             }

// // //             if (largest != i)
// // //             {
// // //                 (list[i], list[largest]) = (list[largest], list[i]);
// // //                 Heapify(list, n, largest);
// // //             }
// // //         }

// // //         static void Main()
// // //         {
// // //             List<int> listVar = new List<int> { 2, 4, 3, 1, 6, 7 };

// // //             HeapSort(listVar);

// // //             foreach (var v in listVar)
// // //             {
// // //                 Console.Write($"{v} ");
// // //             }
// // //         }
// // //     }
// // // }

// // using System;
// // using System.Collections.Generic;

// // namespace SortingDemo
// // {
// //     class TimSortProgram
// //     {
// //         const int RUN = 32;

// //         static void TimSort(List<int> list)
// //         {
// //             int n = list.Count;

// //             for (int i = 0; i < n; i += RUN)
// //             {
// //                 InsertionSort(list, i, Math.Min(i + RUN - 1, n - 1));
// //             }

// //             for (int size = RUN; size < n; size = 2 * size)
// //             {
// //                 for (int left = 0; left < n; left += 2 * size)
// //                 {
// //                     int mid = left + size - 1;
// //                     int right = Math.Min(left + 2 * size - 1, n - 1);

// //                     if (mid < right)
// //                     {
// //                         Merge(list, left, mid, right);
// //                     }
// //                 }
// //             }
// //         }

// //         static void InsertionSort(List<int> list, int left, int right)
// //         {
// //             for (int i = left + 1; i <= right; i++)
// //             {
// //                 int temp = list[i];
// //                 int j = i - 1;

// //                 while (j >= left && list[j] > temp)
// //                 {
// //                     list[j + 1] = list[j];
// //                     j--;
// //                 }

// //                 list[j + 1] = temp;
// //             }
// //         }

// //         static void Merge(List<int> list, int left, int mid, int right)
// //         {
// //             int len1 = mid - left + 1;
// //             int len2 = right - mid;

// //             List<int> leftList = new List<int>(len1);
// //             List<int> rightList = new List<int>(len2);

// //             for (int x = 0; x < len1; x++)
// //                 leftList.Add(list[left + x]);
// //             for (int x = 0; x < len2; x++)
// //                 rightList.Add(list[mid + 1 + x]);

// //             int i = 0;
// //             int j = 0;
// //             int k = left;

// //             while (i < len1 && j < len2)
// //             {
// //                 if (leftList[i] <= rightList[j])
// //                 {
// //                     list[k] = leftList[i];
// //                     i++;
// //                 }
// //                 else
// //                 {
// //                     list[k] = rightList[j];
// //                     j++;
// //                 }
// //                 k++;
// //             }

// //             while (i < len1)
// //             {
// //                 list[k] = leftList[i];
// //                 i++;
// //                 k++;
// //             }

// //             while (j < len2)
// //             {
// //                 list[k] = rightList[j];
// //                 j++;
// //                 k++;
// //             }
// //         }

// //         static void Main()
// //         {
// //             List<int> listVar = new List<int> { 2, 4, 3, 1, 6, 7 };

// //             TimSort(listVar);

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
//     class IntroSortProgram
//     {
//         static void IntroSort(List<int> list)
//         {
//             if (list.Count <= 1) return;

//             int maxDepth = 2 * (int)Math.Floor(Math.Log(list.Count, 2));
//             IntroSortRecursive(list, 0, list.Count - 1, maxDepth);
//         }

//         static void IntroSortRecursive(List<int> list, int low, int high, int depthLimit)
//         {
//             int size = high - low + 1;

//             if (size <= 16)
//             {
//                 InsertionSort(list, low, high);
//                 return;
//             }

//             if (depthLimit == 0)
//             {
//                 HeapSort(list, low, high);
//                 return;
//             }

//             int pivotIndex = Partition(list, low, high);
//             IntroSortRecursive(list, low, pivotIndex - 1, depthLimit - 1);
//             IntroSortRecursive(list, pivotIndex + 1, high, depthLimit - 1);
//         }

//         static int Partition(List<int> list, int low, int high)
//         {
//             int pivot = list[high];
//             int i = low - 1;

//             for (int j = low; j < high; j++)
//             {
//                 if (list[j] <= pivot)
//                 {
//                     i++;
//                     (list[i], list[j]) = (list[j], list[i]);
//                 }
//             }

//             (list[i + 1], list[high]) = (list[high], list[i + 1]);
//             return i + 1;
//         }

//         static void InsertionSort(List<int> list, int low, int high)
//         {
//             for (int i = low + 1; i <= high; i++)
//             {
//                 int key = list[i];
//                 int j = i - 1;

//                 while (j >= low && list[j] > key)
//                 {
//                     list[j + 1] = list[j];
//                     j--;
//                 }

//                 list[j + 1] = key;
//             }
//         }

//         static void HeapSort(List<int> list, int low, int high)
//         {
//             int n = high - low + 1;

//             for (int i = n / 2 - 1; i >= 0; i--)
//             {
//                 Heapify(list, n, i, low);
//             }

//             for (int i = n - 1; i > 0; i--)
//             {
//                 (list[low], list[low + i]) = (list[low + i], list[low]);
//                 Heapify(list, i, 0, low);
//             }
//         }

//         static void Heapify(List<int> list, int n, int i, int low)
//         {
//             int largest = i;
//             int left = 2 * i + 1;
//             int right = 2 * i + 2;

//             if (left < n && list[low + left] > list[low + largest])
//             {
//                 largest = left;
//             }

//             if (right < n && list[low + right] > list[low + largest])
//             {
//                 largest = right;
//             }

//             if (largest != i)
//             {
//                 (list[low + i], list[low + largest]) = (list[low + largest], list[low + i]);
//                 Heapify(list, n, largest, low);
//             }
//         }

//         static void Main()
//         {
//             List<int> listVar = new List<int> { 2, 4, 3, 1, 6, 7 };

//             IntroSort(listVar);

//             foreach (var v in listVar)
//             {
//                 Console.Write($"{v} ");
//             }
//         }
//     }
// }

// using System;
// namespace D7_Training
// {
//     class Program
//     {
//         static void Main()
//         {
//             List<int> listVar = new List<int> {3, 4, 2, 5, 7, 1, 3, 9};
//             int find = 9;

//             foreach(var v in listVar)
//             {
//                 if(v == find)
//                 {
//                     Console.WriteLine($"Found element!");
//                 }
//             }
//             Console.WriteLine("Element not found");
//         }
//     }
// }


// using System;
// using System.Security.AccessControl;
// namespace D7_Training
// {
//     class Program
//     {
//         static void Main()
//         {
//             List<int> listVar = new List<int> {4, 5, 6, 7, 8, 9};
//             int find = 9;
//             int left = 0;
//             int right = listVar.Count - 1;
//             int mid = (right + left)/2;
//             bool found = false;

//             while(left <= right)
//             {
//                 if(listVar[mid] == find)
//                 {
//                     Console.WriteLine($"Element found at {mid}");
//                     found = true;
//                     break;
//                 }
//                 else if(listVar[mid] < find)
//                 {
//                     left = mid + 1;
//                     mid = (left+right)/2;
//                 }
//                 else
//                 {
//                     right = mid - 1;
//                     mid = (left + right)/2;
//                 }
//             }

//             if (!found)
//             {
//                 Console.WriteLine("Element not found!");
//             }
//         }
//     }
// }



// using System;
// using System.Collections.Generic;

// namespace SearchDemo
// {
//     class JumpSearchProgram
//     {
//         static int JumpSearch(List<int> list, int target)
//         {
//             int n = list.Count;
//             if (n == 0) return -1;

//             int step = (int)Math.Floor(Math.Sqrt(n));
//             int prev = 0;

//             while (list[Math.Min(step, n) - 1] < target)
//             {
//                 prev = step;
//                 step += (int)Math.Floor(Math.Sqrt(n));

//                 if (prev >= n)
//                     return -1;
//             }

//             while (list[prev] < target)
//             {
//                 prev++;

//                 if (prev == Math.Min(step, n))
//                     return -1;
//             }

//             if (list[prev] == target)
//                 return prev;

//             return -1;
//         }

//         static void Main()
//         {
//             List<int> listVar = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
//             int index = JumpSearch(listVar, 60);

//             if (index != -1)
//                 Console.WriteLine($"Element found at index {index}");
//             else
//                 Console.WriteLine("Element not found!");
//         }
//     }
// }


using System;
using System.Collections.Generic;

namespace SearchDemo
{
    class InterpolationSearchProgram
    {
        static int InterpolationSearch(List<int> list, int target)
        {
            int low = 0;
            int high = list.Count - 1;

            while (low <= high && target >= list[low] && target <= list[high])
            {
                if (low == high)
                {
                    if (list[low] == target) return low;
                    return -1;
                }

                int pos = low + (target - list[low]) * (high - low) / (list[high] - list[low]);

                if (list[pos] == target)
                    return pos;

                if (list[pos] < target)
                    low = pos + 1;
                else
                    high = pos - 1;
            }

            return -1;
        }

        static void Main()
        {
            List<int> listVar = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            int index = InterpolationSearch(listVar, 70);

            if (index != -1)
                Console.WriteLine($"Element found at index {index}");
            else
                Console.WriteLine("Element not found!");
        }
    }
}