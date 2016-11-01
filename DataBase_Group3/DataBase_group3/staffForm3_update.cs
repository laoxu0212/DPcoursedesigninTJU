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
    public partial class staffForm3_update : Form
    {
        public staffForm3_update()
        {
            InitializeComponent();
        }

        public void showStaff(string staff_id, string name, string age, string sex, string phone_number, string salary, string dept_name)
        {
            textBox1.Text = staff_id;
            textBox2.Text = name;
            textBox3.Text = age;
            textBox4.Text = sex;
            textBox5.Text = phone_number;
            textBox6.Text = salary;
            textBox7.Text = dept_name;
        }
        private void button4_Click(object sender, EventArgs e)   //保存更改
        {
            staff.Staff a = new staff.Staff();
            if (a.staffexist(textBox1.Text))
            {
                if (a.update_all(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text))
                    MessageBox.Show("已更新完");
                else
                    MessageBox.Show("没更新");
            }
            else
                MessageBox.Show("不存在这个人");
        }

        private void button1_Click(object sender, EventArgs e)   //上一步
        {
            this.Hide();
            staffForm1_main f1 = new staffForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)  //返回
        {
            this.Hide();
            staffForm1_main f1 = new staffForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)  //年龄数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)  //电话数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)  //工资数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }
    }
}
