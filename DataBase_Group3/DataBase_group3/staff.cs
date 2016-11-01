using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Windows.Forms;
using System.Data;

namespace staff
{
    class Staff
    {
        public string staff_id;
        public string name;
        public string age;
        public string sex;
        public string phone_number;
        public string salary;
        public string dept_name;
        public bool is_response = false;

        //新增员工
        public bool addStaff(string Name, string Age, string Sex, string Phone_number, string Salary, string Dept_name)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                //插入商家信息
                string sqlstaff = "insert into staff(name,age,sex,phone_number,salary,dept_name) values('" + Name + "','" + Age + "','" + Sex + "','" + Phone_number + "','" + Salary + "','" + Dept_name + "')";
                OracleCommand cmdstaff = new OracleCommand(sqlstaff, con);
                cmdstaff.ExecuteNonQuery();
                //获得自动分配的商家id
                if (Dept_name == "Material_Ctrl_Dept")
                {
                    string sql = "select staff_id from staff where phone_number = '"+Phone_number+"'";
                    OracleCommand cmd = new OracleCommand(sql, con);
                    //cmdstaff.ExecuteNonQuery();
                    this.staff_id = cmd.ExecuteScalar().ToString();
                }
                else if(Dept_name== "Personal_Adm_Dept")
                {
                    string sql = "select staff_id from staff where phone_number = '" + Phone_number + "'";
                    OracleCommand cmd = new OracleCommand(sql, con);
                   // cmdstaff.ExecuteNonQuery();
                    this.staff_id = cmd.ExecuteScalar().ToString();
                }
                else if(Dept_name== "Stall_Mgt_Dept")
                {
                    string sql = "select staff_id from staff where phone_number = '" + Phone_number + "'";
                    OracleCommand cmd = new OracleCommand(sql, con);
                    //cmdstaff.ExecuteNonQuery();
                    this.staff_id = cmd.ExecuteScalar().ToString();
                }
                else if(Dept_name== "Merchant_Mgt_Dept")
                {
                    string sql = "select staff_id from staff where phone_number = '" + Phone_number + "'";
                    OracleCommand cmd = new OracleCommand(sql, con);
                    //cmdstaff.ExecuteNonQuery();
                    this.staff_id = cmd.ExecuteScalar().ToString();
                }
                //插入merchant_login
                string sqlstaff_login = "insert into staff_login(staff_id,password,verification_code) values('" + this.staff_id + "',2234,223456789)";
                OracleCommand cmdlogin = new OracleCommand(sqlstaff_login, con);
                cmdlogin.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public void search(string staff_id)//查询，输入staff_id，更新类中变量
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string n_ame = "select name from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd1 = new OracleCommand(n_ame, con);

                cmd1.ExecuteNonQuery();
                this.name = cmd1.ExecuteScalar().ToString();
                string a_ge = "select age from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd2 = new OracleCommand(a_ge, con);
                cmd2.ExecuteNonQuery();
                this.age = cmd2.ExecuteScalar().ToString();
                string s_ex = "select sex from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd3 = new OracleCommand(s_ex, con);
                cmd2.ExecuteNonQuery();
                this.sex = cmd3.ExecuteScalar().ToString();
                string p_hone = "select phone_number from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd4 = new OracleCommand(p_hone, con);
                cmd2.ExecuteNonQuery();
                this.phone_number = cmd4.ExecuteScalar().ToString();
                string s_alary = "select salary from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd5 = new OracleCommand(s_alary, con);
                cmd5.ExecuteNonQuery();
                this.salary = cmd5.ExecuteScalar().ToString();
                string d_ept = "select dept_name from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd6 = new OracleCommand(d_ept, con);
                cmd6.ExecuteNonQuery();
                this.dept_name = cmd6.ExecuteScalar().ToString();
                con.Close();
            }
            catch { }
        }
        public bool update_all(string staff_id, string name, string age, string sex, string phone_number, string salary, string dept_name)
        {//更改功能中，先调用search，显示后再调用此函数更新
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "update staff set name='" + name + "',age='" + age + "',sex='" + sex + "',phone_number='" + phone_number + "',salary='" + salary + "',dept_name='" + dept_name + "' where staff_id='" + staff_id + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();

                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool detele_staffmerchant(string staff_id)//删除负责marchant的员工
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string d_eptname = "select dept_name from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd = new OracleCommand(d_eptname, con);
                cmd.ExecuteNonQuery();
                string deptname = cmd.ExecuteScalar().ToString();
                string lead_head = "select dept_head from leading where dept_name='" + deptname + "'";
                OracleCommand cmd2 = new OracleCommand(lead_head, con);
                cmd2.ExecuteNonQuery();
                string leadhead = cmd2.ExecuteScalar().ToString();
                if (staff_id == leadhead)//如果他是所在部门负责人，把负责的depthead更新为000000，把相应staffid也改为00000
                {
                    this.is_response = true;
                    string sql = "update leading set dept_head='0' where dept_name='" + deptname + "'";
                    OracleCommand cmd3 = new OracleCommand(sql, con);
                    cmd3.ExecuteNonQuery();
                    string sql2 = "update merchant set staff_id='0' where staff_id='" + staff_id + "'";
                    OracleCommand cmd4 = new OracleCommand(sql2, con);
                    cmd4.ExecuteNonQuery();
                    string sqll = "delete  from staff where staff_id='" + staff_id + "'";
                    OracleCommand cmdd = new OracleCommand(sqll, con);
                    cmdd.ExecuteNonQuery();
                }
                else
                {
                    string sql3 = "update merchant set staff_id='0' where staff_id='" + staff_id + "'";
                    OracleCommand cmd5 = new OracleCommand(sql3, con);
                    cmd5.ExecuteNonQuery();
                    string sql = "delete  from staff where staff_id='" + staff_id + "'";
                    OracleCommand cmdm = new OracleCommand(sql, con);
                    cmdm.ExecuteNonQuery();
                }
                return true;
                con.Close();
            }
            catch
            {
                return false;
            }
        }
        public bool detele_staffstall(string staff_id)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string d_eptname = "select dept_name from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd = new OracleCommand(d_eptname, con);
                cmd.ExecuteNonQuery();
                string deptname = cmd.ExecuteScalar().ToString();
                string lead_head = "select dept_head from leading where dept_name='" + deptname + "'";
                OracleCommand cmd2 = new OracleCommand(lead_head, con);
                cmd2.ExecuteNonQuery();
                string leadhead = cmd2.ExecuteScalar().ToString();
                if (staff_id == leadhead)//如果他是所在部门负责人
                {
                    this.is_response = true;//标记为他负责
                    string sql = "update leading set dept_head ='0' where dept_name='" + deptname + "'";
                    OracleCommand cmd3 = new OracleCommand(sql, con);
                    cmd3.ExecuteNonQuery();
                    string sql2 = "update stall set staff_id='0' where staff_id='" + staff_id + "'";
                    OracleCommand cmd4 = new OracleCommand(sql2, con);
                    cmd4.ExecuteNonQuery();
                    string sqll = "delete  from staff where staff_id='" + staff_id + "'";
                    OracleCommand cmdd = new OracleCommand(sqll, con);
                    cmdd.ExecuteNonQuery();
                }
                else
                {
                    string sql3 = "update stall set staff_id='0' where staff_id='" + staff_id + "'";
                    OracleCommand cmd5 = new OracleCommand(sql3, con);
                    cmd5.ExecuteNonQuery();
                    string sqlm = "delete  from staff where staff_id='" + staff_id + "'";
                    OracleCommand cmdm = new OracleCommand(sqlm, con);
                    cmdm.ExecuteNonQuery();
                }
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool detele_staffwarehouse(string staff_id)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string d_eptname = "select dept_name from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd = new OracleCommand(d_eptname, con);
                cmd.ExecuteNonQuery();
                string deptname = cmd.ExecuteScalar().ToString();
                string lead_head = "select dept_head from leading where dept_name='" + deptname + "'";
                OracleCommand cmd2 = new OracleCommand(lead_head, con);
                cmd2.ExecuteNonQuery();
                string leadhead = cmd2.ExecuteScalar().ToString();
                if (staff_id == leadhead)//如果他是所在部门负责人
                {
                    this.is_response = true;
                    string sql = "update leading set dept_head='0' where dept_name='" + deptname + "'";
                    OracleCommand cmd3 = new OracleCommand(sql, con);
                    cmd3.ExecuteNonQuery();
                    string sql2 = "update warehouse set staff_id='0' where staff_id='" + staff_id + "'";
                    OracleCommand cmd4 = new OracleCommand(sql2, con);
                    cmd4.ExecuteNonQuery();
                    string sqll = "delete  from staff where staff_id='" + staff_id + "'";
                    OracleCommand cmdd = new OracleCommand(sqll, con);
                    cmdd.ExecuteNonQuery();
                }
                else
                {
                    string sql3 = "update warehouse set staff_id='0' where staff_id='" + staff_id + "'";
                    OracleCommand cmd5 = new OracleCommand(sql3, con);
                    cmd5.ExecuteNonQuery();
                    string sqlm = "delete  from staff where staff_id='" + staff_id + "'";
                    OracleCommand cmdm = new OracleCommand(sqlm, con);
                    cmdm.ExecuteNonQuery();
                }
                return true;
                con.Close();
            }
            catch
            {
                return false;
            }
        }
        public bool detele_staffstaff(string staff_id)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string d_eptname = "select dept_name from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd = new OracleCommand(d_eptname, con);
                cmd.ExecuteNonQuery();
                string deptname = cmd.ExecuteScalar().ToString();
                string lead_head = "select dept_head from leading where dept_name='" + d_eptname + "'";
                OracleCommand cmd2 = new OracleCommand(lead_head, con);
                cmd2.ExecuteNonQuery();
                string leadhead = cmd2.ExecuteScalar().ToString();
                if (staff_id == leadhead)//如果他是所在部门负责人
                {
                    this.is_response = true;
                    string sql = "update leading set dept_head='0' where dept_name='" + deptname + "'";
                    OracleCommand cmd3 = new OracleCommand(sql, con);
                    cmd3.ExecuteNonQuery();
                   
                    string sqll = "delete  from staff where staff_id='" + staff_id + "'";
                    OracleCommand cmdd = new OracleCommand(sqll, con);
                    cmdd.ExecuteNonQuery();
                }
                else
                {
                    
                    string sqlm = "delete  from staff where staff_id='" + staff_id + "'";
                    OracleCommand cmdm = new OracleCommand(sqlm, con);
                    cmdm.ExecuteNonQuery();
                }
                return true;
                con.Close();
            }
            catch
            {
                return false;
            }
        }
        public bool addlead(string dept_name, string staff_id)//新增lead表
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "update leading set dept_head='" + staff_id + "' where dept_name='" + dept_name + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                return true;
                con.Close();
            }
            catch
            {
                return false;
            }
        }
        public DataSet showlead()//显示所有负责的人
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                string sql = "select * from leading";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "leading");
                con.Close();
                return ds;
            }
            catch
            {

                return null;
            }
        }
        public DataSet showstaff()//显示所有员工
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                string sql = "select * from STAFF";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "staff");
                con.Close();
                return ds;


            }
            catch
            {
                return null;
            }
        }
        public bool staffexist(string staff_id)//判断员工是否存在
        {

            string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
            OracleConnection con = new OracleConnection(s);
            con.Open();
            string sql = "select name from staff where staff_id='" + staff_id + "'";
            OracleCommand cmd = new OracleCommand(sql, con);
            if (cmd.ExecuteScalar() == null)
            {
                return false;
            }
            else
                return true;
        }
    }
}
