using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionsLib
{
    public struct Fraction
    {
        public int Numerator { get; set; }

        int denominator;
        public int Denominator
        {
            get { return denominator; }

            set
            {
                if(value > 0)
                    denominator = value;
                else
                    throw new ArgumentException("Знаменатель должен быть положительным");
            }
        }

        public Fraction(int numerator, int denominator) : this()
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object obj)
        {
            if(obj is Fraction myFraction)
                return Numerator * myFraction.Denominator == Denominator * myFraction.Numerator;
            
            throw new ArgumentException();
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(
                a.Numerator * b.Denominator + a.Denominator * b.Numerator,
                a.Denominator * b.Denominator);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
