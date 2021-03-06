﻿using NUnit.Framework;

namespace Epam.Demo.SaleTerminalLibrary.Common.Tests
{
    [TestFixture()]
    public class PriceVolumeTests
    {
        [Test()]
        public void When_SetMinimalCount_Expected_GetSameMinimalCount()
        {
            uint initialValue = 100;
            var priceInfo = new VolumePrice {MinimalVolume = initialValue};

            Assert.That(priceInfo.MinimalVolume, Is.EqualTo(initialValue));
        }
    }
}