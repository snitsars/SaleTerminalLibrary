using System;
using Epam.Demo.SaleTerminalLibrary;
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
            PointOfSaleTerminal terminal = new PointOfSaleTerminal();
            //terminal.SetPricing();
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("C");
            terminal.Scan("D");
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("A");
            double result = terminal.CalculateTotal();
            double difference = Math.Abs(result * .00001);

            Assert.That(Math.Abs(result - expected) <= difference);
        }
    }
}
