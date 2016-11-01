using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsm
{
    public partial class merchandise_out : Form
    {
        public merchandise_out()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            merchandise_manage form = new merchandise_manage();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

  

        private void merchandise_out_FormClosing(object sender, FormClosingEventArgs e)
        {

            MessageBoxButtons messageButton = MessageBoxButtons.YesNo;
            DialogResult dr = MessageBox.Show("是否退出系统？", "退出系统", messageButton);
            if (dr == DialogResult.Yes)
            {
                e.Cancel = false;           
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            DataSet ds = new DataSet();
            ds = DataBase.Merchandise.SearchByName(Datebass.user_ifms.ID, textBox2.Text);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "merchandise";
        }

        private void button2_Click(object sender, EventArgs e) {
            if (textBox1.Text == string.Empty
                || textBox3.Text == string.Empty
                || textBox4.Text == string.Empty
                || textBox5.Text == string.Empty) {
                MessageBox.Show("输入不能为空！");
                return;
            }
            if (DataBase.Merchandise.IsAnEntryExist(Datebass.user_ifms.ID, textBox5.Text, textBox3.Text, textBox4.Text) == false) {
                MessageBox.Show("输入有误，不存在该货物表项！");
                return;
            }
            if (DataBase.Merchandise.IsMerchandiseEnough(Datebass.user_ifms.ID, textBox5.Text, textBox3.Text, textBox4.Text, Convert.ToDouble(textBox1.Text)) < 0) {
                MessageBox.Show("货物剩余量不足！");
                return;
            }
            if (DataBase.Merchandise.PickUpMerchandise(Datebass.user_ifms.ID, textBox5.Text, textBox3.Text, textBox4.Text, Convert.ToDouble(textBox1.Text))) {
                MessageBox.Show("取货成功！");
                string name = DataBase.Merchandise.GetName(Datebass.user_ifms.ID, textBox5.Text, textBox3.Text, textBox4.Text);
                textBox2.Text = name;
                DataSet ds = new DataSet();
                ds = DataBase.Merchandise.SearchByName(Datebass.user_ifms.ID, name);
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "merchandise";
                return;
            }
            else {
                MessageBox.Show("取货失败！");
                return;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Stall_Manage.mForm1_main f = new Stall_Manage.mForm1_main();
            f.OnlyNumber(e);
        }
    }
}
