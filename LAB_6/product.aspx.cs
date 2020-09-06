using System;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoDemo
{
    public partial class product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            try
            {
                using (con)
                {
                    string command = "select * from [product]";
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.Connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    gridprod.DataSource = rdr;
                    gridprod.DataBind();
                    rdr.Close();
                    rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        ListItem li = new ListItem();
                        li.Text = (string)rdr["pname"];
                        li.Value = (string)rdr["pname"];
                        listprod.Items.Add(li.Text);
                    }
                }
            }
            catch (Exception err)
            {
                Response.Write("Error in Connection : ");
                Response.Write(err.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            foreach(ListItem i in listprod.Items)
            {
                if(i.Selected)
                {
                    l.Add(i.Value);
                }
            }
            Session["items"] = l;
            Response.Redirect("order.aspx");
        }
    }
}