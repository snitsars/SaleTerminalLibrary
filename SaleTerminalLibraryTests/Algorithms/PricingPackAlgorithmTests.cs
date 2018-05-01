using Epam.Demo.SaleTerminalLibrary.Algorithms;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;
using NUnit.Framework;

namespace Epam.Demo.SaleTerminalLibraryTests.Algorithms
{
    [TestFixture()]
    public class PricingPackAlgorithmTests
    {
        [Test()]
        public void When_CalculatePriceForProductWithSinglePrice_Expected_PriceMultiplayOnCount()
        {
            Pricing pricing = new Pricing();
            pricing.SetPrice("A", 1.25m);

            PricingPackAlgorithm algorithm = new PricingPackAlgorithm();
            decimal result = algorithm.Calculate("A", 3, pricing);

            Assert.That(result, Is.EqualTo(3.75m));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePrice_Expected_VolumePriceMultiplayOnCount()
        {
            Pricing pricing = new Pricing();
            pricing.SetPrice("B", 2.0m);
            pricing.SetVolumePrice("B", 1.25m, 6);

            PricingPackAlgorithm algorithm = new PricingPackAlgorithm();
            decimal result = algorithm.Calculate("B", 12, pricing);

            Assert.That(result, Is.EqualTo(15.0m));
        }
    
        [Test()]
        public void When_CalculatePriceForProductWithVolumePriceWithNotEnoghtCount_Expected_PriceMultiplayOnCount()
        {
            Pricing pricing = new Pricing();
            pricing.SetPrice("B", 1.00m);
            pricing.SetVolumePrice("B", 0.83m, 6);

            PricingPackAlgorithm algorithm = new PricingPackAlgorithm();
            decimal result = algorithm.Calculate("B", 7, pricing);

            Assert.That(result, Is.EqualTo(5.98m));
        }
    }
}