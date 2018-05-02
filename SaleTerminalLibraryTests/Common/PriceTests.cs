using NUnit.Framework;
using System;

namespace Epam.Demo.SaleTerminalLibrary.Common.Tests
{
    [TestFixture()]
    public class PriceTests
    {
        [Test()]
        public void When_SetValue_Expected_GetSameValue()
        {
            decimal initialValue = 100.2m;
            var priceInfo = new Price{Value = initialValue};

            Assert.That(priceInfo.Value, Is.EqualTo(initialValue));
        }

        [Test()]
        public void When_SetLess0Value_Expected_Exception()
        {
            decimal initialValue = -20.0m;
            var priceInfo = new Price();

            Assert.Throws<ArgumentOutOfRangeException>(() => priceInfo.Value = initialValue);
        }

        [Test()]
        public void When_ValueCompareWithOtherdecimal_Expected_TrueIfValueEqual()
        {
            decimal initialValue = 5.10m;
            decimal compareValue = 5.10m;
            var priceInfo = new Price {Value = initialValue};
            Assert.That(priceInfo.Value, Is.EqualTo(compareValue));
        }

        [Test()]
        public void When_ValueCompareWithOtherdecimal_Expected_FalseIfValueNotEqual()
        {
            decimal initialValue = 25.10m;
            decimal compareValue = 25.11m;
            var priceInfo = new Price {Value = initialValue};
            Assert.That(priceInfo.Value, Is.Not.EqualTo(compareValue));
        }
    }
}