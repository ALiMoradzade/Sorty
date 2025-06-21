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

        private void Swap(int a, int b)
        {
            SwapCount++;
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
                        Swap(array[j], array[j + 1]);
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
                int halfLength = array.Length / 2;
                int remainingHalfLength = array.Length - halfLength;

                int[] left = new int[halfLength];
                Array.Copy(array, left, halfLength);

                int[] rigth = new int[remainingHalfLength];
                Array.Copy(array, halfLength, rigth, 0, remainingHalfLength);

                Merge(left);
                Merge(rigth);

                int arrayIndex = 0, leftIndex = 0, rigthIndex = 0;
                while (leftIndex < left.Length && rigthIndex < rigth.Length)
                {
                    CompareCount++;
                    if (left[leftIndex] <= rigth[rigthIndex])
                    {
                        SetCount++;
                        array[arrayIndex] = left[leftIndex];
                        leftIndex++;
                    }
                    else
                    {
                        SetCount++;
                        array[arrayIndex] = rigth[rigthIndex];
                        rigthIndex++;
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
                    else if (rigthIndex < rigth.Length)
                    {
                        SetCount++;
                        array[arrayIndex] = rigth[rigthIndex];
                        rigthIndex++;
                    }
                    arrayIndex++;
                }

            }
            return array;
        }
    }
}
