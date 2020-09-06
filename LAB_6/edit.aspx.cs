using System;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace AdoDemo
{
    public partial class edit : System.Web.UI.Page
    {
        int n;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["constr"] == null)
            {
                string constr = WebConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
                Application["constr"] = constr;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (string)Application["constr"];
            int id = Int32.Parse(numid.Text);
            Session["id"] = id;
            try
            {
                using (con)
                {
                    string command = "select * from student_info where id = @id";
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lbname.Visible = true;
                        txtname.Text = rdr["name"].ToString();
                        txtname.Visible = true;
                        lbsem.Visible = true;
                        numsem.Text = rdr["sem"].ToString();
                        numsem.Visible = true;
                        lbmob.Visible = true;
                        nummob.Text = rdr["mob_no"].ToString();
                        nummob.Visible = true;
                        lbemail.Visible = true;
                        txtemail.Text = rdr["email_id"].ToString();
                        txtemail.Visible = true;
                        butupdate.Visible = true;
                    }
                    rdr.Close();
                }
            }
            catch (Exception err)
            {
                lbconerr1.Text = "Error in Connection : ";
                lbconerr1.Text += err.Message;
            }
        }

        protected void butupdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = (string)Application["constr"];
            int id = (int)Session["id"];
            string name = txtname.Text;
            int sem = Int32.Parse(numsem.Text);
            long mob = Int64.Parse(nummob.Text);
            string email = txtemail.Text;
            try
            {
                using (con)
                {
                    string command = "update student_info set name=@name, sem=@sem, mob_no=@mob, email_id=@email where id = @id";
                    SqlCommand cmd = new SqlCommand(command, con);
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name",txtname.Text);
                    cmd.Parameters.AddWithValue("@sem", Int32.Parse(numsem.Text));
                    cmd.Parameters.AddWithValue("@mob", Int64.Parse(nummob.Text));
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    n = cmd.ExecuteNonQuery();
                    lbrow.Text = n.ToString();
                    lbconerr2.Text = "Student Details Updated.";
                    lbconerr2.ForeColor = Color.Green;
                }
            }
            catch (Exception err)
            {
                lbconerr2.Text = "Error in Connection : ";
                lbconerr2.Text += err.Message;
                lbconerr2.ForeColor = Color.Red;
            }
        }
    }
}