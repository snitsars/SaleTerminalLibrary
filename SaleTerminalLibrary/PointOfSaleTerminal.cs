using System;
using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary
{
    /// <summary>
    /// Class of point-of-sale that accepts an arbitrary ordering of products 
    /// and calculate summary price 
    /// </summary>
    public class PointOfSaleTerminal
    {
        private Cart productCart = new Cart();
        private PricingAlgorithm priceAlgorithm;
        private Pricing pricingValue;


        /// <summary>
        /// Method for set pricing of product 
        /// prices per unit and volume prices
        /// </summary>
        public Pricing SetPricing
        {
            set { pricingValue = value; }
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
        public Double CalculateTotal()
        {
            return 0;
        }
    }
}
