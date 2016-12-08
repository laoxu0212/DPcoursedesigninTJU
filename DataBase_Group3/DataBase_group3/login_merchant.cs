using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebass
{
    public class login_merchant : dologin
    {

        public bool check(string ID, string password)
        {

            string result = "";
            string sql = "select PASSWORD from MERCHANT_LOGIN where MERCHANT_ID = " + "'" + ID + "'";
            Doselect a = Doselect.instance;
            //Doselect a1 = Doselect.instance;
            //if (a == a1) Console.WriteLine("the same!!!!");
            result = a.Do(sql).ToString();
            if (result == password) return true;
            return false;
        }
        public bool update(string ID, string newpassword)
        {
            string result = "";

            string esql = "update MERCHANT_LOGIN set PASSWORD = '" + newpassword + "' where MERCHANT_ID = '" + ID + "'";

            string ssql = "select PASSWORD from MERCHANT_LOGIN where MERCHANT_ID = '" + ID + "'";
            Doexecute b = Doexecute.instance;
            //Doexecute b1 = Doexecute.instance;
            //if (b == b1) Console.WriteLine("the same again!!");
            Doselect a = Doselect.instance;
            b.Do(esql);
            result = a.Do(ssql).ToString();


            if (result == newpassword) return true;
            return false;
        }
        public string find(string ID, string verification_code)
        {
            string result = "";
            string sql = "select PASSWORD from MERCHANT_LOGIN where MERCHANT_ID = '" + ID + "' and verification_code = '" + verification_code + "'";
            Doselect a = Doselect.instance;
            result = a.Do(sql).ToString();
            return result;
        }

        public bool exist(string merchantID)
        {
            object result = null;

            string sql = "select * from merchant where merchant_id='" + merchantID + "'";
            Doselect a = Doselect.instance;
            result = a.Do(sql);
            if (result == null)
            {
                return false;
            }
            else
            {

                return true;
            }
        }
        private login_merchant() { }
        public static readonly login_merchant instance = new login_merchant();
    }
}
