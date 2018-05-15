using Epam.Demo.SaleTerminalLibrary.Interfaces;
using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    class RegularPriceCounting : PriceCountingBase, ITotalCounting
    {

        public RegularPriceCounting(ProductInfo productInfo):
            base (productInfo)
        {
        }

        public decimal Calculate(uint productCount)
        {
            return productCount * productInfo.SinglePrice.Value;
        }
    }
}
