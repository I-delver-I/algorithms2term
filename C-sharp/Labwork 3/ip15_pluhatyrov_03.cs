using System;
using System.Collections.Generic;
using Labwork_3.MainFlow.Capturer;
using Labwork_3.MainFlow;

namespace Labwork_3.MainFlow
{
    class ip15_pluhatyrov_03
    {
        static void Main(string[] args)
        {
            List<int> vertices = VertexCapturer.CaptureVertices();
            
            PrintVertices(vertices);

            List<Tuple<int, int>> edges = EdgeCapturer.CaptureEdges(vertices);
            Graph<int> graph = new Graph<int>(vertices, edges);
            
            PrintVertices(vertices);
            System.Console.WriteLine("Select the start vertex: ");
            int startVertex = VertexCapturer.CaptureVertex(vertices);
            
            Console.WriteLine(string.Join("-->", DFSalgorithm.
            DFS(graph, startVertex)));
        }

        public static void PrintHorizontalRule()
        {
            System.Console.WriteLine(new string('-', 40));  
        }

        static void PrintVertices(List<int> vertices)
        {
            System.Console.WriteLine("The current graph has the next vertices:");

            foreach (int vertex in vertices)
            {
                System.Console.Write($"{vertex}  ");
            }
            
            System.Console.WriteLine(Environment.NewLine);
        }
    }
}
