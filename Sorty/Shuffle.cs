using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorty
{
    internal static class Shuffle
    {
        private static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

        public static int[] Chaos(int[] array)
        {
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                Swap(ref array[i], ref array[r.Next(array.Length) % array.Length]);
            }
            return array;
        }

        public static int[] Riffle(int[] array)
        {
            int half = array.Length / 2;
            int remainingHalf = array.Length - half;

            int[] halfArray = new int[half];
            Array.Copy(array, halfArray, half);

            int[] rHalfArray = new int[remainingHalf];
            Array.Copy(array, half, rHalfArray, 0, remainingHalf);

            Stack<int> halfStack = new Stack<int>(halfArray.Reverse());
            Stack<int> rHalfStack = new Stack<int>(rHalfArray.Reverse());

            List<int> l = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                int n;
                if (i % 2 == 0)
                {
                    n = rHalfStack.Pop();
                }
                else
                {
                    n = halfStack.Pop();
                }
                l.Add(n);
            }

            return l.ToArray();
        }
    }
}
