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
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshList(getListOfProductFromSession());
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.Name = NameTextBox.Text;
                p.Description = DescriptionTextBox.Text;
                p.Price = float.Parse(PriceTextBox.Text);
                List<Product> products = getListOfProductFromSession();
                products.Add(p);

                HttpContext.Current.Session["products"] = products;
                refreshList(products);

            }
            catch (Exception ex)
            {

            }
        }
        
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            List<Product> products = getListOfProductFromSession();
            using (SqlConnection connection = ConnectionTosqlDB())
            {
                foreach (Product p in products) {
                    SqlCommand command = new SqlCommand("insert into Products (name,description,price) values ('"+p.Name+"','"+p.Description+"',"+p.Price+")", connection);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0) {
                         //did not insert this product scussful
                    }
                }
            }
            products.Clear();
            HttpContext.Current.Session["products"] = products;
            refreshList(products);

        }
        private static List<Product> getListOfProductFromSession() {
            if (HttpContext.Current.Session["products"] != null)
                return (List<Product>)HttpContext.Current.Session["products"];
            return new List<Product>();
        }
        private void refreshList(List<Product> products) {
            ProductBulletedList.Items.Clear();
            foreach (Product p in products) {
                ProductBulletedList.Items.Add(p.Name);

            }
        }
        private static SqlConnection ConnectionTosqlDB()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionstring);

            connection.Open();
            return connection;
        }
    }
}