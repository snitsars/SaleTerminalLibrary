namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    /// <summary>
    /// Interface that describe price of products that can be buy in set
    /// </summary>
    public interface IVolumePrice: IPrice
    {
        /// <summary>
        /// Minimal count of products for use volume price
        /// </summary>
        uint MinimalCount { get; set; }
    }
}