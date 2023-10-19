using System;
using System.Collections.Generic;
using System.Text;

using NonlinearLibrary;

namespace NM3_2021.Functions
{
    class TrigonometricFunction : IC2Function
    {
        double a, b, c, d;

        // f(x) = a * cos( b * x ) + c * x + d

        public TrigonometricFunction()
        {
            a = 4.0;
            b = 1.0;
            c = 1.0;
            d = -1.0;
        }

        public TrigonometricFunction(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public double f(double x)
        {
            return a * Math.Cos(b * x) + c * x + d;
        }

        public double f1(double x)
        {
            return -1.0 * a * b * Math.Sin(b * x) + c;
        }

        public double f2(double x)
        {
            return -1.0 * a * b * b * Math.Cos(b * x);
        }

        public override string ToString()
        {
            return String.Format("f(x) = {0:F3} * cos( {1:F3} * x ) + {2:F3} * x + {3:F3}", a, b, c, d);
        }
    }

}
