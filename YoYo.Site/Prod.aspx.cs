using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoYo.Common.Entities;
using YoYo.Site.Logic;
using YoYo.Site.Logic.ClientStorage;

namespace YoYo.Site
{
    public partial class Prod : System.Web.UI.Page
    {
        private readonly CartManager _cartManager;
        private readonly RecentlyViewedManager _rvManager;
        public Prod()
        {
            var repository = new CookieUserDataRepository();
            _cartManager = new CartManager(repository);
            _rvManager = new RecentlyViewedManager(repository);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShopEntities dbShop = new ShopEntities();
            var shopProduct = dbShop.Product.Select(t => t);
            IEnumerable<Product> products = shopProduct;

            if (HttpContext.Current.Request.QueryString.AllKeys.Contains("productID"))
            {
                int productId = int.Parse(HttpContext.Current.Request.QueryString["productID"]);
                products = products.Where(t => t.id == productId);

                Product first = products.First();
                imageBigPicture.ImageUrl ="Images/Products/Big/"+first.Picture;
                labelProdectName.Text = first.Name;
                labelDescription.Text = first.Price.ToString();
                labelDescription1.Text = first.Description;
                HttpContext.Current.Session.Add("productID", first.id.ToString());
                _rvManager.AddProduct(productId);
            }                    
        }

        protected void lnkAddToCart_Click(object sender, EventArgs e)
        {
            string param = HttpContext.Current.Session.Contents["productID"].ToString();
            int productId = int.Parse(param);
            _cartManager.AddProduct(productId);
            Response.Redirect(Request.RawUrl);
        }
    }
}