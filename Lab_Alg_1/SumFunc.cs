using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public class SumFunc
    {
        public void Start(int[] vector)
        {
            int sum = 0;
            for(int i = 0; i < vector.Length; i++)
            {
                sum += vector[i];
            }
        }
    }
}
