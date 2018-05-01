namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    public interface IPointOfSaleTerminal
    {
        decimal CalculateTotal();
        void Scan(string productCode);
    }
}