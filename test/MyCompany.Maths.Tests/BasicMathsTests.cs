using MyCompany.Core.Maths;
using NUnit.Framework;

namespace MyCompany.Maths.Tests
{
    [TestFixture]
    public class BasicMathsTests
    {
        [Test]
        public void Add_WithTwoNumbers_ReturnsSumOfNumbers()
        {
            var sut = new BasicMaths();

            var result = sut.Add(10, 10);

            Assert.AreEqual(result, 20);
        }

        [Test]
        public void Subtract_WithTwoNumbers_ReturnsDifferenceOfNumbers()
        {
            var sut = new BasicMaths();

            var result = sut.Subtract(10, 10);

            Assert.AreEqual(result, 0);
        }

        [Test]
        public void Divide_WithTwoNumbers_ReturnsQuotientOfNumbers()
        {
            var sut = new BasicMaths();

            var result = sut.Divide(10, 5);

            Assert.AreEqual(result, 2);
        }

        [Test]
        public void Multiply_WithTwoNumbers_ReturnsProductOfNumbers()
        {
            var sut = new BasicMaths();

            var result = sut.Multiply(10, 10);

            Assert.AreEqual(result, 100);
        }
    }
}
