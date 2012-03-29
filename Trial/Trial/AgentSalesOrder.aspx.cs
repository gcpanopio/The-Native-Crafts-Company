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
    public partial class AgentSalesOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            SqlDataAdapter da;
            DataSet ds1 = new DataSet();
            SqlCommand com;
            string sql;
            
            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";

            con.Open();

            sql = "SELECT [Commission_Rate] FROM [COMMISSION] WHERE [Position]=1";
            com = new SqlCommand(sql, con);
            decimal count = Convert.ToDecimal(com.ExecuteScalar());

            Label4.Text = count * 100 + "%";

            DateTime firstDay = (FirstDayOfMonthFromDateTime(DateTime.Now));

            sql = "SELECT [amount] FROM [TRANSACTION] WHERE ([date_time] >='" + firstDay + "') AND ([date_time] <= '" + DateTime.Now + "') AND [employee_no]=" + Convert.ToInt32(Session["empNo"]);
            da = new SqlDataAdapter(sql, con);
            da.Fill(ds1, "Sales");

            decimal sum = 0;
            foreach (DataRow dRow in ds1.Tables["Sales"].Rows)
            {
                sum = sum + Convert.ToDecimal(dRow.ItemArray.GetValue(0));
            }

            Label5.Text = "Php " + sum;
            Label2.Text = "Php " + (sum * count);
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.BackColor = System.Drawing.Color.FromArgb(230, 230,230);

            }



        }
        public DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
    }
}