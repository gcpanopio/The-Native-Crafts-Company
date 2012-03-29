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
    public partial class UMViewInventory : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter ad;
        DataSet ds1 = new DataSet();
        SqlDataAdapter ad2;
        DataSet ds2 = new DataSet();
        SqlDataAdapter ad3;
        DataSet ds3 = new DataSet();

        int correctLocation;
        int numberSold = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
            con.Open();

            String sql = "SELECT [location] FROM [EMPLOYEEPROFILE] WHERE [employee_no] = " + Session["empNo"];
            SqlCommand com = new SqlCommand(sql, con);
            correctLocation = Convert.ToInt32(com.ExecuteScalar());
            
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                ds1.Clear();
                Label labelField = (Label)gvr.FindControl("Label1");
                int prodNo = Convert.ToInt32(gvr.Cells[0].Text);

                sql = "SELECT [transaction_no], [quantity] FROM [SALESORDER] WHERE [product_no] = " + prodNo;
                ad = new SqlDataAdapter(sql, con);
                ad.Fill(ds1, "TransQty");

                foreach (DataRow dRow1 in ds1.Tables["TransQty"].Rows)
                {
                    ds2.Clear();
                    sql = "SELECT [employee_no] FROM [TRANSACTION] WHERE [transaction_no] = " + Convert.ToInt32(dRow1.ItemArray.GetValue(0));
                    ad2 = new SqlDataAdapter(sql, con);
                    ad2.Fill(ds2, "AgentNoProd");

                    foreach (DataRow dRow2 in ds2.Tables["AgentNoProd"].Rows) 
                    {
                        ds3.Clear();
                        sql = "SELECT [location] FROM [EMPLOYEEPROFILE] WHERE [employee_no] = " + Convert.ToInt32(dRow2.ItemArray.GetValue(0));
                        ad3 = new SqlDataAdapter(sql, con);
                        ad3.Fill(ds3, "AgentLocProd");

                        foreach (DataRow dRow3 in ds3.Tables["AgentLocProd"].Rows)
                        {
                            if (Convert.ToInt32(dRow3.ItemArray.GetValue(0)) == correctLocation) {
                                numberSold = numberSold + Convert.ToInt32(dRow1.ItemArray.GetValue(1));
                            }
                        }
                    }
                }
                labelField.Text = "" + numberSold;
                numberSold = 0;
            }
        }

        private void BindData()
        {
            string query = "SELECT [product_no], [product_name], [price], [quantity] FROM [PRODUCTS]";
            //con.ConnectionString
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
            ad = new SqlDataAdapter(query, con);
            //ds = new DataSet();
            //ad.Fill(ds, "EMPLOYEEPROFILE");
            // GridView1.DataSource = ds;
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
                
                /*Button l = (Button)e.Row.FindControl("Button1");
                l.Attributes.Add("onclick", "javascript:return " +
                "confirm('Are you sure you want to delete this record " +
                DataBinder.Eval(e.Row.DataItem, "product_no") + "')");*/
            }
        }
    }
}