using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary
{
    public class PricingPackAlgorithm : IPricingAlgorithm
    {
        public double Accuracy { get; set; }

        public double Calculate(string productCode, uint productCount, Pricing pricing)
        {
            IPrice result = new Price();

            IVolumePrice volumePriceInfo = pricing.GetVolumePrice(productCode);
            double? singlePriceInfo = pricing.GetPrice(productCode);

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