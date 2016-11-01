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
    public partial class wForm2_search_result : Form
    {
        public wForm2_search_result()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //上一步
        {
            this.Hide();
            wForm1_main f1 = new wForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)  //确认返回
        {
            this.Hide();
            wForm1_main f1 = new wForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        public void Form2showWarehouse(string warehouse_id, double area, double full_capacity, double left_capacity, string m_id, string s_id) {
            textBox1.Text = warehouse_id;
            textBox2.Text = area.ToString();
            textBox3.Text = full_capacity.ToString();
            textBox4.Text = left_capacity.ToString();
            textBox5.Text = m_id;
            textBox6.Text = s_id;
        }
    }
}
