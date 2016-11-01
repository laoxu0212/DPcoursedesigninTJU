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
    public partial class merchandise_change : Form
    {
        public merchandise_change()
        {
            InitializeComponent();
        }

        public void MerchandiseChangeShowAllInfo(DataSet ds) {
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "merchandise";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            merchandise_manage form = new merchandise_manage();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void merchandise_change_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text == string.Empty 
                || textBox10.Text == string.Empty
                || textBox2.Text == string.Empty
                || textBox3.Text == string.Empty
                || textBox4.Text == string.Empty
                || textBox9.Text == string.Empty
                || textBox6.Text == string.Empty
                || textBox7.Text == string.Empty
                || textBox8.Text == string.Empty) {
                MessageBox.Show("输入不能为空！");
                return;
            }
            if (DataBase.Merchandise.IsAnEntryExist(Datebass.user_ifms.ID, textBox8.Text, textBox7.Text, textBox6.Text) == false) {
                MessageBox.Show("原货物信息输入有误！");
                return;
            }
            if (DataBase.Merchandise.IsWarehouseBelongToMerchant(textBox10.Text, Datebass.user_ifms.ID) == false) {
                MessageBox.Show("新仓库ID输入有误，该仓库不属于此商家！");
                return;
            }
            if (DataBase.Merchandise.IsWarehouseIDSame(Datebass.user_ifms.ID, textBox2.Text, textBox3.Text, textBox4.Text, textBox10.Text)) {
                if (DataBase.Merchandise.UpdateWhenIDSame(Datebass.user_ifms.ID, textBox8.Text, textBox7.Text, textBox6.Text, Convert.ToDouble(textBox1.Text))) {
                    DataBase.Merchandise.UpdateAnEntry(Datebass.user_ifms.ID, textBox8.Text, textBox2.Text, textBox7.Text, textBox3.Text, textBox6.Text, textBox4.Text, textBox9.Text, Convert.ToDouble(textBox1.Text), textBox10.Text);
                    MessageBox.Show("修改成功！");
                    DataSet ds = new DataSet();
                    ds = DataBase.Merchandise.ShowAllMerchandiseInfo(Datebass.user_ifms.ID);
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "merchandise";
                }
            }
            else {
                if (DataBase.Merchandise.UpdateNewCapacity(Datebass.user_ifms.ID, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToDouble(textBox1.Text), textBox10.Text)) {
                    DataBase.Merchandise.UpdateOldCapacity(Datebass.user_ifms.ID, textBox8.Text, textBox7.Text, textBox6.Text);
                    DataBase.Merchandise.UpdateAnEntry(Datebass.user_ifms.ID, textBox8.Text, textBox2.Text, textBox7.Text, textBox3.Text, textBox6.Text, textBox4.Text, textBox9.Text, Convert.ToDouble(textBox1.Text), textBox10.Text);
                    MessageBox.Show("修改成功！");
                    DataSet ds = new DataSet();
                    ds = DataBase.Merchandise.ShowAllMerchandiseInfo(Datebass.user_ifms.ID);
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "merchandise";
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Stall_Manage.mForm1_main f = new Stall_Manage.mForm1_main();
            f.OnlyNumber(e);
        }
    }
}
