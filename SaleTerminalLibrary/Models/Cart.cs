using System.Collections;
using System.Collections.Generic;
using Epam.Demo.SaleTerminalLibrary.Interfaces;

namespace Epam.Demo.SaleTerminalLibrary.Models
{

    public class Cart : ICart
    {
        private readonly Dictionary<string, uint> products = new Dictionary<string, uint>();


        public void AddProductItem(string productCode)
        {
            if (!products.ContainsKey(productCode))
            {
                products.Add(productCode,0);
            }
            
            products[productCode]++;
        }


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


        public IEnumerator GetEnumerator()
        {
            return products.GetEnumerator();
        }
    }
}