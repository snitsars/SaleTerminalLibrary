namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    public interface IAlgorithmTotalCounting
    {
        decimal Calculate(string productCode, uint productCount,
            decimal? singlePrice, decimal? volumePrice, decimal? packPrice, uint? minVolume);
    }
}