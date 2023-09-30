using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public class IntermediateSave
    {
        public void ExtraSaving(int i, double[] results, string nameFile, int step)
        {
            FileProcessing processing = new FileProcessing();
            if(i % 500 == 0)
            {
                File.WriteAllLines(ImportantData.Path + nameFile + ".csv", processing.GetValues(results, step));
            }
        }
        public void ExtraSaving(int i, List<string> results, string nameFile)
        {
            FileProcessing processing = new FileProcessing();
            if (i % 500 == 0)
            {
                File.WriteAllLines(ImportantData.Path + nameFile + ".csv", results);
            }
        }
    }
}
