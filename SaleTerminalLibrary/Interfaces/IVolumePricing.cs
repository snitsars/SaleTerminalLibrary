namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    public interface IVolumePricing
    {
        /// <summary>
        /// Method for set volume price and minimal count of products
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productVolumePrice"></param>
        /// <param name="minimalVolume"></param>
        void SetVolumePrice(string productCode, decimal productVolumePrice, uint minimalVolume);

        /// <summary>
        /// Method for get volume price and minimal count from products
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        IVolumePrice GetVolumePrice(string productCode);
    }
}