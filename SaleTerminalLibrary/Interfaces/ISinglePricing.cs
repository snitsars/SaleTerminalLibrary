namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    public interface ISinglePricing
    {
        /// <summary>
        /// Method for set price of product
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productPrice"></param>
        void SetPrice(string productCode, decimal productPrice);

        /// <summary>
        /// Method for get price from products
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        decimal? GetPrice(string productCode);
    }
}