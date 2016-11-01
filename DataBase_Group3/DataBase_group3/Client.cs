using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.Data;

namespace Datebass
{
    class Client
    {
        public string client_id, name, phone_number;
        public string checkClient(string name, string phone_number)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select client_id from client where name = '" + name + "'and phone_number = '" + phone_number + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                string str = cmd.ExecuteScalar().ToString();
                con.Close();
                return str;
            }
            catch 
            {
                return null;
            }
        }
        public string checkClient(string client_id)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select client_id from client where client_id = '" + client_id + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                string str = cmd.ExecuteScalar().ToString();
                con.Close();
                return str;
            }
            catch 
            {
                return null;
            }
        }

        public DataSet dataset(string name, string phone_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from client where name = '" + name + "' and phone_number = '" + phone_number + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "client");
                con.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public bool new_VIP(string merchant_id, string client_id, int level)
        {
            try
            {
                string s = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();


                string sql = "insert into client_VIP(merchant_id,client_id,grade) values('" + merchant_id + "','" + client_id + "'," + level.ToString() + ")";

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
        public bool insertClient(string name, string phone_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88  ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "insert into client(name,phone_number) values('" + name + "','" + phone_number + "')";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                sql = "select client_id from client where name = '" + name + "'and phone_number = '" + phone_number + "'";
                cmd = new OracleCommand(sql, con);
                string client_id = cmd.ExecuteScalar().ToString();
                con.Close();
                new_VIP(user_ifms.ID, client_id, 0);
                MessageBox.Show("插入成功。");
                return true;
            }
            catch 
            {
                MessageBox.Show("插入失败。");
                return false;
            }

        }
        public bool update_client(string client_id, string name, string phone_number)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                string sql = "update client set name = '" + name + "', phone_number='" + phone_number + "' where client_id = '" + client_id + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("success");
                con.Close();
                return true;

            }
            catch 
            {
                MessageBox.Show("failed");
                return false;
            }
        }
        public bool showClient(string name, string phone_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string Client_ID = "select client_id from client where name ='" + name + "' and phone_number = '" + phone_number + "'";
                string Phone_number = "select phone_number from client where name ='" + name + "' and phone_number = '" + phone_number + "'";
                string Name = "select name from client where name ='" + name + "' and phone_number = '" + phone_number + "'";
                OracleCommand cmdsupplier = new OracleCommand(Client_ID, con);
                OracleCommand cmdname = new OracleCommand(Name, con);
                OracleCommand cmdphone = new OracleCommand(Phone_number, con);
                this.client_id = cmdsupplier.ExecuteScalar().ToString();
                this.name = cmdname.ExecuteScalar().ToString();
                this.phone_number = cmdphone.ExecuteScalar().ToString();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool showClient(string client_id)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string Client_ID = "select client_id from client where client_id = '"+client_id+"'";
                string Phone_number = "select phone_number from client where client_id = '" + client_id + "'";
                string Name = "select name from client where client_id = '" + client_id + "'";
                OracleCommand cmdsupplier = new OracleCommand(Client_ID, con);
                OracleCommand cmdname = new OracleCommand(Name, con);
                OracleCommand cmdphone = new OracleCommand(Phone_number, con);
                this.client_id = cmdsupplier.ExecuteScalar().ToString();
                this.name = cmdname.ExecuteScalar().ToString();
                this.phone_number = cmdphone.ExecuteScalar().ToString();
                con.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("failed");
                return false;
            }
        }
    }
}
