using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//new
using System.Data; //datatable
using System.Data.SqlClient; //sql stuff
using System.Configuration; //access web config file

namespace week2
{
    public partial class TestConnection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get test connection string from our web config
            string connectionString = ConfigurationManager.ConnectionStrings["questionConnection"].ConnectionString;

            //open a connection
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            //setup sql command
            SqlCommand command = new SqlCommand("SELECT * FROM TestQuestion", connection);

            //lets execute command and dump results into a reader
            SqlDataReader reader = command.ExecuteReader();

            //making empty data table to store this data in
            DataTable dt = new DataTable();
            //setup columns
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("text", typeof(String));
            dt.Columns.Add("questionType", typeof(Int32));
            dt.Columns.Add("nextQuestion", typeof(Int32));

            //loop through sql results and shove into table
            while(reader.Read())//works with 1 row at a time
            {
                //generate empty row for table
                DataRow row = dt.NewRow();
                //copy values across
                row["ID"] = reader["questionId"];
                row["text"] = reader["text"];
                row["questionType"] = reader["questionType"];
                row["nextQuestion"] = reader["nextQuestion"];
                //add this row to our data table
                dt.Rows.Add(row);
            }
            //show results in our grid view
            QuestionGridView.DataSource = dt;
            QuestionGridView.DataBind();

            //close DB connection
            connection.Close();

        }
    }
}