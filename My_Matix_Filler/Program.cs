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
                    //Parallel.Invoke(fill.WriteSymbols, fill2.WriteSymbolsReverse);
                    Parallel.Invoke(new Action(fill.WriteSymbols), new Action (fill2.WriteSymbolsReverse));
                    /*Parallel.Invoke(() => fill.WriteSymbols(),
                                      () => fill2.WriteSymbolsReverse());*/
                }
                //if (threads.Length != threads2.Length) { throw new OwnException("Длины массивов отличаются, что привело к ошибке!"); }
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

