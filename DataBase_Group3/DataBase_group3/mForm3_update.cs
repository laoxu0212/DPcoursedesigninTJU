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
    public partial class mForm3_update : Form
    {
        public mForm3_update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)   //上一步
        {
            this.Hide();
            mForm1_main f1 = new mForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)   //确认退出
        {
            this.Hide();
            mForm1_main f1 = new mForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        public void Form3showMerchant(string merchant_id,string staff_id,string name,string phone_number)
        {
            textBox1.Text = merchant_id;
            textBox2.Text = staff_id;
            textBox3.Text = name;
            textBox4.Text = phone_number; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string merchant_id = textBox1.Text.ToString();
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            if (stall.staffexist(textBox2.Text.ToString()))
            {
                if (Convert.ToInt32(textBox2.Text) >= 700000 && Convert.ToInt32(textBox2.Text) <= 799999)
                {
                    bool result = merchant.updateMerchant(merchant_id, textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString());
                    if (result)
                    {
                        merchant.showMerchant(merchant_id);
                        textBox1.Text = merchant_id;
                        textBox2.Text = merchant.staff_id;
                        textBox3.Text = merchant.name;
                        textBox4.Text = merchant.phone_number;
                        MessageBox.Show("sucessful");
                    }
                    else
                        MessageBox.Show("failed");
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)  //6位员工ID
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)   //电话为数字
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }
    }
}
