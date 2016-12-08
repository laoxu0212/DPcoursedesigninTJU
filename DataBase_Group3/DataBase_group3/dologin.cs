using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebass
{
    public interface dologin
    {
        bool check(string ID, string password);
        bool update(string ID, string newpassword);
        string find(string ID, string verification_code);
        bool exist(string staff_id);
    }
}
