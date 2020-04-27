using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class Dashadmin : Form
    {
        public String name;
        public Dashadmin()
        {
            InitializeComponent();
        }

        private void Dashadmin_Load(object sender, EventArgs e)
        {
            label2.Text = name;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AdminViewSale avs = new AdminViewSale();
            avs.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Raw_Meterials raw = new Raw_Meterials();
            this.Hide();
            raw.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Products prod = new Products();
            this.Hide();
            prod.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to logout?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Login lgn = new Login();
                this.Hide();
                lgn.Show();
            }
            else if (result == DialogResult.No)
            {
            }          
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.ForeColor= Color.Lime;
            timer2.Enabled = true;
            timer1.Enabled = false;           
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Maroon;
            timer2.Enabled = false;
            timer1.Enabled = true;
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.MediumSlateBlue;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.MediumSlateBlue;
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.WhiteSmoke;
        }
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.MediumSlateBlue;
        }
        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.WhiteSmoke;
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.MediumSlateBlue;
        }
        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.WhiteSmoke;
        }
        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.BackColor = Color.MediumSlateBlue;
        }
        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = Color.WhiteSmoke;
        }      
    }
}
