using System;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class GreatestCommonDivisorTests {
        private double _time;
        [Test]
        [TestCase(27, 9,Result = 9)]
        [TestCase(27,0, Result = 27)]
        [TestCase(45,60, Result = 15)]
        [TestCase(-3,15, Result = 3)]
        [TestCase(3, 4, Result = 1)]
        public int EuclideanMethodTest(int a, int b) {
            return GreatestCommonDivisor.EuclideanMethod(out _time, a, b);
        }
        [Test]
        [TestCase(15, 45, 3, 15, Result = 3)]
        [TestCase(5, 45, 5, 1, 5, Result = 1)]
        public int EuclideanMethodTest_params(params int[] data){
            return GreatestCommonDivisor.EuclideanMethod(out _time, data);
        }
        [Test]
        [TestCase(0, 0)]
        [ExpectedException(typeof(ArgumentException))]
        public void EuclideanMethodTest_ZeroException(int a, int b) {
            Assert.AreEqual(GreatestCommonDivisor.EuclideanMethod(out _time, a, b), 0);
        }
        [Test]
        [TestCase(3)]
        [ExpectedException(typeof(ArgumentException))]
        public void EuclideanMethodTest_OneArgumentException(params int[] values){
            Assert.AreEqual(GreatestCommonDivisor.EuclideanMethod(out _time, values), 0);
        }
        
        [Test]
        [TestCase(27, 9, Result = 9)]
        [TestCase(27, 0, Result = 27)]
        [TestCase(3, 15, Result = 3)]
        [TestCase(3, 4, Result = 1)]
        [TestCase(0, 0, Result = 0)]
        public int SteinMethodTest(int a, int b) {
            return GreatestCommonDivisor.SteinMethod(out _time, a, b);
        }
        [Test]
        [TestCase(15, 45, 3, 15, Result = 3)]
        [TestCase(1949, 2549, 3461, 1093, 3571, Result = 1)]
        public int SteinMethodTest_Params(params int[] data){
            return GreatestCommonDivisor.SteinMethod(out _time, data);
        }
        [Test]
        [TestCase(-3, 4)]
        [TestCase(3, -5)]
        [ExpectedException(typeof(ArgumentException))]
        public void SteinMethodTest_NegativeArgumentException(int a, int b) {
            Assert.AreEqual(GreatestCommonDivisor.SteinMethod(out _time,a, b), 0);
        }

        [Test]
        [TestCase(3)]
        [ExpectedException(typeof(ArgumentException))]
        public void SteinMethodTest_OneArgumentException(params int[] values){
            Assert.AreEqual(GreatestCommonDivisor.SteinMethod(out _time, values), 0);
        }

    }
}
