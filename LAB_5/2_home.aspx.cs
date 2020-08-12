using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagDemo
{
    public partial class home : System.Web.UI.Page
    {
        Dictionary<string, int> electDict = new Dictionary<string, int>();
        Dictionary<string, int> bookDict = new Dictionary<string, int>();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!(IsPostBack))
            {
                Dictionary<string, int> selectedItem = new Dictionary<string, int>();
                Session["itemDict"] = selectedItem;
            }
            lusr.Text = Session["username"].ToString();
            electDict.Add("Laptop", 50000);
            electDict.Add("GPU", 20000);
            electDict.Add("RAM", 4000);
            bookDict.Add("The Alchemist", 699);
            bookDict.Add("Sherlock Holmes", 499);
            bookDict.Add("Jeet Apki", 199);
        }

        protected void rblitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemtype = rblitem.SelectedValue;
            if("Electronics".Equals(itemtype))
            {
                lbitem.Items.Clear();
                foreach(string item in electDict.Keys)
                {
                    lbitem.Items.Add(item);
                }
            }
            else if("Books".Equals(itemtype))
            {
                lbitem.Items.Clear();
                foreach (string item in bookDict.Keys)
                {
                    lbitem.Items.Add(item);
                }
            }
            else
            {
                lbitem.Items.Clear();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("order.aspx");
        }

        protected void lbitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemtype = rblitem.SelectedValue;
            int i = lbitem.SelectedIndex;
            if(i != -1)
            {
                Dictionary<string, int> selectedItem = (Dictionary<string, int>)Session["itemDict"];
                string item;
                int cost;
                foreach (ListItem li in lbitem.Items)
                {
                    if (li.Selected == true)
                    {
                        item = li.Value;
                        switch (itemtype)
                        {
                            case "Electronics":
                                cost = electDict[item];
                                if(!(selectedItem.ContainsKey(item)))
                                    selectedItem.Add(item, cost);
                                break;
                            case "Books":
                                cost = bookDict[item];
                                if (!(selectedItem.ContainsKey(item)))
                                    selectedItem.Add(item, cost);
                                break;
                        }
                    }
                }
            }
        }
    }
}