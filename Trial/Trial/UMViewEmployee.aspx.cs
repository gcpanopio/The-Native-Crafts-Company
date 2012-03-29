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
    public partial class UMViewEmployee : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter ad;
        decimal sum = 0;
        DataSet ds1 = new DataSet();
        decimal rate = 0;
        decimal UMSalary = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
            con.Open();

            foreach (GridViewRow gvr in GridView1.Rows)
            {
               ds1.Clear();
               Label labelField = (Label)gvr.FindControl("Label1");
               int employeeNo = Convert.ToInt32(gvr.Cells[0].Text);
               DateTime firstDay = (FirstDayOfTheMonthFromDateTime(DateTime.Now));
               string sql = "SELECT [amount] FROM [TRANSACTION] WHERE ([employee_no] = " + employeeNo + ") AND ( [date_time] >= '" + firstDay + "') AND ( [date_time]<= '" + DateTime.Now + "')";
               ad = new SqlDataAdapter(sql, con);
               ad.Fill(ds1, "Sales");
               foreach (DataRow dRow in ds1.Tables["Sales"].Rows)
               {

                   if (!(dRow.ItemArray.GetValue(0) == (DBNull.Value)))
                   {
                       sum = sum + Convert.ToDecimal(dRow.ItemArray.GetValue(0));
                   }
               }

               UMSalary = UMSalary + sum; 
               labelField.Text = "Php " + sum;
               sum = 0;

            }

            string sql2 = "SELECT [Commission_Rate] FROM [COMMISSION] WHERE [Position] = 2";
            ad = new SqlDataAdapter(sql2, con);
            ad.Fill(ds1, "Commission");
            DataRow dRow2 = ds1.Tables["Commission"].Rows[0];
            rate = Convert.ToDecimal(dRow2.ItemArray.GetValue(0));

            Label5.Text = "" + (rate*100) + "%";
            Label6.Text = "" + UMSalary;
            Label7.Text = "" + (UMSalary * rate);

            con.Close(); 

           

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDeleted(object sender, EventArgs e)
        {

        }

        public DateTime FirstDayOfTheMonthFromDateTime(DateTime datetime) {
            return new DateTime(datetime.Year, datetime.Month, 1);
        }
        private void BindData()
        {
            string query = "SELECT [employee_no], [l_name], [f_name], [m_name] FROM [EMPLOYEEPROFILE]";
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
            ad = new SqlDataAdapter(query, con);
            GridView1.DataBind();

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);

            }



        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int Vemployee_no = Convert.ToInt32(e.CommandArgument);
                Session["VempNo"] = Vemployee_no;
                Response.Redirect("~/UMViewEmployeeProfile.aspx", false);

            }
        }
    }
}