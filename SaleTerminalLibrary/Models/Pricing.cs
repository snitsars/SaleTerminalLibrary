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
        private readonly Dictionary<string, IPrice> prices = new Dictionary<string, IPrice>();
        private readonly Dictionary<string, IVolumePrice> volumePrices = new Dictionary<string, IVolumePrice>();


        /// <summary>
        /// Method for set price of product
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productPrice"></param>
        public void SetPrice(string productCode, decimal productPrice)
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
        /// <param name="productCode"></param>
        /// <param name="productVolumePrice"></param>
        /// <param name="minimalVolume"></param>
        public void SetVolumePrice(string productCode, decimal productVolumePrice, uint minimalVolume)
        {
            var productPriceInfo = new VolumePrice
            {
                Value = productVolumePrice,
                MinimalCount = minimalVolume
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
        /// <param name="productCode"></param>
        /// <returns></returns>
        public IVolumePrice GetVolumePrice(string productCode)
        {
            volumePrices.TryGetValue(productCode, out var result);
            return result;
        }


        /// <summary>
        /// Method for get price from products
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public decimal? GetPrice(string productCode)
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
        /// <param name="productCode"></param>
        /// <returns></returns>
        public bool ContainsKey(string productCode)
        {
            return prices.ContainsKey(productCode) || volumePrices.ContainsKey(productCode);
        }
    }
}
