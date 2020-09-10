using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQdemo1
{
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lbcontact.Visible = true;
            txtcontact.Visible = true;
            lbname.Visible = true;
            txtname.Visible = true;
            lbsem.Visible = true;
            numsem.Visible = true;
            txtcpi.Visible = true;
            lbcpi.Visible = true;
            lbemail.Visible = true;
            txtemail.Visible = true;
            Button2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dbcontext = new DataClasses1DataContext();
            student s = dbcontext.students.SingleOrDefault(x => x.sid == Int32.Parse(numsid.Text));
            s.name = txtname.Text;
            s.sem = Int32.Parse(numsem.Text);
            s.cpi = txtcpi.Text;
            s.contactno = txtcontact.Text;
            s.emailid = txtemail.Text;
            dbcontext.SubmitChanges();
            Response.Redirect("show.aspx");
        }
    }
}