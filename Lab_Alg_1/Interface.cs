﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Alg_1
{
    public class Interface
    {
        int[] values = new int[] { ImportantData.MinValue, ImportantData.MaxValue, ImportantData.MaxN };
        public void Work()
        {
            WriteSetting();
            ChooseChangeSetting();
            WriteStartAlgorithm();
            ChooseNext();
        }
        private void WriteSetting()
        {
            Console.WriteLine(TextInterface.Heaps["setting"]);  
            for(int i = 0; i < TextInterface.TextSetting.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(TextInterface.TextSetting[i]);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(values[i]);
            }
            WritePath();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void WritePath()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Путь сохранения результата : " );
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ImportantData.Path);
        }

        private void ChooseChangeSetting()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Изменить настройки алгоритма - 1\nИзменить путь сохранения результата - 2\nПродолжить с текущими настройками - 0");
            Console.ForegroundColor = ConsoleColor.White;
            string? answer = Console.ReadLine();
            switch (answer)
            {
                case ("1"):
                    ChangeSetting();
                    break;
                case ("2"):
                    ChangePath(); 
                    break;
                case ("0"):
                    return;
                default:
                    Console.WriteLine("Необходим ваш точный ответ.");
                    ChooseChangeSetting();
                    break;
            }
        }

        private void ChangeSetting()
        {
            Console.Clear();
            Console.WriteLine(TextInterface.Heaps["setting"]);
            int i = 0;
            while(i < TextInterface.TextSetting.Length)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(TextInterface.TextSetting[i]);
                Console.ForegroundColor = ConsoleColor.Green;
                string? answer = Console.ReadLine();
                CheckError.IsInt(answer);
                if (CheckError.Check)
                {
                    values[i] = CheckError.IntResult;
                    i++;
                }
            }
            RewriteImportantData();
            CheckError.IsMinMax(ImportantData.MinValue, ImportantData.MaxValue);
            if(!CheckError.Check)
            {
                ChangeSetting();
            }
            ChooseChangeSetting();
        }

        private void ChangePath()
        {
            Console.Clear();
            Console.WriteLine(TextInterface.Heaps["path"]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Путь сохранения результата :");
            Console.ForegroundColor = ConsoleColor.Green;
            string? answer = Console.ReadLine();
            CheckError.IsRightPath(answer);
            if (CheckError.Check)
                ImportantData.Path = answer;
            else
            {
                Thread.Sleep(500);
                ChangePath();
            }
            ChooseChangeSetting();
        }

        private void RewriteImportantData()
        {
            ImportantData.MinValue = values[0];
            ImportantData.MaxValue = values[1];
            ImportantData.MaxN = values[2];
        }

        private void WriteStartAlgorithm()
        {
            Console.Clear();
            WriteSetting();
            Console.WriteLine(TextInterface.Heaps["algorithm"]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(TextInterface.ListAlgorithms);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void ChooseNext()
        {
            Console.WriteLine(TextInterface.EndListAlgo);
            string? answer = Console.ReadLine();
            switch (answer)
            {
                case ("настройки"):
                    Work();
                    break;
                default:
                    CheckError.IsNumberAlgorithm(answer);
                    if (CheckError.Check)
                    {
                        AlgorithmLauncher launcher = new AlgorithmLauncher();
                        launcher.Start(answer);

                    }
                    else ChooseNext();
                    Work();
                    break;
            }
        }
    }
}
