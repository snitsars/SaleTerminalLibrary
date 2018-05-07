using Epam.Demo.SaleTerminalLibrary.Algorithms;
using Epam.Demo.SaleTerminalLibrary.Common;
using NUnit.Framework;

namespace Epam.Demo.SaleTerminalLibraryTests.Algorithms
{
    [TestFixture()]
    public class PricingVolumeAlgorithmTests
    {
        [Test()]
        public void When_CalculatePriceForProductWithSinglePrice_Expected_PriceMultiplayOnCount()
        {
            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm();
            decimal result = algorithm.Calculate("A", 3, 1.25m, null, null);

            Assert.That(result, Is.EqualTo(3.75m));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePrice_Expected_VolumePriceMultiplayOnCount()
        {
            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm();
            decimal result = algorithm.Calculate("B", 11, 1.00m, 1.2m, 6);

            Assert.That(result, Is.EqualTo(13.2m));
        }

        [Test()]
        public void When_CalculatePriceForProductWithVolumePriceWithNotEnoghtCount_Expected_PriceMultiplayOnCount()
        {
            PricingVolumeAlgorithm algorithm = new PricingVolumeAlgorithm();
            decimal result = algorithm.Calculate("B", 11, 1.00m, 1.20m, 100);

            Assert.That(result, Is.EqualTo(11.0));
        }
    }
}