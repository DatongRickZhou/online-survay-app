using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace week2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void StartButton_Click(object sender, EventArgs e)
        {
            try {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand newuserInsert = new SqlCommand("INSERT INTO users (fname, lname, dob, ipaddress, phonenumber,survayDate) VALUES (@Fname,@Lname,@Dob,@Ipaddress,@Phone,@survaydate); SELECT CAST(scope_identity() AS int); ", connection);

                    SqlParameter firstname = new SqlParameter();
                    firstname.ParameterName = "@Fname";
                    firstname.Value = FirstNameTextBox.Text;

                    SqlParameter lastname = new SqlParameter();
                    lastname.ParameterName = "@Lname";
                    lastname.Value = LastNameTextBox.Text;

                    SqlParameter DOB = new SqlParameter();
                    DOB.ParameterName = "@Dob";
                    DOB.Value = DateTime.Parse(DOBTextBox.Text);

                    SqlParameter Ipaddress = new SqlParameter();
                    Ipaddress.ParameterName = "@Ipaddress";
                    Ipaddress.Value = GetIPAddress();

                    SqlParameter phonenumber = new SqlParameter();
                    phonenumber.ParameterName = "@Phone";
                    phonenumber.Value = PhoneNumberTextBox.Text;

                    SqlParameter survaydate = new SqlParameter();
                    survaydate.ParameterName = "@survaydate";
                    survaydate.Value = DateTime.UtcNow.Date;

                    newuserInsert.Parameters.Add(firstname);
                    newuserInsert.Parameters.Add(lastname);
                    newuserInsert.Parameters.Add(DOB);
                    newuserInsert.Parameters.Add(phonenumber);
                    newuserInsert.Parameters.Add(Ipaddress);
                    newuserInsert.Parameters.Add(survaydate);
                    int userid = (int)newuserInsert.ExecuteScalar();
                    User user = new User(userid, FirstNameTextBox.Text, LastNameTextBox.Text, DateTime.Parse(DOBTextBox.Text), PhoneNumberTextBox.Text);
                    AppSession.saveUserInSession(user);

                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex);
            }
            
            Server.Transfer("QuestionPage.aspx");

        }

        protected void SkipButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = GetConnection()) { 
            SqlCommand newuserInsert = new SqlCommand("INSERT INTO users (ipaddress,survayDate) VALUES (@Ipaddress,@survaydate); SELECT CAST(scope_identity() AS int); ", connection);
           
            SqlParameter Ipaddress = new SqlParameter();
            Ipaddress.ParameterName = "@Ipaddress";
            Ipaddress.Value = GetIPAddress();

            SqlParameter survaydate = new SqlParameter();
            survaydate.ParameterName = "@survaydate";
            survaydate.Value = DateTime.UtcNow.Date;

            
            newuserInsert.Parameters.Add(Ipaddress);
            newuserInsert.Parameters.Add(survaydate);

            int userid = (int)newuserInsert.ExecuteScalar();
            User user = new User(userid);

            AppSession.saveUserInSession(user);
            Response.Redirect("QuestionPage.aspx");
            }

        }

        private static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["questionConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //connection to question DB
            return connection;
        }

        private string GetIPAddress()
        {
            //get IP through PROXY
            //====================
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            //should break ipAddress down, but here is what it looks like:
            // return ipAddress;
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] address = ipAddress.Split(',');
                if (address.Length != 0)
                {
                    return address[0];
                }
            }
            //if not proxy, get nice ip, give that back :(
            //ACROSS WEB HTTP REQUEST
            //=======================
            ipAddress = context.Request.UserHostAddress;//ServerVariables["REMOTE_ADDR"];

            if (ipAddress.Trim() == "::1")//ITS LOCAL(either lan or on same machine), CHECK LAN IP INSTEAD
            {
                //This is for Local(LAN) Connected ID Address
                string stringHostName = System.Net.Dns.GetHostName();
                //Get Ip Host Entry
                System.Net.IPHostEntry ipHostEntries = System.Net.Dns.GetHostEntry(stringHostName);
                //Get Ip Address From The Ip Host Entry Address List
                System.Net.IPAddress[] arrIpAddress = ipHostEntries.AddressList;

                try
                {
                    ipAddress = arrIpAddress[1].ToString();
                }
                catch
                {
                    try
                    {
                        ipAddress = arrIpAddress[0].ToString();
                    }
                    catch
                    {
                        try
                        {
                            arrIpAddress = System.Net.Dns.GetHostAddresses(stringHostName);
                            ipAddress = arrIpAddress[0].ToString();
                        }
                        catch
                        {
                            ipAddress = "127.0.0.1";
                        }
                    }
                }
            }
            return ipAddress;
        }

        protected void ResearchButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("ResearchPage.aspx");
        }
    }
}