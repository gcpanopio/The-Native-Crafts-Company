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
    public partial class HRViewInventory : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
            GridView1.DataBind();
            GridView1.Sort("product_no", System.Web.UI.WebControls.SortDirection.Ascending);
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
                Int32 com = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "quantity"));
                
                if (com <= (Int32)20)
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(255,102,102);
                }
                Boolean boo = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "availability"));
                if (!boo)
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(191,191,191);
                }

                Button l = (Button)e.Row.FindControl("Button1");
                l.Attributes.Add("onclick", "javascript:return " + "confirm('Are you sure you want to delete this record " +DataBinder.Eval(e.Row.DataItem, "product_no") + "')");
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int product_no = Convert.ToInt32(e.CommandArgument);
                DeleteRecordByID(product_no);
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
          /*  int product_no = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            DeleteRecordByID(product_no);*/
        }

        private void DeleteRecordByID(int product_no)
        {
            BindData();
            String commandString = " DELETE FROM [PRODUCTS] WHERE [product_no]=" + product_no;
            SqlCommand cmd = new SqlCommand(commandString, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            Label4.Text = "Deleted product no. " + product_no + ".";
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRViewInventoryAdd.aspx", false);
        }
    }
}