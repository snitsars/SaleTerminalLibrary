using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibraryTests.Mocks;
using NUnit.Framework;
using System.Collections.Generic;
using Unity;

namespace Epam.Demo.SaleTerminalLibrary.Tests
{
    [TestFixture()]
    public class PointOfSaleTerminalTests
    {
        [Test()]
        public void ScanTest()
        {
            IUnityContainer components = new UnityContainer();
            PackTerminal.RegisterElements(components);

            var terminal = components.Resolve<IPointOfSaleTerminal>();
            Assert.Throws<KeyNotFoundException>(() => terminal.Scan("Dino"));
        }
    }
}