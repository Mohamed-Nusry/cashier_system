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
    public partial class Raw_Meterials : Form
    {
        public Raw_Meterials()
        {
            InitializeComponent();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Dashadmin dash = new Dashadmin();
            this.Hide();
            dash.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PizzaDBConnection.Raw_Meterials raw = new PizzaDBConnection.Raw_Meterials();
            if (textBox1RawID.Text == String.Empty)
            {
                MessageBox.Show("Fields cannot be empty");
            }
            else
            {
                raw.Raw_ID1 = Convert.ToString(textBox1RawID.Text);
                raw.Raw_Name1 = Convert.ToString(textBox2RawName.Text);
                raw.Raw_Quantity1 = Convert.ToString(textBox3RawQuantity.Text);
                raw.Raw_Total1 = int.Parse(textBox4RawTotal.Text);
                raw.Raw_Unit_Price1 = int.Parse(textBox6RawUnitPrice.Text);
                raw.Date = Convert.ToString(textBox5RawDate.Text);
                raw.insertRaw_Meterials(raw);
                MessageBox.Show("Added");
                viewraw();
                textBox1RawID.Text = String.Empty;
                textBox2RawName.Text = String.Empty;
                textBox3RawQuantity.Text = String.Empty;
                textBox4RawTotal.Text = String.Empty;
                textBox5RawDate.Text = String.Empty;
                textBox6RawUnitPrice.Text = String.Empty;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            viewraw();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            PizzaDBConnection.Raw_Meterials raw = new PizzaDBConnection.Raw_Meterials();
            if (textBox1RawID.Text == String.Empty || textBox2RawName.Text == String.Empty || textBox3RawQuantity.Text == String.Empty || textBox4RawTotal.Text == String.Empty || textBox5RawDate.Text == String.Empty || textBox6RawUnitPrice.Text == String.Empty) 
            {
                MessageBox.Show("Fields cannot be empty");
            }
            else
            {
                raw.Raw_ID1 = Convert.ToString(textBox1RawID.Text);
                raw.Raw_Name1 = Convert.ToString(textBox2RawName.Text);
                raw.Raw_Quantity1 = Convert.ToString(textBox3RawQuantity.Text);
                raw.Raw_Total1 = int.Parse(textBox4RawTotal.Text);
                raw.Raw_Unit_Price1 = int.Parse(textBox6RawUnitPrice.Text);
                raw.Date = Convert.ToString(textBox5RawDate.Text);
                raw.updateRaw_Meterials(raw);
                MessageBox.Show("Updated");
                viewraw();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            PizzaDBConnection.Raw_Meterials raw = new PizzaDBConnection.Raw_Meterials();
            if (textBox1RawID.Text == String.Empty)
            {
                label1.ForeColor = Color.DarkRed;
                MessageBox.Show("Enter RawID To Delete");
            }
            else
            {
                label1.ForeColor = Color.Black;
                raw.deleteRaw_Meterials(textBox1RawID.Text);
                MessageBox.Show("Deleted");
                textBox1RawID.Text = String.Empty;
                textBox2RawName.Text = String.Empty;
                textBox3RawQuantity.Text = String.Empty;
                textBox4RawTotal.Text = String.Empty;
                textBox5RawDate.Text = String.Empty;
                textBox6RawUnitPrice.Text = String.Empty ;
                viewraw();
            }
        }
        public void viewraw()
        {
            PizzaDBConnection.Raw_Meterials viewraw = new PizzaDBConnection.Raw_Meterials();
            PizzaDBConnection.DBConnection db = new PizzaDBConnection.DBConnection();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Raw_Meterials", db.createConnection());
            DataTable dta = new DataTable();
            sda.Fill(dta);
            dataGridView1viewraw.DataSource = dta;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1RawID.Text = String.Empty;
            textBox2RawName.Text = String.Empty;
            textBox3RawQuantity.Text = String.Empty;
            textBox4RawTotal.Text = String.Empty;
            textBox5RawDate.Text = String.Empty;
            textBox6RawUnitPrice.Text = String.Empty;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1RawID.Text == String.Empty)
            {
                MessageBox.Show("Enter RawID To Search");
                label1.ForeColor = Color.DarkRed;
            }
            else
            {
                label1.ForeColor = Color.Black;
                PizzaDBConnection.Raw_Meterials raw = new PizzaDBConnection.Raw_Meterials();
                SqlDataReader reader = raw.getRaw_Meterials(textBox1RawID.Text);
                if (reader.Read())
                {
                    textBox2RawName.Text = Convert.ToString(reader["Raw_Name"]);
                    textBox3RawQuantity.Text = Convert.ToString(reader["Raw_Quantity"]);
                    textBox4RawTotal.Text = Convert.ToString(reader["Raw_Total"]);
                    textBox5RawDate.Text = Convert.ToString(reader["Date"]);
                    textBox6RawUnitPrice.Text = Convert.ToString(reader["Raw_Unit_Price"]);                  
                }
            }
        }

        private void Raw_Meterials_Load(object sender, EventArgs e)
        {
            viewraw();
        }
    }
}
