using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    class Fraction
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
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", numerator, denominator);
        }

        public Fraction ParseFraction(string fraction)
        {
            numerator = int.Parse(fraction.Split(new char[] { '/', ' ' })[0]);
            denominator = int.Parse(fraction.Split(new char[] { '/', ' ' })[1]);

            return new Fraction(numerator, denominator);
        }
    }
}
