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
    public class Doexecute : Decorator
    {


        public override object Do(string sql)
        {
            
            try
            {
                s = " DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234 ";
                con = new OracleConnection(s);
                con.Open();

                cmd = new OracleCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

                Write(sql);
            }
            catch (Exception ex)
            {
                return null;
            }

            return cmd;
        }
        private Doexecute() { }
        public static readonly Doexecute instance = new Doexecute();
    }
}
