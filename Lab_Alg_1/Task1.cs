using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public class Task1
    {
        public void DoConstFunc(int[] vector)
        {
            int a = vector.Length;
        }

        public void DoSumFunc(int[] vector)
        {
            int sum = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                sum += vector[i];
            }
        }

        public void DoMultiplicationFunc(int[] vector)
        {
            int multi = 1;
            for (int i = 0; i < vector.Length; i++)
            {
                multi *= vector[i];
            }
        }

        public double DoMethodGornera(int[] vector, int i = 0)
        {
            double x = 1.5;
            if (i >= vector.Length)
                return 0;
            return vector[i] + x * DoMethodGornera(vector, i + 1);
        }

        public void DoDirectMethod(int[] vector)
        {
            double result = 0;
            double x = 1.5;
            for(int i = 1; i <= vector.Length; i++)
            {
                result += vector[i-1] * Math.Pow(x, i - 1);
            }
        }

        public void DoBubbleSort(int[] vector)
        {
            int temp;
            for (int i = 0; i < vector.Length - 1; i++)
            {
                for (int j = 0; j < vector.Length - i - 1; j++)
                {
                    if (vector[j] > vector[j + 1])
                    {
                        temp = vector[j];
                        vector[j] = vector[j + 1];
                        vector[j + 1] = temp;
                    }
                }
            }
        }

        public void DoQuickSort(int[] vector, int startInd, int endInd)
        {
            if (startInd >= endInd)
            {
                return;
            }
            int pivot = Partition(vector, startInd, endInd);
            DoQuickSort(vector, startInd, pivot - 1);
            DoQuickSort(vector, pivot + 1, endInd);
        }

        public int Partition(int[] vector, int startInd, int endInd)
        {
            int pivot = vector[endInd];
            int position = startInd - 1;
            for (int i = startInd; i <= endInd; i++)
            {
                if (vector[i] < pivot)
                {
                    position++;
                    Swap(vector, i, position);
                }

            }
            position++;
            vector[endInd] = vector[position];
            vector[position] = pivot;
            return position;
        }

        public void Swap(int[] vector, int ind1, int ind2)
        {
            int box = vector[ind1];
            vector[ind1] = vector[ind2];
            vector[ind2] = box;
        }

        public  void DoTimSort(int[] vector)
        {
            int n = vector.Length;
            int minRun = FindMinRunLength(vector.Length);
            for (int i = 0; i < n; i+=minRun)
            {
                int leftPart = i;
                int rightPart = Math.Min((i + minRun - 1), (n - 1));
                InsertionSort(vector,leftPart,rightPart);
            }

            for (int size= minRun; size < n; size=2*size)
            {
                for (int leftPart = 0; leftPart < n; leftPart+=2*size)
                {
                    int middlePart = leftPart + size - 1;
                    int rightPart = Math.Min((leftPart + 2 * size - 1), (n - 1));

                    if (middlePart<rightPart)
                    {
                        MergeSort(vector,leftPart,middlePart,rightPart);
                    }
                }
            }
        }

        private int FindMinRunLength (int length)
        {
            int flag = 0;// будет равно 1, если среди сдвинутых битов есть хотя бы один ненулевой
            while (length >= 64)
            {
                flag = flag | (length & 1);
                length = length >> 1;
            }
            return length + flag;
        }
        
        private void InsertionSort(int[] vector, int leftPart, int rightPart)
        {
            for (int i = leftPart+1; i <= rightPart; i++)
            {
                int temp = vector[i];
                int k = i - 1;
                while (k>=leftPart && vector[k]>temp)
                {
                    vector[k + 1] = vector[k];
                    k--;
                }
                vector[k + 1] = temp;
            }
        }

        private void MergeSort(int[]vector,int left, int middle, int right)
        {
            int length1 = middle - left + 1;
            int length2 = right - middle;
            int[] leftPart = new int[length1];
            int[] rightPart = new int[length2];

            for (int x = 0; x < length1; x++)
            {
                leftPart[x] = vector[x + 1];
            }

            for (int x = 0; x < length2; x++)
            {
                rightPart[x] = vector[middle + 1 + x];
            }

            int i = 0;
            int j = 0;
            int k = left;

            while (i<length1 && j<length2)
            {
                if (leftPart[i]<=rightPart[j])
                {
                    vector[k] = leftPart[i];
                    i++;
                }

                else
                {
                    vector[k] = rightPart[j];
                    j++;
                }

                k++;
            }

            while (i<length1)
            {
                vector[k] = leftPart[i];
                k++;
                i++;
            }

            while (j<length2)
            {
                vector[k] = rightPart[j];
                k++;
                j++;
            }
        }

       
        public int DoSimplePow(int x, int n)
        {
            int steps = 0;
            int func = 1;
            int k = 0;
            while (k < n)
            {
                func *= x;
                k++;
                steps += 2;
            }
            return steps;
        }

        int steps = 0;
        public long DoRecursivePow(int x, int n)
        {
            if (n == 0)
            {
                steps += 1;
                return 1;
            }
            long func = DoRecursivePow(x, n / 2);
            steps += 1;
            if (n%2==1)
            {
                func*=func * x;
                steps += 1;
            }
            if (n%2!=1)
            {
                func *= func;
                steps += 1;
            }
            return steps;
        }

        public int DoQuickPow(int c, int k)
        {
            int steps = 0;
            int func;
            if (k % 2 == 1)
            {
                func = c;
            }
            else
            {
                func = 1;
            }

            do
            {
                k /= 2;
                c *= c;
                steps += 2;
                if (k % 2 == 1)
                {
                    steps += 1;
                    func *= c;
                }
            }
            while (k != 0);

            return steps;
        }

        public int DoClassicQuickPow(int c, int k)
        {
            int steps = 0;
            int func = 1;

            while (k != 0)
            {
                if (k % 2 == 0)
                {
                    steps += 2;
                    c *= c;
                    k /= 2;
                }
                else
                {
                    steps += 2;
                    func *= c;
                    k -= 1;
                }
            }

            return steps;
        }

    }
}
