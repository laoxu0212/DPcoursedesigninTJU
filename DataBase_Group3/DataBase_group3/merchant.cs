using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Windows.Forms;

namespace stall_merchant
{
    class Merchant
    {
        public string merchant_id;
        public string staff_id;
        public string name;
        public string phone_number;

        //新增商家
        public bool addMerchant(string staffID,string Name,string Phone_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                //插入商家信息
                string sqlmerchant = "insert into merchant(staff_id,name,phone_number) values('" + staffID + "','"+Name+"','"+Phone_number+"')";
                OracleCommand cmdmerchant = new OracleCommand(sqlmerchant, con);
                //获得自动分配的商家id
                string sql = "select merchant_seq.currval from dual";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmdmerchant.ExecuteNonQuery();
                this.merchant_id = cmd.ExecuteScalar().ToString();
                //插入merchant_login
                string sqlmerchant_login = "insert into merchant_login(merchant_id,password,verification_code) values('" + this.merchant_id + "',1234,123456789)";
                //插入merchant_VIP
                string sqlmerchant_VIP = "insert into merchant_VIP(merchant_id,grade,discount) values('" + this.merchant_id + "',0,0.99)";
                OracleCommand cmdlogin = new OracleCommand(sqlmerchant_login, con);
                OracleCommand cmdVIP = new OracleCommand(sqlmerchant_VIP, con);
                cmdlogin.ExecuteNonQuery();
                cmdVIP.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        //按merchant_id显示商家信息
        public bool showMerchant(string merchantID)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string staffID = "select staff_id from merchant where merchant_id='" + merchantID + "'";
                string Name = "select name from merchant where merchant_id='" + merchantID + "'";
                string Phone_number = "select phone_number from merchant where merchant_id='" + merchantID + "'";
                OracleCommand cmdstaff = new OracleCommand(staffID, con);
                OracleCommand cmdname = new OracleCommand(Name, con);
                OracleCommand cmdphone_number = new OracleCommand(Phone_number, con);
                this.staff_id = cmdstaff.ExecuteScalar().ToString();
                this.name = cmdname.ExecuteScalar().ToString();
                this.phone_number = cmdphone_number.ExecuteScalar().ToString();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        //修改商家信息
        public bool updateMerchant(string merchantID,string staffID,string Name,string Phone_number)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sqlstaff = "update merchant set staff_id = '" + staffID + "' where  merchant_id = '" + merchantID + "'";
                string sqlname = "update merchant set name = '" + Name + "' where  merchant_id = '" + merchantID + "'";
                string sqlphone_number = "update merchant set phone_number = '" + Phone_number + "' where  merchant_id = '" + merchantID + "'";
                OracleCommand cmdstaff = new OracleCommand(sqlstaff, con);
                OracleCommand cmdname = new OracleCommand(sqlname, con);
                OracleCommand cmdphone_number = new OracleCommand(sqlphone_number, con);
                cmdstaff.ExecuteNonQuery();
                cmdname.ExecuteNonQuery();
                cmdphone_number.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //显示所有商家信息
        public DataSet showallMerchant()
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from merchant";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "merchant");
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //通过merchan_id查询
        public DataSet selectMerchantwithMerchant_id(string merchantID)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from merchant where merchant_id = '" + merchantID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "merchant");
                con.Close();
                return ds;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        //按staff_id查找
        public DataSet selectMerchantwithStaff_id(string staffID)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from merchant where staff_id = '" + staffID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "merchant");
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        //删除商家
        public bool deleteMerchant(string merchantID)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sqlstall = "update stall set merchant_id = 0 where merchant_id = '" + merchantID + "'";
                string sqlmarehouse = "update warehouse set merchant_id = 0 where merchant_id = '" + merchantID + "'";
                string sql = "delete from merchant where merchant_id = '"+merchantID+"'";
                OracleCommand cmdstall = new OracleCommand(sqlstall, con);
                OracleCommand cmdmarehouse = new OracleCommand(sqlmarehouse, con);
                OracleCommand cmd = new OracleCommand(sql, con);
                cmdstall.ExecuteNonQuery();
                cmdmarehouse.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        //判断商家id是否存在
        public bool merchantexist(string merchantID)
        {
            string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection con = new OracleConnection(s);
            con.Open();
            string sqlmerchant = "select * from merchant where merchant_id='" + merchantID + "'";
            OracleCommand cmdmerchant = new OracleCommand(sqlmerchant, con);
            if (cmdmerchant.ExecuteScalar() == null)
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
