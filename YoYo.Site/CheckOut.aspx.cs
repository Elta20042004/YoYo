using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoYo.Site.Logic;

namespace YoYo.Site
{


    public partial class CheckOut : System.Web.UI.Page
    {
        CartManager _productManager;

        public CheckOut()
        {
            _productManager = new CartManager(new CookieRepository());
        }
        public static Product New;
        //public static List<Product> CheckOutProducts = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Remove_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int productId = int.Parse(e.CommandArgument.ToString());
                _productManager.RemoveProduct(productId);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}