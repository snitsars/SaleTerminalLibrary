using Epam.Demo.SaleTerminalLibrary.Models;

namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    /// <summary>
    /// Intrface for define method of price calculation algorithm
    /// </summary>
    public interface IPricingAlgorithm
    {
        double Calculate(string productCode, uint productCount, Pricing pricing);
    }
}