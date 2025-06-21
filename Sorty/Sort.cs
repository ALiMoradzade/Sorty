using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorty
{
    internal class Sort
    {
        public int CompareCount { get; set; } = 0;
        public int SwapCount { get; set; } = 0;
        public int SetCount { get; set; } = 0;

        private void Swap(ref int a, ref int b)
        {
            SwapCount++;
            SetCount += 2;
            (a, b) = (b, a);
        }

        public int[] Bubble(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    CompareCount++;
                    if (array[j] > array[j+1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
            return array;
        }

        public int[] Insertion(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                int temp = array[i];
                int j = i;

                while (j > 0 && temp < array[j - 1])
                {
                    SetCount++;
                    array[j] = array[j - 1];
                    j--;
                }
                SetCount++;
                array[j] = temp;
            }
            return array;
        }

        public int[] Merge(int[] array)
        {
            if (array.Length != 1)
            {
                // Divide
                int halfLength = array.Length / 2;
                int remainingHalfLength = array.Length - halfLength;

                int[] left = new int[halfLength];
                Array.Copy(array, left, halfLength);

                int[] right = new int[remainingHalfLength];
                Array.Copy(array, halfLength, right, 0, remainingHalfLength);

                Merge(left);
                Merge(right);

                // Conquer + Merge
                int arrayIndex = 0, leftIndex = 0, rightIndex = 0;
                while (leftIndex < left.Length && rightIndex < right.Length)
                {
                    CompareCount++;
                    if (left[leftIndex] <= right[rightIndex])
                    {
                        SetCount++;
                        array[arrayIndex] = left[leftIndex];
                        leftIndex++;
                    }
                    else
                    {
                        SetCount++;
                        array[arrayIndex] = right[rightIndex];
                        rightIndex++;
                    }
                    arrayIndex++;
                }
                while (arrayIndex < array.Length)
                {
                    if (leftIndex < left.Length)
                    {
                        SetCount++;
                        array[arrayIndex] = left[leftIndex];
                        leftIndex++;
                    }
                    else if (rightIndex < right.Length)
                    {
                        SetCount++;
                        array[arrayIndex] = right[rightIndex];
                        rightIndex++;
                    }
                    arrayIndex++;
                }

            }
            return array;
        }

        public int[] Quick(int[] array, int start, int end)
        {
            int Partition(int[] arr, int low, int high)
            {
                int pivotIndex;
                int pivot = arr[high];
                for (int i = pivotIndex = low; i < high; i++)
                {
                    CompareCount++;
                    if (arr[i] <= pivot)
                    {
                        SwapCount++;
                        Swap(ref arr[i], ref arr[pivotIndex]);
                        pivotIndex++;
                    }
                }
                SwapCount++;
                Swap(ref arr[pivotIndex], ref arr[high]);
                return pivotIndex;
            }

            if (start < end)
            {
                int pivotIndex = Partition(array, start, end);
                Quick(array, start, pivotIndex - 1);
                Quick(array, pivotIndex + 1, end);
            }
            return array;
        }


    }
}
