using System;

namespace Labwork_4
{
    class Program
    {
        public static void Main(string[] args)
        {
            Data data = new Data();
            data.SetDataAdjacencyArrayFromFile("user.txt");
            data.SetDataArrayByGenerating(5);
            data.SetDataArrayFromFile("user.txt");
            data.GetShortestPathDantzig();
        }

        public const double INF = 1e9;
    }
}
