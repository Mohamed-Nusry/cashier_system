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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox7Employee_ID.Text == "")
            {
                label7.ForeColor = Color.DarkRed;
                MessageBox.Show("Enter Employee ID To Search");
            }
            else
            {
                label7.ForeColor = Color.Black;
                PizzaDBConnection.Employee emp = new PizzaDBConnection.Employee();
                SqlDataReader reader = emp.getEmployee(textBox7Employee_ID.Text);
                if (reader.Read())
                {
                    textBox1Name.Text = Convert.ToString(reader["Name"]);
                    textBox2Address.Text = Convert.ToString(reader["Address"]);
                    textBox3Age.Text = Convert.ToString(reader["Age"]);
                    textBox4ID_No.Text = Convert.ToString(reader["ID_No"]);
                    textBox5DOB.Text = Convert.ToString(reader["DOB"]);
                    textBox8Employee_Password.Text = Convert.ToString(reader["Employee_Password"]);
                    textBox9Phone_num.Text = Convert.ToString(reader["Phone_Num"]);
                    comboBox2Role.Text = Convert.ToString(reader["Role"]);
                    comboBox1Gender.Text = Convert.ToString(reader["Gender"]);
                }
            }                 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox7Employee_ID.Text == "" && textBox1Name.Text=="" && textBox2Address.Text=="" && textBox8Employee_Password.Text=="" )
            {
                MessageBox.Show("Fields cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    PizzaDBConnection.Employee emp1 = new PizzaDBConnection.Employee();
                    PizzaDBConnection.Login log = new PizzaDBConnection.Login();
                    emp1.Employee_ID1 = textBox7Employee_ID.Text;
                    emp1.Name1 = textBox1Name.Text;
                    emp1.Address1 = textBox2Address.Text;
                    emp1.Age1 = Convert.ToInt32(textBox3Age.Text);
                    emp1.ID_No1 = textBox4ID_No.Text;
                    emp1.DOB1 = textBox5DOB.Text;
                    emp1.Role1 = comboBox2Role.Text;
                    emp1.Employee_Password1 = textBox8Employee_Password.Text;
                    emp1.Phone_Num1 = Convert.ToInt32(textBox9Phone_num.Text);
                    emp1.Gender1 = comboBox1Gender.Text;

                    log.Username1 = textBox1Name.Text;
                    log.Password1 = textBox8Employee_Password.Text;
                    log.Role1 = comboBox2Role.Text;
                    emp1.insertEmployee(emp1);
                    log.insertLogin(log);

                    MessageBox.Show("User Created");
                    textBox7Employee_ID.Text = String.Empty;
                    textBox1Name.Text = String.Empty;
                    textBox2Address.Text = String.Empty;
                    textBox3Age.Text = String.Empty;
                    textBox4ID_No.Text = String.Empty;
                    textBox5DOB.Text = String.Empty;
                    comboBox2Role.Text = String.Empty;
                    textBox8Employee_Password.Text = String.Empty;
                    textBox9Phone_num.Text = String.Empty;
                    comboBox1Gender.Text = String.Empty;
                    viewemp();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error, A data similar to this ID is already exist or Try again");
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {                     
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            viewemp();           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewemp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7Employee_ID.Text == "" && textBox1Name.Text == "" && textBox2Address.Text == "" && textBox8Employee_Password.Text == "")
            {
                MessageBox.Show("Fields cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    PizzaDBConnection.Employee emp1 = new PizzaDBConnection.Employee();
                    PizzaDBConnection.Login log = new PizzaDBConnection.Login();
                    emp1.Employee_ID1 = textBox7Employee_ID.Text;
                    emp1.Name1 = textBox1Name.Text;
                    emp1.Address1 = textBox2Address.Text;
                    emp1.Age1 = Convert.ToInt32(textBox3Age.Text);
                    emp1.ID_No1 = textBox4ID_No.Text;
                    emp1.DOB1 = textBox5DOB.Text;
                    emp1.Role1 = comboBox2Role.Text;
                    emp1.Employee_Password1 = textBox8Employee_Password.Text;
                    emp1.Phone_Num1 = Convert.ToInt32(textBox9Phone_num.Text);
                    emp1.Gender1 = comboBox1Gender.Text;

                    log.Username1 = textBox1Name.Text;
                    log.Password1 = textBox8Employee_Password.Text;
                    emp1.updateEmployee(emp1);
                    log.updateLogin(log);
                    

                    MessageBox.Show("Updated");
                    viewemp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dashadmin dash = new Dashadmin();
            this.Hide();
            dash.Show();
        }
        public void viewemp()
        {
            PizzaDBConnection.DBConnection db = new PizzaDBConnection.DBConnection();
            SqlConnection con;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM EMPLOYEE", db.createConnection());
            DataTable dta = new DataTable();
            sda.Fill(dta);
            dataGridViewEmpolyees.DataSource = dta;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox7Employee_ID.Text == "")
            {
                MessageBox.Show("Enter Employee ID To Delete");
                label1.ForeColor = Color.DarkRed;
            }
            else
            {

                label1.ForeColor = Color.Black;
                PizzaDBConnection.Employee emp1 = new PizzaDBConnection.Employee();
                PizzaDBConnection.Login log = new PizzaDBConnection.Login();

                emp1.deleteEmployee(textBox7Employee_ID.Text);
                log.deleteLogin(textBox1Name.Text);
                MessageBox.Show("Deleted");
                textBox1Name.Text = String.Empty;
                textBox2Address.Text = String.Empty;
                textBox3Age.Text = String.Empty;
                textBox4ID_No.Text = String.Empty;
                textBox5DOB.Text = String.Empty;
                comboBox2Role.Text = String.Empty;
                textBox7Employee_ID.Text = String.Empty;
                textBox8Employee_Password.Text = String.Empty;
                textBox9Phone_num.Text = String.Empty;
                comboBox1Gender.Text = String.Empty;
                viewemp();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox7Employee_ID.Text = String.Empty;
            textBox1Name.Text = String.Empty;
            textBox2Address.Text = String.Empty;
            textBox3Age.Text = String.Empty;
            textBox4ID_No.Text = String.Empty;
            textBox5DOB.Text = String.Empty;
            comboBox2Role.Text = String.Empty;
            textBox8Employee_Password.Text = String.Empty;
            textBox9Phone_num.Text = String.Empty;
            comboBox1Gender.Text = String.Empty;
        }
    }
}
