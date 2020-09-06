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
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> l = (List<string>)Session["items"];
            long totcost = 0;
            int id = (Int32)Session["userid"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            try
            {
                using (con)
                {
                    foreach(string i in l)
                    {
                        string command = "select * from [product] where pname=@pname";
                        string command2 = "insert into [order] (oid, userid, pid) values(@oid, @userid, @pid)";
                        SqlCommand cmd1 = new SqlCommand(command, con);
                        cmd1.Parameters.AddWithValue("@pname",i);
                        cmd1.Connection.Open();
                        SqlDataReader rdr = cmd1.ExecuteReader();
                        rdr.Read();
                        string pname = rdr["pname"].ToString();
                        int pid = Int32.Parse(rdr["pid"].ToString());
                        long cost = Int32.Parse(rdr["cost"].ToString());
                        totcost += cost;
                        string s = pname + "\t\tRs. " + cost;
                        listdetail.Items.Add(s);
                        cmd1.Connection.Close();
                        SqlCommand cmd2 = new SqlCommand(command2, con);
                        cmd2.Parameters.AddWithValue("@oid", 1);
                        cmd2.Parameters.AddWithValue("@userid", id);
                        cmd2.Parameters.AddWithValue("@pid", pid);
                        cmd2.Connection.Open();
                        int n = cmd2.ExecuteNonQuery();
                        cmd1.Connection.Close();
                    }
                }
            }
            catch (Exception err)
            {
                Response.Write("Error in Connection : ");
                Response.Write(err.Message);
            }
            lbbill.Text = totcost.ToString();
        }
    }
}