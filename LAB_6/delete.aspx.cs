using System;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace AdoDemo
{
    public partial class delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(numid.Text);
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            try
            {
                using (con)
                {
                    string command = "delete from [student_info] where id = @id";
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    int n = cmd.ExecuteNonQuery();
                    lbrow.Text = n.ToString();
                    lbmsg.Text = "Student Details deleted.";
                    lbmsg.ForeColor = Color.Green;
                }
            }
            catch (Exception err)
            {
                lbmsg.Text = "Error in Connection : ";
                lbmsg.Text += err.Message;
                lbmsg.ForeColor = Color.Red;
            }
        }
    }
}