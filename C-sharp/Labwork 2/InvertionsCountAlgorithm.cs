using System;

namespace Labwork_2
{
    public class InvertionsCountAlgorithm
    {
        public static int GetInvertionsCount(int[] inputArray)
        {
            int[] copyOfInputArray = new int[inputArray.Length];
            Array.Copy(inputArray, copyOfInputArray, inputArray.Length);

            return MergeSort(copyOfInputArray, 0, inputArray.Length - 1);
        }

        private static int MergeSort(int[] inputArray, int left, int right)
        {
            int mid;
            int invertionsCount = 0;

            if (right > left)
            {
                mid = (right + left) / 2;

                invertionsCount += MergeSort(inputArray, left, mid);
                invertionsCount += MergeSort(inputArray, mid + 1, right);

                invertionsCount += Merge(inputArray, left, mid + 1, right);
            }

            return invertionsCount;
        }

        private static int Merge(int[] inputArray, int left, int mid, int right)
        {
            int invertionsCount = 0;
            int i = left;
            int j = mid;
            int k = left;
            int[] tempArray = new int[inputArray.Length];

            while ((i <= mid - 1) && (j <= right))
            {
                if (inputArray[i] <= inputArray[j])
                {
                    tempArray[k++] = inputArray[i++];
                }
                else
                {
                    tempArray[k++] = inputArray[j++];
                    invertionsCount += (mid - i);
                }
            }

            while (i <= mid - 1)
            {
                tempArray[k++] = inputArray[i++];
            }

            while (j <= right)
            {
                tempArray[k++] = inputArray[j++];
            }

            for (i = left; i <= right; i++)
            {
                inputArray[i] = tempArray[i];
            }

            return invertionsCount;
        }
    }
}