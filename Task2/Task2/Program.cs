using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты точек в отдельных строках через пробел");
            Console.WriteLine("Enter - конец ввоода");

            var lines = new List<string>();

            while(true)
            {
                var input = Console.ReadLine();

                if (input == string.Empty) break;
                
                lines.Add(input);
            }

            var points = ParsePoints(lines);

            foreach(var point in points)
                Console.WriteLine($"Точка ({point.X}, {point.Y})");

            Console.ReadKey();
        }

        static List<Point> ParsePoints(List<string> list) => list
            .Select(s => s.Split())
            .Select(p => new Point(int.Parse(p[0]), int.Parse(p[1])))
            .ToList();
    }
}
