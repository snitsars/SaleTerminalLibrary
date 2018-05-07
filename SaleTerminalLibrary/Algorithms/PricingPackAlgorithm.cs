using Epam.Demo.SaleTerminalLibrary.Common;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Algorithms
{
    /// <summary>
    /// Class provide algorithm implememntation of calculation total price for all items of product
    /// </summary>
    public class PricingPackAlgorithm : IPricingAlgorithm
    {
        /// <summary>
        /// Implementation of method for calculate total price of pack product based on single and pack price from pricing
        /// </summary>
        public decimal Calculate(string productCode, uint productCount, decimal? singlePrice, decimal? volumePrice, uint? minVolume)
        {
            Price result = new Price();

            if (volumePrice != null && minVolume !=null && productCount >= minVolume && singlePrice != null)
            {
                var countOfPack = productCount / minVolume.Value;
                var counOfFreeItems = productCount % minVolume.Value;
                result.Value += countOfPack * minVolume.Value * volumePrice.Value;
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