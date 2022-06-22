using System;
using System.IO;

namespace Labwork_4
{
    public class Data
    {
        public List<List<double>> AdjacencyArray { get; set; } = new List<List<double>>();
        public int Tops { get; set; }
        public int Ribs { get; set; }        
        private double _iterDantzig;
        private List<int> _path = new List<int>();
        private int _pathCounter;
        private int _from;
        private int _to;
        private AlgorithmDantzig _dantzig;

        private void SetPathToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"======={_from} | {_to} ======={Environment.NewLine}");

                for (var i = 0; i < _pathCounter - 1; i++)
                {
                    writer.WriteLine($"{_path[i]}->{_path[i + 1]} = "
                        + $"{AdjacencyArray[_path[i] - 1][_path[i + 1] - 1]}");
                }
            }
        }

        

        public void CreateArrays()
        {
            for (int i = 0; i < Tops; i++)
            {
                for (int j = 0; j < Tops; j++)
                {
                    AdjacencyArray[i][j] = Program.INF;                    
                }
            }
        }

        public void SetDataArrayFromFile(string fileName)
        {
            int x;
            int y;
            double weight;

            using (StreamReader reader = new StreamReader(fileName))
            {
                Tops = int.Parse(reader.ReadLine());
                Ribs = int.Parse(reader.ReadLine());
                CreateArrays();

                for (var i = 0; i < Ribs; i++)
                {
                    x = int.Parse(reader.ReadLine());
                    y = int.Parse(reader.ReadLine());
                    weight = double.Parse(reader.ReadLine());
                    AdjacencyArray[x - 1][y - 1] = weight;
                }
            }
        }

        public void SetDataAdjacencyArrayFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    Tops = int.Parse(reader.ReadLine());
                    double data;
                    CreateArrays();
                    Ribs = int.Parse(reader.ReadLine());

                    for (var i = 0; i < Tops; i++)
                    {
                        for (var j = 0; j < Tops; j++)
                        {
                            data = double.Parse(reader.ReadLine());
                            AdjacencyArray[i][j] = data;
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public void SetDataArrayByGenerating(int num)
        {
            Tops = num;
            CreateArrays();
            Random random = new Random();

            for (int i = 0; i < num; i++)
            {
                for (var j = 0; j < num; j++)
                {
                    if(i != j)
                    {
                        int a = random.Next(4);

                        if (a == 0)
                        {
                            AdjacencyArray[i][j] = Program.INF;
                            continue;
                        }
                        
                        AdjacencyArray[i][index: j] = random.Next(15+1);
                        Ribs++;
                    }
                }
            }
        }

        public void SetDataToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write($"{Tops} ");
                writer.WriteLine(Ribs);

                for (var i = 0; i < Tops; i++)
                {
                    for (var j = 0; j < Tops; j++)
                    {
                        writer.Write(AdjacencyArray[i][j].ToString().PadLeft(10));
                    }

                    if(i != Tops - 1)
                    {
                        writer.WriteLine();
                    }
                }
            }
        }

        public void ShowGraph()
        {
            using (StreamWriter writer = new StreamWriter("picture.dot"))
            {
                writer.WriteLine("  digraph g{");
                writer.WriteLine("    dpi=\"600\";");
                writer.WriteLine("    rankdir=\"LR\";");
                writer.WriteLine("    splines=\"line\";");

                for (var i = 0; i < Tops; i++)
                {
                    writer.WriteLine($"    {i + 1} [shape=\"circle\"label=\"{i + 1}\"];");
                }

                for (var i = 0; i < Tops; i++)
                {
                    for (var j = 0; j < Tops; j++)
                    {
                        if (AdjacencyArray[i][j] != Program.INF && i != j && AdjacencyArray[i][j] != 0)
                        {
                            writer.WriteLine($"    {i + 1}->{j + 1} [weight=1000 label=\"{AdjacencyArray[i][j]}\"];");
                        }
                    }
                }

                writer.Write("  }");
            }

            File.Delete("picture.png");
        }

        public void ShowPath()
        {
            using (StreamWriter writer = new StreamWriter("Path.dot"))
            {
                writer.WriteLine("  digraph g{");
                writer.WriteLine("    dpi=\"600\";");
                writer.WriteLine("    rankdir=\"LR\";");
                writer.WriteLine("    node[shape=circle, group=main];");

                for (var i = 0; i < _pathCounter; i++)
                {
                    writer.WriteLine($"    {_path[i]}->{_path[i + 1]} "
                        + "[label=\"{AdjacencyArray[_path[i] - 1][_path[i + 1] - 1]}\"];");
                }

                writer.Write("  }");
                File.Delete("Path.png");
                SetPathToFile("reserved_for_path.txt");
            }
        }

        public void GetShortestPathDantzig()
        {
            _pathCounter = 0;
            _dantzig = new AlgorithmDantzig(Tops, Ribs, Adjacency_Array: AdjacencyArray, _from, _to, _path);
            _dantzig.CreateProcessingHistoryArrays();
            _dantzig.Processing();
            _dantzig.GetShortestPath();
            _dantzig.SetResultToFile();
            _pathCounter = _dantzig.Counter;
            _iterDantzig = _dantzig.IterDantzig;
        }

        public bool IsINF(int row, int column)
        {
            if (AdjacencyArray[row][column] == Program.INF)
            {
                return true;
            }

            return false;
        }


        public class AlgorithmDantzig
        {
            public int Tops { get; set; } = default;
            public int Ribs { get; set; } = default;
            public int From { get; set; } = default;
            public int To { get; set; } = default;
            public List<int> Path { get; set; }
            public int Counter { get; set; } = 0;
            public double IterDantzig { get; set; } = 0;
            public List<List<double>> AdjacencyArray { get; set; }
            public List<List<List<double>>> ProcessingArrays { get; set; }
            public List<List<double>> ArrayOfHistory { get; set; }
            
            public AlgorithmDantzig(int tops, int ribs, List<List<double>> Adjacency_Array, int from, int to, List<int> path)
            {
                Tops = tops;
                Ribs = ribs;
                AdjacencyArray = Adjacency_Array;
                From = from;
                To = to;
                Path = path;
            }

            public double SummingDmMJ(List<List<List<double>>> data, int i, int j, int m)
            {
                double sum = 0;
                sum = data[0][m - 1][i] + data[m - 1][i][j];

                return sum;
            }
            
            public double SummingDmIM(List<List<List<double>>> data, int i, int j, int m)
            {
                double sum = 0;
                sum = data[m - 1][i][j] + data[0][j][m - 1];

                return sum;
            }
            
            public void CreateProcessingHistoryArrays()
            {
                for (var i = 0; i < Tops; i++)
                {
                    for (var j = 0; j < Tops; j++)
                    {
                        if (i != j)
                        {
                            ProcessingArrays[0][i][j] = Program.INF;
                        }
                    }
                }

                for (var i = 0; i < Tops; i++)
                {
                    for (var j = 0; j < Tops; j++)
                    {
                        if (i!=j)
                        {
                            ProcessingArrays[0][index: i][j] = AdjacencyArray[i][j];
                        }
                    }

                }

                for (var i = 0; i < Tops; i++) 
                {
                    for (var j = 0; j < Tops; j++) 
                    {
                        if (ProcessingArrays[0][index: i][j] != Program.INF
                            && ProcessingArrays[0][i][j] != 0)
                        {
                            ArrayOfHistory[i][j] = j + 1;
                        }
                    }
                }
                
            }

            public void Processing()
            {
                int counter = 2;

                for (int m = 2; m <= Tops; m++)//layer
                {
                    IterDantzig++;

                    for (int i = 0; i < counter; i++)
                    {
                        IterDantzig++;

                        for (int j = 0; j < counter; j++)
                        {
                            IterDantzig++;

                            if (i == j)
                            {
                                continue;
                            }

                            if (m - 1 == i)
                            {
                                double min = Program.INF * Program.INF;
                                int ptr = default;

                                for (int i1 = 0; i1 < m - 1; i1++)
                                {
                                    IterDantzig++;

                                    if (SummingDmMJ(ProcessingArrays, i1, j, m) < min)
                                    {
                                        ptr = i1;
                                        min = SummingDmMJ(ProcessingArrays, i1, j, m);
                                        ProcessingArrays[m][m - 1][j] = min;
                                    }
                                }

                                if (min < Program.INF && i != ptr)
                                {
                                    ArrayOfHistory[m - 1][j] = ArrayOfHistory[m - 1][ptr];
                                }
                            }
                            else if (m - 1 == j)
                            {
                                double min = Program.INF * Program.INF;
                                int ptr = default;

                                for (int j1 = 0; j1 < m - 1; j1++)
                                {
                                    IterDantzig++;

                                    if (SummingDmIM(ProcessingArrays, i, j1, m) < min)
                                    {
                                        ptr = j1;
                                        min = SummingDmIM(ProcessingArrays, i, j1, m);
                                        ProcessingArrays[m][i][m - 1] = min;
                                    }
                                }

                                if (min < Program.INF && i != ptr)
                                {
                                    ArrayOfHistory[i][m - 1] = ArrayOfHistory[i][ptr];
                                }

                            }
                        }
                    }

                    for (int i = 0; i < counter; i++)
                    {
                        IterDantzig++;

                        for (int j = 0; j < counter; j++)
                        {
                            IterDantzig++;

                            if (i != j && m - 1 != j && m - 1 != i)
                            {

                                if (ProcessingArrays[m][i][m - 1] + ProcessingArrays[m][m - 1][j] < ProcessingArrays[m - 1][i][j])
                                {
                                    ProcessingArrays[m][i][j] = ProcessingArrays[m][i][m - 1] + ProcessingArrays[m][m - 1][j];
                                    ArrayOfHistory[i][j] = ArrayOfHistory[i][m - 1];
                                }
                                else
                                {
                                    ProcessingArrays[m][i][j] = ProcessingArrays[m - 1][i][j];
                                }
                            }
                        }
                    }

                    counter++;
                }
            }

            public void GetShortestPath()
            {
                Path[Counter++] = From;
                int k = (int)ArrayOfHistory[From - 1][To - 1];

                if (k != 0)
                {
                    Path[Counter++] = k;
                }
                while (k != 0)
                {
                    k = (int)ArrayOfHistory[k - 1][To - 1];

                    if (k != 0)
                    {
                        Path[Counter++] = k;
                    }
                }
            }

            public void SetResultToFile()
            {
                using (StreamWriter writer = new StreamWriter(@"Dantzig.txt"))
                {
                    writer.WriteLine("=======The result of Dantzig algorithm=======");

                    for (int i = 0; i < Tops; i++)
                    {
                        for (int j = 0; j < Tops; j++)
                        {
                            writer.Write($"{ProcessingArrays[Tops][i][j].ToString().PadLeft(5)}");
                        }
                        writer.WriteLine();
                    }
                }
            }

            
        }
    }
}