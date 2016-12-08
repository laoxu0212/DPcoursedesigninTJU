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
    public class Doselect : Doconnect
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
        private Doselect() { }
        public static readonly Doselect instance = new Doselect();
    }
}
