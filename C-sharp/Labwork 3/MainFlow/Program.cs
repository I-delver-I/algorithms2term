using System;
using System.Collections.Generic;

namespace Labwork_3.MainFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> vertices = Capturer.CaptureVertices();
            
            System.Console.WriteLine("The nodes of the graph:");
            foreach (var vertex in vertices)
            {
                System.Console.Write($"{vertex}  ");
            }
            System.Console.WriteLine(Environment.NewLine);

            List<Tuple<int, int>> edges = Capturer.CaptureEdges(vertices);

            // Tuple<int, int>[] edges = new[] {Tuple.Create(1,2), Tuple.Create(1,3),
            //     Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
            //     Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
            //     Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10),
            //     };

            Graph<int> graph = new Graph<int>(vertices, edges);

            Console.WriteLine(string.Join(", ", DFSalgorithm.
            DFS(graph, 1)));
            // 1, 3, 6, 5, 8, 9, 10, 7, 4, 2
        }
    }
}
