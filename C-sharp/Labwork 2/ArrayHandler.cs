using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labwork_2
{
    public class ArrayHandler
    {
        public static void PrintSecondDimensionalArray(int[][] inputArray)
        {
            for (var i = 0; i < inputArray.Length; i++)
            {
                for (var y = 0; y < inputArray[i].Length; y++)
                {
                    Console.Write($"{inputArray[i][y]} ");
                }
                Console.WriteLine();
            }
        }

        public static int[][] CreateHitParadesArray(List<string> hitParades)
        {
            string fileDescription = hitParades[0];
            int[] userData = hitParades[0].Split(" ").Select(record => Int32.
            Parse(record)).ToArray();
            
            int usersCount = userData[0];
            int filmsCount = userData[1];

            if (usersCount <= 0 || filmsCount <= 0)
            {
                return new int[0][];
            }

            hitParades = hitParades.Where((hitParade, index) => index > 0).ToList();
            int[][] result = new int[usersCount][];

            for (var i = 0; i < usersCount; i++)
            {
                result[i] = ParseHitParadeAndAppend(hitParades[i]);
            }

            return result;
        }

        public static int[] ParseHitParadeAndAppend(string rawHitParade)
        {
            return rawHitParade.Split(' ').Select(film => Convert.ToInt32(film)).
            ToArray()[1..];
        }

        public static int[][] GetMatrixOfHitParadesSimilarity(int[][] hitParades, int userNumberToCompare)
        {
            int[] hitParadeToCompare = hitParades[userNumberToCompare - 1];
            List<int[]> hitParadesSimilarityArray = new List<int[]>();

            for (var i = 0; i < hitParades.Length; i++)
            {
                if (i != userNumberToCompare - 1)
                {
                    hitParadesSimilarityArray.Add(GetSimilarityArray
                    (hitParadeToCompare, hitParades[i]));
                }
            }

            return hitParadesSimilarityArray.ToArray();
        }

        public static int[] GetSimilarityArray(int[] hitParadeToCompare, int[] comparingHitParade)
        {
            List<int> result = new List<int>();

            for (var i = 0; i < hitParadeToCompare.Length; i++)
            {
                for (var y = 0; y < comparingHitParade.Length; y++)
                {
                    if (hitParadeToCompare[i] == comparingHitParade[y])
                    {
                        result.Add(y + 1);
                    }
                }
            }

            return result.ToArray();
        }

        public static int[][] GetInvertionsMatrix(int[][] similarityMatrix, int baseUserNumber)
        {
            List<int[]> result = new List<int[]>();

            for (int i = 0, userNumber = 1; i < similarityMatrix.Length; i++, userNumber++)
            {
                if (baseUserNumber == userNumber)
                {
                    userNumber++;
                }

                result.Add(new int[] { userNumber, InvertionsCountAlgorithm.
                GetInvertionsCount(similarityMatrix[i]) });
            }

            result = result.OrderBy(invertions => invertions[1]).ToList();
            result.Insert(0, new int[1] { baseUserNumber });

            return result.ToArray();
        }
    }
}