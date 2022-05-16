using System;
using System.Collections.Generic;
using System.Linq;

namespace Labwork_3.MainFlow
{
    public class Validator
    {
        public static void ValidateNode(List<int> graphNodes, int nodeToValidate)
        {
            if (!graphNodes.Contains(nodeToValidate))
            {
                throw new ArgumentException($"The node {nodeToValidate} isn't inside the graph");
            }
        }

        public static void ValidateNode(int nodeToValidate)
        {
            if (nodeToValidate <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nodeToValidate),
                "the value of node should be bigger than 0");
            }
        }

        public static void ValidateEdge(List<Tuple<int, int>> graphEdges, Tuple<int, int> validatableEdge)
        {
            if (graphEdges.Any(tuple => tuple.Item1 == validatableEdge.Item1
                && tuple.Item2 == validatableEdge.Item2)
                || graphEdges.Any(tuple => tuple.Item1 == validatableEdge.Item2
                && tuple.Item2 == validatableEdge.Item1))
            {
                throw new ArgumentException("The edge isn't inside the graph");
            }
        }
    }
}