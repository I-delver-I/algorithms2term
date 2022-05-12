using System;
using System.Linq;

namespace Labwork_1
{
    public class NumSequence
    {
        private readonly Random _random = new Random();

        public string Type { get; set; }

        public int[] Sequence { get; set; }

        public int CountOfElements { get; set; }

        public void GetSequence()
        {
            Sequence = Type.ToLower() switch
            {
                "desc" => GenOrderDescSeq(),
                "asc" => GenOrderSeq(),
                _ => GenerateRandomNumbers(),
            };
        }
       
        private int[] GenerateRandomNumbers()
        {
            int[] array = Enumerable.Range(1, CountOfElements).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                int j = _random.Next(CountOfElements);
                (array[i], array[j]) = (array[j], array[i]);
            }

            return array;
        }

        private int[] GenOrderDescSeq()
        {
            int[] array = Enumerable.Range(1, CountOfElements).Reverse().ToArray();

            return array;
        }

        private int[] GenOrderSeq()
        {
            int[] array = Enumerable.Range(1, CountOfElements).ToArray();

            return array;
        }
    }
}
