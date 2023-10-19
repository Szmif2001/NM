/*
 * Numerical Methods laboratory
 * Ex.2: Calculating value of a function
 * Taylor class for implementing function calculation based on its Taylor/Maclaurin series expansion
 * Marcin.Rudzki@polsl.pl
 * v.1 (2021-10-13)
 * used VS2019 licence MSDNAA
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace NM2_2021
{
    class Taylor
    {
        public static double Exp(double x, int terms, double eps)
        {
            double result = 1.0;
            double denom = 1.0;
            for (int i = 1; i <= terms; i++)
            {
                denom *= (double)i; // iterative calculation of factorial instead of using a dedicated function

                double term = Math.Pow(x, i) / denom; // ith term of the series

                //Console.WriteLine("{0} = {1} / {2}", term,  Math.Pow(x, i), denom); // debug...

                if (Math.Abs(term) < eps) break; // sufficient accuracy already obtained

                result += term;
            }
            return result;
        }

        // TODO
        // in a similar manner implement functions as specified by the instructor! (e.g. a Sin() function)
        public static double Sin(double x, int terms, double eps)
        {
            double result = x;
            double denom = 1.0;
            for (int i = 1; i <= terms; i++)
            {
                denom = MyMath.Factorial((2*i)+1);
                double temp = MyMath.Pow(-1, i) * (MyMath.Pow(x, (2*i)+1)/ denom);
                result += temp;
                if (Math.Abs(temp) < eps) break;
            }

            return result;
        }

        public static double Cos(double x, int terms, double eps)
        {
            double result = 1.0;
            double denom = 1.0;
            for (int i = 1; i <= terms; i++)
            {
                denom = MyMath.Factorial(2*i);
                double temp = MyMath.Pow(-1, i) * (MyMath.Pow(x, 2*i)/denom);
                result += temp;
                if (Math.Abs(temp) < eps) break;
            }
            return result;
        }
    }
}
