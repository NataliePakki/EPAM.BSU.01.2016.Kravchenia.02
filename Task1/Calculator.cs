using System;

namespace Task1
{
    public static class Calculator
    {
        public static double RootNewtonMethod(int number, int n, double eps)
        {
            if (number < 0)
                throw new ArgumentException("Number must not be negative.", "number");
            if (n <= 0)
                throw new ArgumentException("n must be positive", "n");
            double xk1 = (double)number / n;
            double xk;
            do
            {
                xk = xk1;
                xk1 = ((n - 1) * xk + number / Math.Pow(xk, n - 1)) / n;
            } while (Math.Abs(xk - xk1) > eps);
            return xk1;
        }
    }
}
