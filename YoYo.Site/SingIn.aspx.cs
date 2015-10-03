using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YoYo.Site.Logic.ServerStorage;

namespace YoYo.Site
{
    public partial class SingIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var users = CachedUsers.Instance;
            var user = users.GetUser(txtLogin.Text);
            if (user !=null && user.Password == TextParol.Text)
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