using Epam.Demo.SaleTerminalLibrary.Common;

namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    public interface IPricing
    {
        bool Contains(string productCode);
        /*uint GetMinVolume(string productCode);
        decimal? GetSinglePrice(string productCode);
        decimal? GetVolumePrice(string productCode);
        decimal? GetPackPrice(string productCode);*/
        void SetSinglePrice(string productCode, decimal productPrice);
        void SetVolumePrice(string productCode, decimal productVolumePrice, uint minimalVolume);
        void SetPackPrice(string productCode, decimal productPackPrice, uint packCount);
        ITotalCounting GetCountingAlgorithm(string productCode);
    }
}