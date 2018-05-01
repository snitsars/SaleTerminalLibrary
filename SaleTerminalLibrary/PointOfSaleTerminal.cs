using Epam.Demo.SaleTerminalLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace Epam.Demo.SaleTerminalLibrary
{
    /// <summary>
    /// Class of point-of-sale that accepts an arbitrary ordering of products 
    /// and calculate summary price 
    /// </summary>
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private const byte OptionSignAfterPoint = 2;

        private readonly ICart cart;
        private readonly IPricingAlgorithm priceCalulationAlgorithm;
        private readonly IPricing prices;


        /// <summary>
        /// Constructor of terminal class
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="prices">
        /// <param name="priceCalulationAlgorithm"></param>
        public PointOfSaleTerminal(ICart cart, IPricing prices, IPricingAlgorithm priceCalulationAlgorithm)
        {
            this.prices = prices;
            this.priceCalulationAlgorithm = priceCalulationAlgorithm;
            this.cart = cart;
        }

        /// <summary>
        /// Scan product method
        /// </summary>
        public void Scan(string productCode)
        {
            if (!prices.ContainsKey(productCode))
            {
                throw new KeyNotFoundException($"You are trying to scan product {productCode} missing in the pricing");
            }
            cart.AddProductItem(productCode);
        }


        /// <summary>
        /// Calculate price of all products entire shopping cart 
        /// </summary>
        /// <returns></returns>
        public decimal CalculateTotal()
        {
            decimal result = 0;
            foreach (KeyValuePair<string, uint> product in cart)
            {
                result += priceCalulationAlgorithm.Calculate(product.Key, product.Value, prices);
            }
            result = decimal.Round(result, OptionSignAfterPoint, MidpointRounding.AwayFromZero);

            return result;
        }
    }
}
