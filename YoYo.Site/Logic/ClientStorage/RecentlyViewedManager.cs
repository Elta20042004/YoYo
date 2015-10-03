using System.Collections.Generic;

namespace YoYo.Site.Logic.ClientStorage
{
    public class RecentlyViewedManager
    {
        private readonly IUserDataRepository _productRepository;

        public RecentlyViewedManager(IUserDataRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(int productId)
        {
            var products = _productRepository.GetUserData();
            if (products.RecentlyViewed == null)
            {
                products.RecentlyViewed = new List<int>();
            }

            products.RecentlyViewed.Add(productId);
            _productRepository.SaveUserData(products);
        }

        public void RemoveProduct(int productId)
        {
            var products = _productRepository.GetUserData();
            products.RecentlyViewed.Remove(productId);
            _productRepository.SaveUserData(products);
        }

        public List<int> GetProducts()
        {
            var result = _productRepository.GetUserData();
            return result.RecentlyViewed;
        }
    }
}