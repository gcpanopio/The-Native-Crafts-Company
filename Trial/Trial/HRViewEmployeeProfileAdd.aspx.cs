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
    public partial class HRViewEmployeeProfileAdd : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TextBox1.Text.Equals("")) || (TextBox2.Text.Equals("")) || (TextBox3.Text.Equals("")) || (TextBox4.Text.Equals("")) || (TextBox5.Text.Equals("")) || (TextBox6.Text.Equals("")) || (TextBox7.Text.Equals("")) || (TextBox8.Text.Equals("")) || (TextBox9.Text.Equals("")) || (TextBox10.Text.Equals("")))
                {
                    Label12.Text = "All fields must have a value.";
                }
                else
                {


                    if (!(checkSSSTIN(TextBox5.Text, TextBox6.Text)))
                    {
                        Label12.Text = "Employee with similar SSS or TIN detected.";
                    }
                    else if (!(check(Convert.ToInt32(DropDownList3.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue))))
                    {

                    }
                    else
                    {

                        String bdate = DropDownList4.SelectedValue + "/" + DropDownList5.SelectedValue + "/" + TextBox9.Text;
                        String dhired = DropDownList6.SelectedValue + "/" + DropDownList7.SelectedValue + "/" + TextBox10.Text;
                        String commandString = "INSERT INTO EMPLOYEEPROFILE VALUES ('" + TextBox4.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + DropDownList3.SelectedValue + "','" + DropDownList2.SelectedValue + "'," + TextBox5.Text + "," + TextBox6.Text + ",'" + bdate + "', '" + DropDownList8.SelectedValue + "','" + TextBox3.Text + "'," + TextBox2.Text + ",'" + dhired + "','" + TextBox1.Text + "')";
                        SqlCommand cmd = new SqlCommand(commandString, con);
                        cmd.ExecuteNonQuery();

                        commandString = "SELECT MAX(employee_no) FROM [EMPLOYEEPROFILE]";
                        cmd = new SqlCommand(commandString, con);
                        Int32 vEmp = Convert.ToInt32(cmd.ExecuteScalar());
                        Session["VempNo"] = vEmp;

                        String username = generateUName(TextBox4.Text, TextBox7.Text, TextBox8.Text);
                        String password = generatePWord();
                        commandString = "INSERT INTO [LOGIN] (employee_no, username, password) VALUES (" + vEmp + ",'" + username + "','" + password + "')";
                        cmd = new SqlCommand(commandString, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        cmd.Dispose();

                        try
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                            mail.From = new MailAddress("cs192.mp@gmail.com");
                            mail.To.Add(TextBox3.Text);
                            mail.Subject = "Welcome to our company!";
                            mail.IsBodyHtml = true;
                            mail.Body = "*This is a machine generated message.*<br/><br/><br/> Dear " + TextBox7.Text + " " + TextBox4.Text + ", <br/><br/>Welcome to Jimenez' Direct-Selling Company. <br/><br/>Please take note of your username: <b>" + username + "</b> and password: <b>" + password + "</b>. <br/>Do not give your password to anyone. You can change your password anytime at the Change Password Module of your account. <br/><br/> Thank you!";

                            SmtpServer.Port = 587;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("cs192.mp", "directsellingdatabase");
                            SmtpServer.EnableSsl = true;

                            SmtpServer.Send(mail);
                            //Response.Write("<script>alert('mail sent');</script>");
                            Session["profileUpdate"] = 2;
                        }
                        catch (Exception ex)
                        {
                            //Response.Write("<script>alert('" + ex.ToString() + "');</script>");
                            con.Open();
                            commandString = "INSERT INTO [NOTIFY] (employee_no) VALUES (" + vEmp + ")";
                            cmd = new SqlCommand(commandString, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmd.Dispose();

                            Session["profileUpdate"] = 3;
                        }

                        Response.Redirect("HRViewEmployeeProfile.aspx", false);
                    }
                }
            }catch(Exception err){
                Label12.Text = "Incorrect input.";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRViewEmployee.aspx",false);
        }
        public Boolean check(Int32 location, Int32 position)
        {
            if (position == 2)
            {
                String commandString3 = " SELECT [gender] FROM [EMPLOYEEPROFILE] WHERE [location]=" + location + " AND [position]=2";
                SqlCommand cmd = new SqlCommand(commandString3, con);

                if (cmd.ExecuteScalar().ToString()!=null)
                 {
                     Label12.Text = "There is already a UM in this Location";
                     return false;
                 } 
            }
            else if (position == 3)
            {
                String commandString = " SELECT [Location_Name] FROM [LOCATION] WHERE [Location_No]=" + location ;
                SqlCommand cmd = new SqlCommand(commandString, con);
                String locname = cmd.ExecuteScalar().ToString();

                commandString = " SELECT [Location_No] FROM [LOCATION] WHERE [Location_Name]='" + locname+"'";
                SqlDataAdapter ad = new SqlDataAdapter(commandString,con);
                DataSet ds = new DataSet();
                ad.Fill(ds,"locnos");

                foreach(DataRow myDataRow in ds.Tables["locnos"].Rows ){
                    commandString = " SELECT [gender] FROM [EMPLOYEEPROFILE] WHERE [location]=" + myDataRow["Location_No"].ToString() + " AND [position]=3";
                    cmd = new SqlCommand(commandString, con);

                    if (cmd.ExecuteScalar()!=null)
                    {
                        Label12.Text = "There is already a SM in this Location";
                        return false;
                    } 
                }

            }
                return true;
            
        }
        public Boolean checkSSSTIN(String SSS, String TIN)
        {
            Boolean isUnique = true;
            String commandString3 = " SELECT [SSS],[TIN] FROM [EMPLOYEEPROFILE]";
            SqlDataAdapter adapter1 = new SqlDataAdapter(commandString3, con);
            DataSet ds = new DataSet();
            adapter1.Fill(ds, "SSSTIN");
            foreach (DataRow myDataRow in ds.Tables["SSSTIN"].Rows)
            {
                if (myDataRow["SSS"].ToString().Equals(SSS) || myDataRow["TIN"].ToString().Equals(TIN))
                {
                    isUnique = false;
                }
            }
            return isUnique;

        }
        public String generateUName(String lname, String fname, String mname)
        {   
            String username = fname.Substring(0, 1).ToLower() + mname.Substring(0, 1).ToLower() + lname.ToLower().Replace(" ", string.Empty);
            String oUsername = username;
            String commandString3 = " SELECT [username] FROM [LOGIN] ORDER BY [username]";
            SqlDataAdapter adapter1 = new SqlDataAdapter(commandString3, con);
            DataSet ds = new DataSet();
            adapter1.Fill(ds, "USERNAME");
            int count = 1;
            foreach (DataRow myDataRow in ds.Tables["USERNAME"].Rows)
            {
                if (myDataRow["username"].ToString().Equals(username))
                {
                    username = oUsername + count;
                    count++;
                }
            }
            return username;

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
        public string date(string given)
        {
            string editedDate = "";
            string[] parsedGiven = given.Split('/');
            string month = parsedGiven[0];
            if (month.Equals("1"))
                editedDate = "January";
            else if (month.Equals("2"))
                editedDate = "February";
            else if (month.Equals("3"))
                editedDate = "March";
            else if (month.Equals("4"))
                editedDate = "April";
            else if (month.Equals("5"))
                editedDate = "May";
            else if (month.Equals("6"))
                editedDate = "June";
            else if (month.Equals("7"))
                editedDate = "July";
            else if (month.Equals("8"))
                editedDate = "August";
            else if (month.Equals("9"))
                editedDate = "September";
            else if (month.Equals("10"))
                editedDate = "October";
            else if (month.Equals("11"))
                editedDate = "November";
            else if (month.Equals("12"))
                editedDate = "December";
            return editedDate;
        }
    }
}