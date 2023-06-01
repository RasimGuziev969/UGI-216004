using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeReflection
{
    [Serializable]
    [Description("Класс для примера рефлексии типов")]  
    public class MyClass : ICloneable
    {
        public static string Remark = "";

        [Description("Пример открытого свойства")]
        public int PublicProperty { get; set; }

        [Description("Пример открытого поля")]
        [Description("Дополнительное описание")]
        public int PublicField;

        [NonSerialized]
        [Description("Ещё один пример открытого поля")]
        public int AnotherPublicField;

        private int privateField;

        public MyClass(int x)
        { 
            privateField = x; 
        }

        public int MyMethod(int x) => x + privateField;

        public object Clone() => MemberwiseClone();  
    }
}
