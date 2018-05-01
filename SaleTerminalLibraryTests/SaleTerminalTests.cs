using Epam.Demo.SaleTerminalLibrary;
using Epam.Demo.SaleTerminalLibrary.Models;
using NUnit.Framework;

namespace Epam.Demo.SaleTerminalLibraryTests
{
    [TestFixture]
    public class SaleTerminalTests
    {
        [Test]
        public void When_ProductSetABCD_Expected_TotallPrice7_25()
        {
            const decimal expected = 7.25m;
            var pricing = new Pricing();
            pricing.SetPrice("A", 1.25m);
            pricing.SetVolumePrice("A", 1.00m, 3);
            pricing.SetPrice("B", 4.25m);
            pricing.SetPrice("C", 1.00m);
            pricing.SetVolumePrice("C", 0.833m, 6);
            pricing.SetPrice("D", 0.75m);
            var terminal = new PointOfSaleTerminal {PricesTable = pricing};
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("C");
            terminal.Scan("D");

            var result = terminal.CalculateTotal();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_ProductSetABCDABA_Expected_TotallPrice13_25()
        {
            const decimal expected = 13.25m;
            var pricing = new Pricing();
            pricing.SetPrice("A", 1.25m);
            pricing.SetVolumePrice("A", 1.00m, 3);
            pricing.SetPrice("B", 4.25m);
            pricing.SetPrice("C", 1.00m);
            pricing.SetVolumePrice("C", 0.833m, 6);
            pricing.SetPrice("D", 0.75m);
            var terminal = new PointOfSaleTerminal {PricesTable = pricing};
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("C");
            terminal.Scan("D");
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("A");

            var result = terminal.CalculateTotal();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_ProductSetCCCCCCC_Expected_TotallPrice6_00()
        {
            const decimal expected = 6.00m;
            var pricing = new Pricing();
            pricing.SetPrice("C", 1.00m);
            pricing.SetVolumePrice("C", 0.833m, 6);
            var terminal = new PointOfSaleTerminal {PricesTable = pricing};
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");

            var result = terminal.CalculateTotal();

            Assert.That(expected, Is.EqualTo(result));
        }
    }
}