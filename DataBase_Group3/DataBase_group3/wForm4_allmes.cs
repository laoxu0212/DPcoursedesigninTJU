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
    public partial class wForm4_allmes : Form
    {
        public wForm4_allmes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //上一步
        {
            this.Hide();
            wForm1_main f1 = new wForm1_main();
            f1.ShowDialog();
            this.Close();
        }

        public void Form4ShowWarehouse(DataSet ds) {
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "warehouse";
        }

    }
}
