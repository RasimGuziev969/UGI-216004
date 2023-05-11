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
            var words = text
                .SelectMany(s => s.Split(new char[] {' ', '.', ',', ';', '!', '?', ':', '«', '»', '—', '–'},
                    StringSplitOptions.RemoveEmptyEntries))
                .Where(w => char.IsLetter(w[0]))
                .Select(w => w.ToLower())                
                .Distinct()
                .OrderBy(w => w)
                .ToList();

            //PrintWords(words);

            //Task 6
            words = words
                .OrderBy(w => w.Length)
                .ThenBy(w => w)
                .ToList();

            //Task 7 с упорядочением
            //Console.WriteLine();
            //Console.WriteLine(words
            //    .OrderByDescending(w => w.Length)
            //    .ThenBy(w => w)
            //    .FirstOrDefault());

            //Task 7 без упорядочения
            Console.WriteLine(words
                .Select(w => (-w.Length, w))
                .Min()
                .Item2
                );


            //PrintWords(words);

            Console.ReadKey();
        }

        static void PrintWords(IEnumerable<string> words)
        {
            foreach( var word in words)
                Console.WriteLine(word);
        }

    }
}
