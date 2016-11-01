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
    public partial class staffForm2_search_result : Form
    {
        public staffForm2_search_result()
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

        private void button2_Click(object sender, EventArgs e)  //返回
        {
            this.Hide();
            staffForm1_main f1 = new staffForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        public void showStaff(string staff_id,string name,string age,string sex,string phone_number,string salary,string dept_name)
        {
            textBox1.Text = staff_id;
            textBox2.Text = name;
            textBox3.Text = age;
            textBox4.Text = sex;
            textBox5.Text = phone_number;
            textBox6.Text = salary;
            textBox7.Text = dept_name;
        }
    }
}
