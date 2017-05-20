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
            if (threads.Length != threads2.Length) { throw new OwnException("����� �������� ����������, ��� ������� � ������!"); }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(WriteSymbols)); //������������� ������ c ����������� ���t���� ThreadStart
                threads2[i] = new Thread(() => { WriteSymbolsReverse(); }); //������������� ������ c ����������� ������
                threads[i].Start(); //�����
                threads2[i].Start();
                //threads[i].Join();
                threads2[i].Join(); //������� ���� ����� �����������
            }
            }
            catch (OwnException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex.Message);
                Console.WriteLine("������ ������� ������ ���������� ��� {0}", ex.HelpLink);
            }
            Console.ReadLine();
        }
        /// <summary>
        /// ���������� ����� �������
        /// </summary>
        static void WriteSymbols()
        {
            //���������� ����� ��� ������������� � ������������ �������
            lock (block) // Monitor.Enter(block)
            {
                Random randomNumber = new Random();
                int randColor = randomNumber.Next(15); //�������� ��������� ����� ������ 15
                Console.ForegroundColor = (ConsoleColor)randColor; //������ �������
                for (int j = randomNumber.Next(1, 25); j < 30; j++) //������� 1 ������� ��������� �����
                {
                    char sym = (char)randomNumber.Next(30, 79); // �������� ��������� �������
                    Console.SetCursorPosition(curPosCol, curPosRow++); //������������� ������� ������� � ����� �� 1 ����
                    Console.Write(sym);
                    Thread.Sleep(2);
                }
                curPosCol++; //����������� ������ �� 1 ������� ������
                curPosRow = 0; //�������� ������� ������
            } // Monitor.Exit(block)
        }
        /// <summary>
        /// ���������� ������ ������
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
                curPosCol2--; //����������� ������ �� 1 ������� �����
                curPosRow2 = 0;
            }
        }
    }
}

