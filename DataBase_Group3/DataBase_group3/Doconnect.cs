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
    
    public abstract class Doconnect
    {
        public bool state;
        public object result;
        public OracleConnection con;
        public OracleCommand cmd;
        public string s;
        public abstract object Do(string sql);
    }
   
    
}
