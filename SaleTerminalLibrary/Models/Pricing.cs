﻿using Epam.Demo.SaleTerminalLibrary.Common;
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
                productInfo.PriceCounting = new RegularPriceCounting(productInfo);
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
                productInfo.PriceCounting = new VolumeTotalCounting(productInfo);
                prices.Add(productCode, productInfo);
            }
            prices[productCode].PriceCounting = new VolumeTotalCounting(prices[productCode]);
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
            prices[productCode].PriceCounting = new PackPriceCounting(prices[productCode]);
        }


        public ITotalCounting GetCountingAlgorithm(string productCode)
        {
            ITotalCounting result = null;
            if (prices.ContainsKey(productCode))
            {
                result = prices[productCode].PriceCounting;
            }
            return result;
        }

        public bool Contains(string productCode)
        {
            return prices.ContainsKey(productCode);
        }
    }
}
