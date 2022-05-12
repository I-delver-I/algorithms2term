using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Labwork_2
{
    public class FileHandler
    {
        public string Description { get; set; }
        public string Path { get; }
        public List<string> Content { get; set; }
        public string Name { get; }

        public FileHandler(string path, bool isCreated)
        {
            Path = path;
            Name = path.Split("\\").Last();
            Content = GetFileContent();
            Description = Content.First();

            if (!isCreated)
            {
                using FileStream file = File.Create(path);
            }
        }

        /// <summary>
        /// Gets input file path which is situated in the folder of project
        /// </summary>
        /// <param name="inputFileName"></param>
        /// <returns></returns>
        public static string GetFilePath(string inputFileName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            
            return @$"{workingDirectory}\{inputFileName}";
        }

        public void Clear()
        {
            File.WriteAllText(Path, string.Empty);
            Description = default;
            Content = default;
        }

        public void WriteContentToFile(List<string> rawContent)
        {
            Content = rawContent;
            Description = rawContent.First();
            StringBuilder content = new StringBuilder();
            rawContent.ForEach(record => 
            {
                if (record != rawContent.Last())
                {
                    record += Environment.NewLine;
                }

                content.Append(record);
            });

            using (StreamWriter destFile = new StreamWriter(Path))
            {
                destFile.Write(content);
            }

            Content = rawContent;
            Description = rawContent.First();
        }

        /// <summary>
        /// Initializes content and description of the file
        /// </summary>
        /// <returns></returns>
        private List<string> GetFileContent()
        {
            List<string> result = new List<string>();

            try
            {
                using StreamReader inputReader = new StreamReader(Path);
                while (!inputReader.EndOfStream)
                {
                    result.Add(inputReader.ReadLine());
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (result.Count > 0) ? result : new List<string>() { string.Empty };
        }

        public void PrintFileContent()
        {
            foreach (string hitParade in Content)
            {
                Console.WriteLine($"{hitParade}");
            }
        }
    }
}