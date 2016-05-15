using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.productDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'productDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.productDataSet.Product);

        }

        private void showDetailButton_Click(object sender, EventArgs e)
        {
            DetailForm details = new DetailForm();
            details.ShowDialog();
            this.productTableAdapter.Fill(this.productDataSet.Product);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.productTableAdapter.FillByPrice(this.productDataSet.Product);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.productTableAdapter.FillByUnits(this.productDataSet.Product);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal average;
            average = (decimal)this.productTableAdapter.averagePrice();// must cast all sql with things that returns data;
            MessageBox.Show("Average is : " + average.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.productTableAdapter.searchBy(this.productDataSet.Product, @textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.productTableAdapter.Fill(this.productDataSet.Product);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int qty = 0;
            decimal price = 0;

            if (!int.TryParse(textBox3.Text, out qty)) 
            {
                MessageBox.Show("Invalid qty");
                textBox3.Clear();
                textBox3.Focus();
            }
            else if (!decimal.TryParse(textBox4.Text, out price))
            {
                MessageBox.Show("Invalid qty");
                textBox3.Clear();
                textBox3.Focus();
            }
            else
            {
                try
                {
                    this.productTableAdapter.UpdateQuery(textBox3.Text, textBox2.Text, qty, price, textBox3.Text);
                    this.productTableAdapter.Fill(this.productDataSet.Product);
                }
                catch
                {
                    MessageBox.Show("Error-Not updated");
                }
            }
        }
    }
}
