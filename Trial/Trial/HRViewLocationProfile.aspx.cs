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
    public partial class HRViewLocationProfile : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                LocationName.Text = Session["VlocName"].ToString();
                BindData();
            }
        }

        private void BindData()
        {
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
            GridView1.DataBind();
            GridView1.Sort("Location_No", System.Web.UI.WebControls.SortDirection.Ascending);

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
                DataBinder.Eval(e.Row.DataItem, "Location_Address") + "?')");
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                Int32 Location_No = Convert.ToInt32(e.CommandArgument);
                Session["VlocNo"] = Location_No;
                BindData();
                con.Open();
                String cmdString = "SELECT [location] FROM [EMPLOYEEPROFILE] WHERE ([employee_no]=" + Session["empNo"] + ")";
                SqlCommand c = new SqlCommand(cmdString, con);
                Int32 myLoc = Convert.ToInt32(c.ExecuteScalar());
                if (Location_No.Equals(myLoc))
                {
                    Label1.Text = "Cannot delete your own location."; 
                }
                else
                {
                    DeleteRecordByID(Location_No);
                }
              
                con.Close();
                c.Dispose();
                
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           /* int Location_No = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            BindData();
            con.Open();
            String cmdString = "SELECT [location] FROM [EMPLOYEEPROFILE] WHERE ([employee_no]=" + Session["empNo"] + ")";
            SqlCommand c = new SqlCommand(cmdString, con);
            Int32 myLoc = Convert.ToInt32(c.ExecuteScalar());
            if (Location_No == myLoc)
            {
                Response.Write("<script>alert('Cannot delete your own location. two');</script>");
            }
            else
            {
                DeleteRecordByID(Location_No);
            }
            con.Close();
            c.Dispose();*/
        }

        private void DeleteRecordByID(int Location_No)
        {
            BindData();
            con.Open();
            String commandString3 = " SELECT [employee_no] FROM [EMPLOYEEPROFILE] WHERE ([location] = " +Location_No+ ")";
            SqlDataAdapter adapter1 = new SqlDataAdapter(commandString3, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "EMPLOYEENUMBER");
            try
            {
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
            catch (Exception a){}

            String commandString = " DELETE FROM [LOCATION] WHERE ([Location_No]='" + Location_No + "')";
            SqlCommand cmd = new SqlCommand(commandString, con);
            cmd.ExecuteNonQuery();

            Label1.Text = "Deleted location #" + Location_No + ".";

            con.Close();
            cmd.Dispose();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRViewLocationProfileAdd.aspx", false);
        }
    }
}