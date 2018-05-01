using System;
using System.Collections.Generic;
using Epam.Demo.SaleTerminalLibrary.Algorithms;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary
{
    /// <summary>
    /// Class of point-of-sale that accepts an arbitrary ordering of products 
    /// and calculate summary price 
    /// </summary>
    public class PointOfSaleTerminal
    {
        private byte optionSignAfterPoint = 2;

        private readonly ICart productCart = new Cart();
        private readonly IPricingAlgorithm totalPriceCalculator = new PricingPackAlgorithm();
        private IPricing pricingValue;


        /// <summary>
        /// Method for set pricing of product 
        /// prices per unit and volume prices
        /// </summary>
        public Pricing PricesTable
        {
            set => pricingValue = value;
        }


        /// <summary>
        /// Scan product method
        /// </summary>
        public void Scan(string productCode)
        {
            productCart.AddProductItem(productCode);
        }


        /// <summary>
        /// Calculate price of all products entire shopping cart 
        /// </summary>
        /// <returns></returns>
        public decimal CalculateTotal()
        {
            decimal result = 0;
            foreach (KeyValuePair<string, uint> product in productCart)
            {
                result += totalPriceCalculator.Calculate(product.Key, product.Value, pricingValue);
            }
            result = decimal.Round(result, optionSignAfterPoint, MidpointRounding.AwayFromZero);

            return result;
        }
    }
}
