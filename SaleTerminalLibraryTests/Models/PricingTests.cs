using Epam.Demo.SaleTerminalLibrary.Models;
using NUnit.Framework;

namespace Epam.Demo.SaleTerminalLibraryTests.Models
{
    [TestFixture()]
    public class PricingTests
    {
        [Test()]
        public void When_ProductPriceWasSet_Expected_GetThisPrice()
        {
            decimal initialPrice = 10.5m;
            Pricing pricing = new Pricing();
            pricing.SetPrice("A", initialPrice);
            Assert.That(pricing.GetPrice("A"), Is.EqualTo(initialPrice));
        }


        [Test()]
        public void When_CallSetPriceForExistProduct_Expected_GetUpdatedPrice()
        {
            decimal initialPrice = 12.5m;
            decimal expectedPrice = 18.9m;
            Pricing pricing = new Pricing();
            pricing.SetPrice("A", initialPrice);
            pricing.SetPrice("A", expectedPrice);
            Assert.That(pricing.GetPrice("A"), Is.EqualTo(expectedPrice));
        }


        [Test()]
        public void When_CallSetVolumePriceForNewProduct_Expected_GetThisVolumePrice()
        {
            decimal initialVolumePrice = 10.0m;
            Pricing pricing = new Pricing();
            pricing.SetVolumePrice("A", initialVolumePrice, 3);
            Assert.That(pricing.GetVolumePrice("A").Value, Is.EqualTo(initialVolumePrice));
        }


        [Test()]
        public void When_CallSetVolumePriceForExistingProduct_Expected_UpdateThisVolumePrice()
        {
            decimal initialVolumePrice = 10.0m;
            decimal expectedVolumePrice = 15.7m;
            Pricing pricing = new Pricing();
            pricing.SetVolumePrice("A", initialVolumePrice, 3);
            pricing.SetVolumePrice("A", expectedVolumePrice, 3);
            Assert.That(pricing.GetVolumePrice("A").Value, Is.EqualTo(expectedVolumePrice));
        }

        [Test()]
        public void When_GetPriceForNotExistProduct_Expected_nullInResult()
        {
            decimal initialPrice = 9.99m;
            string initialProduct = "Tort";
            Pricing pricing = new Pricing();
            pricing.SetPrice(initialProduct, initialPrice);

            var productPrice = pricing.GetPrice("D");
            Assert.That(productPrice, Is.Null);
        }

        [Test()]
        public void When_GetVolumePriceForNotExistProduct_Expected_nullInResult()
        {
            decimal initialVolumePrice = 8.99m;
            uint initialMinimalCount = 5;
            string initialProduct = "Tort";
            Pricing pricing = new Pricing();
            pricing.SetVolumePrice(initialProduct, initialVolumePrice, initialMinimalCount);

            var productPrice = pricing.GetVolumePrice("D");
            Assert.That(productPrice, Is.Null);
        }
    }
}