using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication4.Logic;

namespace WebApplication4
{
    
    
    public partial class CheckOut : System.Web.UI.Page
    {
        ProductManager _productManager;

        public CheckOut()
        {
            _productManager = new ProductManager(new FileRepository());
        }
        public static Product New;
        //public static List<Product> CheckOutProducts = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Refrash();
        }

        protected void Remove_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName=="Remove")
            {
                int productId = int.Parse(e.CommandArgument.ToString());
                _productManager.RemuveProduct(productId);
                Refrash();
            }
        }
            protected void Refrash()
        {
            List<int> SelectedProductId = _productManager.GetProducts();
            ShopEntities dbShop = new ShopEntities();
            List<Product> selectedProducts = new List<Product>();
            foreach (var product in dbShop.Products)
            {
                if (SelectedProductId.Contains(product.id))
                {
                    selectedProducts.Add(product);
                }

            }
            ListView_Products.DataSource = selectedProducts;
            ListView_Products.DataBind();
        }
    }
}