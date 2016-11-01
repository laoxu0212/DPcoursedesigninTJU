using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsm {
    public partial class merchandise_info : Form {
        public merchandise_info() {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) {
            merchandise_manage form = new merchandise_manage();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void merchandise_info_FormClosing(object sender, FormClosingEventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox2.Text == String.Empty)  //输入不能为空
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            DataSet ds = new DataSet();
            ds = DataBase.Merchandise.SearchByName(Datebass.user_ifms.ID, textBox2.Text);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "merchandise";
        }
    }
}
