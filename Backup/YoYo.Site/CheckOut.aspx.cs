using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class CheckOut : System.Web.UI.Page
    {
        
        public static Product New;
        public static List<Product> CheckOutProducts = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListView_Products.DataSource = CheckOutProducts;
            ListView_Products.DataBind();               
            
        }
    }
}