using System;
using System.Collections.Generic;
using System.Text;

using NonlinearLibrary;

namespace NM3_2021.Functions
{
    class ExponentialFunction : IC2Function
    {
        // f(x) = a * exp( b * x ) + c * x^2 + d
        double a, b, c, d;

    public ExponentialFunction()
    {
        a = 1.0;
        b = 0.5;
        c = -1.0;
        d = 1.0;
    }

    public ExponentialFunction(double a, double b, double c, double d)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
    }

    public double f(double x)
    {
        return a * Math.Exp(b * x) + c * x * x + d;
    }

    public double f1(double x)
    {
        return a * b * Math.Exp(b * x) + 2.0 * c * x;
    }

    public double f2(double x)
    {
        return a * b * b * Math.Exp(b * x) + 2.0 * c;
    }

    public override string ToString()
    {
        return String.Format("f(x) = {0:F3} * exp( {1:F3} * x ) + {2:F3} * x^2 + {3:F3}", a, b, c, d);
    }
}

}
