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
    public partial class vip_mainpage : Form
    {
        public vip_mainpage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            vip_get pp = new vip_get();
            pp.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            vip_mtf pp = new vip_mtf();
            pp.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            usermainpage pp = new usermainpage();
            pp.ShowDialog();
            this.Close();
        }

        private void vip_mainpage_Load(object sender, EventArgs e)
        {

        }
    }
}
