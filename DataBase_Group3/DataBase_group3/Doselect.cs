using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.Data;
using System.IO;

using System.Text;
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
                log.instance.Write(sql);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return result;
        }
        public DataSet Data(string sql,string table)
        {
             try
            {
                string s = "  DATA SOURCE=localhost:1521/orcl2;USER ID=scott; password = 1234 ";
                OracleConnection con = new OracleConnection(s);
                con.Open();
                OracleCommand cmd = new OracleCommand(sql, con);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, table);
                return ds;
                con.Close();

                log.instance.Write(sql);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private Doselect() { }
        public static readonly Doselect instance = new Doselect();
    }
}
