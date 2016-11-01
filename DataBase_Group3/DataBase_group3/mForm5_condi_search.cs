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
    public partial class mForm5_condi_search : Form
    {
        public mForm5_condi_search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//上一步
        {
            this.Hide();
            mForm1_main f1 = new mForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //员工ID查询
        {
            DataSet ds = new DataSet();
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            if (stall.staffexist(textBox1.Text.ToString()))
            {
                if (Convert.ToInt32(textBox1.Text) >= 700000 && Convert.ToInt32(textBox1.Text) <= 799999)
                {
                    ds = merchant.selectMerchantwithStaff_id(textBox1.Text.ToString());
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "merchant";
                }
                else
                {
                    MessageBox.Show("请输入商家管理员工id");
                }
            }
            else
            {
                MessageBox.Show("请输入正确员工id");
            }
        }

        private void button3_Click(object sender, EventArgs e)//商家ID查询
        {
            DataSet ds = new DataSet();
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            if (merchant.merchantexist(textBox2.Text.ToString()))
            {
                ds = merchant.selectMerchantwithMerchant_id(textBox2.Text.ToString());
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "merchant";
            }
            else
            {
                MessageBox.Show("请输入正确的商家id");
            }
        }

        private void button4_Click(object sender, EventArgs e)  //显示所有信息
        {
            DataSet ds = new DataSet();
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            ds = merchant.showallMerchant();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "merchant";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)  //员工ID数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)  //商家ID数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }
    }
}
