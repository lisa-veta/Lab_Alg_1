using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    internal class Task3
    {

        public void CocktailShakerSort(int[] vector)
        {
            for (var i = 0; i < vector.Length / 2; i++)
            {
                bool flag = false;
                for (int j = i; j < vector.Length - i - 1; j++)
                {
                    if (vector[j] > vector[j + 1])
                    {
                        Swap(vector, j, j+1);
                        flag = true;
                    }
                }

                for (int j = vector.Length - 2 - i; j > i; j--)
                {
                    if (vector[j - 1] > vector[j])
                    {
                        Swap(vector, j - 1, j);
                        flag = true;
                    }
                }

                if (!flag)
                {
                    break;
                }
            }

        }

        public void Swap(int[] vector, int a, int b)
        {
            int temp = vector[a];
            vector[a] = vector[b];
            vector[b] = temp;
        }
    }
}
