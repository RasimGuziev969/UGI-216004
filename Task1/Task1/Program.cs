using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел");
            var n = int.Parse(Console.ReadLine());

            var numbers = new int[n];
            var rnd = new Random();

            for(int i = 0; i < numbers.Length; i++)
                numbers[i] = rnd.Next(10);

            PrintIntArray(numbers);
            PrintIntArray(GetDifferentNumbers(numbers));

            Console.ReadKey();
        }

        static int[] GetDifferentNumbers(int[] numbers) => 
            numbers
            .Distinct()
            .OrderBy(x => x)
            .ToArray();

        static void PrintIntArray(int[] numbers)
        {
            foreach(int i in numbers)
                Console.Write($"{i} ");

            Console.WriteLine();
        }
    }
}
