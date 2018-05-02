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
        /// <param name="singlePrice"></param>
        /// <param name="volumePrice"></param>
        /// <returns></returns>
        decimal Calculate(string productCode, uint productCount, decimal? singlePrice, IVolumePrice volumePrice);
    }
}