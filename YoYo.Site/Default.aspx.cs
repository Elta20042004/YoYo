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

            IEnumerable<Product> products = dbShop.Products;

            if (HttpContext.Current.Request.QueryString.AllKeys.Contains("Category"))
            {
                int categoryID = int.Parse(HttpContext.Current.Request.QueryString["Category"].ToString());
                products = products.Where(t => t.CategoryId == categoryID);
            }
            ListView_Products.DataSource = products;
            ListView_Products.DataBind();
            menuBar.Items.Clear();
            foreach (var category in dbShop.Categories)
            {
                var menuItem = new MenuItem(category.Name, category.id.ToString(), "", category.NavigateUrl);
                menuBar.Items.Add(menuItem);
            }
        }

        protected void menuBar_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void ListView_Products_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Color_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Lena - pupsik
            ShopEntities dbShop = new ShopEntities();

            IEnumerable<Product> products = dbShop.Products;
            List<int> selectedColors = new List<int>();

            foreach (object ColorProduct in Color.Items)
            {
                ListItem typedItem = ColorProduct as ListItem;
                if (typedItem != null && 
                    typedItem.Selected)
                {
                    int newtypedItem = int.Parse(typedItem.Value);
                    selectedColors.Add(newtypedItem);
                }
            }

            var colorProducts = products.Where(t => selectedColors.Contains(t.Color));
            ListView_Products.DataSource = colorProducts;
            ListView_Products.DataBind();
        }
    }
}
