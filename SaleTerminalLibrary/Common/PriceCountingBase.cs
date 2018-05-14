using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary.Common
{
    public class PriceCountingBase
    {
        protected readonly ProductInfo productInfo;

        public PriceCountingBase(ProductInfo productInfo)
        {
            this.productInfo = productInfo;
        }
    }
}