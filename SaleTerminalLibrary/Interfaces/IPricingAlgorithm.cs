namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    /// <summary>
    /// Intrface for define method of price calculation algorithm
    /// </summary>
    public interface IPricingAlgorithm
    {
        /// <summary>
        /// Method for calculate total price of product based on single volume and pack priced from pricing
        /// </summary>
        decimal Calculate(string productCode, uint productCount, decimal? singlePrice, decimal? volumePrice, uint? minVolume);
    }
}