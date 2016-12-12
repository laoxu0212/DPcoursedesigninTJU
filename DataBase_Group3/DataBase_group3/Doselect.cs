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
    class log
    {
        public void Write()
        {
            FileStream fs = new FileStream("log.txt", FileMode.Create);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes("Hello World!");
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
    }
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
