using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datebass
{
    public partial class supplier_manage : Form
    {
        public supplier_manage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            if (textBox10.Text != null && textBox10.Text != "")
            {
                bool result = supplier.showSupplier(textBox10.Text);
                if (result)
                {
                    textBox9.Text = supplier.supplier_id;
                    textBox3.Text = supplier.phone_number;
                    textBox4.Text = supplier.name;
                    textBox5.Text = supplier.address;
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }
            else
            {
                MessageBox.Show("供应商编号为'" + supplier.selectSupplier(textBox1.Text, textBox2.Text) + "'");
                bool result = supplier.showSupplier(textBox1.Text, textBox2.Text);
                if (result)
                {
                    textBox9.Text = supplier.supplier_id;
                    textBox3.Text = supplier.phone_number;
                    textBox4.Text = supplier.name;
                    textBox5.Text = supplier.address;
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }
        }

        private void supplier_manage_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            if(supplier.insertSupplier(textBox8.Text, textBox7.Text, textBox6.Text))
            {
                MessageBox.Show("供应商编号为'" + supplier.selectSupplier(textBox8.Text, textBox7.Text) + "'");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.update_supplier(textBox9.Text, textBox4.Text, textBox3.Text, textBox5.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            usermainpage p = new usermainpage();
            this.Hide();
            p.ShowDialog();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
