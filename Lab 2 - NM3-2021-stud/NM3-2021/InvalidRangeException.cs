/*
 * Numerical Methods laboratory
 * Ex.3: Approximate solving of nonlinear equations
 * InvalidRangeException class - used to indicate that the insulation interval is improper.
 * Marcin.Rudzki@polsl.pl
 * v.1 (2021-10-20)
 * used VS2019 licence MSDNAA
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace NM3_2021
{
    public class InvalidRangeException : Exception
    {
        public InvalidRangeException() { }
        public InvalidRangeException(string message) : base(message) { }
        public InvalidRangeException(string message, Exception inner) : base(message, inner) { }
        protected InvalidRangeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
