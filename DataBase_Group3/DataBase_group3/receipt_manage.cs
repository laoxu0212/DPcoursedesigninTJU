using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;


namespace Datebass
{
    public partial class receipt_manage : Form
    {
        public receipt_manage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Receipt receipt = new Receipt();
            DataSet ds = new DataSet();
            if (textBox2.Text != null && textBox2.Text != "")
            {
                ds = receipt.selectReceipt(textBox1.Text, textBox2.Text);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "receipt";
                bool result = receipt.showReceipt(textBox1.Text, textBox2.Text);
                if (result)
                {
                    textBox10.Text = receipt.supplier_id;
                    textBox9.Text = receipt.batch_number;
                    textBox4.Text = receipt.time;
                    textBox3.Text = receipt.amount;
                    textBox6.Text = receipt.name;
                    textBox5.Text = receipt.total_price;
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }
            else if (textBox2.Text == "" && textBox1.Text != "")
            {
                ds = Receipt.selectReceipt(textBox1.Text);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "receipt";
            }
            
        }

        private void receipt_manage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Receipt receipt = new Receipt();
            if (receipt.checkReceipt(user_ifms.ID, textBox9.Text, textBox10.Text) != "")
            {
                bool result = receipt.updateReceipt(textBox10.Text, textBox9.Text, user_ifms.ID, textBox4.Text, textBox3.Text, textBox6.Text, textBox5.Text);
                if (result)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("failed");
                    return;
                }
            }
            MessageBox.Show("failed");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Receipt receipt = new Receipt();
            DataSet ds = receipt.selectReceiptByTime(textBox8.Text, textBox7.Text);
            if (ds != null)
            {
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "receipt";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            usermainpage p = new usermainpage();
            p.ShowDialog();
            this.Close();
        }
    }
}
