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
            int[,] matrixResult = new int[matrixA.Length, matrixA.Length];

            for (int i = 0; i < matrixA.Length; i++)
            {
                for (int j = 0; j < matrixA.Length; j++)
                {
                    for (int k = 0; k < matrixA.Length; k++)
                    {
                        matrixResult[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            
            return matrixResult;
        }
    }
}
