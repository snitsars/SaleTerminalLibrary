using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Epam.Demo.SaleTerminalLibrary
{

    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private const byte OptionSignAfterPoint = 2;
        private readonly ICart cart;
        private readonly IPricing prices;
        


        public PointOfSaleTerminal(ICart cart, IPricing prices)
        {
            this.prices = prices;
            this.cart = cart;
        }


        public void Scan(string productCode)
        {
            if (!prices.Contains(productCode))
            {
                throw new KeyNotFoundException($"You are trying to scan product {productCode} missing in the pricing");
            }

            cart.AddProductItem(productCode);
        }


        public decimal CalculateTotal()
        {
            decimal result = 0m;
            
            foreach (KeyValuePair<string, uint> product in cart)
            {
                var algorithm = prices?.GetCountingAlgorithm(product.Key);
                if (algorithm != null)
                {
                    result += algorithm.Calculate(product.Value);
                }
            }
            result = decimal.Round(result, OptionSignAfterPoint, MidpointRounding.AwayFromZero);

            return result;
        }
    }
}