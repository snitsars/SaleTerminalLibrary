using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Algorithms
{
    /// <summary>
    /// Class derrive implemetation of calculation price algorithm for volume buyers
    /// </summary>
    public class PricingVolumeAlgorithm : IPricingAlgorithm
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
            var result = new Price();

            if (productCount >= volumePrice?.MinimalCount)
            {
                result.Value = productCount * volumePrice.Value;
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