using System;
using System.Diagnostics;

namespace Labwork_1
{
    public static class SortAlgorithm
    {
        public static void ChooseSortAlgorithm(int[] seq)
        {
            Console.WriteLine("Enter the algorithm to sort with (bubble, comb) or close program in another case:");
            switch (Console.ReadLine().ToLower())
            {
                case "bubble":
                    SortBubble(seq);
                    break;
                case "comb":
                    CombSort(seq);
                    break;
                default:
                    break;
            }
        }

        private static void SortBubble(int[] seq)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            long comparisons = 0;
            long swaps = 0;
            int temp;
            bool isReady = true;

            for (int y = 0; y < seq.Length - 1 && isReady; y++)
            {
                isReady = false;
                for (int i = 1; i < seq.Length; i++)
                {
                    if (seq[i - 1] > seq[i])
                    {
                        temp = seq[i];
                        seq[i] = seq[i - 1];
                        seq[i - 1] = temp;
                        swaps++;
                        isReady = true;
                    }
                    comparisons++;
                }
            }

            timer.Stop();
            Console.WriteLine($"The new bubble-sorted sequence:\n{string.Join(" ", seq)}");
            PrintResult(comparisons, swaps, timer);
        }

        private static void CombSort(int[] array)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            double factor = 1.2473309;
            int step = array.Length - 1;
            long swaps = 0;
            long comparisons = 0;

            while (step >= 1)
            {
                for (int i = 0; i + step < array.Length; i++)
                {
                    if (array[i] > array[i + step])
                    {
                        Swap(ref array[i], ref array[i + step]);
                        swaps++;
                    }
                    comparisons++;
                }

                step = (int)(step / factor);
            }

            timer.Stop();
            Console.WriteLine($"The array sorted in the combining way is:\n{string.Join(" ", array)}");
            PrintResult(comparisons, swaps, timer);
        }

        private static void Swap(ref int value1, ref int value2)
        {
            int temp = value1;
            value1 = value2;
            value2 = temp;
        }

        private static void PrintResult(long comparisons, long swaps, Stopwatch timer)
        {
            Console.WriteLine($"It has {comparisons} comparisons and {swaps} swaps");
            Console.WriteLine($"It took {timer.Elapsed} time to perform the algorithm.");
        }
    }
}
