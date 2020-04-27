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
    
    public partial class Dashcashier : Form
    {
        public String name;
        public Dashcashier()
        {
            InitializeComponent();
        }
        private void Dashcashier_Load(object sender, EventArgs e)
        {
            label2.Text = name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sale sle = new Sale();
            sle.Show();
            this.Hide();
        }   
        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.MediumSlateBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.WhiteSmoke;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to logout?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Login lgn = new Login();
                lgn.Show();
                this.Hide();
            }
            else if (result == DialogResult.No)
            {
                
            }  
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.MediumSlateBlue;
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.WhiteSmoke;
        }
    }
}
