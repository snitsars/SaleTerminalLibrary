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
            const double expected = 3.75;
            Pricing pricing = new Pricing();
            pricing.SetPrice("A", 1.25);

            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm()
            {
                Accuracy = 0.01
            };
            double result = algorithm.Calculate("A", 3, pricing);
            double difference = Math.Abs(result * algorithm.Accuracy);

            Assert.That(Math.Abs(result - expected), Is.LessThanOrEqualTo(difference));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePrice_Expected_VolumePriceMultiplayOnCount()
        {
            const double expected = 13.2;
            Pricing pricing = new Pricing();
            pricing.SetPrice("B", 1.00);
            pricing.SetVolumePrice("B", 1.2, 6);

            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm()
            {
                Accuracy = 0.01
            };
            double result = algorithm.Calculate("B", 11, pricing);
            double difference = Math.Abs(result * algorithm.Accuracy);

            Assert.That(Math.Abs(result - expected), Is.LessThanOrEqualTo(difference));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePriceWithNotEnoghtCount_Expected_PriceMultiplayOnCount()
        {
            const double expected = 11.0;
            Pricing pricing = new Pricing();
            pricing.SetPrice("B", 1.00);
            pricing.SetVolumePrice("B", 1.2, 100);

            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm()
            {
                Accuracy = 0.01
            };
            double result = algorithm.Calculate("B", 11, pricing);
            double difference = Math.Abs(result * algorithm.Accuracy);

            Assert.That(Math.Abs(result - expected), Is.LessThanOrEqualTo(difference));
        }
    }
}