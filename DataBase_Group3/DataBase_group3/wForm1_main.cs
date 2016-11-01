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
    public partial class wForm1_main : Form {
        public wForm1_main() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)   //查询
        {
            if (textBox1.Text == String.Empty)  //输入不能为空
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            if (Datebass.Warehouse.IsWarehouseExisted(textBox1.Text) == false) {
                MessageBox.Show("仓库ID不存在！");
                return;
            }
            string warehouse_id = textBox1.Text.ToString();
            Datebass.Warehouse warehouse = new Datebass.Warehouse();
            bool result = warehouse.SearchAnEntryByID(warehouse_id);
            if (result) {
                wForm2_search_result f2 = new wForm2_search_result();
                {
                    f2.Form2showWarehouse(warehouse_id, warehouse.area, warehouse.full_capacity, warehouse.left_capacity, warehouse.merchant_id, warehouse.staff_id);
                }
                this.Hide();
                f2.ShowDialog();
                f2.Left = this.Left;             //form位置
                f2.Top = this.Top;
                this.Close();
            }
            else {
                MessageBox.Show("failed");
            }
        }

        private void button2_Click(object sender, EventArgs e)  //修改
        {
            if (textBox1.Text == String.Empty)  //输入不能为空
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            if (Datebass.Warehouse.IsWarehouseExisted(textBox1.Text) == false) {
                MessageBox.Show("仓库ID不存在！");
                return;
            }
            string warehouse_id = textBox1.Text.ToString();
            Datebass.Warehouse warehouse = new Datebass.Warehouse();
            bool result = warehouse.SearchAnEntryByID(warehouse_id);
            if (result) {
                wForm3_update f3 = new wForm3_update();
                {
                    f3.Form3showWarehouse(warehouse_id, warehouse.area, warehouse.full_capacity, warehouse.left_capacity, warehouse.merchant_id, warehouse.staff_id);
                }
                this.Hide();
                f3.ShowDialog();
                this.Close();
            }
            else {
                MessageBox.Show("failed");
            }
        }

        private void button3_Click(object sender, EventArgs e)   //显示所有信息
        {
            this.Hide();
            wForm4_allmes f4 = new wForm4_allmes();
            DataSet ds = new DataSet();
            ds = Datebass.Warehouse.ShowAllWarehouse();
            f4.Form4ShowWarehouse(ds);
            f4.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)  //条件查询
        {
            this.Hide();
            wForm5_condi_search f5 = new wForm5_condi_search();
            f5.ShowDialog();
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)   //输入六位ID
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Datebass.Form1 pp = new Datebass.Form1();
            pp.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Datebass.Modifypassword p = new Datebass.Modifypassword();
            p.ShowDialog();
        }
    }
}
