using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Algorithms
{
    /// <summary>
    /// Class provide algorithm implememntation of calculation total price for all items of product
    /// </summary>
    public class PricingVolumeAlgorithm : IPricingAlgorithm
    {
        /// <summary>
        /// Implementation of method for calculate total price of volume product based on single and volume price from pricing
        /// </summary>
        public decimal Calculate(string productCode, uint productCount, decimal? singlePrice, decimal? volumePrice, uint? minVolume)
        {
            var result = new Price();

            if (volumePrice != null && minVolume !=null && productCount >= minVolume)
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