using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Foto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopEntities dbShop = new ShopEntities();

            IEnumerable<Product> products = dbShop.Products;

            if (HttpContext.Current.Request.QueryString.AllKeys.Contains("productID"))
            {
                int productId = int.Parse(HttpContext.Current.Request.QueryString["productID"].ToString());
                products = products.Where(t => t.id == productId);

                Product One = products.First();
                imageBigPicture.ImageUrl = One.PictureBig;
                labelProdectName.Text = One.Name;
                labelDescription.Text = One.Price.ToString();
                CheckOut.New = One;
            }                    
        }

        protected void ListView_Products_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void buttonChechOut_Click(object sender, EventArgs e)
        {

            CheckOut.CheckOutProducts.Add(CheckOut.New);
            Response.Write("<script>window.open('CheckOut.aspx')</script>");
        }
    }
}