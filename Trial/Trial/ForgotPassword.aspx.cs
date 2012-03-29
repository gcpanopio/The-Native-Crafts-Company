using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace Trial
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["usernameDNE"]) == true)
            {
                Label1.Text = "The username you entered does not exist. Please try again.";
                Session["usernameDNE"] = false;
            }
            if (Convert.ToBoolean(Session["internetError"]) == true)
            {
                Label1.Text = "Make sure you have an internet connection.";
                Session["internetError"] = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((TextBox1.Text.Equals("")))
            {
                Label1.Text = "Please enter your username.";
            }
            else
            {
                string username;
                int empno;

                SqlConnection con = new SqlConnection();
                DataSet ds1 = new DataSet();
                SqlCommand com = new SqlCommand();
                string sql;

                con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Shiela\\Desktop\\MP-192\\Trial\\Trial\\App_Data\\Direct-Selling.mdf;Integrated Security=True;User Instance=True";
                con.Open();
                username = TextBox1.Text;

                try
                {
                    sql = "SELECT [employee_no] FROM [LOGIN] WHERE [username]='" + username + "'";
                    com = new SqlCommand(sql, con);
                    empno = Convert.ToInt32(com.ExecuteScalar());

                    try
                    {
                        sql = "SELECT [email] FROM [EMPLOYEEPROFILE] WHERE [employee_no]=" + empno;
                        com = new SqlCommand(sql, con);
                        string email = com.ExecuteScalar().ToString();

                        string newpassword;

                        // password gen
                        newpassword = generatePWord();
                        //
                        try
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                            mail.From = new MailAddress("cs192.mp@gmail.com");
                            mail.To.Add(email);
                            mail.Subject = "Forgot password";
                            mail.IsBodyHtml = true;
                            mail.Body = "Greetings! Your new password is <b>" + newpassword + "</b>";

                            SmtpServer.Port = 587;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("cs192.mp", "directsellingdatabase");
                            SmtpServer.EnableSsl = true;

                            SmtpServer.Send(mail);

                            sql = "UPDATE [LOGIN] SET [password]='" + newpassword + "' WHERE [employee_no]=" + empno;
                            com = new SqlCommand(sql, con);
                            com.ExecuteNonQuery();

                            Session["retrieve"] = true;
                            Response.Redirect("Account/Login.aspx", false);
                            //Response.Write("<script>alert('mail Send');</script>");
                        }catch(Exception err){
                            Session["internetError"] = true;
                            Response.Redirect("ForgotPassword.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                       // Response.Write("<script>alert('" + ex.ToString() + "');</script>");

                    }

                }
                catch (IndexOutOfRangeException error)
                {
                    Session["usernameDNE"] = true;
                    Response.Redirect("ForgetPassword.apsx");
                }
            }
        }
        public String generatePWord()
        {
            String pword = "";
            int charCount = 0;
            Random rand = new Random();
            while (charCount != 6)
            {
                int num = rand.Next(48, 123);
                while ((num > 57 && num < 65) || (num > 90 && num < 97))
                {
                    num = rand.Next(48, 123);
                }
                char a = (char)(num);
                pword = pword + a;
                charCount++;
            }


            return pword;
        }
    }
}