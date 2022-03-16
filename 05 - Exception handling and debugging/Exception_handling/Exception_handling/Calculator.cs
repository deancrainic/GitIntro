using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_handling
{
    internal class Calculator
    {
        public static double Add(double firstSummand, double secondSummand)
        {
            if (firstSummand < 0 || secondSummand < 0)
                throw new ArithmeticException("At least one of the numbers is negative");

            return firstSummand + secondSummand;
        }

        public static double Substract(double minuend, double subtrahend)
        {
            if (minuend < 0 || subtrahend < 0)
                throw new ArithmeticException("At least one of the numbers is negative");

            if (minuend < subtrahend)
                throw new ArithmeticException("The minuend is smaller then the subtrahend");

            return minuend - subtrahend;
        }

        public static double Multiply(double multiplier, double multiplicand)
        {
            if (multiplier < 0 || multiplicand < 0)
                throw new ArithmeticException("At least one of the numbers is negative");

            return multiplier * multiplicand;
        }

        public static double Divide(double divident, double divisor)
        {
            if (divident < 0 || divisor < 0)
                throw new ArithmeticException("At least one of the numbers is negative");

            if (divisor == 0)
                throw new ArithmeticException("The divisor is equal to 0");

            return divident / divisor;
        }
    }
}
