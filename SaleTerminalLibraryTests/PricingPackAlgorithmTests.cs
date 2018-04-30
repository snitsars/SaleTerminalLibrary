using Epam.Demo.SaleTerminalLibrary.Models;
using NUnit.Framework;
using System;

namespace Epam.Demo.SaleTerminalLibrary.Tests
{
    [TestFixture()]
    public class PricingPackAlgorithmTests
    {
        [Test()]
        public void When_CalculatePriceForProductWithSinglePrice_Expected_PriceMultiplayOnCount()
        {
            const double expected = 3.75;
            Pricing pricing = new Pricing();
            pricing.SetPrice("A", 1.25);

            PricingPackAlgorithm algorithm = new PricingPackAlgorithm()
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
            const double expected = 15.0;
            Pricing pricing = new Pricing();
            pricing.SetPrice("B", 2.0);
            pricing.SetVolumePrice("B", 1.25, 6);

            PricingPackAlgorithm algorithm = new PricingPackAlgorithm()
            {
                Accuracy = 0.01
            };
            double result = algorithm.Calculate("B", 12, pricing);
            double difference = Math.Abs(result * algorithm.Accuracy);

            Assert.That(Math.Abs(result - expected), Is.LessThanOrEqualTo(difference));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePriceWithNotEnoghtCount_Expected_PriceMultiplayOnCount()
        {
            const double expected = 5.97;
            Pricing pricing = new Pricing();
            pricing.SetPrice("B", 1.00);
            pricing.SetVolumePrice("B", 0.83, 6);

            PricingPackAlgorithm algorithm = new PricingPackAlgorithm()
            {
                Accuracy = 0.01
            };
            double result = algorithm.Calculate("B", 7, pricing);
            double difference = Math.Abs(result * algorithm.Accuracy);

            Assert.That(Math.Abs(result - expected), Is.LessThanOrEqualTo(difference));

        }
    }
}