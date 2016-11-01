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
    public partial class staffForm5_lead : Form
    {
        public staffForm5_lead()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //上一步
        {
            this.Hide();
            staffForm1_main f1 = new staffForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)  //确认返回
        {
            this.Hide();
            staffForm1_main f1 = new staffForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)  //保存更改
        {
            staff.Leading a = new staff.Leading();
            staff.Staff b = new staff.Staff();
            if (b.staffexist(textBox7.Text))
            {
                if (a.addlead(textBox1.Text, textBox7.Text))
                {
                    MessageBox.Show("已经新增");
                }
                else
                    MessageBox.Show("没新增,原因可能为：此员工不是这个部门的");
            }
            else
                MessageBox.Show("此员工不存在");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)  //员工部门数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)   //员工ID数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            staff.Leading a = new staff.Leading();
            DataSet ds = new DataSet();
            ds = a.showlead();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "leading";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            staff.Staff a = new staff.Staff();
            DataSet ds = new DataSet();
            ds = a.showstaff();
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "staff";
        }
    }
}
