using System;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace AdoDemo
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Butlog_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            try
            {
                using (con)
                {
                    string command = "select password from [user] where userid=@id";
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@id", Int32.Parse(numid.Text));
                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    string pass = (string)rdr["password"];
                    if (pass.Equals(txtpass.Text))
                    {
                        Session["userid"] = Int32.Parse(numid.Text);
                        Response.Redirect("product.aspx");
                    }
                    else
                        Response.Write("Incorrect Credentials.");
                }
            }
            catch (Exception err)
            {
                Response.Write("Error in Connection : ");
                Response.Write(err.Message);
            }
        }
    }
}