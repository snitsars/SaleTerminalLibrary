using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;
using Epam.Demo.SaleTerminalLibraryTests.Mocks;
using NUnit.Framework;
using Unity;

namespace Epam.Demo.SaleTerminalLibraryTests
{
    [TestFixture]
    public class PackSaleTerminalTests
    {
        private readonly IUnityContainer components;

        public PackSaleTerminalTests()
        {
            components = new UnityContainer();
            PackTerminal.RegisterElements(components);

            IPricing pricing = new Pricing();
            pricing.SetSinglePrice("A", 1.25m);
            pricing.SetVolumePrice("A", 1.00m, 3);
            pricing.SetSinglePrice("B", 4.25m);
            pricing.SetSinglePrice("C", 1.00m);
            pricing.SetVolumePrice("C", 0.833m, 6);
            pricing.SetSinglePrice("D", 0.75m);

            components.RegisterInstance(pricing);
        }

        [Test]
        public void When_InPackTerminalProductSetABCD_Expected_TotallPrice7_25()
        {
            const decimal expected = 7.25m;
            IPointOfSaleTerminal terminal = components.Resolve<IPointOfSaleTerminal>();
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("C");
            terminal.Scan("D");

            var result = terminal.CalculateTotal();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_InPackTerminalProductSetABCDABA_Expected_TotallPrice13_25()
        {
            const decimal expected = 13.25m;
            IPointOfSaleTerminal terminal = components.Resolve<IPointOfSaleTerminal>();
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
        public void When_InPackTerminalProductSetCCCCCCC_Expected_TotallPrice6_00()
        {
            const decimal expected = 6.00m;
            IPointOfSaleTerminal terminal = components.Resolve<IPointOfSaleTerminal>();
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