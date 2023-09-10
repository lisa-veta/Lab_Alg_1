using System;
using System.Diagnostics;

namespace Lab_Alg_1
{
    public class Program
    {
        delegate void WorkingMethod(int[] vector);
        WorkingMethod Wd; 
        int maxValue = 50000;
        int maxN = 50000;
        public static void Main(string[] args)
        {
            new Program().Working();
            //Working();
        }

        public void Working()
        {
            Wd = new SumFunc().Start;
            //string[] results = new string[maxN];
            double[] results  = new double[maxN];

            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double sumWorks = 0;
                
                for (int count = 0; count < 5; count++)
                {
                    watсh.Start();
                    Wd(CreateVector(n));
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.Milliseconds;
                    sumWorks += s;
                    //Console.Write($"   {s} : {sumWorks} ;");
                }
                //results[n - 1] = $"{n};{(double)(sumWorks)/5.0}";
                results[n - 1] = (double)(sumWorks) / 5.0;

                Console.WriteLine($"{n} : {(double)(sumWorks)/5.0}");
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines("C:\\Users\\4769003\\OneDrive\\Рабочий стол\\result.csv", fileProcessing.GetValues(results));
        }

        public int[] CreateVector(int n)
        {
            int[] array = new int[n];
            var random = new Random();
            for(int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, maxValue);
            }
            return array;
        }
    }
}
