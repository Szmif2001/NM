using System;
using System.Collections.Generic;
using System.Text;

using NonlinearLibrary;

namespace NM3_2021.Functions
{
    class LinearFunction : IC2Function
    {
        double a, b;

        // f(x) = a * x + b 

        public LinearFunction()
        {
            a = -2.0;
            b = 5.0;
        }
        public LinearFunction(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public double f(double x)
        {
            return a * x + b;
        }
        public double f1(double x)
        {
            return a;
        }
        public double f2(double x)
        {
            return 0.0;
        }
        public override string ToString()
        {
            return String.Format("f(x) = {0:F3} * x + {1:F3}", a, b);
        }

    }
}
