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
    public partial class merchandise_in : Form
    {
        public merchandise_in()
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

        private void merchandise_in_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text == string.Empty
                || textBox10.Text == string.Empty
                || textBox2.Text == string.Empty
                || textBox3.Text == string.Empty
                || textBox4.Text == string.Empty
                || textBox9.Text == string.Empty) {
                MessageBox.Show("输入不能为空！");
                return;
            }
            if (DataBase.Merchandise.IsWarehouseBelongToMerchant(textBox10.Text, Datebass.user_ifms.ID) == false) {
                MessageBox.Show("仓库ID输入有误，该仓库不属于此商家！");
                return;
            }
            if (DataBase.Merchandise.IsWarehouseCapacityEnough(textBox10.Text, Convert.ToDouble(textBox1.Text)) < 0) {
                MessageBox.Show("仓库剩余容量不足！");
                return;
            }
            if (DataBase.Merchandise.AddAnEntry(Datebass.user_ifms.ID, textBox2.Text, textBox3.Text, textBox4.Text, textBox9.Text, Convert.ToDouble(textBox1.Text), textBox10.Text)) {
                MessageBox.Show("存货成功！");
                return;
            }
            else {
                MessageBox.Show("输入有误，存货失败！");
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
