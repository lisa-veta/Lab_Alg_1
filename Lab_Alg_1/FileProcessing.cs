using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public class FileProcessing
    {
        public List<string> GetValues(double[] results)
        {
            List<string> newResilt = new List<string>();
            newResilt.Add($"{1};{results[0]}");
            for (int i = 1; i < results.Length-1; i++)
            {
                if (results[i] != results[i+1] || results[i] != results[i - 1])
                {
                    newResilt.Add($"{i + 1};{results[i]}");
                }
            }
            newResilt.Add($"{results.Length};{results[results.Length-1]}");
            return newResilt;
        }
    }
}
