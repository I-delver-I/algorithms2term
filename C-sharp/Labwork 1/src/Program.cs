using System;
using System.Diagnostics;
using System.Linq;

namespace Labwork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] seq = ChoosingThePrimSeq();
            seq = CombSort(seq);
        }

        public static void SortBubble(int[] seq, Order order)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            long comparison = 0, swaps = 0;
            int temp = 0;
            bool isReady = true;

            if (order is Order.Ascending)
            {
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
                        comparison++;
                    }
                }
            }
            else if (order is Order.Descending)
            {
                for (int y = 0; y < seq.Length - 1 && isReady; y++)
                {
                    isReady = false;
                    for (int i = 1; i < seq.Length; i++)
                    {
                        if (seq[i - 1] < seq[i])
                        {
                            temp = seq[i];
                            seq[i] = seq[i - 1];
                            seq[i - 1] = temp;
                            swaps++;
                            isReady = true;
                        }
                        comparison++;
                    }
                }
            }
            timer.Stop();
            Console.WriteLine("The new sorted sequence:");
            PrintSeq(seq);
            Console.WriteLine($"The bubble-sorted sequence with the next" +
                $" count of the comparisons is - {comparison}; swaps - {swaps} is: ");
            Console.WriteLine($"It takes {timer.Elapsed} time to perform the algorithm.");
        }

        public static int[] CombSort(int[] array)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            double factor = 1.2473309;
            int step = array.Length - 1, swaps = 0, comparisons = 0;
            
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
            Console.WriteLine("The array sorted in the combining way is:");
            PrintSeq(array);
            Console.WriteLine($"The array sorted in the combining way has {comparisons} comparisons and {swaps} swaps.");
            Console.WriteLine($"It took {timer.Elapsed} time to perform the algorithm.");

            return array;
        }

        public static void Swap(ref int value1, ref int value2)
        {
            int temp = value1;
            value1 = value2;
            value2 = temp;
        }

        public static int[] ChoosingThePrimSeq()
        {
            Console.Write("Enter the type of the primary sequence you want to be formed (desc, asc) or use \"rand\" by default: ");
            string way = Console.ReadLine();

            switch (way.ToLower())
            {
                case "desc":
                    return GenOrderDescSeq();
                case "asc":
                    return GenOrderSeq();
                default:
                    return GenerateRandomNumbersInRange();
            }
        }

        public static int[] GenerateRandomNumbersInRange()
        {
            int n = 0;
            Random random = new Random();
            Console.Write("Enter the count of elements of the array: ");
            Int32.TryParse(Console.ReadLine(), out n);
            int[] array = Enumerable.Range(1, n).ToArray();

            for (int i = 0; i < n; i++)
            {
                int j = random.Next(n);
                int x = array[i];
                array[i] = array[j];
                array[j] = x;
            }

            PrintSeq(array);

            return array;
        }

        public static int[] GenOrderDescSeq()
        {
            Console.Write("Please, enter the length of the sequnce: ");
            int[] seq = Enumerable.Range(1, Convert.ToInt32(Console.ReadLine())).Reverse().ToArray();
            Console.WriteLine("The sequence sorted descending:");
            PrintSeq(seq);
            return seq;
        }

        public static int[] GenOrderSeq()
        {
            Console.Write("Please, enter the length of the sequnce: ");
            int[] seq = Enumerable.Range(1, Convert.ToInt32(Console.ReadLine())).ToArray();
            Console.WriteLine("The sequence sorted ascending:");
            PrintSeq(seq);
            Console.Write(Environment.NewLine);
            return seq;
        }

        public static void PrintSeq(int[] seq)
        {
            Console.WriteLine(string.Join(" ", seq));
        }
        public enum Order
        {
            Ascending,
            Descending
        }
    }
}
