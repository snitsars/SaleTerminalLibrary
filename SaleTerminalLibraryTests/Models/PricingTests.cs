using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Models;
using NUnit.Framework;

namespace Epam.Demo.SaleTerminalLibraryTests.Models
{
    [TestFixture()]
    public class PricingTests
    {
        [Test()]
        public void When_PriceForProductExistInSingelPricing_Expected_True()
        {
            decimal initialPrice = 9.99m;
            string initialProduct = "Tort";
            Pricing pricing = new Pricing();
            pricing.SetSinglePrice(initialProduct, initialPrice);

            Assert.That(true, Is.EqualTo(pricing.Contains(initialProduct)));
        }

        [Test()]
        public void When_PriceForProductExistInVolumePricing_Expected_True()
        {
            decimal initialPrice = 9.99m;
            string initialProduct = "juice";
            uint minimalVolume = 5;
            Pricing pricing = new Pricing();
            pricing.SetVolumePrice(initialProduct, initialPrice, minimalVolume);

            Assert.That(true, Is.EqualTo(pricing.Contains(initialProduct)));
        }

        [Test()]
        public void When_PriceForProductMissingInVolumePricing_Expected_False()
        {
            Pricing pricing = new Pricing();

            Assert.That(false, Is.EqualTo(pricing.Contains("juice")));
        }
    }
}