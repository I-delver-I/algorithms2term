using System;
using System.Linq;

namespace Labwork_1
{
    public static class NumSequence
    {
        public static int[] ChoosingThePrimSeq()
        {
            Console.Write("Enter the type of the primary sequence you want to be formed (desc, asc) or use \"rand\" by default: ");
            string way = Console.ReadLine();
            Console.Write("Please, enter the length of the sequnce: ");

            return way.ToLower() switch
            {
                "desc" => GenOrderDescSeq(),
                "asc" => GenOrderSeq(),
                _ => GenerateRandomNumbersInRange()
            };
        }

        private static int[] GenerateRandomNumbersInRange()
        {
            Random random = new Random();
            int.TryParse(Console.ReadLine(), out int n);
            int[] array = Enumerable.Range(1, n).ToArray();

            for (int i = 0; i < n; i++)
            {
                int j = random.Next(n);
                int x = array[i];
                array[i] = array[j];
                array[j] = x;
            }

            Console.WriteLine(string.Join(" ", array));

            return array;
        }

        private static int[] GenOrderDescSeq()
        {
            int[] seq = Enumerable.Range(1, Convert.ToInt32(Console.ReadLine())).Reverse().ToArray();
            Console.WriteLine("The sequence sorted descending:");
            Console.WriteLine(string.Join(" ", seq));

            return seq;
        }

        private static int[] GenOrderSeq()
        {
            int[] seq = Enumerable.Range(1, Convert.ToInt32(Console.ReadLine())).ToArray();
            Console.WriteLine($"The sequence sorted ascending:\n{string.Join(" ", seq)}");

            return seq;
        }
    }
}
