using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagDemo
{
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> items = (Dictionary<string, int>)Session["itemDict"];
            int tcost = 0;
            foreach(KeyValuePair<string,int> keypair in items)
            {
                tcost += keypair.Value;
                string s = keypair.Key + "\t\t\tRs." + keypair.Value;
                lbbill.Items.Add(s);
            }
            lcost.Text = tcost.ToString();
            items.Clear();
        }
    }
}