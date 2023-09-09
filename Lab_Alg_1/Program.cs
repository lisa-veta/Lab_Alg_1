using System;
using System.Diagnostics;

namespace Lab_Alg_1
{
    public class Program
    {
        delegate void WorkingMethod(int[] vector);
        WorkingMethod Wd; 
        int maxValue = 50000;
        int maxN = 100000;
        public static void Main(string[] args)
        {
            new Program().Working();
            //Working();
        }

        public void Working()
        {
            Wd = new SumFunc().Start;
            string[] results = new string[maxN];

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
                results[n - 1] = $"{n};{(double)(sumWorks)}";

                Console.WriteLine($"{n} : {(double)(sumWorks)}");
            }
            File.WriteAllLines("C:\\Users\\user\\Desktop\\result.csv", results);
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
