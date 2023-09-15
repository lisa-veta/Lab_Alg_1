using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public class Task3
    {
        public void DoHeapSort(int[] vector)
        {
            int n = vector.Length;
            for (int i = n / 2; i >= 0; i--)
                MaxHeapify(vector, n, i);
            for(int i = n - 1; i >= 0; i--)
            {
                Swap(vector, 0, i);
                MaxHeapify(vector, i, 0);
            }
        }

        public void MaxHeapify(int[] vector, int n, int ind)
        {
            int largest = ind;
            int indLeft = ind * 2 + 1;
            int indRight = ind * 2 + 2;
            if (indLeft < n && vector[indLeft] > vector[largest])
                largest = indLeft;
            if (indRight < n && vector[indRight] > vector[largest])
                largest = indRight;
            if (largest != ind)
            {
                Swap(vector, ind, largest);
                MaxHeapify(vector, n, largest);
            }
        }

        public void Swap(int[] vector, int a, int b)
        {
            int box = vector[a];
            vector[a] = vector[b];
            vector[b] = box;
        }

        public void DoCocktailShakerSort(int[] vector)
        {
            for (var i = 0; i < vector.Length / 2; i++)
            {
                bool flag = false;
                for (int j = i; j < vector.Length - i - 1; j++)
                {
                    if (vector[j] > vector[j + 1])
                    {
                        Swap(vector, j, j + 1);
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

    }
}
