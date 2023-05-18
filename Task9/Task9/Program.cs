using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array1 = new[] { 1, 2, 3, 4, 5 };
            var array2 = new[] { 1, -2, 0, 3, 4, 5 };

            Console.WriteLine("Bсе ли числа положительные? Массив 1: " + IsAllElementsPositive(array1));
            Console.WriteLine("Bсе ли числа положительные? Массив 2: " + IsAllElementsPositive(array2));

            Console.WriteLine("Есть ли ноль? Массив 1: " + IsContainZero(array1));
            Console.WriteLine("Есть ли ноль? Массив 2: " + IsContainZero(array2));

            Console.ReadKey();
        }

        static bool IsAllElementsPositive(int[] numbers) => numbers.All(x => x > 0);

        static bool IsContainZero(int[] numbers) => numbers.Any(x => x == 0);
    }
}
