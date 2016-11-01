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
    public partial class staffForm4_add : Form
    {
        public staffForm4_add()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)   //上一步
        {
            this.Hide();
            staffForm1_main f1 = new staffForm1_main();
            f1.ShowDialog();
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)  //保存更改
        {
            if (textBox6.Text.ToString() == "Material_Ctrl_Dept" || textBox6.Text.ToString() == "Personal_Adm_Dept" || textBox6.Text.ToString() == "Stall_Mgt_Dept" || textBox6.Text.ToString() == "Merchant_Mgt_Dept")
            {
                staff.Staff staff = new staff.Staff();
                bool result = staff.addStaff(textBox1.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString(), textBox6.Text.ToString());
                if (result)
                {
                    textBox7.Text = staff.staff_id;
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }
            else
            {
                MessageBox.Show("请输入正确的部门名");
            }
        }

        private void button2_Click(object sender, EventArgs e)  //返回
        {
            this.Hide();
            staffForm1_main f1 = new staffForm1_main();
            f1.ShowDialog();
            this.Close();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)  //年龄数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)  //电话数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)  //工资数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }
    }
}
