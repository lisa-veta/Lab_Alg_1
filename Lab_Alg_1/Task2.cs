using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public class Task2
    {
        public int[,] DoMultiplicationMatrix(int n, int maxValue)
        {
            int[,] matrixA = CreateMatrix(n, maxValue);
            int[,] matrixB = CreateMatrix(n, maxValue);
            int[,] matrixResult = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        matrixResult[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            
            return matrixResult;
        }

        public int[,] CreateMatrix(int n, int maxValue)
        {
            int[,] matrix = new int[n, n];
            Random random = new Random();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(0, maxValue);
                }
            }
            return matrix;
        }
    }
}
