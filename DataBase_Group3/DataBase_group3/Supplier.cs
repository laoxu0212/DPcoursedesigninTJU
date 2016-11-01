using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace Datebass
{
    class Supplier
    {
        public string supplier_id, name, address, phone_number;
        public string selectSupplier(string name, string phone_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select supplier_id from supplier where name = '" + name + "'and phone_number = '" + phone_number + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                string supplier_id = cmd.ExecuteScalar().ToString();
                con.Close();
                return supplier_id;
            }
            catch
            {
                MessageBox.Show("查询失败。");
                return null;
            }
        }
        public bool insertSupplier(string name, string phone_number, string address)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "insert into supplier(name,phone_number,address) values('" + name + "','" + phone_number + "','" + address + "')";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("插入成功。");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string checkSupplier_id(string supplier_id)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select supplier_id from supplier where supplier_id = '" + supplier_id + "'";
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
        public bool update_supplier(string supplier_id, string name, string phone_number, string address)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                string sql = "update supplier set name = '" + name + "', phone_number='" + phone_number + "', address='" + address + "' where supplier_id = '" + supplier_id + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("success");
                con.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool showSupplier(string name, string phone_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string Supplier_ID = "select supplier_id from supplier where name ='" + name + "' and phone_number = '" + phone_number + "'";
                string Phone_number = "select phone_number from supplier where name ='" + name + "' and phone_number = '" + phone_number + "'";
                string Name = "select name from supplier where name ='" + name + "' and phone_number = '" + phone_number + "'";
                string Address = "select address from supplier where name ='" + name + "' and phone_number = '" + phone_number + "'";
                OracleCommand cmdsupplier = new OracleCommand(Supplier_ID, con);
                OracleCommand cmdname = new OracleCommand(Name, con);
                OracleCommand cmdphone = new OracleCommand(Phone_number, con);
                OracleCommand cmdaddress = new OracleCommand(Address, con);
                this.supplier_id = cmdsupplier.ExecuteScalar().ToString();
                this.name = cmdname.ExecuteScalar().ToString();
                this.phone_number = cmdphone.ExecuteScalar().ToString();
                this.address = cmdaddress.ExecuteScalar().ToString();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool showSupplier(string supplier_id)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string Supplier_ID = "select supplier_id from supplier where supplier_id = '"+supplier_id+"'";
                string Phone_number = "select phone_number from supplier where supplier_id = '" + supplier_id + "'";
                string Name = "select name from supplier where supplier_id = '" + supplier_id + "'";
                string Address = "select address from supplier where supplier_id = '" + supplier_id + "'";
                OracleCommand cmdsupplier = new OracleCommand(Supplier_ID, con);
                OracleCommand cmdname = new OracleCommand(Name, con);
                OracleCommand cmdphone = new OracleCommand(Phone_number, con);
                OracleCommand cmdaddress = new OracleCommand(Address, con);
                this.supplier_id = cmdsupplier.ExecuteScalar().ToString();
                this.name = cmdname.ExecuteScalar().ToString();
                this.phone_number = cmdphone.ExecuteScalar().ToString();
                this.address = cmdaddress.ExecuteScalar().ToString();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
