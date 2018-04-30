using System.Collections.Generic;

namespace Epam.Demo.SaleTerminalLibrary.Models
{
    /// <summary>
    /// Class contained information about products prices single and volume.
    /// </summary>
    public class Pricing
    {
        private Dictionary<string, double> prices = new Dictionary<string, double>();
        private Dictionary<string, KeyValuePair<double, int>> volumePrices = new Dictionary<string, KeyValuePair<double, int>>();


        /// <summary>
        /// Method for set price of product
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productPrice"></param>
        public void SetPrice(string productCode, double productPrice)
        {
            if (prices.ContainsKey(productCode))
            {
                prices[productCode] = productPrice;
            }
            else
            {
                prices.Add(productCode, productPrice);
            }
        }


        /// <summary>
        /// Method for set volume price and minimal count of products
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productVolumePrice"></param>
        /// <param name="minimalVolume"></param>
        public void SetVolumePrice(string productCode, double productVolumePrice, int minimalVolume)
        {
            if (volumePrices.ContainsKey(productCode))
            {
                var productInfo = new KeyValuePair<double, int>(productVolumePrice, minimalVolume);
                volumePrices[productCode] = productInfo;
            }
            else
            {
                volumePrices.Add(productCode, new KeyValuePair<double, int>(productVolumePrice, minimalVolume));
            }
        }


        /// <summary>
        /// Method for get volume price and minimal count from products
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public KeyValuePair<double, int> GetVolumePrice(string productCode)
        {
            volumePrices.TryGetValue(productCode, out var pairResult);
            return pairResult;
        }


        /// <summary>
        /// Method for get price from products
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public double? GetPrice(string productCode)
        {
            if (prices.TryGetValue(productCode, out var price))
            {
                return price;
            }
            return null;
        }
    }
}
