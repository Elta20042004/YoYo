using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoYo.Common.Entities;

namespace YoYo.Site
{
    public partial class _Default : Page
    {
        private const string NavigateUrl = "~/Shop.aspx?Category={0}";
        protected void Page_Load(object sender, EventArgs e)
        {
            var dbShop = new ShopEntities();
            var temp = dbShop.Category.ToList();
            var shop = dbShop.Category.Select(p => p);
            foreach (var c in shop)
            {
                string url = string.Format(NavigateUrl, c.id);
                var menuItem = new MenuItem(c.Name, c.id.ToString(), "", url);
                menuBar.Items.Add(menuItem);
            }
        }

        protected void ListView_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
