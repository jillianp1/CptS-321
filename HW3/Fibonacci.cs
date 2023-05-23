// <copyright file="Fibonacci.cs" company="Jillian Plahn 11713440">
// Copyright (c) Jillian Plahn. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    /// <summary>
    /// Fibonacci class with methods to find fibonacci and override methods.
    /// </summary>
    public partial class FibonacciTextReader : System.IO.TextReader
    {
        /// <summary>
        /// num Lines is the max number of lines..
        /// </summary>
        private int numLines;

        /// <summary>
        /// Current is a variable used as a counter.
        /// </summary>
        private int current = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="maxLines">
        /// maxLine parameter gives the max amount of lines to print.
        /// </param>
        public FibonacciTextReader(int maxLines)
        {
            this.numLines = maxLines;
        }

        /// <summary>
        /// Will return fibonacci number at given index
        /// Adapted from https://www.geeksforgeeks.org/program-for-nth-fibonacci-number/.
        /// </summary>
        /// <param name = "n">
        /// n is an index and tells the method what fibonacci number to find.
        /// </param>
        /// <returns>
        /// Returns fibonacci number.
        /// </returns>
        public static BigInteger GetFibonacci(int n)
        {
            BigInteger a = 0, b = 1, c;
            if (n == 1)
            {
                return a;
            }
           else
           {
                for (int i = 3; i <= n; i++)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
           }

            return b;
        }

        /// <summary>
        /// Override the ReadLine method. Return null after the nth call.
        /// </summary>
        /// <returns>
        /// Fibonnaci number of current converted to a string.
        /// </returns>
        public override string ReadLine()
        {
            return FibonacciTextReader.GetFibonacci(this.current).ToString();
        }

        /// <summary>
        /// Method to override read to end method because I used it in my generic load function.
        /// This will get the fibonacci sequence through a loop and keep appending to output string.
        /// https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?redirectedfrom=MSDN&view=net-7.0.
        /// </summary>
        /// <returns>
        /// output string of fibonacci numbers.
        /// </returns>
        public override string ReadToEnd()
        {
            // Create StringBuilder to hold the result
            StringBuilder output = new StringBuilder();

            // Get the fibonacci numbers to max line and append them all
            for (int i = 1; i <= this.numLines; i++)
            {
                if (this.current <= this.numLines)
                {
                    output.Append(i + ": " + this.ReadLine() + "\r\n");
                }
                else
                {
                    return null;
                }

                this.current++;
            }

            // Return the appended numbers and convert to string
            return output.ToString();
        }
    }
}
