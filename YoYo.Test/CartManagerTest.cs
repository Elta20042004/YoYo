using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using YoYo.Site.Logic;
using YoYo.Site.Logic.ClientStorage;

namespace YoYo.Test
{
    [TestClass]
    public class CartManagerTest
    {
        [TestMethod]
        public void Serialize()
        {
            CartManager manager = new CartManager(new CookieUserDataRepository());
            manager.AddProduct(1);
            manager.AddProduct(2);
            List<int> current = manager.GetProducts();
        }
    }
}
