using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace Datebass
{
    class login
    {
        //public int ID;
        //public string password;
        //public void set()
        //{
        //    ID = 123213;
        //    password = "asdfasdfas";
        //}
        public bool staff_check(string ID,string password)
        {

            string result = "";
            try
            {
                string s = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                //string sql = "update test set sex = 'female' where name = '76' ";
                string sql = "select PASSWORD from STAFF_LOGIN where STAFF_ID = " + "'" + ID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);

                //cmd.ExecuteNonQuery();
                result = cmd.ExecuteScalar().ToString();
                con.Close();


            }
            catch (Exception ex)
            {
            }

            if (result == password) return true;
            return false;
        }
        public bool staff_update(string ID, string newpassword)
        {
            string result = "";
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                //string sql = "update test set sex = 'female' where name = '76' ";
                string sql = "update STAFF_LOGIN set PASSWORD = '" + newpassword+ "' where STAFF_ID = '" + ID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                sql = "select PASSWORD from STAFF_LOGIN where STAFF_ID = '" + ID + "'";
                cmd = new OracleCommand(sql, con);
                result = cmd.ExecuteScalar().ToString();
                con.Close();


            }
            catch (Exception ex)
            {
            }

            if (result == newpassword) return true;
            return false;
        }
        public string staff_find(string ID, string verification_code)
        {
            string result = "";
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                //string sql = "update test set sex = 'female' where name = '76' ";
                string sql = "select PASSWORD from STAFF_LOGIN where STAFF_ID = '" + ID + "' and verification_code = '" + verification_code + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                //cmd.ExecuteNonQuery();
                //sql = "select PASSWORD from login where ID = '" + ID + "'";
                //cmd = new OracleCommand(sql, con);
                result = cmd.ExecuteScalar().ToString();
                con.Close();


            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public bool merchant_check(string ID, string password)
        {

            string result = "";
            try
            {
                string s = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                //string sql = "update test set sex = 'female' where name = '76' ";
                string sql = "select PASSWORD from MERCHANT_LOGIN where MERCHANT_ID = " + "'" + ID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);

                //cmd.ExecuteNonQuery();
                result = cmd.ExecuteScalar().ToString();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (result == password) return true;
            return false;
        }
        public bool merchant_update(string ID, string newpassword)
        {
            string result = "";
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                //string sql = "update test set sex = 'female' where name = '76' ";
                string sql = "update MERCHANT_LOGIN set PASSWORD = '" + newpassword + "' where MERCHANT_ID = '" + ID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                sql = "select PASSWORD from MERCHANT_LOGIN where MERCHANT_ID = '" + ID + "'";
                cmd = new OracleCommand(sql, con);
                result = cmd.ExecuteScalar().ToString();
                con.Close();


            }
            catch (Exception ex)
            {
            }

            if (result == newpassword) return true;
            return false;
        }
        public string merchant_find(string ID, string verification_code)
        {
            string result = "";
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                //string sql = "update test set sex = 'female' where name = '76' ";
                string sql = "select PASSWORD from MERCHANT_LOGIN where MERCHANT_ID = '" + ID + "' and verification_code = '" + verification_code + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                //cmd.ExecuteNonQuery();
                //sql = "select PASSWORD from login where ID = '" + ID + "'";
                //cmd = new OracleCommand(sql, con);
                result = cmd.ExecuteScalar().ToString();
                con.Close();


            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public bool check(string ID, string password)
        {
            if (ID[0] == '1' || ID[0] == '2' || ID[0] == '3' || ID[0] == '4')
                return merchant_check(ID, password);
            else return staff_check(ID, password);
        }

        public bool update(string ID, string password)
        {
            if (ID[0] == '1' || ID[0] == '2' || ID[0] == '3' || ID[0] == '4')
                return merchant_update(ID, password);
            else return staff_update(ID, password);
        }

        public string find(string ID, string password)
        {
            if (ID[0] == '1' || ID[0] == '2' || ID[0] == '3' || ID[0] == '4')
                return merchant_find(ID, password);
            else return staff_find(ID, password);
        }
        public bool staffexist(string staff_id)//检查员工id是否存在
        {
            string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
            OracleConnection con = new OracleConnection(s);
            con.Open();
            string sql = "select * from staff where staff_id='" + staff_id + "'";
            OracleCommand cmd = new OracleCommand(sql, con);
            if (cmd.ExecuteScalar() == null)
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }
        }
    }
}
