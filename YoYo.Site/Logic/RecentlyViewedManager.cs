using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoYo.Site.Logic
{
    public class RecentlyViewedManager
    {
        private readonly IProductRepository _productRepository;

        public RecentlyViewedManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(int productId)
        {
            var products = _productRepository.GetCookieData();
            if (products.RecentlyViewed == null)
            {
                products.RecentlyViewed = new List<int>();
            }
            products.RecentlyViewed.Add(productId);
            _productRepository.PutCookieData(products);

        }

        public void RemoveProduct(int productId)
        {
            var products = _productRepository.GetCookieData();
            products.RecentlyViewed.Remove(productId);
            _productRepository.PutCookieData(products);
        }

        public List<int> GetProducts()
        {
            var result = _productRepository.GetCookieData();
            return result.RecentlyViewed;
        }
    }
}