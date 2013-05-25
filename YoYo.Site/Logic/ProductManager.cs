using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Logic
{
    public class ProductManager
    {
        IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(int productId)
        {
            var products = _productRepository.GetProducts();
            products.Add(productId);
            _productRepository.PutProducts(products);
        }

        public void RemuveProduct(int productId)
        {
            var products = _productRepository.GetProducts();
            products.Remove(productId);
            _productRepository.PutProducts(products);
        }

        public List<int> GetProducts()
        {
            var result = _productRepository.GetProducts();
            return result;
        }

        public int Summa()
        {
            IList<int> selectedProducts = GetProducts();
            ShopEntities dbShop = new ShopEntities();
            int Sum = 0;
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

            return Sum;
        }
    }
}