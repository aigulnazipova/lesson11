using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tymakov14
{
    [DeveloperInfo("Aigul Nazipova")]
    internal class RationalNumber
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю!");
            }

            Numerator = numerator;
            Denominator = denominator;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            RationalNumber other = (RationalNumber)obj;
            return Numerator * other.Denominator == other.Numerator * Denominator;
        }

        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
        }

        public static bool operator !=(RationalNumber a, RationalNumber b)
        {
            return !(a == b);
        }

        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
        }

        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
        }

        public static bool operator <=(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator <= b.Numerator * a.Denominator;
        }

        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            return a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator ++(RationalNumber a)
        {
            return new RationalNumber(a.Numerator + a.Denominator, a.Denominator);
        }

        public static RationalNumber operator --(RationalNumber a)
        {
            return new RationalNumber(a.Numerator - a.Denominator, a.Denominator);
        }

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            return new RationalNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }

            return new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static RationalNumber operator %(RationalNumber a, RationalNumber b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }

            return a - (a / b) * b;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static implicit operator RationalNumber(int value)
        {
            return new RationalNumber(value, 1);
        }

        public static implicit operator RationalNumber(float value)
        {
            int denominator = 1;
            while ((value * denominator) % 1 != 0)
            {
                denominator *= 10;
            }

            return new RationalNumber((int)(value * denominator), denominator);
        }

        public static explicit operator float(RationalNumber value)
        {
            return (float)value.Numerator / value.Denominator;
        }

        public static explicit operator int(RationalNumber value)
        {
            return value.Numerator / value.Denominator;
        }
    }
}
