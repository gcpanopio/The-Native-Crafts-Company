

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace Trial
{
    public partial class SM : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                String commandstring = "SELECT * FROM NOTIFY";
                SqlDataAdapter ad = new SqlDataAdapter(commandstring, con);
                DataSet ds = new DataSet();
                ad.Fill(ds, "NOTIFY");
                foreach (DataRow myDataRow in ds.Tables["NOTIFY"].Rows)
                {
                    commandstring = "SELECT [email] FROM [EMPLOYEEPROFILE] WHERE [employee_no]=" + myDataRow["employee_no"].ToString();
                    SqlCommand cmd = new SqlCommand(commandstring, con);
                    String email = cmd.ExecuteScalar().ToString();
                    commandstring = "SELECT [f_name] FROM [EMPLOYEEPROFILE] WHERE [employee_no]=" + myDataRow["employee_no"].ToString();
                    cmd = new SqlCommand(commandstring, con);
                    String firstname = cmd.ExecuteScalar().ToString();
                    commandstring = "SELECT [l_name] FROM [EMPLOYEEPROFILE] WHERE [employee_no]=" + myDataRow["employee_no"].ToString();
                    cmd = new SqlCommand(commandstring, con);
                    String lastname = cmd.ExecuteScalar().ToString();
                    commandstring = "SELECT [username] FROM [LOGIN] WHERE [employee_no]=" + myDataRow["employee_no"].ToString();
                    cmd = new SqlCommand(commandstring, con);
                    String username = cmd.ExecuteScalar().ToString();
                    commandstring = "SELECT [password] FROM [LOGIN] WHERE [employee_no]=" + myDataRow["employee_no"].ToString();
                    cmd = new SqlCommand(commandstring, con);
                    String password = cmd.ExecuteScalar().ToString();
                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                        mail.From = new MailAddress("cs192.mp@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Welcome to our company!";
                        mail.IsBodyHtml = true;
                        mail.Body = "*This is a machine generated message.*<br/><br/><br/> Dear " + firstname + " " + lastname + ", <br/><br/>Welcome to Jimenez' Direct-Selling Company. <br/><br/>Please take note of your username: <b>" + username + "</b> and password: <b>" + password + "</b>. <br/>Do not give your password to anyone. You can change your password anytime at the Change Password Module of your account. <br/><br/> Thank you!";

                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("cs192.mp", "directsellingdatabase");
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);

                        commandstring = "DELETE FROM [NOTIFY] WHERE [employee_no]=" + myDataRow["employee_no"].ToString();
                        cmd = new SqlCommand(commandstring, con);
                        cmd.ExecuteNonQuery();
                        //  Label1.Text = "Email Sent";

                    }
                    catch (Exception ex)
                    {
                        //   Label1.Text = "Email Still Not Sent";

                    }

                }
            }
            catch (Exception error)
            {
                //  Label1.Text = "Nothing in there";
            }

        }

        public void setEmployeeNo()
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMProfile.aspx", false);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMViewEmployee.aspx", false);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMChangePassword.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}