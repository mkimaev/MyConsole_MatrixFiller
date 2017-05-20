using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My_Matix_Filler
{
    class Program
    {
        static void Main(string[] args)
        {
            Filler fill = new Filler();
            Filler fill2 = new Filler();
            try
            {
                while (true)
                {
                    Task.Factory.StartNew(fill.WriteSymbols).Wait(); // использую фабрику
                    Task.Factory.StartNew(fill2.WriteSymbolsReverse).Wait();
                    Thread.Sleep(2); //пауза, чтобы таски успели корректно запуститься и завершиться
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
    }
}

