using NUnit.Framework;
namespace Task3.Tests {
    [TestFixture]
    public class IntExtensionTests {
        [Test]
        [TestCase(0, Result = "0")]
        [TestCase(4, Result = "4")]
        [TestCase(27, Result = "1B")]
        public string ToHexStringTest(int number) {
            return number.ToHexString();
        }

        [TestCase(-24, Result = "-18")]
        [TestCase(-240, Result = "-F0")]
        public string ToHexStringTest_Negative(int number) {
            return number.ToHexString();
        }
    }
}
