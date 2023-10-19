using System;
using System.Collections.Generic;
using System.Text;

using NonlinearLibrary;

namespace NM3_2021.Functions
{
    class LogarithmicFunction : IC2Function
    {
        double a, b, c;

        // f(x) = a * x^2 + b * log( x ) + c

        public LogarithmicFunction()
        {
            a = 1.0;
            b = -8.0;
            c = -1.0;
        }

        public LogarithmicFunction(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double f(double x)
        {
            return a * x * x + b * Math.Log(x) + c;
        }

        public double f1(double x)
        {
            return 2.0 * a * x + b / x;
        }

        public double f2(double x)
        {
            return 2.0 * a - b / x / x;
        }

        public override string ToString()
        {
            return String.Format("f(x) = {0:F3} * x^2 + log( x ) + {2:F3}", a, b, c);
        }
    }

}
