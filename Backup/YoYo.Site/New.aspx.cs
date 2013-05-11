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

        int categoryID;
        protected void Page_Load(object sender, EventArgs e)
        {                
            if (HttpContext.Current.Request.QueryString.AllKeys.Contains("Category"))
            {
                categoryID = int.Parse(HttpContext.Current.Request.QueryString["Category"].ToString());                
            }
            ListView_Products.DataSource = getCategoryProducts();
            ListView_Products.DataBind();                       
        }

        protected IEnumerable<Product> getCategoryProducts()
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

            var colorProducts = getCategoryProducts().Where(t => selectedColors.Contains(t.Color));
            ListView_Products.DataSource = colorProducts;
            ListView_Products.DataBind();
        }
     
    }
}