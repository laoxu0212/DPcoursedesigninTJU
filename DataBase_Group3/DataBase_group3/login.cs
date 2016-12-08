using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace Datebass
{

    class login
    {
        login_merchant merchant = login_merchant.instance;
        login_staff staff = login_staff.instance;
        public bool check(string ID, string password)
        {
            
            if (ID[0] == '1' || ID[0] == '2' || ID[0] == '3' || ID[0] == '4')
                return merchant.check(ID, password);
            else return staff.check(ID, password);

        }

        public bool update(string ID, string password)
        {
            if (ID[0] == '1' || ID[0] == '2' || ID[0] == '3' || ID[0] == '4')
                return merchant.update(ID, password);
            else return staff.update(ID, password);
        }

        public string find(string ID, string password)
        {
            if (ID[0] == '1' || ID[0] == '2' || ID[0] == '3' || ID[0] == '4')
                return merchant.find(ID, password);
            else return staff.find(ID, password);
        }
        public bool exist(string ID)
        {
            if (ID[0] == '1' || ID[0] == '2' || ID[0] == '3' || ID[0] == '4')
                return merchant.exist(ID);
            else return staff.exist(ID);
        }

        private login() { }
        public static readonly login instance = new login();
    }
}
