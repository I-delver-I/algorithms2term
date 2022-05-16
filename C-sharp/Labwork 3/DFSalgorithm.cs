using System;
using System.Collections.Generic;

namespace Labwork_3
{
    public class DFSalgorithm
    {
        public static HashSet<T> DFS<T>(Graph<T> graph, T start, Action<T> preVisit = null) 
        {
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
            {
                return visited;
            }
                
            var stack = new Stack<T>();
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

                foreach(var neighbor in graph.AdjacencyList[vertex])
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