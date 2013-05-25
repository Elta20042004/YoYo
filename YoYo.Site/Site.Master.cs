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

            Bag.Text = "Bag " + "(" + _productManager.Summa().ToString() + "$" +")";
        }

      

        //public int Summa()
        //{
        //    IList<int> selectedProducts = _productManager.GetProducts();
        //    ShopEntities dbShop = new ShopEntities();
        //    return selectedProducts.Join(dbShop.Products, t => t, f => f.id, (rt, rf) => rf.Price.Value)
        //                           .Sum();
        //}


        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
    }
}

