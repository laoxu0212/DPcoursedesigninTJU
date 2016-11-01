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
    class Receipt
    {
        public string supplier_id, batch_number, name, time, amount, total_price;
        public DataSet selectReceipt(string supplier_id, string batch_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from receipt where supplier_id = '" + supplier_id + "' and batch_number = '" + batch_number + "' and merchant_id = '" + user_ifms.ID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "receipt");
                con.Close();
                return ds;
            }
            catch
            {
                MessageBox.Show("查询失败。");
                return null;
            }

        }
        static public DataSet selectReceipt(string supplier_id)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from receipt where supplier_id = '" + supplier_id + "' and merchant_id = '" + user_ifms.ID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery(); 
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "receipt");
                con.Close();
                return ds;
            }
            catch
            {
                MessageBox.Show("查询失败。");
                return null;
            }

        }
        public bool insertReceipt(string supplier_id, string batch_number, string merchant_id, string time, string amount, string name, string total_price)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "insert into receipt values('" + supplier_id + "','" + batch_number + "','" + merchant_id + "',to_date('" + time + "','yyyy-mm-dd'),'" + Convert.ToInt32(amount) + "','" + name + "','" + Convert.ToInt32(total_price) + "')";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("插入成功。");
                con.Close();
            }
            catch
            {
                MessageBox.Show("插入失败。");
                return false;
            }
            return true;
        }
        public bool updateReceipt(string supplier_id, string batch_number, string merchant_id, string time, string amount, string name, string total_price)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                string sql = "update receipt set time = to_date('" + time + "','yyyy-mm-dd') ,amount = '" + amount + "',name = '" + name + "',total_price = '" + total_price + "' where merchant_id = '" + merchant_id + "' and supplier_id = '" + supplier_id + "' and  batch_number ='" + batch_number + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("修改成功。");
                return true;

            }
            catch
            {
                MessageBox.Show("修改失败。");
                return false;
            }
        }
        public DataSet selectReceiptByTime(string starttime,string endtime)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from receipt where time between to_date('" + starttime + "','yyyy-mm-dd') and to_date('" + endtime + "','yyyy-mm-dd') and merchant_id = '"+user_ifms.ID+"'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "receipt");
                return ds;
                con.Close();
            }
            catch
            {
                return null;
            }
        }
        public bool showReceipt(string supplier_id,string batch_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string Supplier_ID = "select supplier_id from receipt where supplier_id='" + supplier_id + "' and batch_number = '"+batch_number+"'";
                string Batch_number = "select batch_number from receipt where supplier_id='" + supplier_id + "' and batch_number = '" + batch_number + "'";
                string Time = "select to_char(time,'yyyy-mm-dd') from receipt where supplier_id='" + supplier_id + "' and batch_number = '" + batch_number + "'";
                string Amount = "select amount from receipt where supplier_id='" + supplier_id + "' and batch_number = '" + batch_number + "'";
                string Name = "select name from receipt where supplier_id='" + supplier_id + "' and batch_number = '" + batch_number + "'";
                string Total_price = "select total_price from receipt where supplier_id='" + supplier_id + "' and batch_number = '" + batch_number + "'";
                OracleCommand cmdsupplier = new OracleCommand(Supplier_ID, con);
                OracleCommand cmdname = new OracleCommand(Name, con);
                OracleCommand cmdtime = new OracleCommand(Time, con);
                OracleCommand cmdbatch = new OracleCommand(Batch_number, con);
                OracleCommand cmdamount = new OracleCommand(Amount, con);
                OracleCommand cmdprice = new OracleCommand(Total_price, con);
                this.supplier_id = cmdsupplier.ExecuteScalar().ToString();
                this.name = cmdname.ExecuteScalar().ToString();
                this.time = cmdtime.ExecuteScalar().ToString();
                this.batch_number = cmdbatch.ExecuteScalar().ToString();
                this.amount = cmdamount.ExecuteScalar().ToString();
                this.total_price = cmdprice.ExecuteScalar().ToString();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string checkReceipt(string merchant_id, string order_id, string supplier_id)
        {

            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select amount from receipt where supplier_id = '" + supplier_id + "' and batch_number = '" + order_id + "' and merchant_id = '" + merchant_id + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                string str = "";
                str = cmd.ExecuteScalar().ToString();
                con.Close();
                return str;
            }
            catch
            {
                return "";
            }
        }
    }
}
