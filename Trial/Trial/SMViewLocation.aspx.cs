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
    public partial class SMViewLocation : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter ad;
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        SqlDataAdapter ad2;

        protected void Page_Load(object sender, EventArgs e)
        {
            decimal AgentSalary = 0;
            decimal sum = 0;
            decimal totalSum = 0;
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
            con.Open();

            int locationNo;

            foreach (GridViewRow gvr in GridView1.Rows)
            {
                ds1.Clear();
                Label labelField = (Label)gvr.FindControl("Label1");
                string locationAddress = (gvr.Cells[0].Text).ToString();
                string sql = "SELECT [Location_No] FROM LOCATION WHERE [Location_Address] = '" + locationAddress + "' ";
                SqlCommand com = new SqlCommand(sql, con);
                locationNo = Convert.ToInt32(com.ExecuteScalar());

                sql = "SELECT [employee_no] FROM [EMPLOYEEPROFILE] WHERE [position] = 1 AND [location] = " + locationNo;
                ad = new SqlDataAdapter(sql, con);
                ad.Fill(ds1, "AgentNos");              //LAHAT NG AGENTS

                foreach (DataRow dRow in ds1.Tables["AgentNos"].Rows)
                {
                    ds2.Clear();
                    DateTime firstDay = (FirstDayOfTheMonthFromDateTime(DateTime.Now));
                    sql = "SELECT [amount] FROM [TRANSACTION] WHERE ([employee_no] = " + Convert.ToInt32(dRow.ItemArray.GetValue(0)) + ") AND ( [date_time] >= '" + firstDay + "') AND ( [date_time]<= '" + DateTime.Now + "')";
                    ad2 = new SqlDataAdapter(sql, con);
                    ad2.Fill(ds2, "AgentSales");        //LAHAT NG SALES

                    foreach (DataRow dRow2 in ds2.Tables["AgentSales"].Rows)
                    {
                        if (!(dRow2.ItemArray.GetValue(0) == (DBNull.Value)))
                        {
                            sum = sum + Convert.ToDecimal(dRow2.ItemArray.GetValue(0));
                        }
                    }

                    AgentSalary = AgentSalary + sum;
                    sum = 0;
                }
                totalSum = totalSum + AgentSalary;
                AgentSalary = 0;
                labelField.Text = "" + totalSum;
                totalSum = 0;
            }
        }  

        private void BindData()
        {
            string query = "SELECT DISTINCT [Location_Name] FROM [LOCATION]";
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
            ad = new SqlDataAdapter(query, con);
            GridView1.DataBind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDeleted(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);

            }

        }
        public DateTime FirstDayOfTheMonthFromDateTime(DateTime datetime) {
            return new DateTime(datetime.Year, datetime.Month, 1);
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           /* if (e.CommandName == "Delete")
            {
                // get the Location_No of the clicked row
                String Location_Name = Convert.ToString(e.CommandArgument);
                // Delete the record 
                DeleteRecordByID(Location_Name);
                // Implement this on your own :) 
            }*/
        }
    }
}