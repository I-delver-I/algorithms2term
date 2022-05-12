using System;

namespace Labwork_1
{
    public class SortAlgorithm
    {
        public long Comparisons { get; set; } = 0;

        public long Swaps { get; set; } = 0;

        public int GapDividings { get; set; } = 0;
        
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
            bool swapped = true;

            for (int y = 0; y < seq.Length - 1 && swapped; y++)
            {
                swapped = false;
                for (int i = 1; i < seq.Length - y; i++)
                {
                    if (seq[i - 1] > seq[i])
                    {
                        seq[i - 1] += seq[i];
                        seq[i] = seq[i - 1] - seq[i];
                        seq[i - 1] = seq[i - 1] - seq[i];

                        Swaps++;
                        swapped = true;
                    }
                    Comparisons++;
                }
            }
        }

        private void CombSort(int[] seq)
        {
            double factor = 1.2473309;
            int step = seq.Length - 1;

            while (step >= 1)
            {
                for (int i = 0; i + step < seq.Length; i++)
                {
                    if (seq[i] > seq[i + step])
                    {
                        seq[i + step] += seq[i];
                        seq[i] = seq[i + step] - seq[i];
                        seq[i + step] = seq[i + step] - seq[i];

                        Swaps++;
                    }
                    Comparisons++;
                }
                step = (int)(step / factor);
                GapDividings++;
            }
        }
    }
}
