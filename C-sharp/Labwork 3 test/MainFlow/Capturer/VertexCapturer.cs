using System;
using System.Collections.Generic;
using System.Linq;

namespace Labwork_3.MainFlow.Capturer
{
    public static class VertexCapturer
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
                        result = CaptureVerticesInRange();
                        break;
                    case "man":
                        result = CaptureCustomVertices();
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

        private static List<int> CaptureVerticesInRange()
        {
            List<int> result = new();
            bool exceptionIsCaught = true;
            
            while (exceptionIsCaught)
            {
                System.Console.Write("Enter the number whom the maximum vertex value should equal: ");
                exceptionIsCaught = false;

                try
                {
                    int vertex = int.Parse(Console.ReadLine());
                    GraphValidator.ValidateVertexExistence(vertex);
                    result = Enumerable.Range(1,vertex).ToList();
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("The entered value isn't a number");
                    System.Console.WriteLine("Try again: ");
                    exceptionIsCaught = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine("Try again: ");
                    exceptionIsCaught = true;
                }
            }

            return result;
        }

        private static List<int> CaptureCustomVertices()
        {
            List<int> result = new();
            bool exceptionIsCaught = true;
            
            do
            {
                exceptionIsCaught = false;

                try
                {
                    System.Console.Write("Enter the value of vertex whom to add in list: ");
                    int nodeValue = int.Parse(Console.ReadLine());
                    
                    GraphValidator.ValidateVertexAbsence(result, nodeValue);

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
                    System.Console.WriteLine("Enter <Backspace> to end typing or any key to continue");
                }
            } while (exceptionIsCaught || Console.ReadKey().Key != ConsoleKey.Backspace);

            return result;
        }

        public static int CaptureVertex(List<int> graphVertices)
        {
            System.Console.Write("Enter the value of vertex that equals at least 1: ");
            int vertex = default;
            bool exceptionIsCaught = true;

            while (exceptionIsCaught)
            {
                exceptionIsCaught = false;

                try
                {
                    vertex = int.Parse(Console.ReadLine());
                    GraphValidator.ValidateVertexExistence(graphVertices,vertex);
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
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.Write("Try again: ");
                    exceptionIsCaught = true;
                }
            }

            return vertex;
        }
    }
}