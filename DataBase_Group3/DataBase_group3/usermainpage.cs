using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datebass
{
    public partial class usermainpage : Form
    {
        public usermainpage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void usermainpage_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
           
            Modifypassword pp = new Modifypassword();
            pp.ShowDialog();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            vip_mainpage pp = new vip_mainpage();
            pp.ShowDialog();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 pp = new Form1();
            pp.ShowDialog();
            this.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            deliver_order_manage p = new deliver_order_manage();
            this.Hide();
            p.ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            wsm.merchandise_manage d = new wsm.merchandise_manage();
            this.Hide();
            d.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientManage p = new ClientManage();
            p.ShowDialog();            
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Insert p = new Insert();
            p.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            receipt_manage p = new receipt_manage();
            p.ShowDialog();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            supplier_manage p = new supplier_manage();
            this.Hide();
            p.ShowDialog();
            this.Close();
        }
    }
}
