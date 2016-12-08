using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace Datebass
{
    class tt
    {

    }
    class login
    {
        //public int ID;
        //public string password;
        //public void set()
        //{
        //    ID = 123213;
        //    password = "asdfasdfas";
        //}
        public bool staff_check(string ID, string password)
        {

            string result = "";
            string sql = "select PASSWORD from STAFF_LOGIN where STAFF_ID = " + "'" + ID + "'";
            Doselect a = Doselect.instance;
            result = a.Do(sql).ToString();
            if (result == password) return true;
            return false;
        }
        public bool staff_update(string ID, string newpassword)
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
        public string staff_find(string ID, string verification_code)
        {
            string result = "";
            string sql = "select PASSWORD from STAFF_LOGIN where STAFF_ID = '" + ID + "' and verification_code = '" + verification_code + "'";
            Doselect a = Doselect.instance;
            result = a.Do(sql).ToString();
            return result;
        }

        public bool merchant_check(string ID, string password)
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
        public bool merchant_update(string ID, string newpassword)
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
        public string merchant_find(string ID, string verification_code)
        {
            string result = "";
            string sql = "select PASSWORD from MERCHANT_LOGIN where MERCHANT_ID = '" + ID + "' and verification_code = '" + verification_code + "'";
            Doselect a = Doselect.instance;
            result = a.Do(sql).ToString();
            return result;
        }

        public bool check(string ID, string password)
        {
            if (ID[0] == '1' || ID[0] == '2' || ID[0] == '3' || ID[0] == '4')
                return merchant_check(ID, password);
            else return staff_check(ID, password);
        }

        public bool update(string ID, string password)
        {
            if (ID[0] == '1' || ID[0] == '2' || ID[0] == '3' || ID[0] == '4')
                return merchant_update(ID, password);
            else return staff_update(ID, password);
        }

        public string find(string ID, string password)
        {
            if (ID[0] == '1' || ID[0] == '2' || ID[0] == '3' || ID[0] == '4')
                return merchant_find(ID, password);
            else return staff_find(ID, password);
        }
        public bool staffexist(string staff_id)//检查员工id是否存在
        {
            object result = null;
            string sql = "select * from staff where staff_id='" + staff_id + "'";
            Doselect a = Doselect.instance;
            result=a.Do(sql);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
