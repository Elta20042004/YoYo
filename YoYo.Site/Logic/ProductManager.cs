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
    }
}