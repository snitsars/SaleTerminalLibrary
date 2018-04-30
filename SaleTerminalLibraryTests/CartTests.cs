using NUnit.Framework;
using Epam.Demo.SaleTerminalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Demo.SaleTerminalLibrary.Tests
{
    [TestFixture()]
    public class CartTests
    {
        [Test()]
        public void When_CartEmptyAndCallAddProductItem_Expected_CartWithProductCountOne()
        {
            const string expectedProductCode = "A";
            const int expectedProductCount = 1;

            Cart cart = new Cart();
            cart.AddProductItem(expectedProductCode);
            int productCount = 0;
            string productCode = "";
            foreach (KeyValuePair<string, int> product in cart)
            {
                productCode = product.Key;
                productCount = product.Value;
            }
            Assert.That(productCode == expectedProductCode && productCount == expectedProductCount);
        }

        [Test()]
        public void When_CartNotEmptyAndCallAddProductItemForExistProduc_Expected_CartWithProductCountMoreThanOne()
        {
            const string expectedProductCode = "A";
            const int expectedProductCount = 4;

            Cart cart = new Cart();
            cart.AddProductItem(expectedProductCode);
            cart.AddProductItem(expectedProductCode);
            cart.AddProductItem(expectedProductCode);
            cart.AddProductItem(expectedProductCode);
            int productCount = 0;
            string productCode = "";
            foreach (KeyValuePair<string, int> product in cart)
            {
                productCode = product.Key;
                productCount = product.Value;
            }
            Assert.That(productCode == expectedProductCode && productCount == expectedProductCount);
        }

        [Test()]
        public void When_CartEmptyAndCallAddProductItemForNewProduct_Expected_CartWith2ProductsCountOfEach1()
        {
            List<string> initialProducts = new List<string>() { "A", "B"};
            Dictionary<string, int> expectedProductsCodeAndCount = new Dictionary<string, int>() { {"A",1},{"B",1}};

            Cart cart = new Cart();
            foreach (var product in initialProducts)
            {
                cart.AddProductItem(product);
            }
            
            CollectionAssert.AreEqual(expectedProductsCodeAndCount, cart);
        }


        [Test()]
        public void When_CartEmpty_CallAddProductItemForExistProduct_Expected_CartWithProducts()
        {
            List<string> initialProducts = new List<string>() { "A", "A", "B", "B", "B", "C" };
            Dictionary<string, int> expectedProductsCodeAndCount = new Dictionary<string, int>() {{ "A", 2 }, { "B", 3 }, {"C", 1}};
 
            Cart cart = new Cart();
            foreach(var product in initialProducts)
            {
                cart.AddProductItem(product);
            }

            CollectionAssert.AreEqual(expectedProductsCodeAndCount, cart);
        }

        [Test()]
        public void When_CartNotEmpty_CallRemoveProductItem_Expected_CorrectProductListAndCountOfEach()
        {
            List<string> initialProducts = new List<string>() { "A", "A", "B", "B", "B", "C" };
            Dictionary<string, int> expectedProductsCodeAndCount = new Dictionary<string, int>() { { "A", 1 }, { "B", 2 }, { "C", 1 } };

            Cart cart = new Cart();
            foreach (var product in initialProducts)
            {
                cart.AddProductItem(product);
            }

            cart.RemoveProductItem("A");
            cart.RemoveProductItem("B");

            CollectionAssert.AreEqual(expectedProductsCodeAndCount, cart);
        }

        [Test()]
        public void When_CartNotEmpty_CallRemoveProductItemForProductWithCount1_Expected_CartWithoutThisProduct()
        {
            List<string> initialProducts = new List<string>() { "A", "A", "B", "B", "B", "C" };
            Dictionary<string, int> expectedProductsCodeAndCount = new Dictionary<string, int>() { { "A", 2 }, { "B", 3 } };

            Cart cart = new Cart();
            foreach (var product in initialProducts)
            {
                cart.AddProductItem(product);
            }

            cart.RemoveProductItem("C");

            CollectionAssert.AreEqual(expectedProductsCodeAndCount, cart);
        }


        [Test()]
        public void When_CartEmpty_CallRemoveProductItemForNotExistProduct_Expected_Exception()
        {
            Cart cart = new Cart();
            Assert.Throws<KeyNotFoundException>(() => cart.RemoveProductItem("C"));
        }
    }
}