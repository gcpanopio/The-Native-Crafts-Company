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
    public partial class HRCommission : System.Web.UI.Page
    {
        
        SqlConnection con;
        DataSet ds1; 

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            ds1 = new DataSet();

            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";

            con.Open();

            String cmdString = "SELECT [Commission_Rate] FROM [COMMISSION] WHERE ([Position]= 1)";
            SqlCommand c = new SqlCommand(cmdString, con);
            Decimal aCom = Convert.ToDecimal(c.ExecuteScalar());

            Label1.Text = (Convert.ToDecimal(aCom * 100)) + "%";

            cmdString = "SELECT [Commission_Rate] FROM [COMMISSION] WHERE ([Position]= 2)";
            c = new SqlCommand(cmdString, con);
            Decimal uCom = Convert.ToDecimal(c.ExecuteScalar());

            Label2.Text = (Convert.ToDecimal(uCom * 100)) + "%";

            cmdString = "SELECT [Commission_Rate] FROM [COMMISSION] WHERE ([Position]= 3)";
            c = new SqlCommand(cmdString, con);
            Decimal sCom = Convert.ToDecimal(c.ExecuteScalar());

            Label3.Text = (Convert.ToDecimal(sCom * 100)) + "%";

            con.Close();
            con.Dispose();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRCommissionEdit.aspx", false);

        }
    }
}