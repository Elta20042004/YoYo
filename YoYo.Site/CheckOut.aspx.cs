using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication4.Logic;

namespace WebApplication4
{


    public partial class CheckOut : System.Web.UI.Page
    {
        CartManager _productManager;

        public CheckOut()
        {
            _productManager = new CartManager(new CookieRepository());
        }
        public static Product New;
        //public static List<Product> CheckOutProducts = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Remove_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int productId = int.Parse(e.CommandArgument.ToString());
                _productManager.RemoveProduct(productId);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Refresh()
        {
            IList<int> selectedProductId = _productManager.GetProducts();           
            Dictionary<int, int> productSelection = new Dictionary<int, int>();
            foreach (int product in selectedProductId)
            {
                if (!productSelection.ContainsKey(product))
                {
                    productSelection.Add(product, 1);
                }
                else
                {
                    productSelection[product] = productSelection[product]+1;
                }
            }

            ShopEntities dbShop = new ShopEntities();
            List<CheckOutProduct> selectedProducts = new List<CheckOutProduct>();

            foreach (Product product in dbShop.Products)
            {
                if (productSelection.ContainsKey(product.id))
                {
                    CheckOutProduct temp = new CheckOutProduct();
                    temp.id = product.id;
                    temp.Picture = product.Picture;
                    temp.Name = product.Name;
                    temp.Price = product.Price;
                    temp.Quantity = productSelection[product.id];
                    selectedProducts.Add(temp);
                }
            }

            ListView_Products.DataSource = selectedProducts;
            ListView_Products.DataBind();
        }

        public class CheckOutProduct : Product
        {
            public int Quantity
            {
                get;
                set;
            }
        }
    }


}