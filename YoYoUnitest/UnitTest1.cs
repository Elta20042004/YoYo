using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebApplication4.Logic;

namespace YoYoUnitest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Serialize()
        {
            ProductManager manager = new ProductManager(new FileRepository());
            manager.AddProduct(1);
            manager.AddProduct(2);
            List<int> current = manager.GetProducts();
        }
    }
}
