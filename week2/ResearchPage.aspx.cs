using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace week2
{
    public partial class ResearchPage : System.Web.UI.Page
    {
        private static string endSimble = ");";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                //load option for Gender
                try
                {
                    using (SqlConnection connection = GetConnection())
                    {
                        SqlCommand command = new SqlCommand("Select * from options where qid = 1", connection);
                        SqlDataReader reader = command.ExecuteReader();
                        GenderDropdownList.DataSource = reader;
                        GenderDropdownList.DataTextField = "description";
                        GenderDropdownList.DataValueField = "oid";
                        GenderDropdownList.DataBind();
                        GenderDropdownList.Items.Insert(0, new ListItem("Please select", "Default value"));

                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex);
                }

                //load option for State
                try
                {
                    using (SqlConnection connection = GetConnection())
                    {
                        SqlCommand command = new SqlCommand("Select * from options where qid = 3", connection);
                        SqlDataReader reader = command.ExecuteReader();

                        StateDropDownList.DataSource = reader;
                        StateDropDownList.DataTextField = "description";
                        StateDropDownList.DataValueField = "oid";
                        StateDropDownList.DataBind();
                        StateDropDownList.Items.Insert(0, new ListItem("Please select", "Default value"));

                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex);
                }

                //load option for Bank
                try
                {
                    using (SqlConnection connection = GetConnection())
                    {
                        SqlCommand command = new SqlCommand("Select * from options where qid = 7", connection);
                        SqlDataReader reader = command.ExecuteReader();
                        BankDropdownList.DataSource = reader;
                        BankDropdownList.DataTextField = "description";
                        BankDropdownList.DataValueField = "oid";
                        BankDropdownList.DataBind();
                        BankDropdownList.Items.Insert(0, new ListItem("Please select", "Default value"));
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex);
                }

                //load option for Service
                try
                {
                    using (SqlConnection connection = GetConnection())
                    {
                        SqlCommand command = new SqlCommand("Select * from options where qid = 13", connection);
                        SqlDataReader reader = command.ExecuteReader();
                        
                        ServiceDropdownList.DataSource = reader;
                        ServiceDropdownList.DataTextField = "description";
                        ServiceDropdownList.DataValueField = "oid";
                        ServiceDropdownList.DataBind();
                        ServiceDropdownList.Items.Insert(0, new ListItem("Please select", "Default value"));
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex);
                }

            }
            
            
        }
        protected void confirm_Click(object sender, EventArgs e)
        {
            string commond = "select * from users Where uid in ( Select uid from answer Where";
           
            //check gender selected
            string a = GenderDropdownList.SelectedItem.Value;
            if (GenderDropdownList.SelectedIndex != 0)
            {
                string condition = " oid = " + GenderDropdownList.SelectedItem.Value + " or";
                commond += condition;
                
            }
            else {

            }
            if (StateDropDownList.SelectedIndex != 0) {
                string condition = " oid = " + StateDropDownList.SelectedItem.Value + " or";
                commond += condition;
               
            }
            if (BankDropdownList.SelectedIndex != 0) {
                string condition = " oid = " + BankDropdownList.SelectedItem.Value + " or";
                commond += condition;
                
            }
            if (ServiceDropdownList.SelectedIndex != 0) {
                string condition = " oid = " + ServiceDropdownList.SelectedItem.Value + " or";
                commond += condition;
               
            }
            commond = commond.Substring(0, commond.Length - 3);
            commond += endSimble;

            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    //SqlCommand query = new SqlCommand(commond,connection);
                    SqlCommand command1 = new SqlCommand(commond, connection);
                    SqlDataReader reader = command1.ExecuteReader();
                    // this will query your database and return the result to your datatable
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("User ID ", typeof(Int32));
                    dataTable.Columns.Add("First Name ", typeof(String));
                    dataTable.Columns.Add("Last Name ", typeof(String));
                    dataTable.Columns.Add("Ip Address ", typeof(String));
                    dataTable.Columns.Add("Phone Number ", typeof(String));
                    dataTable.Columns.Add("Survay Date ", typeof(String));
 
                    while (reader.Read()) {
                        DataRow row = dataTable.NewRow();
                        row["User ID "] = reader["uid"];
                        row["First Name "] = reader["fname"];
                        row["Last Name "] = reader["lname"];
                        row["Ip Address "] = reader["ipaddress"];
                        row["Phone Number "] = reader["phonenumber"];
                        row["Survay Date "] = reader["survayDate"];
                        dataTable.Rows.Add(row);
                    }
                    
                    researchTable.DataSource = dataTable;
                    researchTable.DataBind();

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex);
            }

        }

        protected void reset_Click(object sender, EventArgs e)
        {

            Response.Redirect(Request.Url.ToString());

        }

        private static SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["questionConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            //connection to question DB
            return connection;
        }
    }

}