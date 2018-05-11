using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    public class TotallCounting: IAlgorithmTotalCounting
    {
        public decimal Calculate(string productCode, uint productCount,
            decimal? singlePrice, decimal? volumePrice, decimal? packPrice, uint? minVolume)
        {
            var result = new Price();

            if (volumePrice != null && minVolume != null && minVolume > 0 && productCount >= minVolume)
            {
                result.Value = productCount * volumePrice.Value;
            }
            else if (packPrice != null && minVolume != null && minVolume > 0 && productCount >= minVolume)
            {
                result.Value = GetPackPrice(productCount, singlePrice, packPrice.Value, minVolume.Value);
            }
            else
            {
                if (singlePrice != null)
                    result.Value = productCount * singlePrice.Value;
            }

            return result.Value;
        }

        private decimal GetPackPrice(uint productCount, decimal? singlePrice, decimal packPrice, uint minVolume)
        {
            decimal result = 0;
            if (minVolume > 0)
            {
                var countOfPack = productCount / minVolume;
                var counOfFreeItems = productCount % minVolume;
                if (counOfFreeItems > 0 && singlePrice != null)
                {
                    result += countOfPack * packPrice;
                    result += counOfFreeItems * singlePrice.Value;
                }
                else
                {
                    result += countOfPack * packPrice;
                }
            }

            return result;
        }
    }
}