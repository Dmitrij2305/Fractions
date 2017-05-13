using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    public class Fraction
    {
        private int numerator;
        private int denominator;

        public int Numerator
        {
            get { return numerator; }
        }

        public int Denominator
        {
            get { return denominator; }
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator > 0)
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
            else if (denominator < 0)
            {
                this.numerator = -numerator;
                this.denominator = -denominator;
            }
            else 
            {
                throw new ArgumentException("Denominator must not be zero", "denominator");
            }

            reduce();
        }

        private void reduce()
        {
            int divisor = gcm(Math.Abs(numerator), denominator);

            numerator /= divisor;
            denominator /= divisor;
        }

        private int gcm(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a + b;
        }

        public override string ToString()
        {
            if (denominator == 1)
                return numerator.ToString();

            if (numerator == 0)
                return "0";

            return String.Format("{0}/{1}", numerator, denominator);
        }

        public static Fraction Parse(string fraction)
        {
            string[] data = fraction.Split('/');

            data[0] = data[0].Replace(" ", string.Empty);

            int numerator = int.Parse(data[0]);
            int denominator = int.Parse(data[1]);

            return new Fraction(numerator, denominator);
        }

        public double ConvertFromFractionToDouble()
        {
            return (double)numerator / (double)denominator;
        }

        public static Fraction ConvertFromDoubleToFraction(double x)
        {
            if (x == 0)
                return new Fraction(0, 1);

            int digitsAfterPointCount = getDigitsAfterPointCount(x);
            int denominator = 1;
            while (digitsAfterPointCount != 0)
            {
                denominator *= 10;
                digitsAfterPointCount--;
            }
            int numerator = (int)(x * denominator);
            Fraction fraction = new Fraction(numerator, denominator);
            fraction.reduce();

            return fraction;
        }

        private static int getDigitsAfterPointCount(double x)
        {
            int digitsAfterPointCount = 0;

            while (x % 1 != 0)
            {
                digitsAfterPointCount++;
                x *= 10;
            }

            return digitsAfterPointCount;
        }
    }
}
