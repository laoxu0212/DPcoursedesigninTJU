using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data;

namespace Datebass
{
    class DeliverOrder
    {
        public string client_id, batch_number, name, amount, time, total_price;
        public DataSet selectDeliverOrder(string client_id,string order_id)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from deliver_order where client_id = '" + client_id + "' and order_id = '" + order_id + "' and merchant_id = '" + user_ifms.ID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "deliver_order");
                con.Close();
                return ds;
            }
            catch
            {
                MessageBox.Show("查询失败。");
                return null;
            }
        }
        public string checkDeliverOrder(string merchant_id,string order_id,string client_id)
        {

            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select amount from deliver_order where client_id = '" + client_id + "' and order_id = '" + order_id + "' and merchant_id = '" + merchant_id + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                string str = "";
                str = cmd.ExecuteScalar().ToString();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "deliver_order");
                con.Close();
                return str;
            }
            catch
            {
                return "";
            }
        }
        public DataSet selectDeliverOrder(string client_id)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from deliver_order where client_id = '" + client_id + "' and merchant_id = '" + user_ifms.ID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "deliver_order");
                con.Close();
                return ds;
            }
            catch 
            {
                MessageBox.Show("查询失败。");
                return null;
            }
        }
        public bool insertDeliverOrder(string merchant_id, string order_id, string client_id, string time, string amount, string name, string total_price)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "insert into deliver_order values('" + merchant_id + "','" + order_id + "','" + client_id + "',to_date('" + time + "','yyyy-mm-dd'),'" + Convert.ToInt32(amount) + "','" + name + "','" + Convert.ToInt32(total_price) + "')";
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
        public bool updateDeliverOrder(string merchant_id, string order_id, string client_id, string time, string amount, string name, string total_price)
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "update deliver_order set time = to_date('" + time + "','yyyy-mm-dd') ,amount = '"+amount+"',name = '"+name+"',total_price = '"+total_price+"' where merchant_id = '" + merchant_id + "'and client_id ='" + client_id + "' and order_id = '" + order_id + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("修改成功。");
                return true;

            }
            catch
            {
                return false;
            }
        }
        public DataSet selectDeliverOrderByTime(string starttime, string endtime)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from deliver_order where time between to_date('" + starttime + "','yyyy-mm-dd') and to_date('" + endtime + "','yyyy-mm-dd') and merchant_id = '"+user_ifms.ID+"'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "deliver_order");
                return ds;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        public DataSet countSaleByTime(string starttime, string endtime)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select sum(total_price) from deliver_order where time between to_date('" + starttime + "','yyyy-mm-dd') and to_date('" + endtime + "','yyyy-mm-dd') and merchant_id = '"+user_ifms.ID+"'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "deliver_order");
                return ds;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        public bool showReceipt(string client_id, string batch_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string Client_ID = "select client_id from deliver_order where client_id='" + client_id + "' and order_id = '" + batch_number + "' and merchant_id = '"+user_ifms.ID+"'";
                string Batch_number = "select order_id from deliver_order where client_id='" + client_id + "' and order_id = '" + batch_number + "' and merchant_id = '" + user_ifms.ID + "'";
                string Time = "select to_char(time,'yyyy-mm-dd') from deliver_order where client_id='" + client_id + "' and order_id = '" + batch_number + "' and merchant_id = '" + user_ifms.ID + "'";
                string Amount = "select amount from deliver_order where client_id='" + client_id + "' and order_id = '" + batch_number + "' and merchant_id = '" + user_ifms.ID + "'";
                string Name = "select name from deliver_order where client_id='" + client_id + "' and order_id = '" + batch_number + "' and merchant_id = '" + user_ifms.ID + "'";
                string Total_price = "select total_price from deliver_order where client_id='" + client_id + "' and order_id = '" + batch_number + "' and merchant_id = '" + user_ifms.ID + "'";
                OracleCommand cmdclient = new OracleCommand(Client_ID, con);
                OracleCommand cmdname = new OracleCommand(Name, con);
                OracleCommand cmdtime = new OracleCommand(Time, con);
                OracleCommand cmdbatch = new OracleCommand(Batch_number, con);
                OracleCommand cmdamount = new OracleCommand(Amount, con);
                OracleCommand cmdprice = new OracleCommand(Total_price, con);
                this.client_id = cmdclient.ExecuteScalar().ToString();
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
    }
}
