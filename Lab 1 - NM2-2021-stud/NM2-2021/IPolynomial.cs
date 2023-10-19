/*
 * Numerical Methods laboratory
 * Ex.2: Calculating value of a function
 * Interface for polynomials
 * Marcin.Rudzki@polsl.pl
 * v.1 (2021-10-13)
 * used VS2019 licence MSDNAA
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace NM2_2021
{
    interface IPolynomial
    {
        bool UseHorner { get; set; }
        double EvaluateAt(double x);
    }
}
