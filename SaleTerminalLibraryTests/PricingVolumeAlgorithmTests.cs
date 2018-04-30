using NUnit.Framework;
using Epam.Demo.SaleTerminalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Demo.SaleTerminalLibrary.Models;

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

            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm();
            double result = algorithm.Calculate("A", 3, pricing);
            double difference = Math.Abs(result * 0.01);

            Assert.That(Math.Abs(result - expected), Is.LessThanOrEqualTo(difference));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePrice_Expected_VolumePriceMultiplayOnCount()
        {
            const double expected = 13.2;
            Pricing pricing = new Pricing();
            pricing.SetPrice("B", 1.00);
            pricing.SetVolumePrice("B", 1.2, 6);

            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm();
            double result = algorithm.Calculate("B", 11, pricing);
            double difference = Math.Abs(result * 0.01);

            Assert.That(Math.Abs(result - expected), Is.LessThanOrEqualTo(difference));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePriceWithNotEnoghtCount_Expected_PriceMultiplayOnCount()
        {
            const double expected = 11.0;
            Pricing pricing = new Pricing();
            pricing.SetPrice("B", 1.00);
            pricing.SetVolumePrice("B", 1.2, 100);

            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm();
            double result = algorithm.Calculate("B", 11, pricing);
            double difference = Math.Abs(result * 0.01);

            Assert.That(Math.Abs(result - expected), Is.LessThanOrEqualTo(difference));
        }
    }
}