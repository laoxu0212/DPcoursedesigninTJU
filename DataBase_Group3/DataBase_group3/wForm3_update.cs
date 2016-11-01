using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stall_Manage {
    public partial class wForm3_update : Form {
        public wForm3_update() {
            InitializeComponent();
        }

        public void Form3showWarehouse(string warehouse_id, double area, double full_capacity, double left_capacity, string m_id, string s_id) {
            textBox1.Text = warehouse_id;
            textBox2.Text = area.ToString();
            textBox3.Text = full_capacity.ToString();
            textBox4.Text = left_capacity.ToString();
            textBox5.Text = m_id;
            textBox6.Text = s_id;
        }

        private void button1_Click(object sender, EventArgs e)  //上一步
        {
            this.Hide();
            wForm1_main f1 = new wForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)  //上一步
        {
            this.Hide();
            wForm1_main f1 = new wForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)  //剩余容量限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)  //商家编号数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)  //员工编号数字限制
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void button4_Click(object sender, EventArgs e) {    //保存更改
            string warehouse_id = textBox1.Text;
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            stall_merchant.Stall stall = new stall_merchant.Stall();
            Datebass.Warehouse warehouse = new Datebass.Warehouse();
            if (merchant.merchantexist(textBox5.Text) == false) {
                MessageBox.Show("请输入正确的商家id");
                return;
            }
            if (Convert.ToInt32(textBox6.Text) >= 500000 && Convert.ToInt32(textBox2.Text) <= 599999) {
                if (stall.staffexist(textBox6.Text) == false) {
                    MessageBox.Show("请输入正确的员工id");
                    return;
                }
            }
            else {
                MessageBox.Show("该员工ID无法管理仓库，请输入正确的员工ID");
                return;
            }
            bool result = Datebass.Warehouse.UpdateAnEntry(warehouse_id, Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), textBox5.Text, textBox6.Text);
            if (result) {
                warehouse.SearchAnEntryByID(warehouse_id);
                textBox1.Text = warehouse_id;
                textBox2.Text = warehouse.area.ToString();
                textBox3.Text = warehouse.full_capacity.ToString();
                textBox4.Text = warehouse.left_capacity.ToString();
                textBox5.Text = warehouse.merchant_id;
                textBox6.Text = warehouse.staff_id;
                MessageBox.Show("sucessful");
            }
            else
                MessageBox.Show("failed");
        }
    }
}
