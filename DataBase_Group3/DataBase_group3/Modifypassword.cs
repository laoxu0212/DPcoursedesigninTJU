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
    public partial class Modifypassword : Form
    {
        public Modifypassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login a = new login();
            if (a.check(user_ifms.ID, textBox3.Text))
            {
                if (textBox1.Text == textBox2.Text)
                {
                    if (a.update(user_ifms.ID, textBox1.Text))
                    {
                        MessageBox.Show("修改成功");
                        this.Hide();
                        this.Close();
                    }
                }
               else MessageBox.Show("两次密码不一致！");
                
           }
            else MessageBox.Show("密码错误！");
        }
    }
}
