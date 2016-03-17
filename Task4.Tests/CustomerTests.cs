using System;
using System.Globalization;
using NUnit.Framework;

namespace Task4.Tests {
    public class CustomerTests {
        private readonly Customer cust = new Customer("John", "+375-17-4341283", 10000);
      
        [Test]
        [TestCase(Result = "John, +375-17-4341283, $10,000.00")]
        public string CustomerToStringTest() {
            return cust.ToString();
        }

        [Test]
        [TestCase(Result = "Name: John, Contact phone: +375-17-4341283, Recenue: $10,000.00 ")]
        public string CustomerToStringTest_CustomerFormatProvider() {
            return cust.ToString("npr",new CustomerFormatProvider());
        }
        [Test]
        [TestCase(Result = "10.000,00 €")]
        public string CustomerToStringTest_DeFormatProvider() {
            return cust.ToString("r",new CultureInfo("de-DE"));
        }
        [Test]
        [TestCase(Result = "$10,000.00")]
        public string CustomerToStringTest_NullFormatProvider() {
            return cust.ToString("r", null);
        }
        [Test]
        [TestCase(Result = "John, +375-17-4341283, $10,000.00")]
        public string CustomerToStringTest_GFormat() {
            return cust.ToString("g", null);
        }
    }
}
