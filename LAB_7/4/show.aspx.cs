using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQdemo1
{
    public partial class show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext dbcontext = new DataClasses1DataContext();
            GridView1.DataSource = from student in dbcontext.students select new { student.sid, student.name };
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("insert.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("update.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("delete.aspx");
        }
    }
}