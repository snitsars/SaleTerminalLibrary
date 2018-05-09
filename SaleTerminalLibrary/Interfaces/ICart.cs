using System.Collections;

namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    public interface ICart : IEnumerable
    {
        void AddProductItem(string productCode);

        void RemoveProductItem(string productCode);

        new IEnumerator GetEnumerator();
    }
}