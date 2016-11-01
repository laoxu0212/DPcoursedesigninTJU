using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
namespace staff
{
    class Leading
    {
        public bool addlead(string dept_name, string staff_id)//新增lead表
        {
            try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
        
                string sql2 = "select dept_name from staff where staff_id='" + staff_id + "'";
                OracleCommand cmd2 = new OracleCommand(sql2, con);
                cmd2.ExecuteNonQuery();
                string deptname = cmd2.ExecuteScalar().ToString();
                if (deptname == dept_name)
                {
                    string sql = "update leading set dept_head='" + staff_id + "' where dept_name='" + dept_name + "'";
                    OracleCommand cmd = new OracleCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else
                    return false;
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
    }
}
