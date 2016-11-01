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
    public partial class merchandise_count : Form
    {
        public merchandise_count()
        {
            InitializeComponent();
        }

        public void MerchandiseCountShowAllInfo(DataSet ds) {
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "merchandise";
        }

        public void MerchandiseCountShowNumber(DataSet ds) {
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "merchandise";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            merchandise_manage form = new merchandise_manage();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void merchandise_count_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
