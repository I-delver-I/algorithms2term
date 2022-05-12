using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Labwork_2.MainFlow
{
    class ip15_pluhatyrov_02
    {
        static void Main(string[] args)
        {
            ValidateProgramRun(args[0]);

            FileHandler inputFile = new FileHandler(FileHandler.
            GetFilePath(args[0]), true);
            System.Console.WriteLine("The content of input file:");
            inputFile.PrintFileContent();
            PrintHorizontalRule();

            int[][] hitParades = ArrayHandler.CreateHitParadesArray(inputFile.Content);
            Console.WriteLine("The hit-parades array:");
            ArrayHandler.PrintSecondDimensionalArray(hitParades);
            PrintHorizontalRule();
            
            int userNumber = Capturer.CaptureUserNumber(Int32.Parse(inputFile.
            Description.Split(" ").First()));
            int[][] similarityMatrix = ArrayHandler.
            GetMatrixOfHitParadesSimilarity(hitParades, userNumber);
            Console.WriteLine("The similarities array:");
            ArrayHandler.PrintSecondDimensionalArray(similarityMatrix);
            PrintHorizontalRule();

            Console.WriteLine($"Invertions report:");
            int[][] inversionsMatrix = ArrayHandler.
            GetInvertionsMatrix(similarityMatrix, userNumber);
            ArrayHandler.PrintSecondDimensionalArray(inversionsMatrix);

            string outputFilePath = "ip15_pluhatyrov_02_output.txt";
            FileHandler outputFile = new FileHandler(FileHandler.
            GetFilePath(outputFilePath), false);
            List<string> inversionsData = new List<string>();
            
            foreach (int[] inversion in inversionsMatrix)
            {
                inversionsData.Add(string.Join(" ", inversion));
            }
            
            outputFile.WriteContentToFile(inversionsData);
            System.Console.WriteLine("The content of output file is the same:");
            outputFile.PrintFileContent();
        }

        static void PrintHorizontalRule()
        {
            Console.WriteLine(new string('-', 40));
        }

        static void ValidateProgramRun(string inputFileName)
        {
            if (inputFileName.Length == 0)
            {
                System.Console.WriteLine("Please, give correct command argument as an input file name");
                Environment.Exit(0);
            }
        }
    }
}
