using System;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class GreatestCommonDivisorTests
    {
        [Test]
        [TestCase(27, 9,Result = 9)]
        [TestCase(27,0, Result = 27)]
        [TestCase(3,15, Result = 3)]
        [TestCase(-3,15, Result = 3)]
        [TestCase(3, 4, Result = 1)]
        public int EuclideanMethodTest(int a, int b) {
            return GreatestCommonDivisor.EuclideanMethod(a, b);
        }

        [Test]
        [TestCase(0, 0)]
        [ExpectedException(typeof(ArgumentException))]
        public void EuclideanMethodTest_Exception(int a, int b)
        {
            Assert.AreEqual(GreatestCommonDivisor.EuclideanMethod(a, b),0);
        }


        [Test]
        [TestCase(3, 15, 45, Result = 3)]
        [TestCase(45, 15, 45, Result = 15)]
        public int EuclideanMethodTest_3arg(int a, int b, int c)
        {
            return GreatestCommonDivisor.EuclideanMethod(a, b, c);
        }
        [Test]
        [TestCase(15,45,3,15, Result = 3)]
        [TestCase(5, 45, 5, 1, 5 , Result = 1)]
        public int EuclideanMethodTest_params(params int[] data)
        {
            return GreatestCommonDivisor.EuclideanMethod(data);
        }
        
        [Test]
        [TestCase(27, 9, Result = 9)]
        [TestCase(27, 0, Result = 27)]
        [TestCase(3, 15, Result = 3)]
        [TestCase(3, 4, Result = 1)]
        [TestCase(0, 0, Result = 0)]
        public int SteinMethodTest(int a, int b)
        {
            return GreatestCommonDivisor.SteinMethod(a, b);
        }

        [Test]
        [TestCase(-3, 4)]
        [TestCase(3, -5)]
        [ExpectedException(typeof(ArgumentException))]
        public void SteinMethodTest_Exception(int a, int b)
        {
            Assert.AreEqual(GreatestCommonDivisor.SteinMethod(a, b), 0);
        }

        [Test]
        [TestCase(3, 15, 45, Result = 3)]
        [TestCase(45, 15, 45, Result = 15)]
        public int SteinMethodTest_3arg(int a, int b, int c)
        {
            return GreatestCommonDivisor.SteinMethod(a, b, c);
        }
        [Test]
        [TestCase(15, 45, 3, 15, Result = 3)]
        [TestCase(5, 45, 5, 1, 5, Result = 1)]
        public int SteinMethodTest_Params(params int[] data)
        {
            return GreatestCommonDivisor.SteinMethod(data);
        }
        [Test]
        [TestCase(3)]
        [ExpectedException(typeof(ArgumentException))]
        public void SteinMethodTest_ExceptionOneArgument(params int[] a)
        {
            Assert.AreEqual(GreatestCommonDivisor.EuclideanMethod(a), 0);
        }

    }
}
