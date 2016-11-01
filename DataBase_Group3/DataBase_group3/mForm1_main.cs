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
    public partial class mForm1_main : Form
    {
        public mForm1_main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //查询商家信息
        {
            if (textBox1.Text == String.Empty)  //输入不能为空
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            string merchant_id = textBox1.Text.ToString();
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            if (merchant.merchantexist(textBox1.Text.ToString()))
            {
                bool result = merchant.showMerchant(merchant_id);
                if (result)
                {
                    mForm2_search_result f2 = new mForm2_search_result();
                    {
                        f2.Form2showMerchant(merchant_id, merchant.staff_id, merchant.name, merchant.phone_number);
                    }
                    this.Hide();
                    f2.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("failed");
            }
            else
            {
                MessageBox.Show("该商家不存在");
            }
        }

        private void button2_Click(object sender, EventArgs e)  //修改商家信息
        {
            if (textBox1.Text == String.Empty)  //输入不能为空
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            string merchant_id = textBox1.Text.ToString();
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            if (merchant.merchantexist(textBox1.Text.ToString()))
            {
                bool result = merchant.showMerchant(merchant_id);
                if (result)
                {
                    mForm3_update f3 = new mForm3_update();
                    {
                        f3.Form3showMerchant(merchant_id, merchant.staff_id, merchant.name, merchant.phone_number);
                    }
                    this.Hide();
                    f3.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("failed");
            }
            else
            {
                MessageBox.Show("该商家不存在");
            }

        }

        private void button3_Click(object sender, EventArgs e)  //删除商家信息
        {
            if (textBox1.Text == String.Empty)  //输入不能为空
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            string merchant_id = textBox1.Text.ToString();
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            if (merchant.merchantexist(textBox1.Text.ToString()))
            {
                bool result = merchant.deleteMerchant(merchant_id);
                if (result)
                {
                    MessageBox.Show("sucessful");
                }
                else
                    MessageBox.Show("failed");
            }
            else
            {
                MessageBox.Show("该商家不存在");
            }
        }

        private void button4_Click(object sender, EventArgs e)  //新增商家信息
        {
            this.Hide();
            mForm4_add f4 = new mForm4_add();
            f4.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)  //进行条件查询
        {
            this.Hide();
            mForm5_condi_search f5 = new mForm5_condi_search();
            f5.ShowDialog();
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)   //6位ID
        {
            OnlyNumber(e);
        }

        public void OnlyNumber(KeyPressEventArgs e)
        {
            try
            {
                int kc = (int)e.KeyChar;
                if ((kc < 48 || kc > 57) && kc != 8)
                    e.Handled = true;
            }
            catch (Exception)
            {
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Datebass.Form1 p = new Datebass.Form1();
            this.Hide();
            p.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Datebass.Modifypassword p = new Datebass.Modifypassword();
            p.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Datebass.Form1 p = new Datebass.Form1();
            this.Hide();
            p.ShowDialog();
            this.Close();
        }
    }
}
