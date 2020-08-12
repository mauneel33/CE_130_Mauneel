using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagDemo
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string usr = txtusnm.Text;
            string pass = txtpass.Text;
            if("user1".Equals(usr) && "user1".Equals(pass))
            {
                Session["username"] = usr;
                Response.Redirect("home.aspx");
            }
            else 
            {
                linvalid.Text = "Invalid Credentials!";
            }
        }
    }
}