using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя текстового файла");
            var fileName = Console.ReadLine();

            if(!File.Exists(fileName)) 
            {
                Console.WriteLine("Такого файла нет");
                Console.ReadKey();
                return;
            }

            var text = File.ReadAllLines(fileName);

            //Task 5
            //var words = text
            //    .SelectMany(s => s.Split(new char[] {' ', '.', ',', ';', '!', '?', ':', '«', '»', '—', '–'},
            //        StringSplitOptions.RemoveEmptyEntries))
            //    .Where(w => char.IsLetter(w[0]))
            //    .Select(w => w.ToLower())                
            //    .Distinct()
            //    .OrderBy(w => w)
            //    .ToList();

            //PrintWords(words);

            //Task 6
            //words = words
            //    .OrderBy(w => w.Length)
            //    .ThenBy(w => w)
            //    .ToList();

            //Task 7 с упорядочением
            //Console.WriteLine();
            //Console.WriteLine(words
            //    .OrderByDescending(w => w.Length)
            //    .ThenBy(w => w)
            //    .FirstOrDefault());

            //Task 7 без упорядочения
            //Console.WriteLine(words
            //    .Select(w => (-w.Length, w))
            //    .Min()
            //    .Item2
            //    );


            //PrintWords(words);

            //Task 11
            var words = text
                .SelectMany(s => s.Split(new char[] { ' ', '.', ',', ';', '!', '?', ':', '«', '»', '—', '–' },
                    StringSplitOptions.RemoveEmptyEntries))
                .Where(w => char.IsLetter(w[0]));

            var dict = GetFrequencyDictionary(words);

            foreach (var entry in dict)
                Console.WriteLine($"{entry.Key}: {entry.Value:F4}");

            //Таблица частот в порядке убывания частот
            Console.WriteLine();

            foreach (var elem in dict
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
                Console.WriteLine($"{elem.Key}: {elem.Value:F4}");

            Console.ReadKey();
        }

        static void PrintWords(IEnumerable<string> words)
        {
            foreach( var word in words)
                Console.WriteLine(word);
        }

        static SortedDictionary<char, double> GetFrequencyDictionary(IEnumerable<string> words)
        {
            var n = (double)words.Count();

            return new SortedDictionary<char, double>(
                words
                    .Select(w => w.ToUpper())
                    .GroupBy(w => w[0])
                    .ToDictionary(g => g.Key, g => g.Count() / n)
                );
        }


    }
}
