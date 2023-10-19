using System;
using System.Collections.Generic;
using System.Text;

using NonlinearLibrary;

namespace NM3_2021.Functions
{
    class ExemplaryFunction : IC2Function
    {
        double a = 1.0;
        double b = 2.0;
        double c = 1.0;
        double d = -2.0;

        // f(x) = a * sin( b * x ) + c * x + d

        public double f(double x)
        {
            return a * Math.Sin(b * x) + c * x + d;
        }

        public double f1(double x)
        {
            // y = f'(x) - first derivative of f(x) 
            return a * b * Math.Cos(b * x) + c;
        }
        public double f2(double x)
        {
            // y = f"(x) - second derivative of f(x) 
            return -1.0 * a * b * b * Math.Sin(b * x);
        }
        public override string ToString()
        {
            return String.Format("f(x) = {0:F3} * sin( {1:F3} * x ) + {2:F3} * x + {3:F3}", a, b, c, d);
        }
    }

}
