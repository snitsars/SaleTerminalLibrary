using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary.Algorithms
{
    public class PricingPackAlgorithm : IPricingAlgorithm
    {
        public decimal Calculate(string productCode, uint productCount, Pricing pricing)
        {
            IPrice result = new Price();

            IVolumePrice volumePriceInfo = pricing.GetVolumePrice(productCode);
            decimal? singlePriceInfo = pricing.GetPrice(productCode);

            if (productCount >= volumePriceInfo?.MinimalCount && singlePriceInfo != null)
            {
                var countOfPack = productCount / volumePriceInfo.MinimalCount;
                var counOfFreeItems = productCount % volumePriceInfo.MinimalCount;
                result.Value += countOfPack * volumePriceInfo.MinimalCount * volumePriceInfo.Value;
                result.Value += counOfFreeItems * singlePriceInfo.Value;
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