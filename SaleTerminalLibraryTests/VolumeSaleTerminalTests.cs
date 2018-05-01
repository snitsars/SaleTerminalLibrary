using Epam.Demo.SaleTerminalLibrary;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using NUnit.Framework;
using Unity;

namespace Epam.Demo.SaleTerminalLibraryTests
{
    [TestFixture]
    public class VolumeSaleTerminalTests
    {
        [Test]
        public void When_InVolumeTerminalProductSetABCD_Expected_TotallPrice7_25()
        {
            const decimal expected = 7.25m;

            IUnityContainer components = new UnityContainer();
            VolumeTerminal.RegisterElements(components);

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

            IUnityContainer components = new UnityContainer();
            VolumeTerminal.RegisterElements(components);

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

            IUnityContainer components = new UnityContainer();
            VolumeTerminal.RegisterElements(components);

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