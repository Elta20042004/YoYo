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
        CartManager _productManager;
        RecentlyViewedManager _rvManager;
        public SiteMaster()
        {
            var repository = new CookieRepository();
            _productManager = new CartManager(repository);
            _rvManager = new RecentlyViewedManager(repository);
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
            Refresh();
        }

        protected void Refresh()
        {
            IList<int> selectedProductId = _rvManager.GetProducts();
            if (selectedProductId == null)
            {
                return;
            }
            Dictionary<int, int> productSelection = new Dictionary<int, int>();
            foreach (int product in selectedProductId)
            {
                if (!productSelection.ContainsKey(product))
                {
                    productSelection.Add(product, 1);
                }
                else
                {
                    productSelection[product] = productSelection[product] + 1;
                }
            }

            ShopEntities dbShop = new ShopEntities();
            List<Product> selectedProducts = new List<Product>();

            foreach (Product product in dbShop.Products)
            {
                if (productSelection.ContainsKey(product.id))
                {
                    Product temp = new Product();
                    temp.id = product.id;
                    temp.Picture = product.Picture;                  
                    selectedProducts.Add(temp);
                }
            }

            RV_Products.DataSource = selectedProducts;
            RV_Products.DataBind();
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

