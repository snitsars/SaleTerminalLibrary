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
    public class GraterOrEqualZerroRuleTests
    {
        [Test()]
        public void When_ValueIsZerro_Expected_TrueInResult()
        {
            IValidationRule valueRuleChecker = new GraterOrEqualZerroRule();
            bool result = valueRuleChecker.IsValid(0.0m);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test()]
        public void When_ValueGraterThanZerro_Expected_TrueInResult()
        {
            IValidationRule valueRuleChecker = new GraterOrEqualZerroRule();
            bool result = valueRuleChecker.IsValid(91.2m);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test()]
        public void When_ValueLessThanZerro_Expected_FalseInResult()
        {
            IValidationRule valueRuleChecker = new GraterOrEqualZerroRule();
            bool result = valueRuleChecker.IsValid(-100.2m);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}