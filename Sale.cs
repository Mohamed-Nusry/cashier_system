using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDBConnection;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Assignment
{
    public partial class Sale : Form
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
        public int up;
        public String ok = "false";

        public Sale()
        {
            
            InitializeComponent();
        }     
        private void Sale_Load(object sender, EventArgs e)
        {
            customer();     
        }
        private void button2_Click(object sender, EventArgs e)
        {     
            PizzaDBConnection.DBConnection DB = new PizzaDBConnection.DBConnection();
            SqlConnection con;
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM SALE",DB.createConnection());
            DataTable dta = new DataTable();
            sda.Fill(dta);
            dataGridViewsale.DataSource = dta;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Dashcashier dc = new Dashcashier();
            dc.Show();
            this.Hide();
        }    
        private void textBox1Product_ID_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(label16.Text) == 0)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
            
            PizzaDBConnection.Products prod = new PizzaDBConnection.Products();
            SqlDataReader reader = prod.getProducts(textBox1Product_ID.Text);
            if (reader.Read())
            {
                textBox2Product_Name.Text = Convert.ToString(reader["Product_Name"]);
                textBox3Unit_Prize.Text = Convert.ToString(reader["Product_Price"]);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label16.Text = String.Empty;
            label14.Text = String.Empty;
            label12.Text = String.Empty;
            textBoxSale_ID.Text = String.Empty;
            textBox1Product_ID.Text = String.Empty;
            textBox2Product_Name.Text = String.Empty;
            comboBox1Product_Size.Text = String.Empty;
            textBox4Product_Quantity.Text = (0.ToString());
            textBox3Unit_Prize.Text = (0.ToString());
            comboBox2Payment_Type.Text = String.Empty;
            textBox1TotalAmount.Text = String.Empty;
            textBox5Total_Price.Text = String.Empty;

            Salerec rec = new Salerec();
            rec.CustomerID = rec.CustomerID + CustomerID;
            rec.SaleID = rec.SaleID+SaleID;
            rec.Product_ID = rec.Product_ID  + Product_ID;
            rec.Product_Name = rec.Product_Name +  Product_Name;
            rec.Product_Size = rec.Product_Size +  Product_Size;
            rec.Product_Quantity = rec.Product_Quantity +  Product_Quantity;
            rec.Unit_Price = rec.Unit_Price + Unit_Price;
            rec.Payment_Type = rec.Payment_Type  + Payment_Type;
            rec.Total_Price =  Total_Price;
            rec.amount = rec.amount + amount;
            rec.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int val = 0;
            int total = Convert.ToInt32(textBox4Product_Quantity.Text) * Convert.ToInt32(textBox3Unit_Prize.Text);
            val = Convert.ToInt32(textBox5Total_Price.Text) + total;
            textBox5Total_Price.Text = (val.ToString());
            ok = "false";
            try
            {
                makesale();
                
              
            }
            catch(Exception ex)
            {
                MessageBox.Show("Try again");
            }
            if (ok == "true")
            {
                int sales = Convert.ToInt32(label14.Text) + 1;
                label14.Text = (sales.ToString());
                CustomerID =label12.Text;
                SaleID = SaleID  + textBoxSale_ID.Text+" , ";
                Product_ID = Product_ID + textBox1Product_ID.Text + " , ";
                Product_Name = Product_Name + textBox2Product_Name.Text + " , ";
                Product_Size = Product_Size + comboBox1Product_Size.Text + " , ";
                Product_Quantity = Product_Quantity + textBox4Product_Quantity.Text + " , ";
                Unit_Price = Unit_Price + textBox3Unit_Prize.Text + " , ";
                Payment_Type = Payment_Type + comboBox2Payment_Type.Text + " , ";
                amount = amount + textBox1TotalAmount.Text+" , ";
                Total_Price = Convert.ToInt32(textBox5Total_Price.Text);
               
                textBoxSale_ID.Text = String.Empty;
                textBox1Product_ID.Text = String.Empty;
                textBox2Product_Name.Text = String.Empty;
                comboBox1Product_Size.Text = String.Empty;
               textBox4Product_Quantity.Text = (0.ToString());
                textBox3Unit_Prize.Text = (0.ToString());
                comboBox2Payment_Type.Text = String.Empty;
                textBox1TotalAmount.Text = String.Empty;
                button5.Enabled = true;
                MessageBox.Show("Added to the cart");
            }
            else
            {
                MessageBox.Show("Cannot add empty products to the cart");
            }
        }
        public void makesale()
        {
            try
            {
                if (textBoxSale_ID.Text == "" || textBox2Product_Name.Text == "" || textBox3Unit_Prize.Text == "" || textBox1Product_ID.Text == "" || comboBox1Product_Size.Text == "" || comboBox2Payment_Type.Text == ""||textBox1TotalAmount.Text == "" || textBox4Product_Quantity.Text == "" || textBox5Total_Price.Text == "")
                {
                    MessageBox.Show("Enter Sale ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                }
                else
                {
                    ok = "true";                  
                    PizzaDBConnection.Sale sl = new PizzaDBConnection.Sale();
                    sl.Sale_ID1 = textBoxSale_ID.Text;
                    sl.Product_ID1 = textBox1Product_ID.Text;
                    sl.Product_Name1 = textBox2Product_Name.Text;
                    sl.Product_Size1 = comboBox1Product_Size.Text;
                    sl.Product_Quantity1 = Convert.ToInt32(textBox4Product_Quantity.Text);
                    sl.Unit_Price1 = Convert.ToInt32(textBox3Unit_Prize.Text.ToString());
                    sl.Payment_Type1 = comboBox2Payment_Type.Text;
                    sl.Total_Price1 = Convert.ToInt32(textBox1TotalAmount.Text.ToString());
                    sl.insertSale(sl);                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed, Something went wrong");
            }
            }   
        public void customer()
        {
            PizzaDBConnection.DBConnection DB = new PizzaDBConnection.DBConnection();
            PizzaDBConnection.Login lgn = new PizzaDBConnection.Login();
            int a = 0;
            int count = 0;
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Sale", DB.createConnection());// where Username='" + textBox1username.Text + "' and Password='" + textBox2password.Text + "' and Role='" + comboBoxtype.Text + "'", DB.createConnection());
            DataTable dt = new DataTable();
            sda.Fill(dt);

            a = Convert.ToInt32(dt.Rows[0][0].ToString());
            count = a + Convert.ToInt32(label14.Text);

            label12.Text = (count.ToString());         
            }

        private void textBox4Product_Quantity_Leave(object sender, EventArgs e)
        {        
            int total = Convert.ToInt32(textBox4Product_Quantity.Text) * Convert.ToInt32(textBox3Unit_Prize.Text);
           
            if (textBox4Product_Quantity.Text == String.Empty)
            {
                textBox4Product_Quantity.Text = "1";
            }     
            textBox1TotalAmount.Text = (total.ToString());
        }
        private void comboBox1Product_Size_Leave(object sender, EventArgs e)
        {
           
            if (comboBox1Product_Size.Text == "Large")
            {
                up = Convert.ToInt32(label16.Text)+ 350;
               
            }
            else if (comboBox1Product_Size.Text == "Medium")
            {
                up = Convert.ToInt32(label16.Text) + 200;
            }
            else if (comboBox1Product_Size.Text == "Small")
            {
                up = Convert.ToInt32(label16.Text) + 0;
            }


            textBox3Unit_Prize.Text = (up.ToString());

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            up = Convert.ToInt32(textBox3Unit_Prize.Text);
            label16.Text = (up.ToString());
            timer1.Enabled = false;      
        }

        private void textBox1Product_ID_Click(object sender, EventArgs e)
        {
            label16.Text = (0.ToString());
        }

        private void comboBox1Product_Size_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            textBox3Unit_Prize.Text = label16.Text;       
        }
    }
    }

