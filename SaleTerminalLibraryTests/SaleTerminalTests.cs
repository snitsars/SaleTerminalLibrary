using System;
using Epam.Demo.SaleTerminalLibrary;
using Epam.Demo.SaleTerminalLibrary.Models;
using NUnit.Framework;

namespace Epam.Demo.SaleTerminalLibraryTests
{
    [TestFixture]
    public class SaleTerminalTests
    {
        [Test]
        public void When_ProductSetABCDABA_Expected_TotallPrice13_25()
        {
            const double expected = 13.25;
            Pricing pricing = new Pricing();
            pricing.SetPrice("A", 1.25);
            pricing.SetVolumePrice("A", 1.00, 3);
            pricing.SetPrice("B", 4.25);
            pricing.SetPrice("C", 1.00);
            pricing.SetVolumePrice("C", 0.833, 6);
            pricing.SetPrice("D", 0.75);


            PointOfSaleTerminal terminal = new PointOfSaleTerminal();
            terminal.PricesTable = pricing;
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("C");
            terminal.Scan("D");
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("A");
            double result = terminal.CalculateTotal();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_ProductSetCCCCCCC_Expected_TotallPrice6_00()
        {
            const double expected = 6.00;
            Pricing pricing = new Pricing();
            pricing.SetPrice("C", 1.00);
            pricing.SetVolumePrice("C", 0.833, 6);

            PointOfSaleTerminal terminal = new PointOfSaleTerminal();
            terminal.PricesTable = pricing;
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");

            double result = terminal.CalculateTotal();
            double difference = Math.Abs(result * 0.001);
            Assert.That(Math.Abs(result - expected) <= difference);
        }

        [Test]
        public void When_ProductSetABCD_Expected_TotallPrice7_25()
        {
            const double expected = 7.25;
            Pricing pricing = new Pricing();
            pricing.SetPrice("A", 1.25);
            pricing.SetVolumePrice("A", 1.00, 3);
            pricing.SetPrice("B", 4.25);
            pricing.SetPrice("C", 1.00);
            pricing.SetVolumePrice("C", 0.833, 6);
            pricing.SetPrice("D", 0.75);


            PointOfSaleTerminal terminal = new PointOfSaleTerminal();
            terminal.PricesTable = pricing;
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("C");
            terminal.Scan("D");
            double result = terminal.CalculateTotal();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
