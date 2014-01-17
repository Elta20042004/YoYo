using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{


    public partial class Shop : System.Web.UI.Page
    {
        
        int categoryID;
        protected void Page_Load(object sender, EventArgs e)
        {                
            if (HttpContext.Current.Request.QueryString.AllKeys.Contains("Category"))
            {
                categoryID = int.Parse(HttpContext.Current.Request.QueryString["Category"]);                
            }
            ListView_Products.DataSource = GetCategoryProducts();
            ListView_Products.DataBind();                       
        }

        protected IEnumerable<Product> GetCategoryProducts()
        {
            ShopEntities dbShop = new ShopEntities();

            IEnumerable<Product> products = dbShop.Products;
            products = products.Where(t => t.CategoryId == categoryID);
            return (products);
        
        }

        protected void Color_OnSelectedIndexChanged(object sender, EventArgs e)
        {          
           
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

            var colorProducts = GetCategoryProducts().Where(t => selectedColors.Contains(t.Color));
            ListView_Products.DataSource = colorProducts;
            ListView_Products.DataBind();
        }

        
     
    }
}