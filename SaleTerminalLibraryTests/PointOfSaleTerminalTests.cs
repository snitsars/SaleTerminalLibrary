using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;
using NUnit.Framework;
using System.Collections.Generic;
using Unity;

namespace Epam.Demo.SaleTerminalLibrary.Tests
{
    [TestFixture()]
    public class PointOfSaleTerminalTests
    {
        private readonly IUnityContainer components;

        public PointOfSaleTerminalTests()
        {
            components = new UnityContainer();

            IPricing pricing = new Pricing();
            pricing.SetSinglePrice("A", 1.25m);
            pricing.SetVolumePrice("A", 1.00m, 3);
            pricing.SetSinglePrice("B", 4.25m);
            pricing.SetSinglePrice("C", 1.00m);
            pricing.SetVolumePrice("C", 0.833m, 6);
            pricing.SetSinglePrice("D", 0.75m);

            components.RegisterInstance(pricing);
            components.RegisterType<ICart, Cart>();
        }

        [Test()]
        public void When_ScanProductCodeThatMissingInPricing_Expected_exception()
        {
            IPointOfSaleTerminal terminal = new PointOfSaleTerminal(components.Resolve<ICart>(), components.Resolve<IPricing>());
            Assert.Throws<KeyNotFoundException>(() => terminal.Scan("Dino"));
        }

        [Test()]
        public void When_ScanProductCodeThatExistInPricing_Expected_NoException()
        {
            IPointOfSaleTerminal terminal = new PointOfSaleTerminal(components.Resolve<ICart>(), components.Resolve<IPricing>());
            Assert.DoesNotThrow(() => terminal.Scan("A"));
        }
    }
}