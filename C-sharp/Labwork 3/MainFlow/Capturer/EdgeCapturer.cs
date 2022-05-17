using System;
using System.Collections.Generic;

namespace Labwork_3.MainFlow.Capturer
{
    public static class EdgeCapturer
    {
        public static List<Tuple<int, int>> CaptureEdges(List<int> graphVertices)
        {
            List<Tuple<int, int>> result = new();
            bool isCommandCaught = false;

            while (!isCommandCaught)
            {
                isCommandCaught = true;
                System.Console.Write("Enter <auto> to capture auto edges or <man> to do it manually: ");
            
                switch (Console.ReadLine().Trim())
                {
                    case "auto":
                        result = CaptureRandomEdges(graphVertices);
                        break;
                    case "man":
                        result = CaptureCustomEdges(graphVertices);
                        break;
                    default:
                        System.Console.WriteLine("Unknown command");
                        isCommandCaught = false;
                        break;
                }
            }
            
            return result;
        }

        private static List<Tuple<int, int>> CaptureRandomEdges(List<int> graphVertices)
        {
            List<Tuple<int, int>> result = new();
            
            for (var i = 0; i < graphVertices.Count; i++)
            {
                for (var y = i + 1; y < graphVertices.Count && y - i != 3; y++)
                {
                    result.Add(new Tuple<int, int>(graphVertices[i],
                        graphVertices[y]));
                }
            }

            return result;
        }

        private static List<Tuple<int, int>> CaptureCustomEdges(List<int> graphVertices)
        {
            List<Tuple<int, int>> result = new();
            bool exceptionIsCaught = true;
            
            do
            {
                exceptionIsCaught = false;

                try
                {
                    System.Console.WriteLine("Enter the first vertex: ");
                    int firstVertex = VertexCapturer.CaptureVertex(graphVertices);

                    System.Console.WriteLine("Enter the second vertex: ");
                    int secondVertex = VertexCapturer.CaptureVertex(graphVertices);

                    GraphValidator.ValidateEdge(result,
                        new Tuple<int, int>(firstVertex, secondVertex));
                    result.Add(new Tuple<int, int>(firstVertex,secondVertex));
                    ip15_pluhatyrov_03.PrintHorizontalRule(); 
                }
                catch (ArgumentException ex)
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
    }
}