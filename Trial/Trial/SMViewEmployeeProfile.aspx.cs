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
    public partial class SMViewEmployeeProfile : System.Web.UI.Page
    {
        int VemployeeNo;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds1;
        //int empNo;

        protected void Page_Load(object sender, EventArgs e)
        {
            //VemployeeNo = Convert.ToInt32(Request.QueryString["id"]);
            VemployeeNo = Convert.ToInt32(Session["VempNo"]);
            //Session["empNo"] = VemployeeNo;
            con = new SqlConnection();
            ds1 = new DataSet();

            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";

            con.Open();

            string sql = "SELECT * FROM EMPLOYEEPROFILE WHERE [employee_no] like '" + VemployeeNo + "'";
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds1, "EMPLOYEEPROFILE");
            DisplayProfile();

            con.Close();
            con.Dispose();
        }

        private void DisplayProfile()
        {
            DataRow dRow;
            dRow = ds1.Tables["EMPLOYEEPROFILE"].Rows[0];
            Label1.Text = VemployeeNo.ToString();
            Label2.Text = dRow.ItemArray.GetValue(1).ToString() + ", " + dRow.ItemArray.GetValue(2).ToString() + " " + dRow.ItemArray.GetValue(3).ToString();
            Label6.Text = date(dRow.ItemArray.GetValue(8).ToString().Substring(0, 10));
            Label7.Text = dRow.ItemArray.GetValue(9).ToString();
            Label3.Text = dRow.ItemArray.GetValue(13).ToString();
            Label9.Text = dRow.ItemArray.GetValue(7).ToString();
            Label8.Text = dRow.ItemArray.GetValue(6).ToString();
            Label5.Text = dRow.ItemArray.GetValue(10).ToString();
            Label4.Text = dRow.ItemArray.GetValue(11).ToString();
            Label12.Text = date(dRow.ItemArray.GetValue(12).ToString().Substring(0, 10));
            String position = dRow.ItemArray.GetValue(5).ToString();
            String location = dRow.ItemArray.GetValue(4).ToString();

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

            int update = Convert.ToInt32(Session["profileUpdate"]);
            if (update == 1)
            {
                Label14.Text = "You're profile is successfully updated!";
                Session["profileUpdate"] = 0;
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
