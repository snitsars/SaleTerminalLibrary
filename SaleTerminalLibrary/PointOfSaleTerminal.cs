using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace Epam.Demo.SaleTerminalLibrary
{

    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private const byte OptionSignAfterPoint = 2;
        private readonly ICart cart;
        private readonly IPricing prices;
        private readonly IAlgorithmTotalCounting totallPrice;


        public PointOfSaleTerminal(ICart cart, IPricing prices)
        {
            this.prices = prices;
            this.cart = cart;
            totallPrice = new TotallCounting();
        }


        public void Scan(string productCode)
        {
            if (!prices.ContainsKey(productCode))
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
                var price = prices?.GetSinglePrice(product.Key);
                var volumPrice = prices?.GetVolumePrice(product.Key);
                var packPrice = prices?.GetPackPrice(product.Key);
                var minimalVolume = prices?.GetMinVolume(product.Key);

                result += totallPrice.Calculate(product.Key, product.Value, price, volumPrice, packPrice, minimalVolume);
            }

            result = decimal.Round(result, OptionSignAfterPoint, MidpointRounding.AwayFromZero);

            return result;
        }
    }
}