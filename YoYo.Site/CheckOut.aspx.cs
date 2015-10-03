using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoYo.Site.Logic;
using YoYo.Site.Logic.ClientStorage;

namespace YoYo.Site
{
    public partial class CheckOut : Page
    {
        private readonly CartManager _productManager;

        public CheckOut()
        {
            _productManager = new CartManager(new CookieUserDataRepository());
        }

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