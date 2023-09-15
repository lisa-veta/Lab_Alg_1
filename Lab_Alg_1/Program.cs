using System;
using System.Diagnostics;

namespace Lab_Alg_1
{
    public class Program
    { 
        static int maxValue = 5000;
        static int maxN = 2000;
        public static void Main(string[] args)
        {
            Working();
        }


        public static void Working(st)
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

                    Random random = new Random();
                    task.CocktailShakerSort(CreateVector(n, maxValue));

                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
                results[n - 1] = (double)(sumWorks) / 5.0;

            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines("C:\\Users\\4769003\\OneDrive\\Рабочий стол\\result.csv", fileProcessing.GetValues(results));
        }
        public static void StartTimSort()
        {
            Task1 sort = new Task1();
            var watсh = new Stopwatch();
            double[] results = new double[maxN];
            List<string> result = new List<string>();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double allTimeWork = 0;

                for (int count = 0; count < 5; count++)
                {
                    watсh.Start();
                    sort.TimSort(CreateVector(n, maxValue));
                    watсh.Stop();
                    double time = watсh.Elapsed.TotalSeconds;
                    allTimeWork += time;
                }

                results[n - 1] = (allTimeWork) / 5.0;
                result.Add($"{n.ToString()};{((allTimeWork) / 5.0).ToString("F8")}");

                //Console.WriteLine($"{n} : {((allTimeWork) / 5.0).ToString("F8")}");
            }
            File.WriteAllLines("C:\\Users\\polin\\OneDrive\\Desktop\\result1.csv",result);
        }
        public static void StartRecursivePow()
        {
            Task1 task = new Task1();
            Random rand = new Random();
            int num = 15;
            int stepen = rand.Next(10);
            List<string> results = new List<string>();
            for (int i = 2; i <= num; i++)
            {
                long steps = 0;
                steps = task.RecursivePow(i, stepen);
                results.Add($"{i}^{stepen};{steps}");
                //Console.WriteLine($"{i}^{stepen} : {steps}");
            }
            File.WriteAllLines("C:\\Users\\polin\\OneDrive\\Desktop\\result.csv",results);
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
