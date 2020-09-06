using System;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Drawing;
namespace AdoDemo
{
    public partial class insert : System.Web.UI.Page
    {
        int n;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Application["dbcon"] == null)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
                Application["dbcon"] = con;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = (SqlConnection)Application["dbcon"];
            try
            {
                using (con)
                {
                    string command = "insert into student_info(name, sem, mob_no, email_id) values(@name, @sem, @mob, @email)";
                    SqlCommand cmd = new SqlCommand(command,con);
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@name",txtname.Text);
                    cmd.Parameters.AddWithValue("@sem",Int32.Parse(numsem.Text));
                    cmd.Parameters.AddWithValue("@mob",Int64.Parse(nummob.Text));
                    cmd.Parameters.AddWithValue("@email",txtemail.Text);
                    n = cmd.ExecuteNonQuery();
                    lconerr.Text = "Student details inserted successfully.";
                    lconerr.ForeColor = Color.Green;
                }
            }
            catch(Exception err)
            {
                lconerr.Text = "Error in Connection : ";
                lconerr.Text += err.Message;
            }
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }
    }
}