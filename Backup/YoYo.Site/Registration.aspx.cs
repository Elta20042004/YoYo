using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Onclick(object sender, EventArgs e)
        {
            User h = new User();
            h.First_Name = txtFirstName.Text;
            h.Last_Name = txtLastName.Text;
            h.Email = TextEmail.Text;
            h.Password = TextPassword.Text;

            ShopEntities dbShop = new ShopEntities();
            dbShop.Users.AddObject(h);
            dbShop.SaveChanges();
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int counter = 0;
            ShopEntities dbShop = new ShopEntities();
            foreach (var user in dbShop.Users)
            {
                if (user.Email == TextEmail.Text)
                {
                    counter = counter + 1;
                }
            }
            args.IsValid = counter == 0;
        }
    }
}