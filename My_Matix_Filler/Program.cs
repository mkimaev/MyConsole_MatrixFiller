using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace My_Matix_Filler
{
    class Program
    {
        static int curPosRow = 0;
        static int curPosRow2 = 0;
        static int curPosCol = 0;
        static int curPosCol2 = 118;
        static object block = new object();
        static void Main(string[] args)
        {
            try
            { 
                
            Thread[] threads = new Thread[60];
            Thread[] threads2 = new Thread[60];
            if (threads.Length != threads2.Length) { throw new OwnException("Длины массивов отличаются, что привело к ошибке!"); }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(WriteSymbols)); //инициализация потока c применением делtгата ThreadStart
                threads2[i] = new Thread(() => { WriteSymbolsReverse(); }); //инициализация потока c применением лямбды
                threads[i].Start(); //старт
                threads2[i].Start();
                //threads[i].Join();
                threads2[i].Join(); //ожидаем пока поток завершиться
            }
            }
            catch (OwnException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Пример рабочей версии посмотрите тут {0}", ex.HelpLink);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// прорисовка слева направо
        /// </summary>
        static void WriteSymbols()
        {
            //используем приёмы для синхронизацию к разделяемому ресурсу
            lock (block) // Monitor.Enter(block)
            {
                Random randomNumber = new Random();
                int randColor = randomNumber.Next(15); //получаем случайное число меньше 15
                Console.ForegroundColor = (ConsoleColor)randColor; //красим символы
                for (int j = randomNumber.Next(1, 25); j < 30; j++) //пускаем 1 колонку случайной длины
                {
                    char sym = (char)randomNumber.Next(30, 79); // получаем случайные символы
                    Console.SetCursorPosition(curPosCol, curPosRow++); //устанавливаем позицию курсора и сдвиг на 1 вниз
                    Console.Write(sym);
                    Thread.Sleep(2);
                }
                curPosCol++; //передвигаем курсор на 1 колонку правее
                curPosRow = 0; //обнуляем позицию строки
            } // Monitor.Exit(block)
        }
        /// <summary>
        /// прорисовка справа налево
        /// </summary>
        static void WriteSymbolsReverse()
        {
            //lock (block)
            {
                Random randomNumReverse = new Random();
                int randColor = randomNumReverse.Next(15);
                Console.ForegroundColor = (ConsoleColor)randColor;
                for (int j = randomNumReverse.Next(1, 25); j < 30; j++)
                {
                    char sym = (char)randomNumReverse.Next(30, 79);
                    Console.SetCursorPosition(curPosCol2, curPosRow2++);
                    Console.Write(sym);
                    Thread.Sleep(2);
                }
                curPosCol2--; //передвигаем курсор на 1 колонку левее
                curPosRow2 = 0;
            }
        }
    }
}

