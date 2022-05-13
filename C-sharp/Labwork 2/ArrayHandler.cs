using System;
using System.Collections.Generic;
using System.Linq;

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

        public static int[][] CreateHitParadesArray(FileRepresentator inputFile)
        {
            int[] userData = inputFile.Description.Split(" ").
                Select(num => Int32.Parse(num)).ToArray();
            int usersCount = userData[0];
            int filmsCount = userData[1];

            if (usersCount <= 0 || filmsCount <= 0)
            {
                return new int[0][];
            }

            List<string> hitParades = inputFile.Content.Skip(1).ToList();
            int[][] result = new int[usersCount][];

            for (var i = 0; i < usersCount; i++)
            {
                result[i] = ParseHitParadeAndRemoveUserNumber(hitParades[i]);
            }

            return result;
        }

        private static int[] ParseHitParadeAndRemoveUserNumber(string hitParade)
        {
            return hitParade.Split(' ').Select(film => Convert.ToInt32(film)).
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
                    hitParadesSimilarityArray.Add(GetSimilaritySequence
                    (hitParadeToCompare, hitParades[i]));
                }
            }

            return hitParadesSimilarityArray.ToArray();
        }

        private static int[] GetSimilaritySequence(int[] hitParadeToCompareWith, int[] comparableHitParade)
        {
            List<int> result = new List<int>();

            for (var i = 0; i < hitParadeToCompareWith.Length; i++)
            {
                for (var y = 0; y < comparableHitParade.Length; y++)
                {
                    if (hitParadeToCompareWith[i] == comparableHitParade[y])
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
            result.Prepend(new int[1] { baseUserNumber });

            return result.ToArray();
        }
    }
}