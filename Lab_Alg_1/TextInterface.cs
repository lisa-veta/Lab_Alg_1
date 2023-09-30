using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public static class TextInterface
    {
        static string[] textSetting = new string[] {"Минимальное значение элемента в массиве данных : ", "Максимальное значение элемента в массиве данных : ", "Максимальная длинна массива данных : ", "Шаг даных в итоговом отчете : " };
        static Dictionary<string, string> heaps = new Dictionary<string, string>() { { "setting", "- Настройки работы алгоритмов -" }, { "algorithm", "- Алгоритмы -" }, { "path", "- Настройка пути сохранения результата -" } };
        static string listAlgorithms = "1 Постоянная функция\n" +
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
                "10.3 Гномья сортировка";
        static string endListAlgo = "Напишите номер алгоритма для запуска. Для смены настроек алгоритма напишите \"настройки\"";
        static string[] numbersAlgoritms = new string[] {"1", "2", "3", "4.1", "4.2", "5", "6", "7", "8.1", "8.1s", "8.2", "8.2s", "8.3", "8.3s", "8.4", "8.4s", "9", "10.1", "10.2", "10.3" };

        public static string[] TextSetting { get { return textSetting; } }
        public static Dictionary<string, string> Heaps { get { return heaps; } }
        public static string ListAlgorithms { get { return listAlgorithms; } }
        public static string EndListAlgo { get { return endListAlgo; } }
        public static string[] NumbersAlgoritms { get { return numbersAlgoritms;} }
    }
}
