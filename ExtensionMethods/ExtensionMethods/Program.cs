using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string s = Console.ReadLine();

            Console.WriteLine($"Количество слов: {s.CountWords()}");

            var rnd = new Random();

            for(var i = 0; i < 100; i++)
            {
                Console.Write($"{rnd.NextDouble():F2} ");
            }

            Console.WriteLine();

            for (var i = 0; i < 100; i++)
            {
                Console.Write($"{rnd.FlatDistribution(-1, 2):F2} ");
            }

            Console.WriteLine();

            for (var i = 0; i < 100; i++)
            {
                Console.Write($"{rnd.ExpDistribution(0.3):F2} ");
            }

            Console.ReadKey();
        }
    }
}
