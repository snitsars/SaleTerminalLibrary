using System.Collections;
using System.Collections.Generic;

namespace Epam.Demo.SaleTerminalLibrary.Models
{

    /// <summary>
    /// Class for save products that scaned and ready to sale
    /// </summary>
    public class Cart : IEnumerable
    {
        private readonly Dictionary<string, uint> products = new Dictionary<string, uint>();


        /// <summary>
        /// Method for add product item to cart or increment count of product if 
        /// similar product in the cart
        /// </summary>
        /// <param name="productCode"></param>
        public void AddProductItem(string productCode)
        {
            if (!products.ContainsKey(productCode))
            {
                products.Add(productCode,0);
            }
            
            products[productCode]++;
        }


        /// <summary>
        /// Methods for decrement prouct count if similar product in cart
        /// or remove product from cart if count less than one.
        /// This method can throw excetion if product code do not find.
        /// </summary>
        /// <param name="productCode"></param>
        /// <exception cref="KeyNotFoundException">When try to remove not exist product code </exception>
        public void RemoveProductItem(string productCode)
        {
            if (products.ContainsKey(productCode))
            {
                products[productCode]--;
                if (products[productCode] <= 0)
                    products.Remove(productCode);
            }
            else
            {
                throw new  KeyNotFoundException($"You are trying to remove product {productCode} missing in the cart");
            }

        }


        /// <summary>
        /// Get enumerator for products, can be used in for eache loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return products.GetEnumerator();
        }
    }
}