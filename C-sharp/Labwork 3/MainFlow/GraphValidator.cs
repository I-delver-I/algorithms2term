using System;
using System.Collections.Generic;
using System.Linq;

namespace Labwork_3.MainFlow
{
    public class GraphValidator
    {
        public static void ValidateVertexExistence(List<int> graphVertices, int validatableVertex)
        {
            if (!graphVertices.Contains(validatableVertex))
            {
                throw new ArgumentException($"The vertex {validatableVertex} isn't inside the graph");
            }
        }

        public static void ValidateVertexAbsence(List<int> graphVertices, int validatableVertex)
        {
            if (graphVertices.Contains(validatableVertex))
            {
                throw new ArgumentException($"The vertex {validatableVertex} is inside the graph");
            }
        }

        public static void ValidateVertexExistence(int validatableVertex)
        {
            if (validatableVertex <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(validatableVertex),
                "the value of vertex should be bigger than 0");
            }
        }

        public static void ValidateEdge(List<Tuple<int, int>> graphEdges, Tuple<int, int> validatableEdge)
        {
            if (graphEdges.Any(tuple => tuple.Item1 == validatableEdge.Item1
                && tuple.Item2 == validatableEdge.Item2)
                || graphEdges.Any(tuple => tuple.Item1 == validatableEdge.Item2
                && tuple.Item2 == validatableEdge.Item1))
            {
                throw new ArgumentException("The edge is already inside the graph");
            }
        }
    }
}