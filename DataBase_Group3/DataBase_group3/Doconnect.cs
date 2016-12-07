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
    public interface Doconnect
    {
        object Do(string sql);
    }
    class Doselect:Doconnect
    {
        public bool state;
        public object Do(string sql)
        {

           object result=null;
           OracleCommand cmd;
            try
            {
                string s = " DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                //string sql = "update test set sex = 'female' where name = '76' ";
                //string sql = "select PASSWORD from STAFF_LOGIN where STAFF_ID = " + "'" + ID + "'";
                cmd = new OracleCommand(sql, con);

                //cmd.ExecuteNonQuery();
                result = cmd.ExecuteScalar();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return result;
        }
    }
    class Doexecute : Doconnect
    {
        public object Do(string sql)
        {

            object result = true;
            OracleCommand cmd;
            try
            {
                string s = " DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();

                //string sql = "update test set sex = 'female' where name = '76' ";
                //string sql = "select PASSWORD from STAFF_LOGIN where STAFF_ID = " + "'" + ID + "'";
                cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                //result = cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                result = false;
            }

            return result;
        }
    }
}
