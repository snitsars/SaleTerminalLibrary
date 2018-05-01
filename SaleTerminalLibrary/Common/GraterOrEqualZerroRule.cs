using System;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    /// <summary>
    /// Implementation of value validation rule
    /// value shouldbe 0 or grater
    /// </summary>
    public class GraterOrEqualZerroRule : IValidationRule
    {
        /// <summary>
        /// Method for check that value is aplicable
        /// This is very simple method but we can create more comlicated rule and replace it
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Validate(decimal value)
        {
            return value >= 0;
        }
    }
}