using System;

namespace Labwork_4
{
    class Program
    {
        public static void Main(string[] args)
        {
            int n = 6;
            int Adj= new int[6][6]{
                {0, 10, 18, 8, max, max},
                {10, 0, 16, 9, 21, max},
                {max, 16, 0, max, max,15},
                {7, 9, max, 0, max, 12},
                {max, max, max, max, 0, 23},
                {max, max, 15, max, 23, 0},};
            System.Console.WriteLine("Matrix ways :");
            Danzig(Adj, n);
            //Warshall(Adj, n);
            
        }
    }
}
