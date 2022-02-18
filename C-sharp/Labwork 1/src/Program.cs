using System;
using System.Diagnostics;

namespace Labwork_1
{
    static public class Program
    {
        static void Main(string[] args)
        {
            NumSequence numSequence = new NumSequence();
            SortAlgorithm algorithm = new SortAlgorithm();
            Stopwatch timer = new Stopwatch();

            // Define the length of the sequence
            Console.Write("Please, enter the length of the sequnce: ");

            try
            {
                numSequence.CountOfElements = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                throw new FormatException("The entered value is not an integer");
            }
            
            // Define the type of the sequence
            Console.Write("Enter the type of the primary sequence you want to be formed (desc, asc) or use \"rand\" by default: ");
            numSequence.Type = Console.ReadLine();
            numSequence.GetSequence();
            Console.WriteLine("The primary sequence is:\n" + string.Join(" ", numSequence.Sequence));

            // // Define the type of the algorithm
            Console.WriteLine("Enter the algorithm to sort with (bubble, comb) or close program in another case:");
            algorithm.Name = Console.ReadLine();

            // Algorithm works
            timer.Start();
            algorithm.StartAlgorithm(numSequence.Sequence);
            timer.Stop();

            // Result of the algorithm's activity
            Console.WriteLine($"The new {algorithm.Name}-sorted sequence:\n{string.Join(" ", numSequence.Sequence)}");
            Console.WriteLine($"It has {algorithm.Comparisons} comparisons and {algorithm.Swaps} swaps");
            Console.WriteLine($"It took {timer.Elapsed} time to perform the algorithm.");
        }
    }
}
