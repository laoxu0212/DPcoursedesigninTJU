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
    public partial class vip_get : Form
    {
        public vip_get()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            vip_mainpage pp = new vip_mainpage();
            pp.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VIP a = new VIP();
            DataSet ds = new DataSet();
            ds = a.check_discount(user_ifms.ID,textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "client_VIP natural join merchant_vip";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            VIP a = new VIP();
            if (a.update_grade(user_ifms.ID, textBox5.Text, textBox6.Text, textBox7.Text))
            {
                MessageBox.Show("修改成功");
                DataSet ds = new DataSet();
                ds = a.check_discount(user_ifms.ID, textBox5.Text, textBox6.Text);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "client_VIP natural join merchant_vip";

            }
            else MessageBox.Show("输入信息有误，请重新输入");
        }

        private void vip_get_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            VIP a = new VIP();
            ds = a.display(user_ifms.ID);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "client_VIP natural join merchant_vip";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
