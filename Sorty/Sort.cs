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

        public int[] Bubble(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    CompareCount++;
                    if (array[j] > array[j+1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            return array;
        }
    }

}
