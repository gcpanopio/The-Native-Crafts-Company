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
    public partial class HRViewEmployeeProfileEdit : System.Web.UI.Page
    {
        int VemployeeNo;
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds1;

        protected void Page_Load(object sender, EventArgs e)
        {
            VemployeeNo = Convert.ToInt32(Session["VempNo"]);
            con = new SqlConnection();
            ds1 = new DataSet();

            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";

            con.Open();

            string sql = "SELECT * FROM EMPLOYEEPROFILE WHERE [employee_no] like '" + VemployeeNo + "'";
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds1, "EMPLOYEEPROFILE");
            DisplayProfile();
        }

        private void DisplayProfile()
        {
            DataRow dRow;
            dRow = ds1.Tables["EMPLOYEEPROFILE"].Rows[0];
            Label1.Text = VemployeeNo.ToString();

            String cmdString = "SELECT [location] FROM [EMPLOYEEPROFILE] WHERE ([employee_no]=" + VemployeeNo + ")";
            SqlCommand c = new SqlCommand(cmdString, con);
            String myLoc = Convert.ToString(c.ExecuteScalar());

            cmdString = "SELECT [position] FROM [EMPLOYEEPROFILE] WHERE ([employee_no]=" + VemployeeNo + ")";
            c = new SqlCommand(cmdString, con);
            String myPos = Convert.ToString(c.ExecuteScalar());

            if (!IsPostBack)
            {
                string given = dRow.ItemArray.GetValue(8).ToString().Substring(0, 10);
                string[] parsedGiven = given.Split('/');
                DropDownList4.Text = date(given);
                DropDownList5.Text = parsedGiven[1];
                DropDownList4.SelectedValue = parsedGiven[0];
                DropDownList5.SelectedValue = parsedGiven[1];
                parsedGiven = parsedGiven[2].Split(' ');
                TextBox9.Text = parsedGiven[0];

                given = dRow.ItemArray.GetValue(12).ToString().Substring(0, 10);
                parsedGiven = given.Split('/');
                DropDownList6.Text = date(given);
                DropDownList6.SelectedValue = parsedGiven[0];
                DropDownList7.Text = parsedGiven[1];
                DropDownList7.SelectedValue = parsedGiven[1];
                parsedGiven = parsedGiven[2].Split(' ');
                TextBox10.Text = parsedGiven[0];

                DropDownList8.Text = dRow.ItemArray.GetValue(9).ToString();
                DropDownList8.SelectedValue = dRow.ItemArray.GetValue(9).ToString();

                DropDownList2.Text = dRow.ItemArray.GetValue(5).ToString();
                DropDownList3.Text = dRow.ItemArray.GetValue(4).ToString();
                DropDownList2.SelectedValue = myPos;
                DropDownList3.SelectedValue = myLoc;

                TextBox1.Text = dRow.ItemArray.GetValue(13).ToString();
                TextBox2.Text = dRow.ItemArray.GetValue(11).ToString();
                TextBox3.Text = dRow.ItemArray.GetValue(10).ToString();
                TextBox4.Text = dRow.ItemArray.GetValue(1).ToString();
                TextBox5.Text = dRow.ItemArray.GetValue(6).ToString();
                TextBox6.Text = dRow.ItemArray.GetValue(7).ToString();
                TextBox7.Text = dRow.ItemArray.GetValue(2).ToString();
                TextBox8.Text = dRow.ItemArray.GetValue(3).ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TextBox1.Text.Equals("")) || (TextBox2.Text.Equals("")) || (TextBox3.Text.Equals("")) || (TextBox4.Text.Equals("")) || (TextBox5.Text.Equals("")) || (TextBox6.Text.Equals("")) || (TextBox7.Text.Equals("")) || (TextBox8.Text.Equals("")) || (TextBox9.Text.Equals("")) || (TextBox10.Text.Equals("")))
                {
                    Label12.Text = "All fields must have a value.";
                }
                else
                {
                    if (!(checkSSSTIN(TextBox5.Text, TextBox6.Text)))
                    {
                        Label12.Text = "Employee with similar SSS or TIN detected.";
                    }
                    else
                    {
                        String bdate = DropDownList4.SelectedValue + "/" + DropDownList5.SelectedValue + "/" + TextBox9.Text;
                        String dhired = DropDownList6.SelectedValue + "/" + DropDownList7.SelectedValue + "/" + TextBox10.Text;
                        String commandString = " UPDATE EMPLOYEEPROFILE SET [address]='" + TextBox1.Text + "', [contact_no]=" + TextBox2.Text + ",  [email]='" + TextBox3.Text + "', [l_name]='" + TextBox4.Text + "', [f_name]='" + TextBox7.Text + "', [m_name]='" + TextBox8.Text + "', [SSS]= " + TextBox5.Text + ", [TIN]= " + TextBox6.Text + ",[gender]='" + DropDownList8.SelectedValue + "', [position]='" + DropDownList2.SelectedValue + "', [location]='" + DropDownList3.SelectedValue + "', [birthdate]='" + bdate + "', [date_hired]='" + dhired + "' WHERE [employee_no]=" + VemployeeNo;
                        SqlCommand cmd = new SqlCommand(commandString, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        con.Dispose();

                        Response.Redirect("HRViewEmployeeProfile.aspx", false);
                        Session["profileUpdate"] = 1;
                    }
                }
            }catch(Exception err){
                Label12.Text = "Incorrect input.";
            }
        }
        public Boolean checkSSSTIN(String SSS, String TIN)
        {
            Boolean isUnique = true;
            String commandString3 = " SELECT [SSS],[TIN] FROM [EMPLOYEEPROFILE] WHERE NOT([employee_no]=" + VemployeeNo+")";
            SqlDataAdapter adapter1 = new SqlDataAdapter(commandString3, con);
            DataSet ds = new DataSet();
            adapter1.Fill(ds, "SSSTIN");
            foreach (DataRow myDataRow in ds.Tables["SSSTIN"].Rows)
            {
                if (myDataRow["SSS"].ToString().Equals(SSS) || myDataRow["TIN"].ToString().Equals(TIN))
                {
                    isUnique = false;
                }
            }
            return isUnique;

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
            return editedDate;
        }
    }
}