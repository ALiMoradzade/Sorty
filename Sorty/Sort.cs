using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorty
{
    internal class Sort
    {
        public int CompareCount { get; set; } = 0;
        public int SwapCount { get; set; } = 0;

        private static void Swap(int a, int b)
        {
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
                        SwapCount++;
                    }
                }
            }
            return array;
        }

        public int[] InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                int temp = array[i];
                int j = i;

                while (j > 0 && temp < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = temp;
            }
            return array;
        }
    }
}
