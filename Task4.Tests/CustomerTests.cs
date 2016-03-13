using System;
using NUnit.Framework;

namespace Task4.Tests {
    public class CustomerTests {
        private Customer cust = new Customer("John", "+375-17-4341283", 10000);
        private class TestFormatProvider : IFormatProvider, ICustomFormatter
        {
            public string Format(string format, object arg, IFormatProvider formatProvider){
                Customer t = arg as Customer;
                if (t == null) { return arg.ToString(); }
                return "Customer record: " + t.ContactPhone + ", " + t.Name + ", " + t.Recenue;
            }

            public object GetFormat(Type formatType){
                return (formatType == typeof(Customer)) ? this : null;
            }
        }

        [Test]
        [TestCase(Result = "Customer record: John, +375-17-4341283, 10000")]
        public string CustomerToStringTest() {
            return cust.ToString();
        }

        [Test]
        [TestCase(Result = "Customer record: +375-17-4341283, John, 10000")]
        public string CustomerToStringTest_AnotherFormat() {
            return cust.ToString(new TestFormatProvider());
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
