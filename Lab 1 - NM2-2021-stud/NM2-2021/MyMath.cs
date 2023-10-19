/* 
 * Numerical Methods laboratory
 * Ex.2: Calculating value of a function
 * MyMath class used for counting the number of multiplications in the process of evaluating some expressions
 * Marcin.Rudzki@polsl.pl
 * v.1 (2021-10-13)
 * used VS2019 licence MSDNAA
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace NM2_2021
{
    class MyMath
    {
        static int mults = 0;
        public static int MultiplicationsDone
        {
            get { return mults; }
            set { mults = value; }
        }

        static bool countMults = false;
        public static bool CountMultiplications
        {
            get { return countMults; }
            set { countMults = value; }
        }

        public static double Mul(double x, double y)
        {
            if (countMults) // used to show cost of calculating polynomial using direct and Horner method
            {
                mults++;
                //System.Threading.Thread.Sleep(100); // to show the performace impact
            }
            return x * y;
        }
        public static double Pow(double x, int y)
        {
            if (y == 0) return 1.0; // x^0 = 1

            if (y < 0)
            {
                x = 1.0 / x;
                y = -y;
            }

            double result = x;

            for (int i = 2; i <= y; i++)
            {
                result = Mul(result, x); // if counting multiplications is required
                // result *= x; // otherwise
            }

            return result;
        }

        public static int Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("Factorial is not defined for negative arguments!");

            int result = 1;
            for (int i = n; i >= 2; i--)
            {
                result = (int)Mul(result, i); // if counting multiplications is required
                // result *= i; // otherwise
            }

            return result;
        }

    }
}
