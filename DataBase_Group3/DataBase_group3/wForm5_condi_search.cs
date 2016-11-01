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
    public partial class wForm5_condi_search : Form
    {
        public wForm5_condi_search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)   //上一步
        {
            this.Hide();
            wForm1_main f1 = new wForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)   //仓库面积
        {
            if (textBox2.Text == String.Empty) {
                MessageBox.Show("输入不能为空！");
                return;
            }
            DataSet ds = new DataSet();
            ds = Datebass.Warehouse.SearchByArea(Convert.ToDouble(textBox2.Text));
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "warehouse";
        }

        private void button3_Click(object sender, EventArgs e)   //仓库容量
        {
            if (textBox3.Text == string.Empty || textBox4.Text == string.Empty) {
                MessageBox.Show("输入不能为空！");
                return;
            }
            DataSet ds = new DataSet();
            ds = Datebass.Warehouse.SearchByFullCapacity(Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text));
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "warehouse";
        }

        private void button6_Click(object sender, EventArgs e)   //划归员工
        {
            if (textBox9.Text == String.Empty) {
                MessageBox.Show("输入不能为空！");
                return;
            }
            stall_merchant.Stall stall = new stall_merchant.Stall();
            if (stall.staffexist(textBox9.Text) == false) {
                MessageBox.Show("请输入正确的员工ID！");
                return;
            }
            DataSet ds = new DataSet();
            ds = Datebass.Warehouse.SearchByStaffID(textBox9.Text);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "warehouse";
        }

        private void button7_Click(object sender, EventArgs e)   //所属商家
        {
            if (textBox10.Text == String.Empty) {
                MessageBox.Show("输入不能为空！");
                return;
            }
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            if (merchant.merchantexist(textBox10.Text) == false) {
                MessageBox.Show("请输入正确的商家ID！");
                return;
            }
            DataSet ds = new DataSet();
            ds = Datebass.Warehouse.SearchByMerchantID(textBox10.Text);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "warehouse";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)  //仓库面积输入数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)  //容量数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)  //容量数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)  //员工ID数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)  //商家ID数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }
    }
}
