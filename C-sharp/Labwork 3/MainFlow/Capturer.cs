using System;
using System.Collections.Generic;
using System.Linq;

namespace Labwork_3.MainFlow
{
    public class Capturer
    {
        public static List<int> CaptureVertices()
        {
            System.Console.WriteLine("Enter <auto> to generate vertices automatically"
                + " from 1 up to the chosen number or <man> to enter each of them on you own: ");
            bool inputIsInvalid = true;
            List<int> result = new();

            while (inputIsInvalid)
            {
                inputIsInvalid = false;

                switch (Console.ReadLine().Trim())
                {
                    case "auto":
                        result = CaptureAutoNodes();
                        break;
                    case "man":
                        result = CaptureCustomNodes();
                        break;
                    default:
                        System.Console.WriteLine("You entered wrong command");
                        System.Console.Write("Try again: ");
                        inputIsInvalid = true;
                        break;
                }
            }

            return result;
        }

        private static List<int> CaptureAutoNodes()
        {
            List<int> result = new();
            bool exceptionIsCaught = true;
            
            while (exceptionIsCaught)
            {
                System.Console.Write("Enter the number whom the maximum node value should equal: ");
                exceptionIsCaught = false;

                try
                {
                    result = Enumerable.Range(1,int.Parse(Console.ReadLine())).ToList();
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("The entered value isn't a number");
                    System.Console.Write("Try again: ");
                    exceptionIsCaught = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.Write("Try again: ");
                    exceptionIsCaught = true;
                }
            }

            return result;
        }

        private static List<int> CaptureCustomNodes()
        {
            List<int> result = new();
            bool exceptionIsCaught = true;
            
            do
            {
                exceptionIsCaught = false;

                try
                {
                    System.Console.Write("Enter the value of node whom to add in list: ");
                    int nodeValue = int.Parse(Console.ReadLine());
                    
                    Validator.ValidateNode(nodeValue);

                    result.Add(nodeValue);
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("The entered value isn't a number");
                    System.Console.WriteLine("Try again");
                    exceptionIsCaught = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine("Try again");
                    exceptionIsCaught = true;
                }

                if (!exceptionIsCaught)
                {
                    System.Console.WriteLine("Enter <Esc> to end typing or any key to continue");
                }
            } while (exceptionIsCaught || Console.ReadKey().Key != ConsoleKey.Escape);

            return result;
        }

        public static List<Tuple<int, int>> CaptureEdges(List<int> nodes)
        {
            List<Tuple<int, int>> result = new();
            bool exceptionIsCaught = true;
            
            do
            {
                exceptionIsCaught = false;

                try
                {
                    System.Console.Write("Enter the first node: ");
                    int firstNode = CaptureNode();

                    System.Console.Write("Enter the second node: ");
                    int secondNode = CaptureNode();

                    Validator.ValidateEdge(result,
                        new Tuple<int, int>(firstNode, secondNode));
                    result.Add(new Tuple<int, int>(firstNode,secondNode));
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine("Try again");
                    exceptionIsCaught = true;
                }

                if (!exceptionIsCaught)
                {
                    System.Console.WriteLine("Enter <Esc> to end typing or any key to continue");
                }
            } while (exceptionIsCaught || Console.ReadKey().Key != ConsoleKey.Escape);

            return result;
        }

        private static int CaptureNode()
        {
            System.Console.Write("Enter the value of node that equals at least 1: ");
            int node = default;
            bool exceptionIsCaught = true;

            while (exceptionIsCaught)
            {
                exceptionIsCaught = false;

                try
                {
                    node = int.Parse(Console.ReadLine());
                    Validator.ValidateNode(node);                    
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("The entered value isn't a number");
                    System.Console.Write("Try again: ");
                    exceptionIsCaught = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.Write("Try again: ");
                    exceptionIsCaught = true;
                }
            }

            return node;
        }
    }
}