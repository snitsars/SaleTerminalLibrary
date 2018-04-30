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
            double initialValue = 100.2;
            var priceInfo = new Price
            {
                Value = initialValue
            };

            Assert.That(priceInfo, Is.EqualTo(initialValue));
        }

        [Test()]
        public void When_SetLess0Value_Expected_Exception()
        {
            double initialValue = -20.0;
            var priceInfo = new Price();

            Assert.Throws<ArgumentOutOfRangeException>(() => priceInfo.Value = initialValue);
        }

        [Test()]
        public void When_ValueCompareWithOtherDouble_Expected_TrueIfValueEqual()
        {
            double initialValue = 5.10;
            double compareValue = 5.10;
            var priceInfo = new Price();
            priceInfo.Value = initialValue;
            Assert.That(priceInfo, Is.EqualTo(compareValue));
        }

        [Test()]
        public void When_ValueCompareWithOtherDouble_Expected_FalseIfValueNotEqual()
        {
            double initialValue = 25.10;
            double compareValue = 25.11;
            var priceInfo = new Price();
            priceInfo.Value = initialValue;
            Assert.That(priceInfo, Is.Not.EqualTo(compareValue));
        }
    }
}