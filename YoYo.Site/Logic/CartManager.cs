using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoYo.Site.Logic
{
    public class CartManager
    {
        IProductRepository _productRepository;

        public CartManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(int productId)
        {
            var products = _productRepository.GetCookieData();
            products.Cart.Add(productId);
            _productRepository.PutCookieData(products);
        }

        public void RemoveProduct(int productId)
        {
            var products = _productRepository.GetCookieData();
            products.Cart.Remove(productId);
            _productRepository.PutCookieData(products);
        }

        public List<int> GetProducts()
        {
            var result = _productRepository.GetCookieData();
            return result.Cart;
        }

        public int Summa()
        {
            List<int> selectedProducts = GetProducts();
            ShopEntities dbShop = new ShopEntities();
            int Sum = 0;
            if (selectedProducts != null)
            {
                foreach (var product in selectedProducts)
                {
                    foreach (var pr in dbShop.Products)
                    {
                        if (product == pr.id)
                        {
                            Sum = Sum + pr.Price.Value;
                        }
                    }
                }
            }
            return Sum;
        }
    }
}