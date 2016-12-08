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
        Doselect select = Doselect.instance;
        Doexecute execute =Doexecute.instance;
        public string checkClient(string name, string phone_number)
        {
            string str = null;
            string sql = "select client_id from client where name = '" + name + "'and phone_number = '" + phone_number + "'";

            str = select.Do(sql).ToString();
            return str;
        }
        public string checkClient(string client_id)
        {
            string str = null;
            string sql = "select client_id from client where client_id = '" + client_id + "'";

            str = select.Do(sql).ToString();
            return str;
        }

        public DataSet dataset(string name, string phone_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234 ";
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
                string sql = "insert into client_VIP(merchant_id,client_id,grade) values('" + merchant_id + "','" + client_id + "'," + level.ToString() + ")";
                execute.Do(sql);
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
                string sql = "insert into client(name,phone_number) values('" + name + "','" + phone_number + "')";
                execute.Do(sql);
                sql = "select client_id from client where name = '" + name + "'and phone_number = '" + phone_number + "'";
                
                string client_id = select.Do(sql).ToString();
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

                string sql = "update client set name = '" + name + "', phone_number='" + phone_number + "' where client_id = '" + client_id + "'";
               
                execute.Do(sql);
                MessageBox.Show("success");
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
                string Client_ID = "select client_id from client where name ='" + name + "' and phone_number = '" + phone_number + "'";
                string Phone_number = "select phone_number from client where name ='" + name + "' and phone_number = '" + phone_number + "'";
                string Name = "select name from client where name ='" + name + "' and phone_number = '" + phone_number + "'";
                
                this.client_id = select.Do(Client_ID).ToString();
                this.name = select.Do(Name).ToString();
                this.phone_number = select.Do(Phone_number).ToString();
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
                
                string Client_ID = "select client_id from client where client_id = '" + client_id + "'";
                string Phone_number = "select phone_number from client where client_id = '" + client_id + "'";
                string Name = "select name from client where client_id = '" + client_id + "'";
                
                this.client_id = select.Do(Client_ID).ToString();
                this.name = select.Do(Name).ToString();
                this.phone_number =select.Do(Phone_number).ToString();
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
