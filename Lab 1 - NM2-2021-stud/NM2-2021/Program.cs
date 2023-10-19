/*
 * Numerical Methods laboratory
 * Ex.2: Calculating value of a function
 * Main program
 * Marcin.Rudzki@polsl.pl
 * v.1.1 (2021-10-13 divided into smaller methods, fixed const arguments in Tasks 3, 4)
 * used VS2019 licence MSDNAA
 */

using System;

namespace NM2_2021
{
  
    class Program
    {
        // DO NOT MODIFY!
        static void Pause()
        {
            Console.WriteLine("\r\nHit [Any] key...");
            Console.ReadKey(false);
            Console.WriteLine();
        }

        // DO NOT MODIFY!
        static void ShowAndEvaluatePolynomial(IPolynomial poly, double x)
        {
            Console.WriteLine(poly); // display the polynomial (implicitly the ToString() is called)

            MyMath.CountMultiplications = true; // we want to compare the complexity of the two methods
            MyMath.MultiplicationsDone = 0; // reset the multiplication counter

            double result = poly.EvaluateAt(x); // evaluate the polynomial using the selected approach

            MyMath.CountMultiplications = false;

            Console.WriteLine("Wn({0}) = {1}  evaluated using the {2} scheme", x, result, poly.UseHorner ? "Horner" : "Direct");
            Console.WriteLine("It took {0} multiplications.", MyMath.MultiplicationsDone);

            Pause();
        }

        // DO NOT MODIFY!
        static void TasksPolynomial(Polynomial poly, double x)
        {
            // Task 1
            Console.WriteLine("===== TASK 1 =====");
            poly.UseHorner = false; // first - the direct way
            ShowAndEvaluatePolynomial(poly, x);

            // Task 2
            Console.WriteLine("===== TASK 2 =====");
            poly.UseHorner = true; // second - the Horner scheme
            ShowAndEvaluatePolynomial(poly, x);
        }

        // Example how to check and compare Your Taylor series expansion with a "true" method (framework built-in function)
        // DO NOT MODIFY!
        // Use it as a basis for testing the function You have implemented in the Taylor class
        static void TasksTaylorExp(double x) 
        {
            Console.WriteLine("===== TASK 3 demo =====");
            for (int i = 1; i <= 15; i++) // test the calculation using up to 15 terms
            {
                double y3 = Taylor.Exp(x, i, 1e-5); // with sufficient precision
                Console.WriteLine("n={0,3} \t {1,15:F12}", i, y3);
                // what output do You expect? When the eps "kicked in" in the calculations?
            }

            Pause();

            Console.WriteLine("===== TASK 4 demo =====");
            double relErrTh = 0.1 * 0.01; // 1% == 0.01 - required relative error

            double y4true = Math.Exp(x); // library implementation, "true" value
            Console.WriteLine("Library value of e^{0} = {1}", x, y4true);

            Console.WriteLine("{0,25}|{1,25}|{2,25}", "my value", "relative error", "absolute error");
            for (int i = 1; i <= 20; i++) // not more than 20 terms
            {
                double y4appr = Taylor.Exp(x, i, 1e-18);  // Your implementation of the same function, "approximated" value
                double absErr = Math.Abs(y4true - y4appr); // abolute error
                double relErr = absErr / Math.Abs(y4true); // relative error

                Console.WriteLine("{0,25:F20}|{1,25:F20}|{2,25:F20}", y4appr, relErr, absErr);
                if (relErr < relErrTh)
                {
                    Console.WriteLine("{0} terms were sufficient to obtain the required accuracy", i);
                    break;
                }
            }
        }

        static void TaylorSinCos(double x)
        {
            Console.WriteLine("===== SIN =====");
            for (int i = 1; i <= 15; i++)
            {
                double y3 = Taylor.Sin(x, i, 1e-5);
                Console.WriteLine("n={0,3} \t {1,15:F12}", i, y3);
            }

            Pause();


            double relErrThSIN = 0.1 * 0.01;

            double SINTrue = Math.Sin(x);
            Console.WriteLine("Library value of e^{0} = {1}", x, SINTrue);

            Console.WriteLine("{0,25}|{1,25}|{2,25}", "my value", "relative error", "absolute error");
            for (int i = 1; i <= 20; i++)
            {
                double SINappr = Taylor.Sin(x, i, 1e-18);
                double absErrSIN = Math.Abs(SINTrue - SINappr);
                double relErrSIN = absErrSIN / Math.Abs(SINTrue);

                Console.WriteLine("{0,25:F20}|{1,25:F20}|{2,25:F20}", SINappr, relErrSIN, absErrSIN);
                if (relErrSIN < relErrThSIN)
                {
                    Console.WriteLine("{0} terms were sufficient to obtain the required accuracy", i);
                    break;
                }
            }

            Pause();

            Console.WriteLine("===== COS =====");
            for (int i = 1; i <= 15; i++)
            {
                double y3 = Taylor.Cos(x, i, 1e-5);
                Console.WriteLine("n={0,3} \t {1,15:F12}", i, y3);
            }

            double relErrThCOS = 0.1 * 0.01;

            double COSTrue = Math.Cos(x);
            Console.WriteLine("Library value of e^{0} = {1}", x, COSTrue);

            Console.WriteLine("{0,25}|{1,25}|{2,25}", "my value", "relative error", "absolute error");
            for (int i = 1; i <= 20; i++)
            {
                double COSappr = Taylor.Cos(x, i, 1e-18);
                double absErrCOS = Math.Abs(COSTrue - COSappr);
                double relErrCOS = absErrCOS / Math.Abs(COSTrue);

                Console.WriteLine("{0,25:F20}|{1,25:F20}|{2,25:F20}", COSappr, relErrCOS, absErrCOS);
                if (relErrCOS < relErrThCOS)
                {
                    Console.WriteLine("{0} terms were sufficient to obtain the required accuracy", i);
                    break;
                }
            }
        }


        // Main program
        static void Main(string[] args)
        {
            double x4poly = 2.5; // argument (indeterminate value) - change if required!
            //x4poly = 1.0;

            // exemplary ponynomial - change coefficients as told by the instructor
            Polynomial poly = new Polynomial(new double[] { -1, 2, 0, -3.5, 1 }); // caution! the order of coefficients is: a0, a1, a2, ..., an 
            //poly = new Polynomial(new double[] { 1, 2, 3 });


            // Task 1 and 2 - polynomial evaluation in "direct" and Horner scheme
            TasksPolynomial(poly, x4poly);

            // TODO: conclusions? 
            // (*) Write answers to the questions from the instruction.



            // Task 3 and 4 - Taylor series expansion of a function
            double x4taylor = 2.0; // argument of the function

            // An exp(x) is given as an example, basing on it test anlother function that You have implemented in the Taylor class
            TasksTaylorExp(x4taylor);

            Pause();

            TaylorSinCos(x4taylor);

            Pause();



            // TODO: in a similar manner test Your implementation of the function given, e.g. a Sin() function

            // TODO: conclusions? 
            // (*) Write answers to the questions from the instruction.
        }
    }
}
