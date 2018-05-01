using System;

namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    /// <summary>
    /// Interface that describe price of product
    /// </summary>
    public interface IPrice
    {
        /// <summary>
        /// Property value of price
        /// </summary>
        decimal Value { get; set; }
    }
}