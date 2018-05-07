using System.Collections;

namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    public interface ICart : IEnumerable
    {
        /// <summary>
        /// Method for add product item to cart 
        /// or increment count of product if similar product in the cart
        /// </summary>
        void AddProductItem(string productCode);

        /// <summary>
        /// Methods for remove product from cart 
        /// or decrement prouct count if similar product in cart
        /// This method can throw excetion if product code do not find.
        /// </summary>
        /// <exception cref="KeyNotFoundException">When try to remove not exist product code </exception>
        void RemoveProductItem(string productCode);

        /// <summary>
        /// Get enumerator for products, can be used in for eache loop
        /// </summary>
        new IEnumerator GetEnumerator();
    }
}