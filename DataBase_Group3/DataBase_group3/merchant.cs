using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Windows.Forms;

namespace Datebass
{
    class Merchant
    {
        Doselect select = Doselect.instance;
        Doexecute execute = Doexecute.instance;
        public string merchant_id;
        public string staff_id;
        public string name;
        public string phone_number;

        //新增商家
        public bool addMerchant(string staffID,string Name,string Phone_number)
        {
            try
            {
                
                //插入商家信息
                string sqlmerchant = "insert into merchant(staff_id,name,phone_number) values('" + staffID + "','"+Name+"','"+Phone_number+"')";
                //OracleCommand cmdmerchant = new OracleCommand(sqlmerchant, con);
                //获得自动分配的商家id
                string sql = "select merchant_seq.currval from dual";
                //OracleCommand cmd = new OracleCommand(sql, con);
                execute.Do(sqlmerchant);
                this.merchant_id = select.Do(sql).ToString();
                //插入merchant_login
                string sqlmerchant_login = "insert into merchant_login(merchant_id,password,verification_code) values('" + this.merchant_id + "',1234,123456789)";
                //插入merchant_VIP
                string sqlmerchant_VIP = "insert into merchant_VIP(merchant_id,grade,discount) values('" + this.merchant_id + "',0,0.99)";
                execute.Do(sqlmerchant_login);
                execute.Do(sqlmerchant_VIP);
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
                
                string staffID = "select staff_id from merchant where merchant_id='" + merchantID + "'";
                string Name = "select name from merchant where merchant_id='" + merchantID + "'";
                string Phone_number = "select phone_number from merchant where merchant_id='" + merchantID + "'";
               
                this.staff_id = select.Do(staffID).ToString();
                this.name = select.Do(Name).ToString();
                this.phone_number = select.Do(Phone_number).ToString();
                
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
                
                string sqlstaff = "update merchant set staff_id = '" + staffID + "' where  merchant_id = '" + merchantID + "'";
                string sqlname = "update merchant set name = '" + Name + "' where  merchant_id = '" + merchantID + "'";
                string sqlphone_number = "update merchant set phone_number = '" + Phone_number + "' where  merchant_id = '" + merchantID + "'";

                select.Do(sqlstaff);
                select.Do(sqlname);
                select.Do(sqlphone_number);
                
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
                //string s = "DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234";
                //OracleConnection con = new OracleConnection(s);
                //con.Open();
                string sql = "select * from merchant";
                //OracleCommand cmd = new OracleCommand(sql, con);
                //cmd.ExecuteNonQuery();
                //OracleDataAdapter oda = new OracleDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //oda.Fill(ds, "merchant");
                //con.Close();
                return select.Data(sql, "merchant");
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
                //string s = "DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234";
                //OracleConnection con = new OracleConnection(s);
                //con.Open();
                string sql = "select * from merchant where merchant_id = '" + merchantID + "'";
                //OracleCommand cmd = new OracleCommand(sql, con);
                //cmd.ExecuteNonQuery();
                //OracleDataAdapter oda = new OracleDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //oda.Fill(ds, "merchant");
                //con.Close();
                return select.Data(sql, "merchant");
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
                //string s = "DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234";
                //OracleConnection con = new OracleConnection(s);
                //con.Open();
                string sql = "select * from merchant where staff_id = '" + staffID + "'";
                //OracleCommand cmd = new OracleCommand(sql, con);
                //cmd.ExecuteNonQuery();
                //OracleDataAdapter oda = new OracleDataAdapter(cmd);
                //DataSet ds = new DataSet();
                //oda.Fill(ds, "merchant");
                //con.Close();
                return select.Data(sql, "merchant");
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
                
                string sqlstall = "update stall set merchant_id = 0 where merchant_id = '" + merchantID + "'";
                string sqlmarehouse = "update warehouse set merchant_id = 0 where merchant_id = '" + merchantID + "'";
                string sql = "delete from merchant where merchant_id = '"+merchantID+"'";

                execute.Do(sqlstall);
                execute.Do(sqlmarehouse);
                execute.Do(sql);
                
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
            
            string sqlmerchant = "select * from merchant where merchant_id='" + merchantID + "'";
            
            if (select.Do(sqlmerchant) == null)
            {
                
                return false;
            }
            else
            {
               
                return true;
            }
        }
    }
}
