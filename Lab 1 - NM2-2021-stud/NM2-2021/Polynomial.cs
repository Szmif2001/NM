/*
 * Numerical Methods laboratory
 * Ex.2: Calculating value of a function
 * Polynomial class - requires implementation of EvaluateDirect() and EvaluateHorner() methods
 * Marcin.Rudzki@polsl.pl
 * v.1 (2021-10-13)
 * used VS2019 licence MSDNAA
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace NM2_2021
{
    class Polynomial : IPolynomial
    {
        double[] An; // coefficient array, index corresponds to the power of the indeterminate (x)

        public bool UseHorner { get; set; } // switch selecting the method of evaluating a polynomial

        public Polynomial(double[] coefficents)
        {
            this.An = (double[])coefficents.Clone(); // shallow copy
            this.UseHorner = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Wn(x) = ");
            // prepare the string representation in order of decreasing powers 
            for (int i = An.Length - 1; i >= 0; i--)
            {
                sb.AppendFormat("({0} * x^{1})", An[i], i);
                if (i > 0) sb.Append(" + ");
            }
            // this representation is not the most optimal but should be readable
            return sb.ToString();
        }

        public double EvaluateAt(double x)
        {
            if (this.UseHorner == true)
            {
                return Polynomial.EvaluateHorner(this, x);
            }
            else
            {
                return Polynomial.EvaluateDirect(this, x);
            }
        }

        // TODO: fill-in those two private static methods:
        static double EvaluateDirect(Polynomial p, double x)
        {
            // TODO
            // use MyMath.Mul(), MyMath.Pow() to count the number of multiplications
            double result = 0.0;
            for (int i = 0; i < p.An.Length; i++)
            {
                double y = MyMath.Pow(x, i);
                result += MyMath.Mul(p.An[i], y);
            }
            //throw new NotImplementedException();
            return result;
        }

        static double EvaluateHorner(Polynomial p, double x)
        {
            // TODO
            // use MyMath.Mul() to count the number of multiplications
            double y = 0.0;
            for (int i = p.An.Length - 1; i >= 1 ; i--)
            {
                y += p.An[i];
                y = MyMath.Mul(y, x);
            }
            y += p.An[0];
            //throw new NotImplementedException();
            return y;
        }

        // EXTRA task for those interested in coding:
        // - what other functionalities this class can also implement?
        // - what operations are possible on polynomials? 
        // - maybe some operations should also be enforced by the IPolynomial interface?
        // Try to implement i.e. operators for adding two polynomials.

    }
}
