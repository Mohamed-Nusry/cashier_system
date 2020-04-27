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
    public partial class AdminViewSale : Form
    {
        public AdminViewSale()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            viewsale();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Dashadmin dash = new Dashadmin();
            this.Hide();
            dash.Show();
        }
        public void viewsale()
        {
            PizzaDBConnection.DBConnection DB = new PizzaDBConnection.DBConnection();
            SqlConnection con;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM SALE", DB.createConnection());
            DataTable dta = new DataTable();
            sda.Fill(dta);
            dataGridViewAdminSale.DataSource = dta;
        }
        private void AdminViewSale_Load(object sender, EventArgs e)
        {
            viewsale();
            count();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1SaleID.Text == String.Empty)
            {
                label1.ForeColor = Color.DarkRed;
                MessageBox.Show("Enter Product ID");
            }
            else
            {
                label1.ForeColor = Color.Black;
                PizzaDBConnection.Sale sle = new PizzaDBConnection.Sale();
                sle.deleteSale(textBox1SaleID.Text);
                MessageBox.Show("Deleted History");
                textBox1SaleID.Text = String.Empty;
                viewsale();
                count();
            }
        }
        public void count()
        {
            PizzaDBConnection.DBConnection DB = new PizzaDBConnection.DBConnection();
            PizzaDBConnection.Sale lgn = new PizzaDBConnection.Sale();
            int a ;
            int count ;
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Sale", DB.createConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            a = Convert.ToInt32(dt.Rows[0][0].ToString());
            count = a + Convert.ToInt32(label2.Text)-1;
            label12.Text = (count.ToString());
        }
    }
}
