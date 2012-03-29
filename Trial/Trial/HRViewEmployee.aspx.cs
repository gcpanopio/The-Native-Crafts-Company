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
    public partial class HRViewEmployee : System.Web.UI.Page
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
            GridView1.Sort("employee_no", System.Web.UI.WebControls.SortDirection.Ascending);

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
                    "confirm('Are you sure you want to delete this record " +
                    DataBinder.Eval(e.Row.DataItem, "employee_no") + "')");
                }
                          

           
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int hrEmpNo = Convert.ToInt32(Session["empNo"]);
                int employee_no = Convert.ToInt32(e.CommandArgument);

                if (hrEmpNo != employee_no)
                {
                    DeleteRecordByID(employee_no); 
                }
                else
                {
                    Label1.Text = "Cannot delete your own account.";
                }
                
            }else if(e.CommandName == "View"){
                int Vemployee_no = Convert.ToInt32(e.CommandArgument);
                Session["VempNo"]=Vemployee_no;
                Response.Redirect("~/HRViewEmployeeProfile.aspx",false);

            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        private void DeleteRecordByID(int employee_no)
        {
            BindData();
            String commandString = " DELETE FROM [EMPLOYEEPROFILE] WHERE [employee_no]=" + employee_no;
            String commandString2 = " DELETE FROM [LOGIN] WHERE [employee_no]=" + employee_no;
            SqlCommand cmd = new SqlCommand(commandString, con);
            SqlCommand cmd2 = new SqlCommand(commandString2, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            cmd2.Dispose();
            Label1.Text = "Deleted employee # "+employee_no+".";
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRViewEmployeeProfileAdd.aspx", false);
        }

    }
}