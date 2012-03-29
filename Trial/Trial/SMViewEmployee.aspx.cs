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
    public partial class SMViewEmployee : System.Web.UI.Page
    {
        SqlConnection con;  
        DataSet ds1 = new DataSet();
        SqlDataAdapter ad2;
        DataSet ds2 = new DataSet();
        SqlDataAdapter ad3;
        DataSet ds3 = new DataSet();
        SqlDataAdapter ad4;
        DataSet ds4 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            decimal sum = 0;          
            decimal totalSum = 0;
            decimal AgentSalary = 0;
            decimal rate;

            int UMlocation;
            
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
            con.Open();

            foreach (GridViewRow gvr in GridView1.Rows)
            {
                ds2.Clear();
                Label labelField = (Label)gvr.FindControl("Label1");
                int employeeNo = Convert.ToInt32(gvr.Cells[0].Text);

                string sql = "SELECT [location] FROM [EMPLOYEEPROFILE] WHERE [employee_no] = " + employeeNo;
                SqlCommand com = new SqlCommand(sql, con);
                UMlocation = Convert.ToInt32(com.ExecuteScalar());

                sql = "SELECT [employee_no] FROM [EMPLOYEEPROFILE] WHERE ([position] = 1 AND [location] = " + UMlocation + ")";
                ad2 = new SqlDataAdapter(sql, con);
                ad2.Fill(ds2, "AgentNos");

                foreach (DataRow dRow2 in ds2.Tables["AgentNos"].Rows)
                {
                    ds3.Clear();
                    DateTime firstDay = (FirstDayOfTheMonthFromDateTime(DateTime.Now));
                    string sql2 = "SELECT [amount] FROM [TRANSACTION] WHERE ([employee_no] = " +  Convert.ToInt32(dRow2.ItemArray.GetValue(0)) + ") AND ( [date_time] >= '" + firstDay + "') AND ( [date_time]<= '" + DateTime.Now + "')";
                    ad3 = new SqlDataAdapter(sql2, con);
                    ad3.Fill(ds3, "AgentSales");

                    foreach (DataRow dRow3 in ds3.Tables["AgentSales"].Rows)
                    {

                        if (!(dRow3.ItemArray.GetValue(0) == (DBNull.Value)))
                        {
                            sum = sum + Convert.ToDecimal(dRow3.ItemArray.GetValue(0));
                        }
                    }

                    AgentSalary = AgentSalary + sum;
                    sum = 0;
                }

                labelField.Text = "Php " + AgentSalary;
                totalSum = totalSum + AgentSalary;  
                AgentSalary = 0;
            }


            Label7.Text = ""+totalSum;
                
            string sql4 = "SELECT [Commission_Rate] FROM [COMMISSION] WHERE [Position] = 3";
            ad4 = new SqlDataAdapter(sql4, con);
            ad4.Fill(ds4, "Commission");
            DataRow dRow4 = ds4.Tables["Commission"].Rows[0];
            rate = Convert.ToDecimal(dRow4.ItemArray.GetValue(0));

            Label5.Text = "" + (rate * 100) + "%";
            Label6.Text = "" + (totalSum * rate);
               
            con.Close();
        
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);

            }



        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDeleted(object sender, EventArgs e)
        {

        }
        public DateTime FirstDayOfTheMonthFromDateTime(DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, 1);
        }
       /*private void BindData()
        {
            string query = "SELECT [employee_no], [l_name], [f_name], [m_name] FROM [EMPLOYEEPROFILE]";
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
            ad = new SqlDataAdapter(query, con);
            GridView1.DataBind();

        }*/

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int Vemployee_no = Convert.ToInt32(e.CommandArgument);
                Session["VempNo"] = Vemployee_no;
                Response.Redirect("~/SMViewEmployeeProfile.aspx", false);

            }
        }
    }
}