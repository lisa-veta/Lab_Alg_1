﻿using System;
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
    }
}
