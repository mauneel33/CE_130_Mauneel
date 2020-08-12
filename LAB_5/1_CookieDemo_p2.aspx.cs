using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagDemo
{
    public partial class CookieDemo_p2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["User"];
            if(cookie == null)
            {
                lname.Text = "No Name";
            }
            else
            {
                lname.Text = cookie["name"];
            }
        }
    }
}