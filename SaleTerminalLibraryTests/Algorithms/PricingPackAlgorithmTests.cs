using Epam.Demo.SaleTerminalLibrary.Algorithms;
using Epam.Demo.SaleTerminalLibrary.Common;
using NUnit.Framework;

namespace Epam.Demo.SaleTerminalLibraryTests.Algorithms
{
    [TestFixture()]
    public class PricingPackAlgorithmTests
    {
        [Test()]
        public void When_CalculatePriceForProductWithSinglePrice_Expected_PriceMultiplayOnCount()
        {
            PricingPackAlgorithm algorithm = new PricingPackAlgorithm();
            decimal result = algorithm.Calculate("A", 3, 1.25m, null, null);
            Assert.That(result, Is.EqualTo(3.75m));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePrice_Expected_VolumePriceMultiplayOnCount()
        {
            PricingPackAlgorithm algorithm = new PricingPackAlgorithm();
            decimal result = algorithm.Calculate("B", 12, 2.0m, 1.25m, 6);

            Assert.That(result, Is.EqualTo(15.0m));
        }
    
        [Test()]
        public void When_CalculatePriceForProductWithVolumePriceWithNotEnoghtCount_Expected_PriceMultiplayOnCount()
        {
            PricingPackAlgorithm algorithm = new PricingPackAlgorithm();
            decimal result = algorithm.Calculate("B", 5, 1.00m, 0.83m, 6);

            Assert.That(result, Is.EqualTo(5.00m));
        }
    }
}