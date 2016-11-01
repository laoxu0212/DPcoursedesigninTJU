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
    public partial class deliver_order_manage : Form
    {
        public deliver_order_manage()
        {
            InitializeComponent();
        }

        private void deliver_order_manage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeliverOrder Do = new DeliverOrder();
            DataSet ds = new DataSet();
            if (textBox2.Text != null && textBox2.Text != ""&&textBox1.Text != ""&&textBox1.Text!=null)
            {
                ds = Do.selectDeliverOrder(textBox1.Text, textBox2.Text);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "deliver_order";
                bool result = Do.showReceipt(textBox1.Text, textBox2.Text);
                if (result)
                {
                    textBox10.Text = Do.client_id;
                    textBox9.Text = Do.batch_number;
                    textBox4.Text = Do.time;
                    textBox3.Text = Do.amount;
                    textBox6.Text = Do.name;
                    textBox5.Text = Do.total_price;
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }
            else if ((textBox2.Text == "" || textBox2.Text == null) && textBox1.Text != "")
            {
                ds = Do.selectDeliverOrder(textBox1.Text);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "deliver_order";
            }
            else
            {
                MessageBox.Show("输入客户id。");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            usermainpage p = new usermainpage();
            this.Hide();
            p.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeliverOrder Do = new DeliverOrder();
            DataSet ds = new DataSet();
            ds = Do.selectDeliverOrderByTime(textBox8.Text, textBox7.Text);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "deliver_order";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeliverOrder Do = new DeliverOrder();
            if (Do.checkDeliverOrder(user_ifms.ID, textBox9.Text, textBox10.Text) != "")
            {
                bool result = Do.updateDeliverOrder(user_ifms.ID, textBox9.Text, textBox10.Text, textBox4.Text, textBox3.Text, textBox6.Text, textBox5.Text);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
