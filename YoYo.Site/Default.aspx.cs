using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Objects;

namespace WebApplication4
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopEntities dbShop = new ShopEntities();
            foreach (var category in dbShop.Categories)
            {
                var menuItem = new MenuItem(category.Name, category.id.ToString(), "", category.NavigateUrl);
                menuBar.Items.Add(menuItem);
            }
        }

        protected void ListView_Products_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
