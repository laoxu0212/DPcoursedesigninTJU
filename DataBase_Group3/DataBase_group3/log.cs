using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.Data;
using System.IO;


namespace Datebass
{
    class log
    {
        public void Write(string sql)
        {
            //FileStream fs = new FileStream("log.txt", FileMode.Create);
            ////获得字节数组
            //byte[] data = System.Text.Encoding.Default.GetBytes("Hello World!");
            ////开始写入
            //fs.Write(data, 0, data.Length);
            ////清空缓冲区、关闭流
            //fs.Flush();
            //fs.Close();

            StreamWriter sw = new StreamWriter("log.txt",true);
            sw.WriteLine(sql);
            sw.Flush();
            sw.Close();
        }
        private log() { }
        public static readonly log instance = new log();
    }
}
