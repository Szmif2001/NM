/*
 * Numerical Methods laboratory
 * Ex.3: Approximate solving of nonlinear equations
 * Main program
 * Marcin.Rudzki@polsl.pl
 * v.1 (2021-10-20)
 * used VS2019 licence MSDNAA
 */
using System;

using NonlinearLibrary;
using NM3_2021.Functions;

namespace NM3_2021
{
    class Program
    {
        // Approximate solving of nonlinear equation f(x)=0 within the insulation interval [a,b]         
        // Variables in the Main() method:
        // a, b - bounds of the insulation interval, OTHER VALUES MAY BE SPECIFIED BY THE INSTRUCTOR!
        // a    - lower bound,
        // b    - upper bound.
        // eps  - radius of the vicinity of the root that is considered as precise enough.
        // fun  - function used in the equation, has to implement the IC2Function interface.
        //        Values of constructor arguments may be given by the instructor.
        //        Usage: IC2Function fun = new ConstantFunction(); // or any other class instance from the Functions subfolder.
        //               double y0 = fun.f(x)  - returns the value of the function for the argument given,
        //               double y1 = fun.f1(x) - returns the value of the first derivative of the function for the argument given,
        //               double y2 = fun.f2(x) - returns the value of the second derivative of the function for the argument given.
        //
        // During the laboratory exercise the methods Bisection, Falsi, Secant and Tangent of the NonLinearEqnSolver class are to be implemented.
        // Those functions are then called by the Solve method depending on the selected solving method. See the NonLinearEqnSolver.cs for details.

        static void Main(string[] args)
        {
            // this is to force English UI on non-English OS settings
            var cultureInfo = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo; // only messages
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo; // + number formatting etc


            double a = 2.3;    // lower bound of the insulation interval,
            double b = 3.0;    // upper bound of the insulation interval,
            double eps = 1e-4; // radius of the viccinity of the root that we are satisfied with.
            // Use this value in BOTH stop criteria, i.e. |f(x)|<eps and |x_{k}-x_{k-1}|<eps

            IC2Function fun = new ExemplaryFunction();
            //IC2Function fun = new ExponentialFunction(1, 0.5, -1, 2);
            //IC2Function fun = new LogarithmicFunction(1, -8, -2);
            //IC2Function fun = new TrigonometricFunction(4, 1, 1, -2);
            // ...

            try
            {
                EvaluateAndShow(SolvingMethod.Bisection, fun, a, b, eps);
                //EvaluateAndShow(SolvingMethod.Falsi, fun, a, b, eps);
                //EvaluateAndShow(SolvingMethod.Secant, fun, a, b, eps);
                //EvaluateAndShow(SolvingMethod.Tangent, fun, a, b, eps);

                // If finished - uncomment the next line to validate Your implementations
                NonLinearEqnSolverTester.Test(new NonLinearEqnSolver(), fun, a, b, eps, true);
            }
            catch (InvalidRangeException ex)
            {
                Console.WriteLine("ERROR!\r\n" + ex.Message + "\r\nCheck the interval and/or the analyzed function!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!\r\n" + ex.Message + "\r\nCorrect the code and try again!");
            }
            Console.ReadKey();
        }

        static void EvaluateAndShow(SolvingMethod method, IC2Function fun, double a, double b, double eps)
        {
            INonLinearEqnSolver solver = new NonLinearEqnSolver();
            solver.Method = method;

            Console.WriteLine("Solving the equation \r\n{0} = 0 \r\nusing the {1} method.", fun, solver.Method);

            int iters;
            double x = solver.Solve(fun, a, b, eps, out iters);

            Console.WriteLine("the solution is: x = [{0}] in [{1}] iterations\r\n", x, iters);
            Console.ReadKey();
        }
    }

}
