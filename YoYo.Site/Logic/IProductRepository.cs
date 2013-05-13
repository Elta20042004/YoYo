using System;
using System.Collections.Generic;
namespace WebApplication4.Logic
{
    public interface IProductRepository
    {
        List<int> GetProducts();
        void PutProducts(List<int> products);
    }
}
