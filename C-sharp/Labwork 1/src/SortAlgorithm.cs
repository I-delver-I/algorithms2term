using System;

namespace Labwork_1
{
    public class SortAlgorithm
    {
        public int Comparisons { get; set; } = 0;

        public int Swaps { get; set; } = 0;

        private string _name;
        public string Name 
        {   get
            {
                return _name;
            }
            set
            {
                if (value != "bubble" && value != "comb")
                {
                    throw new ArgumentException("You didn't enter the name of algorithm!");
                }

                _name = value;
            }
        }

        public void StartAlgorithm(int[] Sequence)
        {
            switch (Name.ToLower())
            {
                case "bubble":
                    SortBubble(Sequence);
                    break;
                case "comb":
                    CombSort(Sequence);
                    break;
                default:
                    break;
            }
        }
        
        private void SortBubble(int[] seq)
        {
            for (int y = 0; y < seq.Length - 1; y++)
            {
                for (int i = 1; i < seq.Length; i++)
                {
                    if (seq[i - 1] > seq[i])
                    {
                        (seq[i - 1], seq[i]) = (seq[i], seq[i - 1]);
                        Swaps++;
                    }
                    Comparisons++;
                }
            }
        }

        private void CombSort(int[] array)
        {
            double factor = 1.2473309;
            int step = array.Length - 1;

            while (step >= 1)
            {
                for (int i = 0; i + step < array.Length; i++)
                {
                    if (array[i] > array[i + step])
                    {
                        (array[i], array[i + step]) = (array[i + step], array[i]);
                        Swaps++;
                    }
                    Comparisons++;
                }
                step = (int)(step / factor);
            }
        }
    }
}
