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
    public partial class vip_mtf : Form
    {
        public vip_mtf()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            vip_mainpage pp = new vip_mainpage();
            pp.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VIP a = new VIP();
            if (a.new_VIPgrade(user_ifms.ID, textBox1.Text,textBox2.Text))
            {
                MessageBox.Show("修改成功");
               
                DataSet ds = new DataSet();
                ds = a.check_merchantgrade(user_ifms.ID);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "merchant_vip";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VIP a = new VIP();
            if (a.update_discount(user_ifms.ID, textBox3.Text, textBox4.Text))
            {
                MessageBox.Show("修改成功");
             
                DataSet ds = new DataSet();
                ds = a.check_merchantgrade(user_ifms.ID);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "merchant_vip";
            }
        }
        

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vip_mtf_Load(object sender, EventArgs e)
        {
            VIP a = new VIP();
            DataSet ds = new DataSet();
            ds = a.check_merchantgrade(user_ifms.ID);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "merchant_vip";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.ForeColor = Color.Black;
        }
    }
}
