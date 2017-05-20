using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My_Matix_Filler
{
    class Filler
    {
        int curPosRow = 0;
        int curPosCol = 0;
        /// <summary>
        /// прорисовка слева направо
        /// </summary>
        public void WriteSymbols()
        {
            if (curPosCol == 118)
            {
                curPosCol = 0;
            }
            Random randomNumber = new Random();
            int randColor = randomNumber.Next(15); //получаем случайное число меньше 15
            Console.ForegroundColor = (ConsoleColor)randColor; //красим символы
            for (int j = randomNumber.Next(1, 25); j < 30; j++) //пускаем 1 колонку случайной длины
            {
                //char sym = (char)randomNumber.Next(30, 79); // получаем случайные символы
                Console.SetCursorPosition(curPosCol, curPosRow++); //устанавливаем позицию курсора и сдвиг на 1 вниз
                //Console.Write(sym);
                Console.Write("Parallel");
                Thread.Sleep(2);
            }
            curPosCol++; //передвигаем курсор на 1 колонку правее
            curPosRow = 0; //обнуляем позицию строки
            Console.Clear();

        }
        /// <summary>
        /// прорисовка справа налево
        /// </summary>
        public void WriteSymbolsReverse()
        {
            if (curPosCol == 0)
            {
                curPosCol = 118;
            }
            Random randomNumReverse = new Random();
            int randColor = randomNumReverse.Next(15);
            Console.ForegroundColor = (ConsoleColor)randColor;
            for (int j = randomNumReverse.Next(1, 25); j < 30; j++)
            {
                //char sym = (char)randomNumReverse.Next(30, 79);
                Console.SetCursorPosition(curPosCol, curPosRow++);
                //Console.Write(sym);
                Console.WriteLine("Parallel");
                Thread.Sleep(2);
            }
            curPosCol--; //передвигаем курсор на 1 колонку левее
            curPosRow = 0;
        }
    }
}
