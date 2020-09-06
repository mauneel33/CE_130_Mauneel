using System;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Drawing;


namespace AdoDemo
{
    public partial class show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            string constr = WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            con.ConnectionString = constr;
            try
            {
                using (con)
                {
                    string command = "select * from student_info";
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.Connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    griddetail.DataSource = rdr;
                    griddetail.DataBind();
                    rdr.Close();
                }
            }
            catch (Exception err)
            {
                lbconerr.Text = "Error in Connection : ";
                lbconerr.Text += err.Message;
            }
        }
    }
}