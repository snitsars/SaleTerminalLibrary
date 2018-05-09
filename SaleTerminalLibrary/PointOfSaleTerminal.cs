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


        public PointOfSaleTerminal(ICart cart, IPricing prices)
        {
            this.prices = prices;
            this.cart = cart;
        }


        public void Scan(string productCode)
        {
            if (!prices.ContainsKey(productCode))
            {
                throw new KeyNotFoundException($"You are trying to scan product {productCode} missing in the pricing");
            }
            cart.AddProductItem(productCode);
        }


        public decimal Calculate(string productCode, uint productCount, 
            decimal? singlePrice, decimal? volumePrice, decimal? packPrice, uint? minVolume)
        {
            var result = new Price();

            if (volumePrice != null && minVolume != null && productCount >= minVolume)
            {
                result.Value = productCount * volumePrice.Value;
            }
            else if (packPrice != null && minVolume != null && productCount >= minVolume)
            {
                GetPackPrice(productCount, singlePrice, packPrice.Value, minVolume.Value, result);
            }
            else
            {
                if (singlePrice != null)
                    result.Value = productCount * singlePrice.Value;
            }

            return result.Value;
        }

        private void GetPackPrice(uint productCount, decimal? singlePrice, decimal packPrice, uint minVolume, Price result)
        {
            var countOfPack = productCount / minVolume;
            var counOfFreeItems = productCount % minVolume;
            if (counOfFreeItems > 0 && singlePrice != null)
            {
                result.Value += countOfPack * packPrice;
                result.Value += counOfFreeItems * singlePrice.Value;
            }
            else
            {
                result.Value += countOfPack * packPrice;
            }
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

                result +=Calculate(product.Key, product.Value, price, volumPrice, packPrice, minimalVolume);
            }
            result = decimal.Round(result, OptionSignAfterPoint, MidpointRounding.AwayFromZero);

            return result;
        }
    }
}
