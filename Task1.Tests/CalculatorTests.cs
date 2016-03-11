using System;
using NUnit.Framework;

namespace Task1.Tests
{

    [TestFixture]
    public class CalculatorTests {
        [Test]
        [TestCase(4, 2, Result = 2)]
        [TestCase(27, 3, Result = 3)]
        public double RootNewtonMethodTest(int number, int n) {
            return Calculator.RootNewtonMethod(number, n, 0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        [TestCase(-4, 2)]
        [TestCase(27, 0)]
        [TestCase(27, -3)]
        public void RootNewtonMethodTest_Exception(int number, int n) {
            Assert.AreEqual(Calculator.RootNewtonMethod(number, n, 0), 0);
        }

        [Test]
        [TestCase(13, 4, 1E-10)]
        [TestCase(3, 14, 1E-16)]
        public void RootNewtonMethodTest_Eps(int number, int n, double eps) {
            double resPow = Math.Pow(number, (double) 1/n);
            double resNewton = Calculator.RootNewtonMethod(number, n, eps);

            Assert.IsTrue(Math.Abs(resPow - resNewton) <= eps);
        }
    }
}
