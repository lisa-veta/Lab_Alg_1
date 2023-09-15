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
            for(int i = 0; i < vector.Length; i++)
            {
                result += vector[i] * Math.Pow(x, i - 1);
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

        public  void TimSort(int[] array)
        {
            int n = array.Length;
            int minRun = FindMinRunLenght(array.Length);
            for (int i = 0; i < n; i+=minRun)
            {
                int leftPart = i;
                int rightPart = Math.Min((i + minRun - 1), (n - 1));
                InsertionSort(array,leftPart,rightPart);
            }

            for (int size= minRun; size < n; size=2*size)
            {
                for (int leftPart = 0; leftPart < n; leftPart+=2*size)
                {
                    int middlePart = leftPart + size - 1;
                    int rightPart = Math.Min((leftPart + 2 * size - 1), (n - 1));

                    if (middlePart<rightPart)
                    {
                        MergeSort(array,leftPart,middlePart,rightPart);
                    }
                }
            }
        }

        private int FindMinRunLenght (int lenght)
        {
            int flag = 0;// будет равно 1, если среди сдвинутых битов есть хотя бы один ненулевой
            while (lenght >= 64)
            {
                flag = flag | (lenght & 1);
                lenght = lenght >> 1;
            }
            return lenght + flag;
        }
        
        private void InsertionSort(int[] array, int leftPart, int rightPart)
        {
            for (int i = leftPart+1; i <= rightPart; i++)
            {
                int temp = array[i];
                int k = i - 1;
                while (k>=leftPart && array[k]>temp)
                {
                    array[k + 1] = array[k];
                    k--;
                }
                array[k + 1] = temp;
            }
        }

        private void MergeSort(int[]array,int left, int middle, int right)
        {
            int lenght1 = middle - left + 1;
            int lenght2 = right - middle;
            int[] leftPart = new int[lenght1];
            int[] rightPart = new int[lenght2];

            for (int x = 0; x < lenght1; x++)
            {
                leftPart[x] = array[x + 1];
            }

            for (int x = 0; x < lenght2; x++)
            {
                rightPart[x] = array[middle + 1 + x];
            }

            int i = 0;
            int j = 0;
            int k = left;

            while (i<lenght1 && j<lenght2)
            {
                if (leftPart[i]<=rightPart[j])
                {
                    array[k] = leftPart[i];
                    i++;
                }

                else
                {
                    array[k] = rightPart[j];
                    j++;
                }

                k++;
            }

            while (i<lenght1)
            {
                array[k] = leftPart[i];
                k++;
                i++;
            }

            while (j<lenght2)
            {
                array[k] = rightPart[j];
                k++;
                j++;
            }
        }

        public int Steps = 0;
        public long RecursivePow(int x, int n)
        {
            if (n == 0)
            {
                Steps += 1;
                return 1;
            }
            long func = RecursivePow(x, n / 2);
            Steps += 1;
            if (n%2==1)
            {
                func*=func * x;
                Steps += 1;
            }
            if (n%2!=1)
            {
                func *= func;
                Steps += 1;
            }
            return Steps;
        }

        public void DoQuickSort(int[] vector, int startInd, int endInd)
        {
            if(startInd >= endInd)
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
            int position = startInd;
            for(int i = startInd; i < endInd - 1; i++)
            {
                if (vector[i] <= pivot)
                { 
                    Swap(vector, i, position);
                    position++;
                }

            }
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

        public int DoSimplePow(int x, int n)
        {
            int func = 1;
            int k = 0;
            while(k < n)
            {
                func *= x;
                k++;
            }
            return func;
        }
      
        public int DoQuickPow(int x, int n)
        {
            int steps = 0;
            int c = x;
            int k = n;
            int f;
            if (k % 2 == 1)
            {
                f = c;
            }
            f = 1;

            do
            {
                k /= 2;
                c *= c;
                steps += 2;
                if (k % 2 == 1)
                {
                    steps += 1;
                    f *= c;
                }
            }
            while (k != 0);

            return steps;
        }

        public int DoClassicQuickPow(int x, int n)
        {
            int steps = 0;
            int c = x;
            int k = n;
            int f = 1;

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
                    f *= c;
                    k -= 1;
                }
            }

            return steps;
        }

    }
}
