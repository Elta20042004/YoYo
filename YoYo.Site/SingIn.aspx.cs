using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YoYo.Site
{
    public partial class SingIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ShopEntities db = new ShopEntities();

            IEnumerable<User> users = db.Users ;

            foreach (var Pipla in db.Users)
            {
                if ((Pipla.Email == txtLogin.Text) && (Pipla.Password == TextParol.Text))
                {
                    Response.Write("<script>window.open('Default.aspx')</script>");
                }
                else
                {
                    Label.Visible = true;
                }
            }

        
        }
    }
}