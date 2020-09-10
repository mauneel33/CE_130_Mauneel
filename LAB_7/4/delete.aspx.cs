using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQdemo1
{
    public partial class delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dbcontext = new DataClasses1DataContext();
            student s = dbcontext.students.SingleOrDefault(x => x.sid == Int32.Parse(numsid.Text));
            dbcontext.students.DeleteOnSubmit(s);
            dbcontext.SubmitChanges();
            Response.Redirect("show.aspx");
        }
    }
}