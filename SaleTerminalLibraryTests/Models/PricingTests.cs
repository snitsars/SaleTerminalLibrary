﻿using Epam.Demo.SaleTerminalLibrary.Models;
using NUnit.Framework;

namespace Epam.Demo.SaleTerminalLibraryTests.Models
{
    [TestFixture()]
    public class PricingTests
    {
        [Test()]
        public void When_ProductPriceWasSet_Expected_GetThisPrice()
        {
            double initialPrice = 10.5;
            Pricing pricing = new Pricing();
            pricing.SetPrice("A", initialPrice);
            Assert.That(pricing.GetPrice("A") == initialPrice);
        }


        [Test()]
        public void When_CallSetPriceForExistProduct_Expected_GetUpdatedPrice()
        {
            double initialPrice = 12.5;
            double expectedPrice = 18.9;
            Pricing pricing = new Pricing();
            pricing.SetPrice("A", initialPrice);
            pricing.SetPrice("A", expectedPrice);
            Assert.That(pricing.GetPrice("A") == expectedPrice);
        }


        [Test()]
        public void When_CallSetVolumePriceForNewProduct_Expected_GetThisVolumePrice()
        {
            double initialVolumePrice = 10.0;
            Pricing pricing = new Pricing();
            pricing.SetVolumePrice("A", initialVolumePrice, 3);
            Assert.That(pricing.GetVolumePrice("A").Value == initialVolumePrice);
        }


        [Test()]
        public void When_CallSetVolumePriceForExistingProduct_Expected_UpdateThisVolumePrice()
        {
            double initialVolumePrice = 10.0;
            double expectedVolumePrice = 15.7;
            Pricing pricing = new Pricing();
            pricing.SetVolumePrice("A", initialVolumePrice, 3);
            pricing.SetVolumePrice("A", expectedVolumePrice, 3);
            Assert.That(pricing.GetVolumePrice("A").Value == expectedVolumePrice);
        }

        [Test()]
        public void When_GetPriceForNotExistProduct_Expected_nullInResult()
        {
            double initialPrice = 9.99;
            string initialProduct = "Tort";
            Pricing pricing = new Pricing();
            pricing.SetPrice(initialProduct, initialPrice);

            var productPrice = pricing.GetPrice("D");
            Assert.That(productPrice == null);
        }

        [Test()]
        public void When_GetVolumePriceForNotExistProduct_Expected_nullInResult()
        {
            double initialVolumePrice = 8.99;
            uint initialMinimalCount = 5;
            string initialProduct = "Tort";
            Pricing pricing = new Pricing();
            pricing.SetVolumePrice(initialProduct, initialVolumePrice, initialMinimalCount);

            var productPrice = pricing.GetVolumePrice("D");
            Assert.That(productPrice == null);
        }
    }
}