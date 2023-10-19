using System;
using System.Collections.Generic;
using System.Text;

using NonlinearLibrary;

namespace NM3_2021.Functions
{
    class QuadraticFunction : IC2Function
    {
        double a, b, c;

        // f(x) = a * x^2 + b * x + c

        public QuadraticFunction()
        {
            a = 1.0;
            b = -2.0;
            c = -3.0;
        }
        public QuadraticFunction(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double f(double x)
        {
            return a * x * x + b * x + c;
        }
        public double f1(double x)
        {
            return 2.0 * a * x + b;
        }
        public double f2(double x)
        {
            return 2.0 * a;
        }
        public override string ToString()
        {
            return String.Format("f(x) = {0:F3} * x^2 + {1:F3} * x + {2:F3}", a, b, c);
        }
    }

}
