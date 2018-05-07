using Epam.Demo.SaleTerminalLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace Epam.Demo.SaleTerminalLibrary
{
    /// <summary>
    /// Class of point-of-sale that can scan set of products 
    /// and calculate summary price.
    /// Should be initialized by the instances of interfaces ICart, IPricing, IPricingAlgorithm
    /// </summary>
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private const byte OptionSignAfterPoint = 2;
        private readonly ICart cart;
        private readonly IPricingAlgorithm priceCalulationAlgorithm;
        private readonly IPricing prices;


        public PointOfSaleTerminal(ICart cart, IPricing prices, IPricingAlgorithm priceCalulationAlgorithm)
        {
            this.prices = prices;
            this.priceCalulationAlgorithm = priceCalulationAlgorithm;
            this.cart = cart;
        }


        /// <summary>
        /// Scan method, takes product code as input parrameter
        /// and add them to cart in case if product code available in pricing.
        /// </summary>
        /// <exception cref="KeyNotFoundException">In case if product code is missing in pricing</exception>
        public void Scan(string productCode)
        {
            if (!prices.ContainsKey(productCode))
            {
                throw new KeyNotFoundException($"You are trying to scan product {productCode} missing in the pricing");
            }
            cart.AddProductItem(productCode);
        }


        /// <summary>
        /// Calculate price of all products entire cart
        /// taking into account volume and pack prices of products
        /// </summary>
        public decimal CalculateTotal()
        {
            decimal result = 0m;
            foreach (KeyValuePair<string, uint> product in cart)
            {
                var price = prices?.GetSinglePrice(product.Key);
                var volumPrice = prices?.GetVolumePrice(product.Key);
                result += priceCalulationAlgorithm.Calculate(product.Key, product.Value, price, volumPrice?.Value, volumPrice?.MinimalVolume);
            }
            result = decimal.Round(result, OptionSignAfterPoint, MidpointRounding.AwayFromZero);

            return result;
        }
    }
}
