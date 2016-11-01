using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stall_Manage
{
    public partial class mForm4_add : Form
    {
        public mForm4_add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //上一步
        {
            this.Hide();
            mForm1_main f1 = new mForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)  //确认退出
        {
            this.Hide();
            mForm1_main f1 = new mForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)  //保存信息
        {
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            if (stall.staffexist(textBox2.Text.ToString()))
            {
                if (Convert.ToInt32(textBox2.Text.ToString()) >= 700000 && Convert.ToInt32(textBox2.Text.ToString()) <= 799999)
                {
                    bool result = merchant.addMerchant(textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString());
                    if (result)
                    {
                        textBox1.Text = merchant.merchant_id;
                    }
                    else
                    {
                        MessageBox.Show("failed");
                    }
                }
                else
                {
                    MessageBox.Show("请输入商家管理员工id");
                }
            }
            else
            {
                MessageBox.Show("请输入正确的员工id");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)  //员工ID数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)  //电话数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }
    }
}
