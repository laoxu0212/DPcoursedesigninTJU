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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            forgetpassword pp = new forgetpassword() ;      
            pp.ShowDialog();
           // this.Close() ;
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login a = new login();
            stall_merchant.Merchant merchant = new stall_merchant.Merchant();
            if (textBox1.Text == "") MessageBox.Show("请输入用户名");
            else
            {
                if (textBox2.Text == "") MessageBox.Show("请输入密码");
                else
                {
                    if (a.staffexist(textBox1.Text.ToString()) || merchant.merchantexist(textBox1.Text.ToString()))
                    {
                        if (a.check(textBox1.Text, textBox2.Text))
                        {

                            user_ifms.ID = textBox1.Text;
                            if (user_ifms.ID[0] == '5')//warehouse 管仓库5
                            {
                                Stall_Manage.wForm1_main p = new Stall_Manage.wForm1_main();
                                this.Hide();
                                p.ShowDialog();
                                this.Close();
                            }
                            else
                            if (user_ifms.ID[0] == '6')//管摊位信息登陆
                            {
                                Stall_Manage.sForm1_main p = new Stall_Manage.sForm1_main();
                                this.Hide();
                                p.ShowDialog();
                                this.Close();
                                

                            }
                            else
                            if (user_ifms.ID[0] == '7')//管商家的人登陆
                            {
                               Stall_Manage.mForm1_main p = new Stall_Manage.mForm1_main();
                                this.Hide();
                                p.ShowDialog();
                                this.Close();
                            }
                            else
                            if (user_ifms.ID[0] == '8' || user_ifms.ID[0] == '9')//管理员工信息人事部登陆
                            {
                                Stall_Manage.staffForm1_main p = new Stall_Manage.staffForm1_main();
                                this.Hide();
                                p.ShowDialog();
                                this.Close();
                            }
                            else//商家登陆
                            {
                                this.Hide();
                                usermainpage pp = new usermainpage();
                                pp.ShowDialog();
                                this.Close();
                            }

                        }
                        else
                            MessageBox.Show("登录失败，请检查用户名和密码");
                    }
                    else
                        MessageBox.Show("用户名不存在");
                }
            }
        }
    }
}
