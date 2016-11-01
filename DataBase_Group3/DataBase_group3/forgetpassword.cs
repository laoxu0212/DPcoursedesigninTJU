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
    public partial class forgetpassword : Form
    {
        public forgetpassword()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            login a = new login();
            stall_merchant.Merchant b = new stall_merchant.Merchant();
            if (a.staffexist(textBox2.Text) || b.merchantexist(textBox2.Text))
            {
                if (a.find(textBox2.Text, textBox1.Text) != "")
                {
                    MessageBox.Show(a.find(textBox2.Text, textBox1.Text), "您的密码是");
                    this.Hide();
                    this.Close();
                }
                else MessageBox.Show("验证码错误！");
            }
            else MessageBox.Show("用户名不存在！");
        }
    }
}
