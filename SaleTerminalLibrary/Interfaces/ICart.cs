using System.Collections;
using System.Collections.Generic;

namespace Epam.Demo.SaleTerminalLibrary.Interfaces
{
    public interface ICart : IEnumerable
    {
        /// <summary>
        /// Method for add product item to cart or increment count of product if 
        /// similar product in the cart
        /// </summary>
        /// <param name="productCode"></param>
        void AddProductItem(string productCode);

        /// <summary>
        /// Methods for decrement prouct count if similar product in cart
        /// or remove product from cart if count less than one.
        /// This method can throw excetion if product code do not find.
        /// </summary>
        /// <param name="productCode"></param>
        /// <exception cref="KeyNotFoundException">When try to remove not exist product code </exception>
        void RemoveProductItem(string productCode);

        /// <summary>
        /// Get enumerator for products, can be used in for eache loop
        /// </summary>
        /// <returns></returns>
        IEnumerator GetEnumerator();
    }
}