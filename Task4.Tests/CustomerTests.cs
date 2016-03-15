using System;
using System.Globalization;
using NUnit.Framework;

namespace Task4.Tests {
    public class CustomerTests {
        private readonly Customer cust = new Customer("John", "+375-17-4341283", 10000);
       

        [Test]
        [TestCase(Result = "Customer record: John, +375-17-4341283, 10000")]
        public string CustomerToStringTest() {
            return cust.ToString();
        }

        [Test]
        [TestCase(Result = "Customer record: +375-17-4341283, John, 10000")]
        public string CustomerToStringTest_CustomerFormatProvider() {
            return cust.ToString(new CustomerFormatProvider());
        }


        [Test]
        [TestCase(Result = "Customer record: John, +375-17-4341283")]
        public string CustomerToStringTest_formatNamePhone() {
            return cust.ToString("name phone");
        }
        [Test]
        [ExpectedException(typeof(FormatException))]
        [TestCase(Result = "Customer record: John, 10000")]
        public string CustomerToStringTest_Exception() {
            return cust.ToString("name recenue");
        }
    }
}
