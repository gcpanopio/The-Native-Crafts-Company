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
    public partial class HRViewLocation : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter adapter;
        DataSet ds;

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
            GridView1.Sort("Location_Name", System.Web.UI.WebControls.SortDirection.Ascending);

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
                
                Button l = (Button)e.Row.FindControl("Button1");
                l.Attributes.Add("onclick", "javascript:return " +
                "confirm('Are you sure you want to delete the record " +
                DataBinder.Eval(e.Row.DataItem, "Location_Name") + "? It will also delete employees in this area.')");
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                BindData();
                con.Open();
                String Location_Name = Convert.ToString(e.CommandArgument);
                String cmdString = "SELECT [location] FROM [EMPLOYEEPROFILE] WHERE ([employee_no]=" + Session["empNo"] + ")";
                SqlCommand c = new SqlCommand(cmdString, con);
                Int32 myLoc = Convert.ToInt32(c.ExecuteScalar());

                cmdString = "SELECT [Location_Name] FROM [LOCATION] WHERE ([Location_No]=" + myLoc + ")";
                c = new SqlCommand(cmdString, con);
                String myLocN = Convert.ToString(c.ExecuteScalar());

                if (!(myLocN.Equals(Location_Name)))
                {
                    DeleteRecordByID(Location_Name);
                }
                else
                {
                    Label1.Text = "Cannot delete your own location.";
                }

                con.Close();
                c.Dispose(); 
                
            }
            else if (e.CommandName == "View")
            {
                String VLocation_Name = Convert.ToString(e.CommandArgument);
                Session["VlocName"] = VLocation_Name;
                Response.Redirect("~/HRViewLocationProfile.aspx", false);

            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        private void DeleteRecordByID(String Location_Name)
        {
            BindData();
            con.Open();

            String commandString1 = " SELECT [Location_No] FROM [LOCATION] WHERE ([Location_Name] ='" + Location_Name + "')";
            adapter = new SqlDataAdapter(commandString1, con);
            ds = new DataSet();
            adapter.Fill(ds, "LOCATION");

            foreach (DataRow myDataRow in ds.Tables["LOCATION"].Rows)
            {
                String commandString3 = " SELECT [employee_no] FROM [EMPLOYEEPROFILE] WHERE ([location] = '" + myDataRow["Location_No"].ToString() + "')";
                SqlDataAdapter adapter1 = new SqlDataAdapter(commandString3, con);
                DataSet ds1 = new DataSet();
                adapter1.Fill(ds1, "EMPLOYEENUMBER");

                foreach (DataRow myDataRow1 in ds1.Tables["EMPLOYEENUMBER"].Rows)
                {
                    String commandString2 = "DELETE FROM [EMPLOYEEPROFILE] WHERE (([employee_no] = '" + myDataRow1["Employee_No"].ToString() + "') AND (NOT [employee_no]=" + Session["empNo"] + "))";
                    String commandString4 = "DELETE FROM [LOGIN] WHERE (([employee_no] = '" + myDataRow1["Employee_No"].ToString() + "') AND (NOT [employee_no]=" + Session["empNo"] + "))";
                    SqlCommand cmd2 = new SqlCommand(commandString2, con);
                    SqlCommand cmd4 = new SqlCommand(commandString4, con);
                    cmd2.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                    cmd2.Dispose();
                    cmd4.Dispose();
                }
            }

            String commandString = " DELETE FROM [LOCATION] WHERE ([Location_Name]='" + Location_Name + "')";
            SqlCommand cmd = new SqlCommand(commandString, con);
            cmd.ExecuteNonQuery();

            Label1.Text = "Deleted "+Location_Name+".";

            con.Close();
            cmd.Dispose();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRViewLocationAdd.aspx", false); 
        }
    }
} 