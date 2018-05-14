using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    public class VolumeTotalCounting: PriceCountingBase, ITotalCountingEx
    {
        public VolumeTotalCounting(ProductInfo productInfo) : base(productInfo)
        {
        }

        public decimal Calculate(uint productCount)
        {
            var result = new Price();
            if (productCount >= productInfo.Volume)
            {
                result.Value = productCount * productInfo.VolumePrice.Value;
            }
            else
            {
                result.Value = productCount * productInfo.SinglePrice.Value;
            }

            return result.Value;
        }
    }
}