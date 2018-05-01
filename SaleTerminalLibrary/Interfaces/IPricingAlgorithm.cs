using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    /// <summary>
    /// Intrface for define method of price calculation algorithm
    /// </summary>
    public interface IPricingAlgorithm
    {
        /// <summary>
        /// Calculate total price for product based on single volume and pack priced from pricing
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productCount"></param>
        /// <param name="pricing"></param>
        /// <returns></returns>
        decimal Calculate(string productCode, uint productCount, Pricing pricing);
    }
}