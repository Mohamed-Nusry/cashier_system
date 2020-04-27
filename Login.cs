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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Dashadmin dash = new Dashadmin();
            Dashcashier cashier = new Dashcashier();
            PizzaDBConnection.DBConnection DB = new PizzaDBConnection.DBConnection();
            PizzaDBConnection.Login lgn = new PizzaDBConnection.Login();            
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Login where Username='" + textBox1username.Text + "' and Password='" + textBox2password.Text + "' and Role='"+comboBoxtype.Text+"'", DB.createConnection());
                DataTable dt = new DataTable();
                sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1" && comboBoxtype.Text == "Admin")
            {
                dash.name = this.textBox1username.Text;
                this.Hide();
                dash.Show();
            }
            else
            {
                if (dt.Rows[0][0].ToString() == "1" && comboBoxtype.Text == "Cashier")
                {
                    cashier.name = this.textBox1username.Text;
                    this.Hide();
                    cashier.Show();
                }
                else
                {
                    MessageBox.Show("Check the username or password and try again");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
            }         
        }
        private void Login_Load(object sender, EventArgs e)
        {
            comboBoxtype.Text = "Select the type";
            comboBoxtype.ForeColor = Color.Gray;
        }
        private void comboBoxtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxtype.ForeColor = Color.Black;
        }
        private void button5_Click(object sender, EventArgs e)
        {



        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void button3_Click(object sender, EventArgs e)
        {

        } 
    }
}







