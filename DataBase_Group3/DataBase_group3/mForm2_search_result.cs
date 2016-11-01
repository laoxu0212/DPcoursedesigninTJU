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
    public partial class mForm2_search_result : Form
    {
        public mForm2_search_result()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)   //上一步
        {
            this.Hide();
            mForm1_main f1 = new mForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        public void Form2showMerchant(string merchant_id, string staff_id, string name,string phone_number)
        {
            textBox1.Text = merchant_id;
            textBox2.Text = staff_id;
            textBox3.Text = name;
            textBox4.Text = phone_number;
        }
    }
}
