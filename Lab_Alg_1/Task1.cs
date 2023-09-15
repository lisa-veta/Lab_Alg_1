﻿using System;
using System.Collections.Generic;
using System.Linq;
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
