using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDemo
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string usr = TextBox1.Text.ToString();
            string pswd = TextBox2.Text.ToString();
            if(usr.Equals("admin") && pswd.Equals("admin"))
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                Label3.Text = "Incorrect Credentials!";
            }
        }
    }
}