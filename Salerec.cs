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
    public partial class Salerec : Form
    {
        public String CustomerID;
        public String SaleID;
        public String Product_ID;
        public String Product_Name;
        public String Product_Size;
        public String Product_Quantity;
        public String Unit_Price;
        public String Payment_Type;
        public String amount;
        public int Total_Price;

        public Salerec()
        {
            InitializeComponent();
        }

        private void Salerec_Load(object sender, EventArgs e)
        {
            setrec();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        public void setrec()
        {
            label18.Text = CustomerID;
            label9.Text = label9.Text + SaleID;
            label10.Text = label10.Text + Product_ID;
            label11.Text = label11.Text + Product_Name;
            label12.Text = label12.Text + Product_Size;
            label13.Text = label13.Text + (Product_Quantity.ToString());
            label14.Text = label14.Text + (Unit_Price.ToString());
            label15.Text = label15.Text + Payment_Type;
            label20.Text = label20.Text + (amount.ToString()) + " ' ";
            label16.Text =  (Total_Price.ToString());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Sale rec = new Sale();
            rec.CustomerID = String.Empty;
            rec.SaleID = String.Empty;
            rec.Product_ID = String.Empty;
            rec.Product_Name = String.Empty;
            rec.Product_Size = String.Empty;
            rec.Product_Quantity = String.Empty;
            rec.Unit_Price = String.Empty;
            rec.Payment_Type = String.Empty;
            rec.amount = String.Empty;
            rec.Total_Price = 0;
            rec.customer();

            SaleID = String.Empty;
            Product_ID = String.Empty;
            Product_Name = String.Empty;
            Product_Size = String.Empty;
            Product_Quantity = String.Empty;
            Unit_Price = String.Empty;
            Payment_Type = String.Empty;
            amount = String.Empty;
            Total_Price = 0;
            setrec();
            Sale sle = new Sale();
            sle.Show();
            this.Hide();
        }
    }
}
