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
            Working();
        }


        public static void ChooseAlg()
        {
            while (true)
            {
                Console.WriteLine("Выберите алгоритм:" +
                "\n1)" +
                "\n2)" +
                "\n3)" +
                "\n4)" +
                "\n5)" +
                "\n6)" +
                "\n7)" +
                "\n8.1)" +
                "\n8.2)" +
                "\n8.3)" +
                "\n8.4)" +
                "\n9)" +
                "\n10)" +
                "\n11)" +
                "\n12)");
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        Working("DoConstFunc");
                        break;
                    case "2":
                        SecondChoise();
                        break;
                    case "3":
                        ThirdChoise();
                        break;
                    case "4":
                        FourthChoise();
                        break;
                    default:
                        Console.WriteLine("\nВыберите действие из предложенных\n");
                        break;
                }
            }
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
                    Random random = new Random();
                    task.DoConstFunc(CreateVector(n, maxValue));
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
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
