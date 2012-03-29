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
    public partial class HRViewInventoryAdd : System.Web.UI.Page
    {
        SqlConnection con;
        DataSet ds1;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            ds1 = new DataSet();

            con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";

            con.Open();

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRViewInventory.aspx", false);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TextBox1.Text.Equals("")) || (TextBox2.Text.Equals("")) || (TextBox3.Text.Equals("")))
                {
                    Label2.Text = "All fields must have a value.";
                }
                else
                {
                    String commandString = "SELECT [product_name] FROM [PRODUCTS]";
                    SqlDataAdapter ad = new SqlDataAdapter(commandString, con);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "prodNames");
                    Boolean locAddExists = false;
                    foreach (DataRow myDataRow in ds.Tables["prodNames"].Rows)
                    {
                        if (myDataRow["product_name"].ToString().Equals(TextBox1.Text))
                        {
                            locAddExists = true;
                        }
                    }

                    if (locAddExists)
                    {
                        Label2.Text = "Product already exist.";
                    }
                    else
                    {
                        commandString = "INSERT INTO PRODUCTS (availability,product_name,price,quantity) VALUES ('" + DropDownList1.SelectedValue + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')";
                        SqlCommand cmd = new SqlCommand(commandString, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        con.Dispose();

                        Response.Redirect("HRViewInventory.aspx", false);
                    }
                }

            }
            catch (Exception err)
            {
                Label2.Text = "Incorrect input.";
            }
        }

    }
}