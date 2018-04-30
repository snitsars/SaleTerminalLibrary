using NUnit.Framework;
using Epam.Demo.SaleTerminalLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Common.Tests
{
    [TestFixture()]
    public class PriceVolumeTests
    {
        [Test()]
        public void When_SetMinimalCount_Expected_GetSameMinimalCount()
        {
            uint initialValue = 100;
            var priceInfo = new VolumePrice();
            priceInfo.MinimalCount = initialValue;

            Assert.That(priceInfo.MinimalCount == initialValue);
        }
    }
}