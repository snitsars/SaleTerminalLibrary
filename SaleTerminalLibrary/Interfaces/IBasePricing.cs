namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    public interface IBasePricing 
    {
        /// <summary>
        /// Determines whether the contains pricing the specified key
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        bool ContainsKey(string productCode);
    }
}