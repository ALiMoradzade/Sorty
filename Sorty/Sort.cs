using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorty
{
    internal class SortStat
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int SetCount { get; set; }
        public int SwapCount { get; set; }
        public int CompareCount { get; set; }

        public SortStat(string name, TimeSpan duration, int setCount, int swapCount, int compareCount)
        {
            Name = name;
            Duration = duration;
            SetCount = setCount;
            SwapCount = swapCount;
            CompareCount = compareCount;
        }
    }

    internal class Sort
    {
        public int CompareCount { get; set; } = 0;
        public int SwapCount { get; set; } = 0;
        public int SetCount { get; set; } = 0;
        public int[] Array { get; }

        private void Swap(ref int a, ref int b)
        {
            SetCount += 2;
            (a, b) = (b, a);
        }

        public Sort(int[] array)
        {
            Array = array.ToArray();
        }

        public Task Bubble()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < Array.Length - 1; i++)
                {
                    for (int j = 0; j < Array.Length - 1 - i; j++)
                    {
                        CompareCount++;
                        if (Array[j] > Array[j + 1])
                        {
                            SwapCount++;
                            Swap(ref Array[j], ref Array[j + 1]);
                        }
                    }
                }
            });
        }

        public Task Insertion()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < Array.Length; ++i)
                {
                    int temp = Array[i];
                    int j = i;
                    // was while loop
                    for (; j > 0 && temp < Array[j - 1]; j--, CompareCount++)
                    {
                        SetCount++;
                        Array[j] = Array[j - 1];
                    }
                    SetCount++;
                    Array[j] = temp;
                }
            });
        }

        public Task Merge()
        {
            return Task.Run(() => Merge(Array));
        }
        private void Merge(int[] array)
        {
            if (array.Length != 1)
            {
                // Divide
                int halfLength = array.Length / 2;
                int remainingHalfLength = array.Length - halfLength;

                int[] left = new int[halfLength];
                System.Array.Copy(array, left, halfLength);

                int[] right = new int[remainingHalfLength];
                System.Array.Copy(array, halfLength, right, 0, remainingHalfLength);

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
        }

        public Task Quick()
        {
            return Task.Run(() =>
            {
                Sorting(Array, 0, Array.Length - 1);

                void Sorting(int[] arr, int start, int end)
                {
                    int Partition(int[] a, int low, int high)
                    {
                        int pivotIndex;
                        int pivot = a[high];
                        for (int i = pivotIndex = low; i < high; i++)
                        {
                            CompareCount++;
                            if (a[i] <= pivot)
                            {
                                SwapCount++;
                                Swap(ref a[i], ref a[pivotIndex]);
                                pivotIndex++;
                            }
                        }
                        SwapCount++;
                        Swap(ref a[pivotIndex], ref a[high]);
                        return pivotIndex;
                    }

                    if (start < end)
                    {
                        int pivotIndex = Partition(arr, start, end);
                        Sorting(arr, start, pivotIndex - 1);
                        Sorting(arr, pivotIndex + 1, end);
                    }
                    
                }
            });
        }

        public Task Selection()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < Array.Length - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < Array.Length; j++)
                    {
                        CompareCount++;
                        if (Array[j] < Array[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    SwapCount++;
                    Swap(ref Array[i], ref Array[minIndex]);
                }
            });
        }

        public Task Shell()
        {
            return Task.Run(() =>
            {
                for (int gap = Array.Length / 2; gap > 0; gap /= 2)
                {
                    for (int i = gap; i < Array.Length; i++)
                    {
                        int temp = Array[i];
                        int j;
                        for (j = i; j >= gap && Array[j - gap] > temp; j -= gap, CompareCount++)
                        {
                            SetCount++;
                            Array[j] = Array[j - gap];
                        }
                        SetCount++;
                        Array[j] = temp;
                    }
                }
            });
        }

        public Task Heap()
        {
            return Task.Run(() =>
            {
                void Heapify(int[] arr, int heapSize, int rootIndex)
                {
                    int largest = rootIndex;
                    int left = 2 * rootIndex + 1;
                    int right = 2 * rootIndex + 2;

                    CompareCount++;
                    if (left < heapSize && arr[left] > arr[largest])
                    {
                        largest = left;
                    }
                    CompareCount++;
                    if (right < heapSize && arr[right] > arr[largest])
                    {
                        largest = right;
                    }

                    if (largest != rootIndex)
                    {
                        SwapCount++;
                        Swap(ref arr[rootIndex], ref arr[largest]);
                        Heapify(arr, heapSize, largest);
                    }
                }

                for (int i = Array.Length / 2; i >= 0; i--)
                {
                    Heapify(Array, Array.Length, i);
                }

                for (int i = Array.Length - 1; i >= 0; i--)
                {
                    SwapCount++;
                    Swap(ref Array[0], ref Array[i]);
                    Heapify(Array, i, 0);
                }
            });
        }

        public Task Gnome()
        {
            return Task.Run(() =>
            {
                int i = 0;
                while (i < Array.Length)
                {
                    if (i == 0)
                    {
                        i++;
                    }
                    CompareCount++;
                    if (Array[i] >= Array[i - 1])
                    {
                        i++;
                    }
                    else
                    {
                        SwapCount++;
                        Swap(ref Array[i], ref Array[i - 1]);
                        i--;
                    }
                }
            });
        }

        public Task Cycle()
        {
            return Task.Run(() =>
            {
                for (int cycleStart = 0; cycleStart < Array.Length - 1; cycleStart++)
                {
                    int temp = Array[cycleStart];
                    int pos = cycleStart;

                    for (int i = cycleStart + 1; i < Array.Length; i++)
                    {
                        CompareCount++;
                        if (Array[i] < temp)
                        {
                            pos++;
                        }
                    }

                    if (pos == cycleStart)
                    {
                        continue;
                    }

                    // was while loop
                    for (; temp == Array[pos]; pos++, CompareCount++)
                    {
                    }


                    if (pos != cycleStart)
                    {
                        SwapCount++;
                        Swap(ref temp, ref Array[pos]);
                    }

                    while (pos != cycleStart)
                    {
                        pos = cycleStart;
                        for (int i = cycleStart + 1; i < Array.Length; i++)
                        {
                            CompareCount++;
                            if (Array[i] < temp)
                            {
                                pos++;
                            }
                        }

                        // was while loop
                        for (; temp == Array[pos]; pos++, CompareCount++)
                        {
                        }

                        CompareCount++;
                        if (temp != Array[pos])
                        {
                            SwapCount++;
                            Swap(ref temp, ref Array[pos]);
                        }
                    }
                }
            });
        }

        public Task Cocktail()
        {
            return Task.Run(() =>
            {
                bool isSwapped = true;
                int start = 0;
                int end = Array.Length;

                while (isSwapped)
                {
                    isSwapped = false;
                    for (int i = start; i < end - 1; i++)
                    {
                        CompareCount++;
                        if (Array[i] > Array[i + 1])
                        {
                            SwapCount++;
                            Swap(ref Array[i], ref Array[i + 1]);
                            isSwapped = true;
                        }
                    }

                    if (!isSwapped)
                    {
                        break;
                    }

                    isSwapped = false;
                    end--;

                    for (int i = end - 1; i >= start; i--)
                    {
                        CompareCount++;
                        if (Array[i] > Array[i + 1])
                        {
                            SwapCount++;
                            Swap(ref Array[i], ref Array[i + 1]);
                            isSwapped = true;
                        }
                    }
                    start = start + 1;
                }
            });
        }

        public Task Bead()
        {
            return Task.Run(() =>
            {
                // find max value
                int max = Array.Max();

                int[,] grid = new int[Array.Length, max];
                int[] levelCount = new int[max];

                // Step 1: "place" beads
                for (int i = 0; i < max; i++)
                {
                    levelCount[i] = 0;
                    for (int j = 0; j < Array.Length; j++)
                    {
                        grid[j, i] = 0; // Not Marked
                    }
                }

                // Step 2: Let beads "fall" by counting per column
                for (int i = 0; i < Array.Length; i++)
                {
                    int num = Array[i];
                    for (int j = 0; num > 0; j++, num--)
                    {
                        grid[levelCount[j]++, j] = 1; // Marked
                    }
                }

                // Step 3: Read out sorted values
                for (int i = 0; i < Array.Length; i++)
                {
                    int putt = 0;
                    for (int j = 0; j < max && grid[Array.Length - 1 - i, j] == 1; j++)
                    {
                        putt++;
                    }
                    Array[i] = putt;
                }
            });
        }

        public Task OddEven()
        {
            return Task.Run(() =>
            {
                bool isSorted = false;

                while (!isSorted)
                {
                    isSorted = true;

                    // odd
                    for (int i = 1; i <= Array.Length - 2; i += 2)
                    {
                        CompareCount++;
                        if (Array[i] > Array[i + 1])
                        {
                            SwapCount++;
                            Swap(ref Array[i], ref Array[i + 1]);
                            isSorted = false;
                        }
                    }

                    // even
                    for (int i = 0; i <= Array.Length - 2; i += 2)
                    {
                        CompareCount++;
                        if (Array[i] > Array[i + 1])
                        {
                            SwapCount++;
                            Swap(ref Array[i], ref Array[i + 1]);
                            isSorted = false;
                        }
                    }
                }
            });
        }

        public Task Radix()
        {
            return Task.Run(() =>
            {
                void Counting(int[] arr, int exp)
                {
                    int[] output = new int[Array.Length];
                    int[] count = new int[Array.Length];

                    for (int i = 0; i < Array.Length; i++)
                    {
                        count[arr[i] / exp % 10]++;
                    }

                    for (int i = 1; i < 10; i++)
                    {
                        count[i] += count[i - 1];
                    }

                    for (int i = Array.Length - 1; i >= 0; i--)
                    {
                        output[count[arr[i] / exp % 10] - 1] = arr[i];
                        count[arr[i] / exp % 10]--;
                    }
                    
                    arr = output;
                }

                int max = Array.Max();
                for (int exp = 1; max / exp > 0; exp *= 10)
                {
                    Counting(Array, exp);
                }
            });
        }

        private void Bogo()
        {
            bool isArraySorted(int[] arr)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    CompareCount++;
                    if (arr[i] > arr[i + 1])
                    {
                        return false;
                    }
                }
                return true;
            }

            while (!isArraySorted(Array))
            {
                Shuffle.Chaos(Array);
            }
        }
    }
}
