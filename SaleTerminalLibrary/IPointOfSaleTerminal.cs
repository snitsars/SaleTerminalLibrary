namespace Epam.Demo.SaleTerminalLibrary
{
    public interface IPointOfSaleTerminal
    {
        decimal CalculateTotal();
        void Scan(string productCode);
    }
}