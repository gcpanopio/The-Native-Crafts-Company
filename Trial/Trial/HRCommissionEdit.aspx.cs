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
    public partial class HRCommissionEdit : System.Web.UI.Page
    {
        SqlConnection con;
         DataSet ds1;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            ds1 = new DataSet();

            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";

            con.Open();

            if (!IsPostBack)
            {
                String cmdString = "SELECT [Commission_Rate] FROM [COMMISSION] WHERE ([Position]= 1)";
                SqlCommand c = new SqlCommand(cmdString, con);
                Decimal aCom = Convert.ToDecimal(c.ExecuteScalar());

                TextBox1.Text = (Convert.ToDecimal(aCom * 100)) + "%";

                cmdString = "SELECT [Commission_Rate] FROM [COMMISSION] WHERE ([Position]= 2)";
                c = new SqlCommand(cmdString, con);
                Decimal uCom = Convert.ToDecimal(c.ExecuteScalar());

                TextBox2.Text = (Convert.ToDecimal(uCom * 100)) + "%";

                cmdString = "SELECT [Commission_Rate] FROM [COMMISSION] WHERE ([Position]= 3)";
                c = new SqlCommand(cmdString, con);
                Decimal sCom = Convert.ToDecimal(c.ExecuteScalar());

                TextBox3.Text = (Convert.ToDecimal(sCom * 100)) + "%";

            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TextBox1.Text.Equals("")) || (TextBox2.Text.Equals("")) || (TextBox3.Text.Equals("")))
                {
                    Label1.Text = "All fields must have a value.";
                }
                else
                {
                    String[] extract = TextBox1.Text.Split('%');
                    Decimal acom = Convert.ToDecimal(extract[0]);
                    acom = acom / 100;
                    extract = TextBox2.Text.Split('%');
                    Decimal ucom = Convert.ToDecimal(extract[0]);
                    ucom = ucom / 100;
                    extract = TextBox3.Text.Split('%');
                    Decimal scom = Convert.ToDecimal(extract[0]);
                    scom = scom / 100;

                    Decimal sum = acom + ucom + scom;

                    if (sum != (Decimal)0.15)
                    {
                        Label1.Text = "Commissions must sum up to 15%.";
                    }
                    else
                    {
                        String commandString = " UPDATE COMMISSION SET [Commission_Rate]=" + acom + " WHERE [Position]= 1";
                        SqlCommand cmd = new SqlCommand(commandString, con);
                        cmd.ExecuteNonQuery();

                        commandString = " UPDATE COMMISSION SET [Commission_Rate]=" + ucom + " WHERE [Position]= 2";
                        cmd = new SqlCommand(commandString, con);
                        cmd.ExecuteNonQuery();

                        commandString = " UPDATE COMMISSION SET [Commission_Rate]=" + scom + " WHERE [Position]= 3";
                        cmd = new SqlCommand(commandString, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        con.Dispose();

                        Response.Redirect("HRCommission.aspx", false);
                    }
                }
            }
            catch (Exception err)
            {
                Label1.Text = "Incorrect input.";
            }
        }
        
    }
}