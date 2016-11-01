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
    public partial class merchandise_manage : Form
    {
        public merchandise_manage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //商家货物信息查询
        {
            merchandise_count form = new merchandise_count();

            DataSet ds = new DataSet();
            ds = DataBase.Merchandise.ShowAllMerchandiseInfo(Datebass.user_ifms.ID);
            form.MerchandiseCountShowAllInfo(ds);

            ds = DataBase.Merchandise.ShowAllMerchandiseNumber(Datebass.user_ifms.ID);
            form.MerchandiseCountShowNumber(ds);

            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            merchandise_in form = new merchandise_in();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            merchandise_out form = new merchandise_out();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            merchandise_info form = new merchandise_info();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void merchandise_manage_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            merchandise_change form = new merchandise_change();
            DataSet ds = new DataSet();
            ds = DataBase.Merchandise.ShowAllMerchandiseInfo(Datebass.user_ifms.ID);
            form.MerchandiseChangeShowAllInfo(ds);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Datebass.usermainpage d = new Datebass.usermainpage();
            this.Hide();
            d.ShowDialog();
            this.Close();
        }
    }
}
