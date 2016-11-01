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
    public partial class staffForm1_main : Form
    {
        public staffForm1_main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //查询
        {
            if (textBox1.Text == String.Empty)  //输入不能为空
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            staff.Staff staff = new staff.Staff();
            if (staff.staffexist(textBox1.Text.ToString()))
            {
                staff.search(textBox1.Text.ToString());
                staffForm2_search_result f2 = new staffForm2_search_result();
                f2.showStaff(textBox1.Text.ToString(), staff.name, staff.age, staff.sex, staff.phone_number, staff.salary, staff.dept_name);
                this.Hide();
                f2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("该员工不存在");
            }
        }

        private void button2_Click(object sender, EventArgs e)  //修改
        {
            if (textBox1.Text == String.Empty)  //输入不能为空
            {
                MessageBox.Show("输入不能为空！");
                return;
            }
            staff.Staff staff = new staff.Staff();
            if (staff.staffexist(textBox1.Text.ToString()))
            {
                staff.search(textBox1.Text.ToString());
                staffForm3_update f3 = new staffForm3_update();
                f3.showStaff(textBox1.Text.ToString(), staff.name, staff.age, staff.sex, staff.phone_number, staff.salary, staff.dept_name);
                this.Hide();
                f3.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("该员工不存在");
            }
        }

        private void button3_Click(object sender, EventArgs e)  //删除
        {
            string staffid = textBox1.Text;
            staff.Staff a = new staff.Staff();
            a.search(staffid);
            string dn = a.dept_name;
            if (a.staffexist(staffid))
            {
                if (dn == "Merchant_Mgt_Dept")
                {
                    if (a.detele_staffmerchant(staffid))
                    {
                        if (a.is_response == true)
                        {
                            MessageBox.Show("此人是merchant负责人，并已成功删除");
                            a.is_response = false;
                        }
                        else
                            MessageBox.Show("此普通员工已经删除");
                    }
                    else
                        MessageBox.Show("未能删除");
                }
                else if (dn == "Stall_Mgt_Dept")
                {
                    if (a.detele_staffstall(staffid))
                    {
                        if (a.is_response == true)
                        {
                            MessageBox.Show("此人是stall的负责人，并已成功删除");
                            a.is_response = false;
                        }
                        else MessageBox.Show("此人是stall的普通员工，已成功删除");
                    }
                    else
                        MessageBox.Show("未能删除");
                }
                else if(dn=="Personal_Adm_Dept")
                {
                    if (a.detele_staffstaff(staffid))
                    {
                        if (a.is_response == true)
                        {
                            MessageBox.Show("此人是人事的负责人，并已成功删除");
                            a.is_response = false;
                        }
                        else MessageBox.Show("此人是人事的普通员工，已成功删除");
                    }
                    else
                        MessageBox.Show("未能删除");
                }
                else if(dn=="Material_Ctrl_Dept")
                {
                    if (a.detele_staffwarehouse(staffid))
                    {
                        if (a.is_response == true)
                        {
                            MessageBox.Show("此人是仓库的负责人，并已成功删除");
                            a.is_response = false;
                        }
                        else MessageBox.Show("此人是仓库的普通员工，已成功删除");
                    }
                    else
                        MessageBox.Show("未能删除");
                }
            }
            else
                MessageBox.Show("不存在，未能删除");
        }

        private void button4_Click(object sender, EventArgs e)   //新增员工
        {
            this.Hide();
            staffForm4_add f4 = new staffForm4_add();
            f4.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)  //领导管理
        {
            this.Hide();
            staffForm5_lead f5 = new staffForm5_lead();
            f5.ShowDialog();
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)   //6位ID
        {
            mForm1_main f = new mForm1_main();
            f.OnlyNumber(e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Datebass.Form1 p = new Datebass.Form1();
            this.Hide();
            p.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Datebass.Modifypassword p = new Datebass.Modifypassword();
            p.ShowDialog();
        }
    }
}
