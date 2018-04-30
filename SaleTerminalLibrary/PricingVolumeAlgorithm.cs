﻿using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary
{
    /// <summary>
    /// Class derrive implemetation of calculation price algorithm for volume buyers
    /// </summary>
    public class PricingVolumeAlgorithm : IPricingAlgorithm
    {
        public double Accuracy { get; set; }

        /// <summary>
        /// Method for calculate price for products that can be order by volume prices
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productCount"></param>
        /// <param name="pricing"></param>
        /// <returns></returns>
        public double Calculate(string productCode, uint productCount, Pricing pricing)
        {
            IPrice result = new Price();

            IVolumePrice volumePriceInfo = pricing.GetVolumePrice(productCode);
            double? singlePriceInfo = pricing.GetPrice(productCode);

            if (productCount >= volumePriceInfo?.MinimalCount)
            {
                result.Value = productCount * volumePriceInfo.Value;
            }
            else
            {
                if (singlePriceInfo != null)
                    result.Value = productCount * singlePriceInfo.Value;
            }

            return result.Value;
        }
    }
}