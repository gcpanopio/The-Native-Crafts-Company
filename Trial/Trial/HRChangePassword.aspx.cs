using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Trial
{
    public partial class HRChangePassword : System.Web.UI.Page
    {
        string oldpassword;
        string newpassword;
        string retype;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand com;
        DataSet ds1;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            ds1 = new DataSet();

            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";

            if (Convert.ToBoolean(Session["changed"]) == true)
            {
                Label1.Text = "Password updated!";
                Session["changed"] = false;
            }

            if (Convert.ToBoolean(Session["error1"]) == true)
            {
                Label1.Text = "Passwords do not match";
                Session["error1"] = false;
            }

            if (Convert.ToBoolean(Session["error2"]) == true)
            {
                Label1.Text = "Incorrect password. Please try again";
                Session["error2"] = false;
            }

            if (Convert.ToBoolean(Session["length"]) == true)
            {
                Label1.Text = "Password length must be at least 6 characters";
                Session["error2"] = false;
            }
            con.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int employeeNo = Convert.ToInt32(Session["empNo"]);

            oldpassword = TextBox1.Text;
            newpassword = TextBox2.Text;
            retype = TextBox3.Text;

            string sql = "SELECT * FROM LOGIN WHERE [password] COLLATE Latin1_General_CS_AS ='" + oldpassword + "' ";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(ds1, "LOGIN");

            DataRow dRow;
            try
            {
                dRow = ds1.Tables["LOGIN"].Rows[0];
                if (newpassword.Length >= 6 && retype.Length >= 6)
                {
                    if (newpassword.Equals(retype))
                    {
                        sql = "UPDATE [LOGIN] SET [password]='" + newpassword + "' WHERE [employee_no]=" + employeeNo;
                        com = new SqlCommand(sql, con);
                        com.ExecuteNonQuery();
                        Session["changed"] = true;
                        Response.Redirect("HRChangePassword.aspx", false);
                    }
                    else
                    {
                        Session["error1"] = true;
                        Response.Redirect("HRChangePassword.aspx", false);
                    }
                }
                else
                {
                    Session["length"] = true;
                    Response.Redirect("HRChangePassword.aspx", false);
                }
            }
            catch (System.IndexOutOfRangeException error)
            {
                Session["error2"] = true;
                Response.Redirect("HRChangePassword.aspx", false);
            }


            con.Close();
            con.Dispose();
        }
    }
}