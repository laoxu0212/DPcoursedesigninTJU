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
    public partial class sForm6_rela : Form
    {
        public sForm6_rela()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //上一步
        {
            this.Hide();
            sForm1_main f1 = new sForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            Stall stall = new Stall();
            ds = stall.selectQuotation();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "quotation";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stall stall = new Stall();
            if (stall.areaexist(textBox1.Text.ToString()))
            {
                bool result = stall.updateQuotation(textBox1.Text.ToString(), textBox2.Text.ToString());
                if (result)
                {
                    MessageBox.Show("sucessful");
                }
                else
                    MessageBox.Show("failed");
            }
            else
            {
                MessageBox.Show("该摊位面积不存在");
            }
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//面积数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)  //定价数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }
    }
}
