using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    class PackPriceCounting : PriceCountingBase, ITotalCountingEx
    {
        
        public PackPriceCounting(ProductInfo productInfo) : 
            base(productInfo)
        {
        }

        public decimal Calculate(uint productCount)
        {
            decimal result = 0;
            if (productInfo.Volume > 0)
            {
                var countOfPack = productCount / productInfo.Volume;
                var counOfFreeItems = productCount % productInfo.Volume;
                if (counOfFreeItems > 0)
                {
                    result += countOfPack * productInfo.PackPrice.Value;
                    result += counOfFreeItems * productInfo.SinglePrice.Value;
                }
                else
                {
                    result += countOfPack * productInfo.Volume;
                }
            }

            return result;
        }
    }
}
