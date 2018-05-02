using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Algorithms
{
    /// <summary>
    /// Class provide algorithm of calculation total price for all items of product
    /// </summary>
    public class PricingPackAlgorithm : IPricingAlgorithm
    {
        /// <summary>
        /// Method for calculate price for products that can be order by volume prices
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productCount"></param>
        /// <param name="singlePrice"></param>
        /// <param name="volumePrice"></param>
        /// <returns></returns>
        public decimal Calculate(string productCode, uint productCount, decimal? singlePrice, IVolumePrice volumePrice)
        {
            IPrice result = new Price();

            if (productCount >= volumePrice?.MinimalCount && singlePrice != null)
            {
                var countOfPack = productCount / volumePrice.MinimalCount;
                var counOfFreeItems = productCount % volumePrice.MinimalCount;
                result.Value += countOfPack * volumePrice.MinimalCount * volumePrice.Value;
                result.Value += counOfFreeItems * singlePrice.Value;
            }
            else
            {
                if (singlePrice != null)
                    result.Value = productCount * singlePrice.Value;
            }

            return result.Value;
        }
    }
}