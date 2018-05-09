using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using System.Collections.Generic;

namespace Epam.Demo.SaleTerminalLibrary.Models
{
    public class Pricing : IPricing
    { 
        private readonly Dictionary<string, ProductInfo> prices = new Dictionary<string, ProductInfo>();


        public void SetSinglePrice(string productCode, decimal productPrice)
        {
            if (prices.ContainsKey(productCode))
            {
                prices[productCode].SinglePrice.Value = productPrice;
            }
            else
            {
                ProductInfo productInfo = new ProductInfo();
                productInfo.SinglePrice = new Price{ Value = productPrice };
               
                prices.Add(productCode, productInfo);
            }
        }


        public void SetVolumePrice(string productCode, decimal productVolumePrice, uint minimalVolume)
        {
            var productPrice = new Price
            {
                Value = productVolumePrice,
            };

            if (prices.ContainsKey(productCode))
            {
                prices[productCode].VolumePrice = productPrice;
                prices[productCode].Volume = minimalVolume;
            }
            else
            {
                ProductInfo productInfo = new ProductInfo { VolumePrice = productPrice};
                prices.Add(productCode, productInfo);
            }
        }

        public void SetPackPrice(string productCode, decimal productPackPrice, uint packCount)
        {
            var productPrice = new Price
            {
                Value = productPackPrice,
            };

            if (prices.ContainsKey(productCode))
            {
                prices[productCode].PackPrice = productPrice;
                prices[productCode].Volume = packCount;
            }
            else
            {
                ProductInfo productInfo = new ProductInfo { VolumePrice = productPrice };
                prices.Add(productCode, productInfo);
            }
        }


        public decimal? GetVolumePrice(string productCode)
        {
            decimal? result = null;
            if(prices.ContainsKey(productCode))
            {
                result = prices[productCode].VolumePrice?.Value;
            }
            return result;
        }

        public uint GetMinVolume(string productCode)
        {
            uint result = 0;
            if (prices.ContainsKey(productCode))
            {
                result = prices[productCode].Volume;
            }
            return result;
        }


        public decimal? GetSinglePrice(string productCode)
        {
            decimal? result = null;
            if (prices.ContainsKey(productCode))
            {
                result = prices[productCode].SinglePrice?.Value;
            }
            return result;
        }

        public decimal? GetPackPrice(string productCode)
        {
            decimal? result = null;
            if (prices.ContainsKey(productCode))
            {
                result = prices[productCode].PackPrice?.Value;
            }
            return result;
        }

        public bool ContainsKey(string productCode)
        {
            return prices.ContainsKey(productCode);
        }
    }
}
