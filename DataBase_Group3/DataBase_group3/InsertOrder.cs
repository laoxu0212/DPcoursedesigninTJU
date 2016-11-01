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
    public partial class Insert : Form
    {
        string merchant_id;
        public Insert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            Receipt receipt = new Receipt();
            if (supplier.checkSupplier_id(textBox1.Text) == null)
            {
                MessageBox.Show("supplier_id不存在");

            }
            else
            {
                receipt.insertReceipt(textBox1.Text, textBox2.Text,user_ifms.ID, textBox3.Text, textBox9.Text, textBox4.Text, textBox10.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            DeliverOrder Do = new DeliverOrder();
            if (client.checkClient(textBox8.Text) != null)
            {
                Do.insertDeliverOrder(user_ifms.ID,textBox7.Text, textBox8.Text, textBox11.Text, textBox5.Text, textBox6.Text, textBox12.Text);
            }
            else
            {
                MessageBox.Show("插入失败！client_id可能不存在。");
            }
        }

        private void Insert_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            usermainpage p = new usermainpage();
            this.Hide();
            p.ShowDialog();
            this.Close();
        }
    }
}
