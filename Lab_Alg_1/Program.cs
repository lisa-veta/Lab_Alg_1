using System;
using System.Diagnostics;

namespace Lab_Alg_1
{
    public class Program
    { 
        static int maxValue = 50;
        static int maxN = 2000;

        public delegate void IntsMassivInVoid(int[] vector);
        public delegate double IntsMassivAndIntInDouble(int[] vector, int a);
        public delegate void IntsMassivAndTwoIntInVoid(int[] vector, int a, int b);
        public delegate int TwoIntInInt(int a, int b);
        public delegate int[,] TwoMatrixInMatrix(int[,] a, int[,] b);

        public static void Main(string[] args)
        {
            Start();
        }

        public static void WriteStartText()
        {
            Console.WriteLine("Введите номер нужной задачи для её запуска:\n" +
                "1 Постоянная функция\n" +
                "2 Сумма элементов\n" +
                "3 Произведение элементов\n" +
                "4.1 Метод Горнера\n" +
                "4.2 Прямое вычисление\n" +
                "5 Сортировка Пузырьком\n" +
                "6 Быстрая сортировка\n" +
                "7 DoTimSort\n" +
                "8.1 Простое возведение в степень\n" +
                "8.1s Простое возведение в степень (шаги)\n" +
                "8.2 Рекурсивное возведение в степень\n" +
                "8.2s Рекурсивное возведение в степень (шаги)\n" +
                "8.3 Быстрое возведение в степень\n" +
                "8.3s Быстрое возведение в степень (шаги)\n" +
                "8.4 Классическое быстрое возведение в степень\n" +
                "8.4s Классическое быстрое возведение в степень (шаги)\n" +
                "9 Перемножение матриц\n" +
                "10.1 Пирамидальная сортировка\n" +
                "10.2 Сортировка перемещением\n" +
                "10.3 Гномья сортировка");
        }

        public static void Start()
        {
            Task1 task1 = new Task1();
            Task2 task2 = new Task2();
            Task3 task3 = new Task3();
            WriteStartText();
            string? resultIn = Console.ReadLine();
            switch(resultIn) 
            {
                case ("1"):
                    WorkingForm1(task1.DoConstFunc);
                    break;
                case ("2"):
                    WorkingForm1(task1.DoSumFunc);
                    break;
                case ("3"):
                    WorkingForm1(task1.DoMultiplicationFunc);
                    break;
                case ("4.1"):
                    WorkingForm2(task1.DoMethodGornera);
                    break;
                case ("4.2"):
                    WorkingForm1(task1.DoDirectMethod);
                    break;
                case ("5"):
                    WorkingForm1(task1.DoBubbleSort);
                    break;
                case ("6"):
                    WorkingForm3(task1.DoQuickSort);
                    break;
                case ("7"):
                    WorkingForm1(task1.DoTimSort);
                    break;
                case ("8.1"):
                    WorkingForm4(task1.DoSimplePow);
                    break;
                case ("8.1s"):
                    WorkingWithoutTime1(task1.DoSimplePow);
                    break;
                case ("8.2"):
                    WorkingForm5(task1);
                    break;
                case ("8.2s"):
                    WorkingWithoutTime2(task1);
                    break;
                case ("8.3"):
                    WorkingForm4(task1.DoQuickPow);
                    break;
                case ("8.3s"):
                    WorkingWithoutTime1(task1.DoQuickPow);
                    break;
                case ("8.4"):
                    WorkingForm4(task1.DoClassicQuickPow);
                    break;
                case ("8.4s"):
                    WorkingWithoutTime1(task1.DoClassicQuickPow);
                    break;
                case ("9"):
                    WorkingForm6(task2.DoMultiplicationMatrix);
                    break;
                case ("10.1"):
                    WorkingForm1(task3.DoHeapSort);
                    break;
                case ("10.2"):
                    WorkingForm1(task3.DoCocktailShakerSort);
                    break;
                case ("10.3"):
                    WorkingForm1(task3.DoGnomeSort);
                    break;
                default:
                    Console.WriteLine("Неизвестная команда");
                    break;
            }
        }

        public static void WorkingForm1(IntsMassivInVoid method)
        {
            double[] results  = new double[maxN];
            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double sumWorks = 0;
                
                for (int count = 0; count < 5; count++)
                {
                    watсh.Start();
                    method(CreateVector(n, maxValue));
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

        public static void WorkingForm2(IntsMassivAndIntInDouble method)
        {
            double[] results = new double[maxN];
            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double sumWorks = 0;

                for (int count = 0; count < 5; count++)
                {
                    watсh.Start();
                    var result = method(CreateVector(n, maxValue), 0);
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

        public static void WorkingForm3(IntsMassivAndTwoIntInVoid method)
        {
            double[] results = new double[maxN];
            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                watсh.Reset();
                double sumWorks = 0;

                for (int count = 0; count < 5; count++)
                {
                    watсh.Start();
                    int[] vector = CreateVector(n, maxValue);
                    method(vector, 0, vector.Length-1);
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

        public static void WorkingForm4(TwoIntInInt method)
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
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines("C:\\Users\\4769003\\OneDrive\\Рабочий стол\\result.csv", fileProcessing.GetValues(results));
        }

        public static void WorkingForm5(Task1 task1)
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
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines("C:\\Users\\4769003\\OneDrive\\Рабочий стол\\result.csv", fileProcessing.GetValues(results));
        }

        public static void WorkingForm6(TwoMatrixInMatrix method)
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
                    var result = method(CreateMatrix(n, maxValue), CreateMatrix(n, maxValue));
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


        public static void WorkingWithoutTime1(TwoIntInInt method)
        {
            List<string> results = new List<string>();
            for (int n = 1; n <= maxN; n++)
            {
                int sumWorks = 0;
                Random random = new Random();
                int x = random.Next(1000);
                int countOfSteps = 0;
                for (int count = 0; count < 5; count++)
                {
                    countOfSteps =  method(x, n);
                    sumWorks +=  countOfSteps;
                }
                //results[n - 1] = $"{n};{(double)(sumWorks)/5.0}";
                countOfSteps = sumWorks / 5;
                results.Add($"{x}^{n};{countOfSteps}");
                Console.WriteLine($"{x}^{n} : {(double)(sumWorks) / 5.0}");
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines("C:\\Users\\4769003\\OneDrive\\Рабочий стол\\result.csv", results);
        }

        public static void WorkingWithoutTime2(Task1 task1)
        {
            List<string> results = new List<string>();
            for (int n = 1; n <= maxN; n++)
            {
                int sumWorks = 0;
                Random random = new Random();
                int x = random.Next(1000);
                int countOfSteps = 0;
                for (int count = 0; count < 5; count++)
                {
                    task1.Steps = 0;
                    var result = (int) task1.DoRecursivePow(x, n);
                    countOfSteps = task1.Steps;
                    sumWorks += countOfSteps;
                }
                //results[n - 1] = $"{n};{(double)(sumWorks)/5.0}";
                countOfSteps = sumWorks / 5;
                results.Add($"{x}^{n};{countOfSteps}");
                Console.WriteLine($"{x}^{n} : {(double)(sumWorks) / 5.0}");
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines("C:\\Users\\user\\Desktop\\result.csv", results);
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

        public static int[,] CreateMatrix(int n, int maxValue)
        {
            int[,] matrix = new int[n, n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(40, maxValue);
                }
            }
            return matrix;
        }
    }
}
