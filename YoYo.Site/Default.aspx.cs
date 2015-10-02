using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;

namespace YoYo.Site
{
    public partial class _Default : Page
    {
        private const string NavigateUrl = "~/Shop.aspx?Category={0}";
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopEntities dbShop = new ShopEntities();
            foreach (var category in dbShop.Categories)
            {
                string url = string.Format(NavigateUrl, category.id);
                var menuItem = new MenuItem(category.Name, category.id.ToString(), "", url);
                menuBar.Items.Add(menuItem);
            }
        }

        protected void ListView_Products_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
