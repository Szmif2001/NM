/*
 * Numerical Methods laboratory
 * Ex.3: Approximate solving of nonlinear equations
 * NonLinearEqnSolver class - requires implementation of Bisection(), Falsi(), Secant() and Tangent().
 * Marcin.Rudzki@polsl.pl
 * v.1 (2021-10-20)
 * used VS2019 licence MSDNAA
 */
using System;
using System.Collections.Generic;
using System.Text;

using NonlinearLibrary;

namespace NM3_2021
{
    class NonLinearEqnSolver : INonLinearEqnSolver
    {
        static readonly int maxIter = 1025;

        public SolvingMethod Method { get; set; }

        public double Solve(IC2Function function, double a, double b, double eps, out int iterations)
        {
            switch (Method)
            {
                case SolvingMethod.Bisection:
                    return Bisection(function, a, b, eps, out iterations);
                case SolvingMethod.Falsi:
                    return Falsi(function, a, b, eps, out iterations);
                case SolvingMethod.Secant:
                    return Secant(function, a, b, eps, out iterations);
                case SolvingMethod.Tangent:
                    return Tangent(function, a, b, eps, out iterations);
                default:
                    throw new ArgumentException("Unknown solving method!");
            }
        }

        private static double Bisection(IC2Function function, double a, double b, double eps, out int iterations)
        {
            //throw new NotImplementedException();
            iterations = 0;
            double c = double.NaN;
            if (function.f(a) * function.f(b) > 0.0)
                throw new Exception("Wrong Insulation interval ");
            do
            {
                if (function.f(a) * function.f(b) < 0.0)
                {
                    // inside a, b there is a root
                    c = (a + b) / 2;
                    iterations++;
                }
                if (function.f(a) * function.f(c) < 0.0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
            }
            while ((iterations < maxIter) && (Math.Abs(function.f(c)) > eps));

            return c;
        }

        private static double Falsi(IC2Function function, double a, double b, double eps, out int iterations)
        {
            //throw new NotImplementedException();
            iterations = 0;
            double c = double.NaN;
            if (function.f(a) * function.f(b) > 0.0)
                throw new Exception("Wrong Insulation interval ");
            do
            {
                c = ((a*function.f(b)) - (b*function.f(a)))/(function.f(b) - function.f(a));
                iterations++;
                if (function.f(a) * function.f(c) < 0.0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }
            }
            while ((iterations < maxIter) && (Math.Abs(function.f(c)) > eps));
            return c;
        }

        private static double Secant(IC2Function function, double a, double b, double eps, out int iterations)
        {
            //throw new NotImplementedException();
            iterations = 0;
            double c = double.NaN;
            if (function.f(a) * function.f(b) > 0.0)
                throw new Exception("Wrong Insulation interval ");
            if (function.f(a) * function.f(b) < 0.0)
            {
                do
                {
                    c = ((a * function.f(b)) - (b * function.f(a))) / (function.f(b) - function.f(a));
                    iterations++;
                    a = b;
                    b = c;
                }
                while (iterations < maxIter && (Math.Abs(function.f(c)) > eps));
            }
            return c;
        }

        private static double Tangent(IC2Function function, double a, double b, double eps, out int iterations)
        {
            //throw new NotImplementedException();
            iterations = 0;
            double c = double.NaN;
            if (function.f(a) * function.f(b) > 0.0)
                throw new Exception("Wrong Insulation interval ");
            do
            {
                iterations++;
                if (function.f(a) * function.f2(a) > 0)
                {
                    c = a - (function.f(a) / function.f1(a));
                    a = c;
                }
                if (function.f(b) * function.f2(b) > 0)
                {
                    c = b - (function.f(b) / function.f1(b));
                    b = c;
                }
            }
            while (iterations < maxIter && (Math.Abs(function.f(c)) > eps));
            return c;
        }

    }

}
