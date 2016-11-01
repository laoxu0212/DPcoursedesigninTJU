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
    class Stall
    {
        //摊位标号
        public string stall_id;
        //摊位所属商家
        public string merchant_id;
        //管理摊位的员工编号
        public string staff_id;
        //摊位面积
        public string area;
        //租用摊位的开始时间
        public string start_time;
        //租用摊位的到期时间
        public string end_time;
        //租用金额
        public string rent_money;
        //标价
        public string price;


        //按stall_id显示摊位信息
        public bool showStall(string stallID)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string merchantID = "select merchant_id from stall where stall_id='" + stallID + "'";
                string staffID = "select staff_id from stall where stall_id='" + stallID + "'";
                string Area = "select area from stall where stall_id='" + stallID + "'";
                string startTime = "select to_char(start_time,'yyyy-mm-dd') from stall where stall_id='" + stallID + "'";
                string endTime = "select to_char(end_time,'yyyy-mm-dd') from stall where stall_id='" + stallID + "'";
                string rentMoney = "select rent_money from stall where stall_id='" + stallID + "'";
                string Price = "select price from stall natural join quotation where stall_id='" + stallID + "'";
                OracleCommand cmdmerchant = new OracleCommand(merchantID, con);
                OracleCommand cmdstaff = new OracleCommand(staffID, con);
                OracleCommand cmdarea = new OracleCommand(Area, con);
                OracleCommand cmdstartTime = new OracleCommand(startTime, con);
                OracleCommand cmdendTime = new OracleCommand(endTime, con);
                OracleCommand cmdrentMoney = new OracleCommand(rentMoney, con);
                OracleCommand cmdprice = new OracleCommand(Price, con);
                this.merchant_id = cmdmerchant.ExecuteScalar().ToString();
                this.staff_id = cmdstaff.ExecuteScalar().ToString();
                this.area = cmdarea.ExecuteScalar().ToString();
                this.start_time = cmdstartTime.ExecuteScalar().ToString();
                this.end_time = cmdendTime.ExecuteScalar().ToString();
                this.rent_money = cmdrentMoney.ExecuteScalar().ToString();
                this.price = cmdprice.ExecuteScalar().ToString();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //修改摊位信息
        public bool updateStall(string stallID, string merchantID, string staffID, string Area, string startTime, string endTime, string rentMoney)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sqlmerchant = "update stall set merchant_id = '" + merchantID + "' where  stall_id = '" + stallID + "'";
                string sqlstaff = "update stall set staff_id = '" + staffID + "' where  stall_id = '" + stallID + "'";
                string sqlarea = "update stall set area = '" + Area + "' where  stall_id = '" + stallID + "'";
                string sqlstart_time = "update stall set start_time = to_date('" + startTime + "','yyyy-mm-dd') where  stall_id = '" + stallID + "'";
                string sqlend_time = "update stall set end_time = to_date('" + endTime + "','yyyy-mm-dd') where  stall_id = '" + stallID + "'";
                string sqlrentMoney = "update stall set rent_money = '" + rentMoney + "' where  stall_id = '" + stallID + "'";
                OracleCommand cmdmerchant = new OracleCommand(sqlmerchant, con);
                OracleCommand cmdstaff = new OracleCommand(sqlstaff, con);
                OracleCommand cmdarea = new OracleCommand(sqlarea, con);
                OracleCommand cmdstart_time = new OracleCommand(sqlstart_time, con);
                OracleCommand cmdend_time = new OracleCommand(sqlend_time, con);
                OracleCommand cmdrentMoney = new OracleCommand(sqlrentMoney, con);
                cmdmerchant.ExecuteNonQuery();
                cmdstaff.ExecuteNonQuery();
                cmdarea.ExecuteNonQuery();
                cmdstart_time.ExecuteNonQuery();
                cmdend_time.ExecuteNonQuery();
                cmdrentMoney.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //显示全部摊位信息
        public DataSet selectStall()
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from stall,quotation where stall.area= quotation.area";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "stall,quotation");
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //按stall_id查询
        public DataSet selectStallwithStall_id(string stallID)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from stall where stall_id = '" + stallID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "stall");
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
        public DataSet selectStallwithMerchant_id(string merchantID)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from stall where merchant_id = '" + merchantID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "stall");
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        //按staff_id查找
        public DataSet selectStallwithStaff_id(string staffID)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from stall where staff_id = '" + staffID + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "stall");
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //按面积查找
        public DataSet selectStallwithArea(string Area)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from stall where area = '" + Area + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "stall");
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //按标价查找
        public DataSet selectStallwithPrice(string minPrice, string maxPrice)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from stall,quotation where stall.area= quotation.area and price between '" + minPrice + "'and'" + maxPrice + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "stall,quotation");
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //按开始时间查找
        public DataSet selectStallwithStart_time(string minStart_time, string maxStart_time)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from stall where start_time between to_date('" + minStart_time + "','yyyy-mm-dd')and to_date('" + maxStart_time + "','yyyy-mm-dd')";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "stall");
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入正确的开始时间");
                return null;
            }
        }

        //按结束时间查找
        public DataSet selectStallwithEnd_time(string minEnd_time, string maxEnd_time)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from stall where end_time between to_date('" + minEnd_time + "','yyyy-mm-dd')and to_date('" + maxEnd_time + "','yyyy-mm-dd')";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "stall");
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入正确结束的时间");
                return null;
            }
        }
        //更改摊位面积价格
        public bool updateQuotation(string Area, string Price)
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "update quotation set price ='" + Price + "'where area = '" + Area + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i == 0)
                {
                    return false;
                }
                else
                    return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        //查询摊位标价
        public DataSet selectQuotation()
        {
            try
            {
                string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                string sql = "select * from quotation";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                oda.Fill(ds, "quotation");
                //cmd.Dispose();
                con.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        //判断摊位是否存在
        public bool stallexist(string stallID)
        {
            string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection con = new OracleConnection(s);
            con.Open();
            string sqlStallID = "select * from stall where stall_id='" + stallID + "'";
            OracleCommand cmdstall = new OracleCommand(sqlStallID, con);
            if (cmdstall.ExecuteScalar() == null)
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

        //判断摊位面积是否存在
        public bool areaexist(string Area)
        {
            string s = "DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection con = new OracleConnection(s);
            con.Open();
            string sqlarea = "select * from quotation where area='" + Area + "'";
            OracleCommand cmdarea = new OracleCommand(sqlarea, con);
            if (cmdarea.ExecuteScalar() == null)
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
        public bool staffexist(string staff_id)//检查员工id是否存在
        {
            string s = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
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
