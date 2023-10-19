using System;
using System.Collections.Generic;
using System.Text;

using NonlinearLibrary;

namespace NM3_2021.Functions
{
    class SquareRootFunction : IC2Function
    {
        double a;

        // f(x) = sqrt(x) + a 

        public SquareRootFunction()
        {
            a = -Math.Sqrt(3.0);
        }

        public SquareRootFunction(double a)
        {
            this.a = a;
        }

        public double f(double x)
        {
            return Math.Sqrt(x) + a;
        }

        public double f1(double x)
        {
            return 1.0 / 2.0 * Math.Pow(x, -1.0 / 2.0);
        }

        public double f2(double x)
        {
            return -1.0 / 4.0 * Math.Pow(x, -3.0 / 2.0);
        }

        public override string ToString()
        {
            return String.Format("f(x) = sqrt(x) + {0:F3}", a);
        }
    }

}
