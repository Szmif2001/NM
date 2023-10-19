using System;
using System.Collections.Generic;
using System.Text;

using NonlinearLibrary;

namespace NM3_2021.Functions
{
    class ConstantFunction : IC2Function
    {
        double a;

        // f(x) = a

        public ConstantFunction() { a = 5.25; }

        public ConstantFunction(double constVal) { a = constVal; }

        public double f(double x)
        {
            return a;
        }

        public double f1(double x)
        {
            return 0.0;
        }

        public double f2(double x)
        {
            return 0.0;
        }

        public override string ToString()
        {
            return String.Format("f(x) = {0:F3}", a);
        }
    }

}
