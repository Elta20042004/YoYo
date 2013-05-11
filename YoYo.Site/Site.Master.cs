using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopEntities dbShop = new ShopEntities();

            NavigationMenu.Items[1].ChildItems.Clear();
            foreach (var category in dbShop.Categories)
            {
                var menuItem = new MenuItem(category.Name, category.id.ToString(), "", category.NavigateUrl);
                NavigationMenu.Items[1].ChildItems.Add(menuItem);
            }
        }


        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            
        }
    }
}

