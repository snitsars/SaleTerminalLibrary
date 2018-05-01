using Epam.Demo.SaleTerminalLibrary.Models;
using NUnit.Framework;
using System;

namespace Epam.Demo.SaleTerminalLibrary.Tests
{
    [TestFixture()]
    public class PricingVolumeAlgorithmTests
    {
        [Test()]
        public void When_CalculatePriceForProductWithSinglePrice_Expected_PriceMultiplayOnCount()
        {
            const decimal expected = 3.75m;
            Pricing pricing = new Pricing();
            pricing.SetPrice("A", 1.25m);

            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm();
            decimal result = algorithm.Calculate("A", 3, pricing);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePrice_Expected_VolumePriceMultiplayOnCount()
        {
            const decimal expected = 13.2m;
            Pricing pricing = new Pricing();
            pricing.SetPrice("B", 1.00m);
            pricing.SetVolumePrice("B", 1.2m, 6);

            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm();
            decimal result = algorithm.Calculate("B", 11, pricing);

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePriceWithNotEnoghtCount_Expected_PriceMultiplayOnCount()
        {
            const decimal expected = 11.0m;
            Pricing pricing = new Pricing();
            pricing.SetPrice("B", 1.00m);
            pricing.SetVolumePrice("B", 1.2m, 100);

            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm();
            decimal result = algorithm.Calculate("B", 11, pricing);

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}