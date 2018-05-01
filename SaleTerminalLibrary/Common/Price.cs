using Epam.Demo.SaleTerminalLibrary.Interfaces;
using System;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    /// <summary>
    /// Class represent price of product that should to be order as single
    /// </summary>
    public class Price : IPrice
    {
        private decimal value;

        /// <summary>
        /// Property for set/get price value
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> In case when we try to set value less than 0</exception>
        public virtual decimal Value
        {
            get => value;
            set
            {
                if(value <= 0)
                { 
                    throw new ArgumentOutOfRangeException($"Price can't be less 0, but you try to set {value}");
                }
                this.value = value;
            }
        }
    }
}
