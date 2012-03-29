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
    public partial class AgentInventory : System.Web.UI.Page
    {
        int[] PNo;
        int[] Qty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    TextBox textbox = (TextBox)gvr.FindControl("TextBox1");
                    textbox.Text = "0"; 
                }
            }

            if (Convert.ToBoolean(Session["Inv"]) == true)
            {
                Label1.Text = "Your orders cannot be processed.";
                Session["Inv"] = false;
            }
            if (Convert.ToBoolean(Session["QtyOver"]) == true)
            {
                Label1.Text = "Please make sure your orders does not exceed the item's quantity.";
                Session["QtyOver"] = false;
            }
            if (Convert.ToBoolean(Session["Done"]) == true)
            {
                Label1.Text = "Orders Complete! Please check the Sales Order page for the list of your completed orders.";
                Session["Done"] = false;
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.BackColor = System.Drawing.Color.FromArgb(247, 247, 247);
                Int32 com = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "quantity"));

                if (com <= (Int32)20)
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(255, 102, 102);
                }
            }



        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)gvr.FindControl("chkchild");
                    if (chk.Checked)
                        i++;
                }

                PNo = new int[i];
                Qty = new int[i];

                i = 0;
                foreach (GridViewRow gvr in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)gvr.FindControl("chkchild");
                    TextBox textbox = (TextBox)gvr.FindControl("TextBox1");
                    if (chk.Checked && textbox.Text.Equals("0") == false)
                    {
                        PNo[i] = Convert.ToInt32(gvr.Cells[2].Text);
                        Qty[i] = Convert.ToInt32(textbox.Text);
                        int qty = Convert.ToInt32(gvr.Cells[5].Text);
                        if (Qty[i] <= qty)
                            i++;
                        else
                        {
                            Session["QtyOver"] = true;
                            break;
                        }
                    }
                }
                if (i != 0)
                    updateDatabase();
                else
                    Session["Inv"] = true;
            }catch(Exception err){
                Label1.Text = "Incorrect input.";
            }
        }

        public void updateDatabase()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                SqlDataAdapter da;
                DataSet ds1 = new DataSet();
                string sql;
                SqlCommand com;
                con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";

                con.Open();

                decimal amount = 0;

                int i;
                for (i = 0; i < PNo.Length; i++)
                {
                    SqlDataAdapter da2 = new SqlDataAdapter();
                    DataSet ds2 = new DataSet();

                    sql = "SELECT [price] FROM [PRODUCTS] WHERE [product_no]=" + PNo[i];
                    da2 = new SqlDataAdapter(sql, con);
                    da2.Fill(ds2, "Total");
                    try
                    {
                        DataRow drow = ds2.Tables["Total"].Rows[0];
                        decimal price = (decimal)drow.ItemArray.GetValue(0);
                        amount = amount + (price * Qty[i]);
                    }
                    catch (IndexOutOfRangeException error)
                    {

                    }
                }

                sql = "INSERT INTO [TRANSACTION] VALUES (" + Session["empNo"] + "," + amount + ",'" + DateTime.Now.ToString("G") + "')";
                com = new SqlCommand(sql, con);
                com.ExecuteNonQuery();

                sql = "SELECT COUNT(*) FROM [TRANSACTION]";
                com = new SqlCommand(sql, con);
                int count = (int)com.ExecuteScalar();

                sql = "SELECT * FROM [TRANSACTION]";
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds1, "Transaction");

                int transNo = 1;
                if (count != 0)
                {
                    DataRow drow = ds1.Tables["Transaction"].Rows[count - 1];
                    transNo = Convert.ToInt32(drow.ItemArray.GetValue(0).ToString());
                }

                for (i = 0; i < PNo.Length; i++)
                {
                    int prodno = PNo[i];
                    int qty = Qty[i];

                    sql = "INSERT INTO SALESORDER (transaction_no, product_no, quantity) VALUES (" + transNo + ", " + PNo[i] + ", " + Qty[i] + ")";
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();

                    sql = "SELECT [quantity] FROM PRODUCTS WHERE [product_no]=" + PNo[i];
                    da = new SqlDataAdapter(sql, con);
                    da.Fill(ds1, "Quantity");

                    DataRow drow = ds1.Tables["Quantity"].Rows[0];
                    int QTY = Convert.ToInt32(drow.ItemArray.GetValue(0).ToString());
                    QTY = QTY - Qty[i];

                    sql = "UPDATE [PRODUCTS] SET [quantity]=" + QTY + " WHERE [product_no]=" + PNo[i];
                    com = new SqlCommand(sql, con);
                    com.ExecuteNonQuery();

                    if (QTY == 0)
                    {
                        sql = "UPDATE [PRODUCTS] SET [availability]= 0  WHERE [product_no]=" + PNo[i];
                        com = new SqlCommand(sql, con);
                        com.ExecuteNonQuery();
                    }

                    Session["Done"] = true;
                    Response.Redirect("~/AgentInventory.aspx", false);
                }
            }catch(Exception err){
                Label1.Text = "Incorrect input.";
            }
        }
    }
}