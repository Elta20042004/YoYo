using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoYo.Site.Logic;

namespace YoYo.Site
{
    public partial class Prod : System.Web.UI.Page
    {
        CartManager _productManager;
        RecentlyViewedManager _rvManager;
        public Prod()
        {
            var repository = new CookieUserDataRepository();
            _productManager = new CartManager(repository);
            _rvManager = new RecentlyViewedManager(repository);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShopEntities dbShop = new ShopEntities();

            IEnumerable<Product> products = dbShop.Products;

            if (HttpContext.Current.Request.QueryString.AllKeys.Contains("productID"))
            {
                int productId = int.Parse(HttpContext.Current.Request.QueryString["productID"]);
                products = products.Where(t => t.id == productId);

                Product One = products.First();
                imageBigPicture.ImageUrl ="Images/Products/Big/"+One.Picture;
                labelProdectName.Text = One.Name;
                labelDescription.Text = One.Price.ToString();
                labelDescription1.Text = One.Description;
                HttpContext.Current.Session.Add("productID", One.id.ToString());
                _rvManager.AddProduct(productId);

            }                    
        }

        protected void lnkAddToCart_Click(object sender, EventArgs e)
        {
            string param = HttpContext.Current.Session.Contents["productID"].ToString();
            int productId = int.Parse(param);
            _productManager.AddProduct(productId);
            Response.Redirect(Request.RawUrl);
        }
    }
}