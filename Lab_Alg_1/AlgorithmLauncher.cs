using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_Alg_1.Program;

namespace Lab_Alg_1
{
    public class AlgorithmLauncher
    {
        public delegate void IntsMassivInVoid(int[] vector);
        public delegate double IntsMassivAndIntInDouble(int[] vector, int a);
        public delegate void IntsMassivAndTwoIntInVoid(int[] vector, int a, int b);
        public delegate int TwoIntInInt(int a, int b);
        public delegate int[,] TwoMatrixInMatrix(int[,] a, int[,] b);

        static int maxValue;
        static int minValue;
        static int maxN;
        static int[] array;
        static int step;

        public AlgorithmLauncher()
        {
            maxValue = ImportantData.MaxValue;
            minValue = ImportantData.MinValue;
            maxN = ImportantData.MaxN;
            step = ImportantData.Step;
        }

        public void Start(string resultIn)
        {
            Task1 task1 = new Task1();
            Task2 task2 = new Task2();
            Task3 task3 = new Task3();
            CreateArray();
            switch (resultIn)
            {
                case ("1"):
                    WorkingForm1(task1.DoConstFunc, "\\ConstFunc");
                    break;
                case ("2"):
                    WorkingForm1(task1.DoSumFunc, "\\SumFunc");
                    break;
                case ("3"):
                    WorkingForm1(task1.DoMultiplicationFunc, "\\MultiFunc");
                    break;
                case ("4.1"):
                    WorkingForm2(task1.DoMethodGornera, "\\MethodGornera");
                    break;
                case ("4.2"):
                    WorkingForm1(task1.DoDirectMethod, "\\DirectMethod");
                    break;
                case ("5"):
                    WorkingForm1(task1.DoBubbleSort, "\\BubbleSort");
                    break;
                case ("6"):
                    WorkingForm3(task1.DoQuickSort, "\\QuickSort");
                    break;
                case ("7"):
                    WorkingForm1(task1.DoTimSort, "\\TimSort");
                    break;
                //case ("8.1"):
                //    WorkingForm4(task1.DoSimplePow, "\\SimplePow");
                //    break;
                case ("8.1"):
                    WorkingWithoutTime1(task1.DoSimplePow, "\\SimplePowSteps");
                    break;
                //case ("8.2"):
                //    WorkingForm5(task1, "\\RecursivePow");
                //    break;
                case ("8.2"):
                    WorkingWithoutTime2(task1, "\\RecursivePowSteps");
                    break;
                //case ("8.3"):
                //    WorkingForm4(task1.DoQuickPow, "\\QuickPow");
                //    break;
                case ("8.3"):
                    WorkingWithoutTime1(task1.DoQuickPow, "\\QuickPowSteps");
                    break;
                //case ("8.4"):
                //    WorkingForm4(task1.DoClassicQuickPow, "\\ClassicQuickPow");
                //    break;
                case ("8.4"):
                    WorkingWithoutTime1(task1.DoClassicQuickPow, "\\ClassicQuickPowSteps");
                    break;
                case ("9"):
                    WorkingForm6(task2.DoMultiplicationMatrix, "\\MultiplicationMatrix");
                    break;
                case ("10.1"):
                    WorkingForm1(task3.DoHeapSort, "\\HeapSort");
                    break;
                case ("10.2"):
                    WorkingForm1(task3.DoCocktailShakerSort, "\\CocktailShakerSort");
                    break;
                case ("10.3"):
                    WorkingForm1(task3.DoGnomeSort, "\\GnomeSort");
                    break;
                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }
        }

        public static void WorkingForm1(IntsMassivInVoid method, string nameFile)
        {
            double[] results = new double[maxN];
            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double sumWorks = 0;

                for (int count = 0; count < 5; count++)
                {
                    int[] vector = CreateVector(n);
                    watсh.Start();
                    method(vector);
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
                results[n - 1] = (double)(sumWorks) / 5.0;
                IntermediateSave interSave = new IntermediateSave();
                interSave.ExtraSaving(n, results, nameFile, step);
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(ImportantData.Path + nameFile + ".csv", fileProcessing.GetValues(results, step));
        }

        public static void WorkingForm2(IntsMassivAndIntInDouble method, string nameFile)
        {
            double[] results = new double[maxN];
            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double sumWorks = 0;

                for (int count = 0; count < 5; count++)
                {
                    int[] vector = CreateVector(n);
                    watсh.Start();
                    var result = method(vector, 0);
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
                results[n - 1] = (double)(sumWorks) / 5.0;
                IntermediateSave interSave = new IntermediateSave();
                interSave.ExtraSaving(n, results, nameFile, step);
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(ImportantData.Path + nameFile + ".csv", fileProcessing.GetValues(results, step));
        }

        public static void WorkingForm3(IntsMassivAndTwoIntInVoid method, string nameFile)
        {
            double[] results = new double[maxN];
            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double sumWorks = 0;

                for (int count = 0; count < 5; count++)
                {
                    int[] vector = CreateVector(n);
                    watсh.Start();
                    method(vector, 0, vector.Length - 1);
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
                results[n - 1] = (double)(sumWorks) / 5.0;
                IntermediateSave interSave = new IntermediateSave();
                interSave.ExtraSaving(n, results, nameFile, step);
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(ImportantData.Path + nameFile + ".csv", fileProcessing.GetValues(results, step));
        }

        public static void WorkingForm4(TwoIntInInt method, string nameFile)
        {
            double[] results = new double[maxN];
            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double sumWorks = 0;
                Random random = new Random();
                int x = random.Next(1000);
                for (int count = 0; count < 5; count++)
                {
                    watсh.Start();
                    var result = method(x, n);
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
                results[n - 1] = (double)(sumWorks) / 5.0;
                IntermediateSave interSave = new IntermediateSave();
                interSave.ExtraSaving(n, results, nameFile, step);
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(ImportantData.Path + nameFile + ".csv", fileProcessing.GetValues(results, step));
        }

        public static void WorkingForm5(Task1 task1, string nameFile)
        {
            double[] results = new double[maxN];
            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double sumWorks = 0;
                Random random = new Random();
                int x = random.Next(1000);
                for (int count = 0; count < 5; count++)
                {
                    watсh.Start();
                    var result = task1.DoRecursivePow(x, n);
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
                results[n - 1] = (double)(sumWorks) / 5.0;
                IntermediateSave interSave = new IntermediateSave();
                interSave.ExtraSaving(n, results, nameFile, step);
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(ImportantData.Path + nameFile + ".csv", fileProcessing.GetValues(results, step));
        }

        public static void WorkingForm6(TwoMatrixInMatrix method, string nameFile)
        {
            double[] results = new double[maxN];
            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double sumWorks = 0;
                Random random = new Random();
                int x = random.Next(1000);
                for (int count = 0; count < 5; count++)
                {
                    watсh.Start();
                    var result = method(CreateMatrix(n), CreateMatrix(n));
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
                results[n - 1] = (double)(sumWorks) / 5.0;
                IntermediateSave interSave = new IntermediateSave();
                interSave.ExtraSaving(n, results, nameFile, step);
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(ImportantData.Path + nameFile + ".csv", fileProcessing.GetValues(results, step));
        }


        public static void WorkingWithoutTime1(TwoIntInInt method, string nameFile)
        {
            List<string> results = new List<string>();
            Random random = new Random();
            int x = 1;
            for (int n = 1; n <= maxN;)
            {
                int sumWorks = 0;
                
                x += random.Next(100);
                int countOfSteps = 0;
                for (int count = 0; count < 5; count++)
                {
                    countOfSteps = method(x, n);
                    sumWorks += countOfSteps;
                }
                //results[n - 1] = $"{n};{(double)(sumWorks)/5.0}";
                countOfSteps = sumWorks / 5;
                results.Add($"{x}^{n};{countOfSteps}");
                Console.WriteLine($"{x}^{n} : {(double)(sumWorks) / 5.0}");
                IntermediateSave interSave = new IntermediateSave();
                interSave.ExtraSaving(n, results, nameFile);
                n += random.Next(100);
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(ImportantData.Path + nameFile + ".csv", results);
        }

        public static void WorkingWithoutTime2(Task1 task1, string nameFile)
        {
            List<string> results = new List<string>();
            int x = 1;
            for (int n = 1; n <= maxN; n++)
            {
                int sumWorks = 0;
                Random random = new Random();
                x += random.Next(1000);
                int countOfSteps = 0;
                for (int count = 0; count < 5; count++)
                {
                    task1.Steps = 0;
                    var result = (int)task1.DoRecursivePow(x, n);
                    countOfSteps = task1.Steps;
                    sumWorks += countOfSteps;
                }
                //results[n - 1] = $"{n};{(double)(sumWorks)/5.0}";
                countOfSteps = sumWorks / 5;
                results.Add($"{x}^{n};{countOfSteps}");
                Console.WriteLine($"{x}^{n} : {(double)(sumWorks) / 5.0}");
                IntermediateSave interSave = new IntermediateSave();
                interSave.ExtraSaving(n, results, nameFile);
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(ImportantData.Path + nameFile + ".csv", results);
        }

        //public static int[] CreateVector(int n)
        //{
        //    int[] array = new int[n];
        //    var random = new Random();
        //    for (int i = 0; i < n; i++)
        //    {
        //        array[i] = random.Next(minValue, maxValue);
        //    }
        //    return array;
        //}

        public static int[] CreateArray()
        {
            array = new int[maxN];
            var random = new Random();
            for (int i = 0; i < maxN; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }
            return array;
        }

        public static int[] CreateVector(int n)
        {
            int[] newArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }

        public static int[,] CreateMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue);
                }
            }
            return matrix;
        }
    }
}
