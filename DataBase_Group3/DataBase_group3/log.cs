﻿using System;
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

            StreamWriter sw = new StreamWriter("log.txt",true);
            sw.WriteLine(sql);
            sw.Flush();
            sw.Close();
        }
        private log() { }
        public static readonly log instance = new log();
    }
}
