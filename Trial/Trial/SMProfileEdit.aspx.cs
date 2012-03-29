using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Trial
{
    public partial class SMProfileEdit : System.Web.UI.Page
    {
        int employeeNo;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds1;

        protected void Page_Load(object sender, EventArgs e)
        {
            employeeNo = Convert.ToInt32(Session["empNo"]);
            con = new SqlConnection();
            ds1 = new DataSet();

            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";

            con.Open();

            string sql = "SELECT * FROM EMPLOYEEPROFILE WHERE [employee_no] like '" + employeeNo + "'";
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds1, "EMPLOYEEPROFILE");
            DisplayProfile();
        }

        private void DisplayProfile()
        {
            DataRow dRow;
            dRow = ds1.Tables["EMPLOYEEPROFILE"].Rows[0];
            Label1.Text = employeeNo.ToString();
            Label2.Text = dRow.ItemArray.GetValue(1).ToString() + ", " + dRow.ItemArray.GetValue(2).ToString() + " " + dRow.ItemArray.GetValue(3).ToString();
            Label6.Text = date(dRow.ItemArray.GetValue(8).ToString().Substring(0, 10));
            Label7.Text = dRow.ItemArray.GetValue(9).ToString();
            Label9.Text = dRow.ItemArray.GetValue(7).ToString();
            Label8.Text = dRow.ItemArray.GetValue(6).ToString();
            Label12.Text = date(dRow.ItemArray.GetValue(12).ToString().Substring(0, 10));
            String position = dRow.ItemArray.GetValue(4).ToString();
            String location = dRow.ItemArray.GetValue(5).ToString();

            if (!IsPostBack)
            {
                TextBox1.Text = dRow.ItemArray.GetValue(13).ToString();
                TextBox2.Text = dRow.ItemArray.GetValue(11).ToString();
                TextBox3.Text = dRow.ItemArray.GetValue(10).ToString();
            }

            string sql = "SELECT [Position] FROM POSITION WHERE [Position_ID] like '" + position + "'";
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds1, "Position");

            dRow = ds1.Tables["Position"].Rows[0];
            Label10.Text = dRow.ItemArray.GetValue(0).ToString();

            sql = "SELECT [Location_Address] FROM LOCATION WHERE [Location_No] like '" + location + "'";
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds1, "Location");

            dRow = ds1.Tables["Location"].Rows[0];
            Label13.Text = dRow.ItemArray.GetValue(0).ToString();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TextBox1.Text.Equals("")) || (TextBox2.Text.Equals("")) || (TextBox3.Text.Equals("")))
                {
                    Label14.Text = "All fields must have a value.";
                }
                else
                {
                    String commandString = " UPDATE EMPLOYEEPROFILE SET [address]='" + TextBox1.Text + "', [contact_no]=" + TextBox2.Text + ",  [email]='" + TextBox3.Text + "' WHERE [employee_no]=" + employeeNo;
                    SqlCommand cmd = new SqlCommand(commandString, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    con.Dispose();

                    Response.Redirect("SMProfile.aspx", false);
                    Session["profileUpdate"] = 1;
                }
            }
            catch (Exception err)
            {
                Label14.Text = "Incorrect input.";
            }
        }

        public string date(string given)
        {
            string editedDate = "";
            string[] parsedGiven = given.Split('/');
            string month = parsedGiven[0];
            if (month.Equals("1"))
                editedDate = "January";
            else if (month.Equals("2"))
                editedDate = "February";
            else if (month.Equals("3"))
                editedDate = "March";
            else if (month.Equals("4"))
                editedDate = "April";
            else if (month.Equals("5"))
                editedDate = "May";
            else if (month.Equals("6"))
                editedDate = "June";
            else if (month.Equals("7"))
                editedDate = "July";
            else if (month.Equals("8"))
                editedDate = "August";
            else if (month.Equals("9"))
                editedDate = "September";
            else if (month.Equals("10"))
                editedDate = "October";
            else if (month.Equals("11"))
                editedDate = "November";
            else if (month.Equals("12"))
                editedDate = "December";
            editedDate = editedDate + " " + parsedGiven[1] + ", " + parsedGiven[2];
            return editedDate;
        }
    }
}