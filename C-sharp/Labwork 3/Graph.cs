using System;
using System.Collections.Generic;

namespace Labwork_3
{
    public class Graph<T> 
    {
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public Graph() {}

        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T,T>> edges) {
            foreach(T vertex in vertices)
            {
                AddVertex(vertex);
            }

            foreach(Tuple<T, T> edge in edges)
            {
                AddEdge(edge);
            }
        }

        public void AddVertex(T vertex) 
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        public void AddEdge(Tuple<T,T> edge) 
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2)) 
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }
    }
}