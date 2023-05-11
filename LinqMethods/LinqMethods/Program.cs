using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMethods
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                11, 12, 13, 14, 15, 16, 17, 18, 19, 20};

            PrintSequence(numbers);
            PrintSequence("Hello world");

            PrintSequence(numbers.Where(x => x % 2 == 0));

            var list = new List<int>();
            foreach (var number in numbers) 
                if(number % 2 == 0)
                    list.Add(number);
            PrintSequence(list);

            //напечатать кубы четных чисел массива numbers
            PrintSequence(numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * x * x)
                );

            var john = new Person("John", "Smith", 23);

            var people = new List<Person> {
                john,
                new Person("Ivan", "Kuznetsov", 22),
                new Person("Kate", "Bush", 18)
            };

            var students = new List<Person>
            {
                john,
                new Person("Peter", "Petrov", 25),
                new Person("Mark", "Petrov", 21),
                new Person("Ann", "Karenina", 30)
            };

            //напечатать имена людей, чей возраст больше 18
            PrintSequence(
                people
                .Where(person => person.Age > 18)
                .Select(person => person.Name)
                );

            //напечатать буквы имен людей, чей возраст больше 18 
            PrintSequence(
                people
                .Where(person => person.Age > 18)
                .Select(person => person.Name.ToLower())
                .SelectMany(x => x)
                );

            //напечатать второй и третий квадраты четных чисел массива numbers
            PrintSequence(numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * x)
                .Skip(1)
                .Take(2)
                );

            PrintSequence(ConcatenateLists(people, students).Select(x => $"{x.Name} {x.Surname}."));

            //напечатать пятый квадрат четных чисел массива numbers
            Console.WriteLine(numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * x)
                .Skip(4)
                .First()
                );

            //напечатать буквы имен людей, чей возраст больше 18, без повторений 
            PrintSequence(
                people
                .Where(person => person.Age > 18)
                .Select(person => person.Name.ToLower())
                .SelectMany(x => x)
                .Distinct()
                );

            var num = new[] { 1, 2, 4, 2, 3, 5, 4, 1, 2, 5, 3, 6 };
            PrintSequence(num.Distinct());

            var stings = new[] { "ab", "aba", "bab", "ab", "bab", "ab" };
            PrintSequence(stings.Distinct());

            //напечатать буквы имен людей, чей возраст больше 18, без повторений
            //в алфавитном порядке
            PrintSequence(
                people
                .Where(person => person.Age > 18)
                .Select(person => person.Name.ToLower())
                .SelectMany(x => x)
                .Distinct()
                .OrderBy(x => x)
                );

            //напечатать списки людей и студентов без повторений в алфавитном порядке
            //(сначала по фамилии, потом по имени

            PrintSequence(ConcatenateLists(people, students)
                .Distinct()
                .OrderBy (x => x.Surname)
                .ThenBy (x => x.Name)
                .Select(x => $"{x.Surname}, {x.Name}."));

            var array = new[] { 2, 8, 17, 4, 7, 11 };

            //Сумма
            Console.WriteLine(array.Sum());

            //Среднее арифметическое
            Console.WriteLine(array.Average());

            //Aggregate
            //Сумма
            Console.WriteLine(array.Aggregate((s,x) => s + x));
            //Произведение
            Console.WriteLine(array.Aggregate(1, (s,x) => s * x));
            //Среднее геометрическое
            Console.WriteLine(array.Aggregate(1, (s, x) => s * x, s => Math.Pow(s, 1.0 / array.Length)));

            Console.ReadKey();
        }

        static void PrintSequence<T>(IEnumerable<T> sequence)
        {
            foreach (T item in sequence)
                Console.Write($"{item.ToString()} ");
            
            Console.WriteLine();
        }

        static T[] ConcatenateLists<T>(List<T> list1, List<T> list2)
        {
            //var result = new List<T>();

            //foreach(var item in list1) 
            //    result.Add(item);

            //foreach(var item in list2)
            //    result.Add(item);

            //return result;

            return new[] { list1, list2 }
                .SelectMany(x => x)
                .ToArray();           
        }
    }
}
