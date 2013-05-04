using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class New : System.Web.UI.Page
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
        }


        protected void Color_OnSelectedIndexChanged(object sender, EventArgs e)
        {          
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