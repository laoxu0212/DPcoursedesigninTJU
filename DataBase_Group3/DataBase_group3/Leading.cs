using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
namespace Datebass
{
    class Leading
    {
        Doselect select = Doselect.instance;
        Doexecute execute = Doexecute.instance;
        public bool addlead(string dept_name, string staff_id)//新增lead表
        {
            try
            {
                string sql2 = "select dept_name from staff where staff_id='" + staff_id + "'";
                string deptname = select.Do(sql2).ToString();
                if (deptname == dept_name)
                {
                    string sql = "update leading set dept_head='" + staff_id + "' where dept_name='" + dept_name + "'";
                
                    execute.Do(sql);
                    return true;
                }
                else
                    return false;
               
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
                string s = "  DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234 ";
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
