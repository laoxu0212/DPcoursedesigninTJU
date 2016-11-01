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
    public partial class sForm4_condi_search : Form
    {
        public sForm4_condi_search()
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)  //租用金额
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)   //摊位面积
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)  //租用结束日期
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)  //租用开始日期
        {

        }

        private void button2_Click(object sender, EventArgs e)  //面积
        {
            DataSet ds = new DataSet();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            if (stall.areaexist(textBox2.Text.ToString()))
            {
                ds = stall.selectStallwithArea(textBox2.Text.ToString());
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "stall";
            }
            else
            {
                MessageBox.Show("该面积的摊位不存在");
            }
        }

        private void button3_Click(object sender, EventArgs e)   //标价
        {
            DataSet ds = new DataSet();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            ds = stall.selectStallwithPrice(textBox3.Text.ToString(), textBox4.Text.ToString());
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "stall,quotation";
        }

        private void button4_Click(object sender, EventArgs e)   //开始日期
        {
            DataSet ds = new DataSet();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            ds = stall.selectStallwithStart_time(textBox1.Text.ToString(), textBox5.Text.ToString());
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "stall";
        }

        private void button5_Click(object sender, EventArgs e)   //结束日期
        {
            DataSet ds = new DataSet();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            ds = stall.selectStallwithEnd_time(textBox6.Text.ToString(), textBox7.Text.ToString());
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "stall";
        }

        private void button6_Click(object sender, EventArgs e)   //员工ID
        {
            DataSet ds = new DataSet();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            if (stall.staffexist(textBox9.Text.ToString()))
            {
                if (Convert.ToInt32(textBox9.Text.ToString()) >= 600000 && Convert.ToInt32(textBox9.Text.ToString()) <= 699999)
                {
                    ds = stall.selectStallwithStaff_id(textBox9.Text.ToString());
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "stall";
                }
                else
                {
                    MessageBox.Show("请输入摊位部门的员工id");
                }
            }
            else
            {
                MessageBox.Show("该员工不存在");
            }
        }

        private void button7_Click(object sender, EventArgs e)   //商家ID
        {
            DataSet ds = new DataSet();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            if (merchant.merchantexist(textBox10.Text.ToString()))
            {
                ds = stall.selectStallwithMerchant_id(textBox10.Text.ToString());
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "stall";
            }
            else
            {
                MessageBox.Show("该商家不存在");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)  //面积数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)  //标价数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)//标价数字限制
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
