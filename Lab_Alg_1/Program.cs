using System;
using System.Diagnostics;

namespace Lab_Alg_1
{
    public class Program
    { 
        static int maxValue = 3;
        static int maxN = 2;
        public static void Main(string[] args)
        {
            Working();
        }

        public static void Working()
        {
            var task = new Task1();
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
                    task.DoConstFunc(CreateVector(n, maxValue));
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

        public static int[] CreateVector(int n, int maxValue)
        {
            int[] array = new int[n];
            var random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, maxValue);
            }
            return array;
        }
    }
}
