using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication4.Logic;

namespace WebApplication4
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        ProductManager _productManager;

        public SiteMaster()
        {
            _productManager = new ProductManager(new FileRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShopEntities dbShop = new ShopEntities();

            NavigationMenu.Items[1].ChildItems.Clear();
            foreach (var category in dbShop.Categories)
            {
                var menuItem = new MenuItem(category.Name, category.id.ToString(), "", category.NavigateUrl);
                NavigationMenu.Items[1].ChildItems.Add(menuItem);
            }

            Bag.Text = "Bag " + Summa().ToString();


        }

        public int Summa()
        {
            IList<int> SummaProducts = _productManager.GetProducts();
            ShopEntities dbShop = new ShopEntities();
            int Sum = 0;
            foreach (var product in dbShop.Products)
            {               
                if (SummaProducts.Contains(product.id)&& product.Price.HasValue)
                {
                    Sum = Sum + product.Price.Value;
                }
            
            }

            return Sum;
        }


        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            
        }
    }
}

