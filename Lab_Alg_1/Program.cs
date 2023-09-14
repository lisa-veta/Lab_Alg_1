using System;
using System.Diagnostics;

namespace Lab_Alg_1
{
    public class Program
    { 
        static int maxValue = 3;
        static int maxN = 10000;
        public static void Main(string[] args)
        {
            WorkingWithoutTime();
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
                    Random random = new Random();
                    task.DoConstFunc(CreateVector(n, maxValue));
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.Milliseconds;
                    sumWorks += s;
                    //Console.Write($"   {s} : {sumWorks} ;");
                }
                //results[n - 1] = $"{n};{(double)(sumWorks)/5.0}";
                results[n - 1] = (double)(sumWorks) / 5.0;

                Console.WriteLine($"{n} : {(double)(sumWorks) / 5.0}");
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines("C:\\Users\\4769003\\OneDrive\\Рабочий стол\\result.csv", fileProcessing.GetValues(results));
        }

        public static void WorkingWithoutTime()
        {
            var task = new Task1();
            //double[] results = new double[maxN];
            List<string> results = new List<string>();
            for (int n = 1; n <= maxN; n++)
            {
                int sumWorks = 0;
                Random random = new Random();
                int x = random.Next(1000);
                int countOfSteps = 0;
                for (int count = 0; count < 5; count++)
                {
                    countOfSteps = task.DoQuickPow(x, n);
                    sumWorks += countOfSteps;
                    //Console.Write($"   {s} : {sumWorks} ;");
                }
                //results[n - 1] = $"{n};{(double)(sumWorks)/5.0}";
                countOfSteps = sumWorks / 5;
                results.Add($"{x}^{n};{countOfSteps}");
                Console.WriteLine($"{x}^{n} : {(double)(sumWorks) / 5.0}");
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines("C:\\Users\\4769003\\OneDrive\\Рабочий стол\\result.csv", results);
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
