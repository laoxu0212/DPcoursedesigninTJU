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
    public partial class sForm3_allmes : Form
    {
        public sForm3_allmes()
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
        public void Form3ShowShall(DataSet ds)
        {
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "stall,quotation";
        }
    }
}
