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
    public partial class sForm1_main : Form
    {
        public sForm1_main()
        {
            InitializeComponent();
            sForm2_update form2_search_result = new sForm2_update();
        }
        private void button1_Click(object sender, EventArgs e)  //更改摊位信息
        {
            if (textBox1.Text == String.Empty)  //输入不能为空
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            string stall_id = textBox1.Text.ToString();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            if (stall.stallexist(stall_id))
            {
                sForm2_update f2 = new sForm2_update();
                bool result = stall.showStall(stall_id);
                if (result)
                {
                    {
                        f2.Form2showStall(stall_id, stall.merchant_id, stall.staff_id, stall.area, stall.start_time, stall.end_time, stall.rent_money, stall.price);
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
                MessageBox.Show("该摊位不存在");
            }
        }

        private void button2_Click(object sender, EventArgs e)  //显示所有信息
        {
            this.Hide();
            sForm3_allmes f3 = new sForm3_allmes();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            DataSet ds = new DataSet();
            ds = stall.selectStall();
            f3.Form3ShowShall(ds);
            f3.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) //查询摊位信息
        {
            if (textBox1.Text == String.Empty)  //输入不能为空
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            string stall_id = textBox1.Text.ToString();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            if (stall.stallexist(stall_id))
            {
                sForm5_search_result f5 = new sForm5_search_result();
                bool result = stall.showStall(stall_id);
                if (result)
                {
                    {
                        f5.Form5showStall(stall_id, stall.merchant_id, stall.staff_id, stall.area, stall.start_time, stall.end_time, stall.rent_money, stall.price);
                    }
                    this.Hide();
                    f5.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("failed");
            }
            else
            {
                MessageBox.Show("该摊位不存在");
            }
        }

        private void button4_Click(object sender, EventArgs e)  //进行条件查询
        {
            this.Hide();
            sForm4_condi_search f4 = new sForm4_condi_search();
            f4.Left = this.Left;             //form位置
            f4.Top = this.Top;
            f4.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)  //定价关系管理
        {
            this.Hide();
            sForm6_rela f6 = new sForm6_rela();
            f6.ShowDialog();
            this.Close();
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)  //6位ID
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
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
    }
}
