using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public static class CheckError
    {
        public static bool Check = true;
        public static int IntResult; 
        public static void IsInt(string? str)
        {
            Check = int.TryParse(str, out IntResult);
            if (!Check)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Тип данных должен быть Int!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void IsMinMax(int a, int b)
        {
            Check = a < b;
            if (!Check) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Минимальное значение должно быть меньше максимального.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
            }
        }

        public static void IsNumberAlgorithm(string? str)
        {
            Check = TextInterface.NumbersAlgoritms.Contains(str);
            if (!Check)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неизветная команда.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
