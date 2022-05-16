using System;
using System.Collections.Generic;

namespace Labwork_3
{
    public class DFSalgorithm
    {
        public static HashSet<T> DFS<T>(Graph<T> graph, T start, Action<T> preVisit = null) 
        {
            HashSet<T> visited = new();

            if (!graph.AdjacencyList.ContainsKey(start))
            {
                return visited;
            }
                
            Stack<T> stack = new();
            stack.Push(start);

            while (stack.Count > 0) 
            {
                T vertex = stack.Pop();

                if (visited.Contains(vertex))
                {
                    continue;
                }

                if (preVisit != null)
                {
                    preVisit(vertex);
                }

                visited.Add(vertex);

                foreach(T neighbor in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }

            return visited;
        }
    }
}