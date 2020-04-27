using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Assignment
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        private void Products_Load(object sender, EventArgs e)
        {
            viewproducts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashadmin dash = new Dashadmin();
            this.Hide();
            dash.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            viewproducts();          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1Product_ID.Text == String.Empty || textBox2ProductName.Text == String.Empty || textBox3ProductPrice.Text == String.Empty || textBox5ProductQuantity.Text == String.Empty)
            {
                MessageBox.Show("Fields cannot be empty (make sure you have searched a product)");
            }
            else
            {
                try
                {
                    PizzaDBConnection.Products prod = new PizzaDBConnection.Products();
                    prod.Product_ID1 = textBox1Product_ID.Text;
                    prod.Product_Name1 = textBox2ProductName.Text;
                    prod.Product_Price1 = Convert.ToInt32(textBox3ProductPrice.Text);
                    prod.Product_Quantity1 = Convert.ToInt32(textBox5ProductQuantity.Text);
                    prod.insertProducts(prod);
                    MessageBox.Show("Added");
                    viewproducts();
                    textBox1Product_ID.Text = String.Empty;
                    textBox2ProductName.Text = String.Empty;
                    textBox3ProductPrice.Text = String.Empty;
                    textBox5ProductQuantity.Text = String.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1Product_ID.Text == "")
            {
                label1.ForeColor = Color.DarkRed;
                MessageBox.Show("Enter Product ID To Delete");
            }
            else
            {
                label1.ForeColor = Color.Black;
                PizzaDBConnection.Products produ = new PizzaDBConnection.Products();
                produ.deleteProducts(textBox1Product_ID.Text);
                MessageBox.Show("Deleted");
                textBox1Product_ID.Text = String.Empty;
                textBox2ProductName.Text = String.Empty;
                textBox3ProductPrice.Text = String.Empty;
                textBox5ProductQuantity.Text = String.Empty;
                viewproducts();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1Product_ID.Text == "")
            {
                label1.ForeColor = Color.DarkRed;
 
                MessageBox.Show("Please Enter the Product ID");
            }
            else
            {
                label1.ForeColor = Color.Black;
                PizzaDBConnection.Products products = new PizzaDBConnection.Products();
                SqlDataReader reader = products.getProducts(textBox1Product_ID.Text);
                if (reader.Read())
                {
                    textBox2ProductName.Text = Convert.ToString(reader["Product_Name"]);
                    textBox3ProductPrice.Text = Convert.ToString(reader["Product_Price"]);
                    textBox5ProductQuantity.Text = Convert.ToString(reader["Product_Quantity"]);
                }               
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1Product_ID.Text = String.Empty;
            textBox2ProductName.Text = String.Empty;
            textBox3ProductPrice.Text = String.Empty;
            textBox5ProductQuantity.Text = String.Empty;
        }
        public void viewproducts()
        {
            PizzaDBConnection.DBConnection db = new PizzaDBConnection.DBConnection();
            PizzaDBConnection.Products pro = new PizzaDBConnection.Products();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Products", db.createConnection());
            DataTable dta = new DataTable();
            sda.Fill(dta);
            dataGridView1.DataSource = dta;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1Product_ID.Text == String.Empty || textBox2ProductName.Text == String.Empty || textBox3ProductPrice.Text == String.Empty || textBox5ProductQuantity.Text == String.Empty)
            {
                MessageBox.Show("Fields cannot be empty (make sure you have searched a product)");

            }
            else
            {
                try
                {
                    PizzaDBConnection.Products prod = new PizzaDBConnection.Products();
                    prod.Product_ID1 = textBox1Product_ID.Text;
                    prod.Product_Name1 = textBox2ProductName.Text;
                    prod.Product_Price1 = Convert.ToInt32(textBox3ProductPrice.Text);
                    prod.Product_Quantity1 = Convert.ToInt32(textBox5ProductQuantity.Text);
                    prod.updateProducts(prod);
                    MessageBox.Show("Updated");
                    viewproducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {          
           if (textBox2ProductName.Text == String.Empty)
            {
                timer2.Enabled = true;
                textBox2ProductName.Text = "Empty";
                
            }
            else if(textBox3ProductPrice.Text == String.Empty)
            {
                timer2.Enabled = true;
                textBox3ProductPrice.Text = "Empty";
               
            }
            else if (textBox5ProductQuantity.Text == String.Empty)
            {
                timer2.Enabled = true;
                textBox5ProductQuantity.Text = "Empty";               
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
        }
    }
}
