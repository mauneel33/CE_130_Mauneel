using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQdemo1
{
    public partial class insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dbcontext = new DataClasses1DataContext();
            int length = (from x in dbcontext.students select x.sid).Max();
            student s = new student
            {
                sid = length + 1,
                name = txtname.Text,
                sem = Int32.Parse(numsem.Text),
                cpi = txtcpi.Text,
                contactno = txtcontact.Text,
                emailid = txtemail.Text
            };
            dbcontext.students.InsertOnSubmit(s);
            dbcontext.SubmitChanges();
        }
    }
}