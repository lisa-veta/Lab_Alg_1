using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public class BubbleSort
    {
        public void Start(int[] vector)
        {
            for(int i = 0; i < vector.Length - 1; i++)
            {
                for (int j = 0; j < vector.Length - i - 1; j++)
                {
                    if (vector[j] > vector[j + 1])
                    {
                        int a = vector[j];
                        int b = vector[j + 1];
                        vector[j] = b;
                        vector[j + 1] = a;
                    }
                }
            }
        }
    }
}
