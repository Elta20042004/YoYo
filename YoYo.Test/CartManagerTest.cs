using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using YoYo.Site.Logic;

namespace YoYoUnitest
{
    [TestClass]
    public class CartManagerTest
    {
        [TestMethod]
        public void Serialize()
        {
            CartManager manager = new CartManager(new CookieRepository());
            manager.AddProduct(1);
            manager.AddProduct(2);
            List<int> current = manager.GetProducts();
        }
    }
}
