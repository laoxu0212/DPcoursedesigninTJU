using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace Datebass
{
    class Supplier
    {
        Doselect select = Doselect.instance;
        Doexecute execute = Doexecute.instance;
        public string supplier_id, name, address, phone_number;
        public string selectSupplier(string name, string phone_number)
        {
            try
            {
                string sql = "select supplier_id from supplier where name = '" + name + "'and phone_number = '" + phone_number + "'";
                
                string supplier_id = select.Do(sql).ToString();
                return supplier_id;
            }
            catch
            {
                MessageBox.Show("查询失败。");
                return null;
            }
        }
        public bool insertSupplier(string name, string phone_number, string address)
        {
            try
            {
                string sql = "insert into supplier(name,phone_number,address) values('" + name + "','" + phone_number + "','" + address + "')";
               
                execute.Do(sql);
                MessageBox.Show("插入成功。");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string checkSupplier_id(string supplier_id)
        {
            try
            {
                string sql = "select supplier_id from supplier where supplier_id = '" + supplier_id + "'";
                
                string str = execute.Do(sql).ToString();
                return str;
            }
            catch
            {
                return null;
            }
        }
        public bool update_supplier(string supplier_id, string name, string phone_number, string address)
        {
            try
            {

                string sql = "update supplier set name = '" + name + "', phone_number='" + phone_number + "', address='" + address + "' where supplier_id = '" + supplier_id + "'";
                
                execute.Do(sql);
                MessageBox.Show("success");
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool showSupplier(string name, string phone_number)
        {
            try
            {
                
                string Supplier_ID = "select supplier_id from supplier where name ='" + name + "' and phone_number = '" + phone_number + "'";
                string Phone_number = "select phone_number from supplier where name ='" + name + "' and phone_number = '" + phone_number + "'";
                string Name = "select name from supplier where name ='" + name + "' and phone_number = '" + phone_number + "'";
                string Address = "select address from supplier where name ='" + name + "' and phone_number = '" + phone_number + "'";
                
                this.supplier_id = select.Do(Supplier_ID).ToString();
                this.name = select.Do(Name).ToString();
                this.phone_number = select.Do(Phone_number).ToString();
                this.address = select.Do(Address).ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool showSupplier(string supplier_id)
        {
            try
            {
                string Supplier_ID = "select supplier_id from supplier where supplier_id = '"+supplier_id+"'";
                string Phone_number = "select phone_number from supplier where supplier_id = '" + supplier_id + "'";
                string Name = "select name from supplier where supplier_id = '" + supplier_id + "'";
                string Address = "select address from supplier where supplier_id = '" + supplier_id + "'";
                
                this.supplier_id = select.Do(Supplier_ID).ToString();
                this.name = select.Do(Name).ToString();
                this.phone_number = select.Do(Phone_number).ToString();
                this.address = select.Do(Address).ToString();

                
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
