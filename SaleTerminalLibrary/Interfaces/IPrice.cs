using System;

namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    /// <summary>
    /// Interface that describe price of product
    /// </summary>
    public interface IPrice : IComparable<double>
    {
        /// <summary>
        /// Property value of price
        /// </summary>
        double Value { get; set; }
    }
}