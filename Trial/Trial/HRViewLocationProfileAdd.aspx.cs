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
    public partial class HRViewLocationProfileAdd : System.Web.UI.Page
    {
        SqlConnection con;
        DataSet ds1;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            ds1 = new DataSet();

            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";
            con.Open();
            Label1.Text = Session["VlocName"].ToString();
            

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRViewLocationProfile.aspx", false);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((TextBox1.Text.Equals("")))
            {
                Label1.Text = "The field must have a value.";
            }
            else
            {
                String commandString = "SELECT [Location_Address] FROM [LOCATION] WHERE [Location_Name]='" + Label1.Text + "'";
                SqlDataAdapter ad = new SqlDataAdapter(commandString, con);
                DataSet ds = new DataSet();
                ad.Fill(ds, "locAdds");
                Boolean locAddExists = false;
                foreach (DataRow myDataRow in ds.Tables["locAdds"].Rows)
                {
                    if (myDataRow["Location_Address"].ToString().Equals(TextBox1.Text))
                    {
                        locAddExists = true;
                    }
                }

                if (locAddExists)
                {
                    Label2.Text = "Location address already exist.";
                }
                else
                {
                    commandString = "INSERT INTO LOCATION VALUES ('" + Label1.Text + "','" + TextBox1.Text + "')";
                    SqlCommand cmd = new SqlCommand(commandString, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    con.Dispose();

                    Response.Redirect("HRViewLocationProfile.aspx", false);
                }
            }
        }

    }
}