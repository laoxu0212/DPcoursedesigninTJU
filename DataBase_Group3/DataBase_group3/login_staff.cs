using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebass
{

    class login_staff : dologin
    {
        public bool check(string ID, string password)
        {

            string result = "";
            string sql = "select PASSWORD from STAFF_LOGIN where STAFF_ID = " + "'" + ID + "'";
            Doselect a = Doselect.instance;
            result = a.Do(sql).ToString();
            if (result == password) return true;
            return false;
        }
        public bool update(string ID, string newpassword)
        {
            string result = "";

            string esql = "update STAFF_LOGIN set PASSWORD = '" + newpassword + "' where STAFF_ID = '" + ID + "'";

            string ssql = "select PASSWORD from STAFF_LOGIN where STAFF_ID = '" + ID + "'";

            Doexecute b = Doexecute.instance;
            Doselect a = Doselect.instance;
            b.Do(esql);
            result = a.Do(ssql).ToString();
            if (result == newpassword) return true;
            return false;
        }
        public string find(string ID, string verification_code)
        {
            string result = "";
            string sql = "select PASSWORD from STAFF_LOGIN where STAFF_ID = '" + ID + "' and verification_code = '" + verification_code + "'";
            Doselect a = Doselect.instance;
            result = a.Do(sql).ToString();
            return result;
        }
        public bool exist(string staff_id)//检查员工id是否存在
        {
            object result = null;
            string sql = "select * from staff where staff_id='" + staff_id + "'";
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

        private login_staff() { }
        public static readonly login_staff instance = new login_staff();
    }
}
