using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoYo.Common.Entities;
using YoYo.Site.Logic;
using YoYo.Site.Logic.ClientStorage;

namespace YoYo.Site
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private readonly CartManager _productManager;
        private readonly RecentlyViewedManager _rvManager;
        public SiteMaster()
        {
            var repository = new CookieUserDataRepository();
            _productManager = new CartManager(repository);
            _rvManager = new RecentlyViewedManager(repository);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            ShopEntities dbShop = new ShopEntities();
            menuMen.DataSource = dbShop.Category.Where(t=>t.ParentID==1).ToList();
            menuMen.DataBind();

            menuWomen.DataSource = dbShop.Category.Where(t => t.ParentID == 2).ToList();
            menuWomen.DataBind();    

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
           
        }

        //public int Sum()
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

