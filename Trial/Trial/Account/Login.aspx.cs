using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Trial.Account
{
    public partial class Login : System.Web.UI.Page
    {
        string username;
        string password;
        System.Data.SqlClient.SqlConnection con;
        System.Data.SqlClient.SqlDataAdapter da;
        DataSet ds1;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new System.Data.SqlClient.SqlConnection();
            ds1 = new DataSet();

            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";
            con.Open();
            
            if (Convert.ToBoolean(Session["retrieve"]) == true)
            {
                Label1.Text = "You can check your email for further instructions about your password retrieval";
                Session["retrieve"] = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int employeeNo = 0;
            int locationNo;
            string locationName;

            username = TextBox1.Text;
            password = TextBox2.Text;

            string sql = "SELECT [employee_no] FROM LOGIN WHERE [username] COLLATE Latin1_General_CS_AS = '" + username + "' AND [password] COLLATE Latin1_General_CS_AS = '" + password + "'";
            da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
            da.Fill(ds1, "LOGIN");
            
            DataRow dRow;
            
            try {
                int position;
                dRow = ds1.Tables["LOGIN"].Rows[0];
                employeeNo = Convert.ToInt32(dRow.ItemArray.GetValue(0).ToString());
                Session["empNo"] = employeeNo;

                sql = "SELECT [position], [location] FROM EMPLOYEEPROFILE WHERE [employee_no]=" + employeeNo;
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds1, "Position");

                dRow = ds1.Tables["Position"].Rows[0];
                position = Convert.ToInt32(dRow.ItemArray.GetValue(0).ToString());
                locationNo = Convert.ToInt32(dRow.ItemArray.GetValue(1).ToString());
                Session["locNo"] = locationNo;

                sql = "SELECT [Location_Name] FROM LOCATION WHERE [Location_No]='" + locationNo + "'";
                da = new System.Data.SqlClient.SqlDataAdapter(sql, con);
                da.Fill(ds1, "LOCATION");
                dRow = ds1.Tables["LOCATION"].Rows[0];
                locationName = dRow.ItemArray.GetValue(0).ToString();
                Session["locName"] = locationName;

                if (position == 4)
                    Response.Redirect("~/HRProfile.aspx", false);
                else if (position == 2)
                    Response.Redirect("~/UMProfile.aspx", false);
                else if (position ==3)
                    Response.Redirect("~/SMProfile.aspx", false);
                else if (position == 1)
                       Response.Redirect("~/AgentProfile.aspx", false);

            }
            catch (System.IndexOutOfRangeException error){
                 Label1.Text = "Incorrect login. Please try again";
            }
            
                       
            con.Close();
            con.Dispose();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ForgotPassword.aspx", false);
        }
    }
}
