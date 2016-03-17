﻿using NUnit.Framework;
using System;
using System.Globalization;
using System.Threading;

namespace Task3.Tests {
    [TestFixture]
    public class HexFormatProviderTests {
        [Test]
        [TestCase(0, Result = "0")]
        [TestCase(4, Result = "4")]
        [TestCase(27, Result = "1B")]
        public string ToHexStringTest(int number) {
            return string.Format(new HexFormatProvider(),"{0:X}",number);
        }

        [TestCase(-24, Result = "-18")]
        [TestCase(-240, Result = "-F0")]
        public string ToHexStringTest_Negative(int number) {
           return string.Format(new HexFormatProvider(),"{0:X}",number);
        }

        [TestCase(145, Result = "0x91")]
        [TestCase(-145, Result = "-0x91")]
        [TestCase(0, Result = "0x0")]
        [TestCase(41837, Result = "0xA36D")]
        [TestCase(47, Result = "0x2F")]
        [TestCase(47.2, ExpectedException = typeof(ArgumentException))]
        public string Format_Test(object number) {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IFormatProvider fp = new HexFormatProvider();

            return string.Format(fp, "{0:H}", number);
        }

        [TestCase(47, "{0:X}", Result = "2F")]
        [TestCase(.473, "{0:P}", Result = "47.30 %")]
        [TestCase(.473, "{0:P0}", Result = "47 %")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.7321, "{0:F2}", Result = "4.73")]

        public string ParentFormat_Test(object number, string format) {

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IFormatProvider fp = new HexFormatProvider();

            return string.Format(fp, format, number);

        }
    }
}
