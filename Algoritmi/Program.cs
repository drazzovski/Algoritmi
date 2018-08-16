using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmi
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearSearchAlg ls = new LinearSearchAlg();
            Console.WriteLine("Linear search: " + ls.LinearSearch(new int[] { 3, 4, 5, 7, 33, 4, 5, 67, 86, 432, 2134, 54, 24, 6 }, 2134));
           

            BinarySearchAlg bs = new BinarySearchAlg();
            Console.WriteLine("Binary search: " + bs.BinarySearch(new int[] { 3, 4, 5, 9, 12, 15, 17, 19, 22, 23, 29, 30, 39, 49, 50, 51, 56, 59, 62, 63, 68, 69, 74, 76, 77, 79, 82, 89, 99, 101, 105 }, 59));

            RecursiveLinearSearchAlg rs = new RecursiveLinearSearchAlg();
            Console.WriteLine("Recursive linear search: " + rs.RecursiveLinear(new int[] { 34, 2, 1, 55, 78, 23, 45, 89, 82, 24, 26, 84, 46, 35 }, 84, 0));

            RecursiveBinarySearchAlg rb = new RecursiveBinarySearchAlg();
            Console.WriteLine("Recursive binary search: " + rb.RecursiveBinary(new int[] { 3, 4, 5, 8, 12, 15, 18, 21, 26, 28, 34, 36, 39, 43, 46, 48, 50, 53, 55, 58, 67, 68, 77, 88, 89, 91, 92, 93, 99 }, 55, 0, 28));

            SelectionSortAlg ss = new SelectionSortAlg();
            Console.WriteLine("Selection sort: " + (string.Join(",", ss.SelectionSort(new int[] {34,54,67,6,43,2,12,34,5,23,45,75,44,56,78,22}))));

            InsertionSortAlg isort = new InsertionSortAlg();
            Console.WriteLine("Insertion sort: " + (string.Join(",", isort.InsertionSort(new int[] { 78,89,2,34,35,65,12,23,17,10,29,28,37,35,67,44,45,65,55,54,39 }))));

            MergeSortAlg ms = new MergeSortAlg();
            Console.WriteLine("Merge sort: " + (string.Join(",", ms.MergeSort(new int[] {9,83,48,23,45,67,13,56,22,34,89,95,65,11,23,25,29,38,46,45,50,1,3,23,45,19,78,54}))));

            QuickSortAlg qs = new QuickSortAlg();
            Console.WriteLine("Quick sort: " + (string.Join(",", qs.QuickSort(new int[] { 7,89,23,45,67,21,2,40,9,87,54,12,19,20,55,78,65,23,11,91,49,34,57,55,44,32,28,49,9,10 }))));

            BubbleSortAlg bub = new BubbleSortAlg();
            Console.WriteLine("Bubble sort: " + (string.Join(",", bub.BubbleSort(new int[] { 76,45,32,23,45,2,13,45,46,60,50,21,23,34,37,44,90,3,8,19,9,23,34,56,68,78,71,99 }))));


            Console.Read();
        }
    }


    // S E A R C H I N G
    class LinearSearchAlg
    {

        public int LinearSearch(int[] arr, int num)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    return i;
                }
            }

            return -1;
        }

    }

    class BinarySearchAlg
    {
        public int BinarySearch(int[] arr, int num)
        {
            int p = 0;
            int r = arr.Length - 1;

            while(p <= r)
            {
                int q = (p + r) / 2;

                if(arr[q] < num)
                {
                    p = q + 1;
                }
                else if( arr[q] > num)
                {
                    r = q - 1;
                } else
                {             
                    return q;
                }
            }

            return -1;

        }
    }

    class RecursiveLinearSearchAlg
    {

        public int RecursiveLinear(int[] arr, int num, int i)
        {

            if (i > arr.Length - 1)
            {
                return -1;

            }
            else if (arr[i] == num) {

                return i;

            } else
            {
               return RecursiveLinear(arr, num, i + 1);
            }
        }

    }

    class RecursiveBinarySearchAlg
    {
        public int RecursiveBinary(int[] arr, int num, int p, int r)
        {
            if(p > r)
            {
                return -1;
            }
            else
            {
                int q = (p + r) / 2;

                if(arr[q] == num)
                {
                    return q;
                } else if(arr[q] > num)
                {
                    return RecursiveBinary(arr, num, p, q - 1);
                } else
                {
                    return RecursiveBinary(arr, num, q + 1, r );
                }
            }
        }
    }


    //S O R T I N G
    class SelectionSortAlg
    {
        public int[] SelectionSort(int[] arr)
        {

            for (var i = 0; i < arr.Length; i++)
            {
                int min = i;

                for (var j = i + 1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                int oldi = arr[i];
                arr[i] = arr[min];
                arr[min] = oldi;
            }

            return arr;
        }
    }

    class InsertionSortAlg
    {

        public int[] InsertionSort(int[] arr)
        {

            for (var i = 0; i < arr.Length; i++)
            {
                int element = arr[i];
                int j = i - 1;

                while(j >= 0 && arr[j] > element)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = element;
            }

            return arr;
        }
    }

    class MergeSortAlg
    {
        public int[] MergeSort(int[] arr)
        {
           return MergeSort(arr, 0, arr.Length - 1);
        }

        public int[] MergeSort(int[] arr, int p, int r)
        {
            
            if(p < r)
            {
                int q = (p + r) / 2;
                MergeSort(arr, p, q);
                MergeSort(arr, q + 1, r);
                Merge(arr, p, q, r);
            }

            int[] Merge(int[] array, int start, int mid, int end)
            {
                int[] tempArray = new int[end - start + 1];

                int left = start;
                int right = mid + 1;
                int k = 0;

                while (left <= mid && right <= end)
                {
                    if (array[left] < array[right])
                    {
                        tempArray[k] = array[left];
                        left++;
                    }
                    else
                    {
                        tempArray[k] = array[right];
                        right++;
                    }

                    k++;
                }

                if (left <= mid)
                {
                    while (left <= mid)
                    {
                        tempArray[k] = array[left];
                        left++;
                        k++;
                    }
                }
                else if (right <= end)
                {
                    while (right <= end)
                    {
                        tempArray[k] = array[right];
                        right++;
                        k++;
                    }
                }

                for (var i = 0; i < tempArray.Length; i++)
                {
                    array[start + i] = tempArray[i];
                }

                return array;

            }

            return arr;

        }
    }

    //linq's
    class QuickSortAlg
    {
        public int[] QuickSort(int[] arr)
        {
            return QuickSort(arr, 0, arr.Length - 1);
        }

        public int[] QuickSort(int[] arr, int p, int r)
        {
            //pivot


            if (p < r)
            {
                int q = Partition(arr, p, r);

                QuickSort(arr, p, q - 1);
                QuickSort(arr, q + 1, r);
            }

            int Partition(int[] array, int start, int end)
            {
                int pivot = array[end];
                int i = start - 1;
               

                for(var j = start; j <= end - 1; j++)
                {
                    if(array[j] <= pivot)
                    {
                        i++;
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
                
                array[end] = array[i + 1];
                array[i + 1] = pivot;
               
                return i + 1;
            }

            return arr;
        }

    }

    //least efficient
    //stable sorting
    class BubbleSortAlg
    {

        public int[] BubbleSort(int[] arr)
        {
            
            for(int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    //stable sorting
                    if(arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            return arr;
        } 
    }



}
