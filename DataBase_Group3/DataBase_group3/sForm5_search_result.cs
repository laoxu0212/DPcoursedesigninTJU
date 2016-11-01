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
    public partial class sForm5_search_result : Form
    {
        public sForm5_search_result()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//上一步
        {
            this.Hide();
            sForm1_main f1 = new sForm1_main();
            f1.ShowDialog();
            this.Close();
        }
        public void Form5showStall(string stall_id, string merchant_id, string staff_id, string area, string start_time, string end_time, string rent_money, string price)
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

        private void button2_Click(object sender, EventArgs e) //确认返回
        {
            this.Hide();
            sForm1_main f1 = new sForm1_main();
            f1.ShowDialog();
            this.Close();
        }
    }
}
