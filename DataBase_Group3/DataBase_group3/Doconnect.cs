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
    //public abstract class t
    //{
    //    public int a;
    //    public abstract object x();
    //}
    //public class tt : t
    //{
    //    public override object x()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    public abstract class Doconnect
    {

        public bool state;
        public object result;
        public OracleConnection con;
        public OracleCommand cmd;
        public string s;
        public abstract object Do(string sql);
    }
    class Doselect : Doconnect
    {
        public override object Do(string sql)
        {

            result = null;

            try
            {
                s = " DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234 ";
                con = new OracleConnection(s);
                con.Open();
                cmd = new OracleCommand(sql, con);
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
        public override object Do(string sql)
        {

            result = true;
            try
            {
                s = " DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234 ";
                con = new OracleConnection(s);
                con.Open();

                cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
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
