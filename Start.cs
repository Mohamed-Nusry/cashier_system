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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }
        private void Start_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Login lgn = new Login();
            progressBar1.Value = progressBar1.Value + 10;
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                lgn.Show();
                this.Hide();       
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 10)
            {
                w.Visible = true;
            }
            if (progressBar1.Value >= 20)
            {
                e1.Visible = true;
            }
            if (progressBar1.Value >= 36)
            {
                l.Visible = true;
            }     
            if (progressBar1.Value >= 52)
            {
                c.Visible = true;
            }
            if (progressBar1.Value >= 60)
            {
                o.Visible = true;
            }
            if (progressBar1.Value >= 68)
            {
                m.Visible = true;
            }
            if (progressBar1.Value >= 70)
            {
                e2.Visible = true;
            }
        }  
    }
}
