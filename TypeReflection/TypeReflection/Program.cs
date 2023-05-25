using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TypeReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(MyClass);
            //var type = Type.GetType("TypeReflection.MyClass");

            PrintTypeInfo(type);

            Console.WriteLine();

            //type = typeof(string);
            //PrintTypeInfo(type);

            var obj = new MyClass(1);
            type = obj.GetType();
            obj.PublicProperty = 5;
            obj.PublicField = -2;
            //obj.PrivateField = 10;
            var result = obj.MyMethod(3);
            Console.WriteLine(result);

            type = typeof(MyClass);
            var obj2 = type
                .GetConstructor(new Type[] { typeof(int) })
                .Invoke(new object[] { 1 });

            type
                .GetProperty("PublicProperty")
                .SetValue(obj2, 5);

            type
                .GetField("PublicField")
                .SetValue(obj2, -2);

            type
                .GetField("privateField",BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue (obj2, 10);

            var val = type
                .GetField("privateField", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(obj2);

            Console.WriteLine(val);

            result = (int)type
                .GetMethod("MyMethod")
                .Invoke(obj2, new object[] { 3 });

            Console.WriteLine(result);

            Console.ReadKey();
        }

        static void PrintTypeInfo(Type type)
        {
            Console.WriteLine("===== Тип ======");
            Console.WriteLine(type.Name);

            Console.WriteLine("===== Поля ======");
            PrintNames(type
                .GetFields()
                .Select(x => x.Name));

            Console.WriteLine("===== Свойства =====");
            PrintNames(type
                .GetProperties()
                .Select(x => x.Name));

            Console.WriteLine("===== Методы =====");
            PrintNames(type
                .GetMethods()
                .Select(x => x.Name));

            Console.WriteLine("===== Интерфейсы ======");
            PrintNames(type
                .GetInterfaces()
                .Select(x => x.Name));

            Console.WriteLine("===== Закрытые поля ======");
            PrintNames(type
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(x => x.Name));

            Console.WriteLine("=====  Статические поля ======");
            PrintNames(type
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(x => x.Name));

            Console.WriteLine("======= Конструкторы ======");
            PrintNames(type
                .GetConstructors()
                .Select(x => x.Name));

            Console.WriteLine("===== Атрибуты =====");
            PrintNames(type
                .GetCustomAttributes()
                .Select(x => x.GetType().Name));

            var descriptions = type.GetCustomAttributes<DescriptionAttribute>();
            if(descriptions.Count() > 0)
            {
                Console.WriteLine("===== Атрибуты Description =====");
                PrintNames(descriptions.Select(x => x.Text));
            }

            Console.WriteLine("===== Атрибуты Description полей ====");
            PrintNames(type
                .GetFields()
                .Select(x => x.GetCustomAttribute<DescriptionAttribute>())
                .Where(x => x != null)
                .Select(x => x.Text));
        }

        static void PrintNames(IEnumerable<string> names)
        {
            foreach (var name in names)
                Console.WriteLine($"-> {name}");
        }
    }
}
