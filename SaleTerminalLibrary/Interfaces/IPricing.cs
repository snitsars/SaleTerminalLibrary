using Epam.Demo.SaleTerminalLibrary.Common;

namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    public interface IPricing
    {
        /// <summary>
        /// Determines whether the contains pricing the specified key
        /// </summary>
        bool ContainsKey(string productCode);
        
        
        /// <summary>
        /// Set price of single product
        /// </summary>
        void SetSinglePrice(string productCode, decimal productPrice);

        
        /// <summary>
        /// Get single product's price 
        /// </summary>
        decimal? GetSinglePrice(string productCode);
        
        
        /// <summary>
        /// Set volume price and minimal count of product
        /// </summary>
        void SetVolumePrice(string productCode, decimal productVolumePrice, uint minimalVolume);


        /// <summary>
        /// Get product's price and minimal volume
        /// </summary>
        VolumePrice GetVolumePrice(string productCode);
    }
}