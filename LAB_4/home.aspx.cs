using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDemo
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lfname.Text = txtfname.Text;
                lage.Text = numage.Text;
                lgender.Text = radgender.Text;
                lmob.Text = nummob.Text;
                lhob.Text = "";
                foreach (ListItem var in checkbhob.Items)
                {
                    if (var.Selected)
                        lhob.Text = lhob.Text + " " + var;
                }
                lstate.Text = ddstate.Text;
                lcity.Text = ddcity.Text;
                lpan.Text = numpan.Text;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = ddstate.Text.ToString();
            if(s.Equals("Gujarat"))
            {
                ddcity.Items.Clear();
                ddcity.Items.Add("Ahmedabad");
                ddcity.Items.Add("Vadodara");
            }
            else if(s.Equals("Maharashtra"))
            {
                ddcity.Items.Clear();
                ddcity.Items.Add("Mumbai");
                ddcity.Items.Add("Pune");
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string pan = args.Value;
            args.IsValid = false;
            if (args.Value == "" || pan.Length != 10 || (pan[0] != 'A' && pan[0] != 'B'))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}