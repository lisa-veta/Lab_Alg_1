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
        public int[,] DoMultiplicationMatrix(int[,] matrixA, int[,] matrixB)
        {
            int n = matrixA.GetLength(0);
            int m = matrixB.GetLength(1);
            int maxK = matrixA.GetLength(1);
            int[,] matrixResult = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < maxK; k++)
                    {
                        matrixResult[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            
            return matrixResult;
        }

    }
}
