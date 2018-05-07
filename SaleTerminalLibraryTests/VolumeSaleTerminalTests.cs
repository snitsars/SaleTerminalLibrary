using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;
using Epam.Demo.SaleTerminalLibraryTests.Mocks;
using NUnit.Framework;
using Unity;

namespace Epam.Demo.SaleTerminalLibraryTests
{
    [TestFixture]
    public class VolumeSaleTerminalTests
    {
        private readonly IUnityContainer components;

        public VolumeSaleTerminalTests()
        {
            components = new UnityContainer();
            VolumeTerminal.RegisterElements(components);

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
        public void When_InVolumeTerminalProductSetABCD_Expected_TotallPrice7_25()
        {
            const decimal expected = 7.25m;
            var terminal = components.Resolve<IPointOfSaleTerminal>();

            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("C");
            terminal.Scan("D");

            var result = terminal.CalculateTotal();
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_InVolumeTerminalProductSetABCDABA_Expected_TotallPrice13_25()
        {
            const decimal expected = 13.25m;
            var terminal = components.Resolve<IPointOfSaleTerminal>();

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
        public void When_InVolumeTerminalProductSetCCCCCCC_Expected_TotallPrice6_00()
        {
            const decimal expected = 5.83m;
            var terminal = components.Resolve<IPointOfSaleTerminal>();

            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");
            terminal.Scan("C");

            var result = terminal.CalculateTotal();
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}