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
    public partial class sForm2_update : Form
    {
        public sForm2_update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //上一步
        {
            this.Hide();
            sForm1_main f1 = new sForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e) //保存更改
        {
            string stall_id = textBox1.Text.ToString();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            if (merchant.merchantexist(textBox2.Text.ToString()) && stall.staffexist(textBox3.Text.ToString()))
            {
                if (Convert.ToInt32(textBox3.Text) >= 600000 && Convert.ToInt32(textBox3.Text) <= 699999)
                {
                    bool result = stall.updateStall(stall_id, textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString());
                    if (result)
                    {
                        stall.showStall(stall_id);
                        textBox1.Text = stall_id;
                        textBox2.Text = stall.merchant_id;
                        textBox3.Text = stall.staff_id;
                        textBox4.Text = stall.area;
                        textBox5.Text = stall.start_time;
                        textBox6.Text = stall.end_time;
                        textBox7.Text = stall.rent_money;
                        textBox8.Text = stall.price;
                        MessageBox.Show("sucessful");
                    }
                    else
                        MessageBox.Show("failed");
                }
                else
                {
                    MessageBox.Show("请输入摊位管理员工id");
                }
            }
            else
            {
                MessageBox.Show("请输入正确的商家和员工id");
            }
           
        }

        public void Form2showStall(string stall_id,string merchant_id,string staff_id,string area,string start_time,string end_time,string rent_money,string price)
        {
            textBox1.Text = stall_id;
            textBox2.Text = merchant_id;
            textBox3.Text = staff_id;
            textBox4.Text = area;
            textBox5.Text = start_time;
            textBox6.Text = end_time;
            textBox7.Text = rent_money;
            textBox8.Text = price;
        }

        private void button2_Click(object sender, EventArgs e) //确认退出
        {
            this.Hide();
            sForm1_main f1 = new sForm1_main();
            f1.ShowDialog();
            this.Close();
        }


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)  //6位数字  商家
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)   //6位数字  员工
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)  //金额数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }
    }
}
