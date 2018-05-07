using System.Collections.Generic;
using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Models
{
    /// <summary>
    /// Class contained information about products prices single and volume.
    /// </summary>
    public class Pricing : IPricing
    {
        private readonly Dictionary<string, Price> prices = new Dictionary<string, Price>();
        private readonly Dictionary<string, VolumePrice> volumePrices = new Dictionary<string, VolumePrice>();


        /// <summary>
        /// Implementation of method SetSinglePrice of product
        /// </summary>
        public void SetSinglePrice(string productCode, decimal productPrice)
        {
            if (prices.ContainsKey(productCode))
            {
                prices[productCode].Value = productPrice;
            }
            else
            {
                Price productPriceInfo = new Price {Value = productPrice};
                prices.Add(productCode, productPriceInfo);
            }
        }


        /// <summary>
        /// Method for set volume price and minimal count of products
        /// </summary>
        public void SetVolumePrice(string productCode, decimal productVolumePrice, uint minimalVolume)
        {
            var productPriceInfo = new VolumePrice
            {
                Value = productVolumePrice,
                MinimalVolume = minimalVolume
            };

            if (volumePrices.ContainsKey(productCode))
            {
                volumePrices[productCode] = productPriceInfo;
            }
            else
            {
                volumePrices.Add(productCode, productPriceInfo);
            }
        }


        /// <summary>
        /// Method for get volume price and minimal count from products
        /// </summary>
        public VolumePrice GetVolumePrice(string productCode)
        {
            volumePrices.TryGetValue(productCode, out var result);
            return result;
        }


        /// <summary>
        /// Method for get price from products
        /// </summary>
        public decimal? GetSinglePrice(string productCode)
        {
            if (prices.TryGetValue(productCode, out var priceInfo))
            {
                return priceInfo.Value;
            }
            return null;
        }


        /// <summary>
        /// Determines whether the contains pricing the specified key 
        /// </summary>
        public bool ContainsKey(string productCode)
        {
            return prices.ContainsKey(productCode) || volumePrices.ContainsKey(productCode);
        }
    }
}
