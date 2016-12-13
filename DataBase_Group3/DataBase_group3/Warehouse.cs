using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace Datebass
{
    class Warehouse {
        Doselect select = Doselect.instance;
        Doexecute execute = Doexecute.instance;
        public string warehouse_id;
        public double area;
        public double full_capacity;
        public double left_capacity;
        public string merchant_id;
        public string staff_id;

        //判断某仓库是否存在
        public bool IsWarehouseExisted(string warehouse_id) {
            
            string search = "select warehouse_id from warehouse where warehouse_id = '" + warehouse_id + "'";
           
            DataSet ds = select.Data(search, "warehouse");
           
            for (int i = 0; i < ds.Tables["warehouse"].Rows.Count; i++) {
                if (warehouse_id == (string)ds.Tables["warehouse"].Rows[i]["warehouse_id"]) {
                    return true;
                }
            }
            return false;
        }

        //展示所有仓库信息
        public DataSet ShowAllWarehouse() {
           
            string search = "select * from warehouse";
            
            return select.Data(search, "warehouse");
        }

        //添加一条新仓库表项
        public bool AddAnEntry(/*string id,*/ double area1, double capacity, string m_id, string s_id) {
            try {
               
                string insert = "insert into warehouse (area, full_capacity, left_capacity, merchant_id, staff_id) values ("
                    + area1.ToString() + ","
                    + capacity.ToString() + ","
                    + capacity.ToString() + ",'"
                    + m_id + "','"
                    + s_id + "')";
               
                execute.Do(insert);
                MessageBox.Show("Succeed");
                //dbcon.Close();
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //根据容量查询
        public DataSet SearchByFullCapacity(double min_capacity, double max_capacity) {
          
            string search = "select * from warehouse where full_capacity >= " + min_capacity.ToString() + " and full_capacity <= " + max_capacity.ToString() ;
            
            return select.Data(search, "warehouse");
        }

        //根据商家ID查询
        public DataSet SearchByMerchantID(string merchant_id) {
            
            string search = "select * from warehouse where merchant_id = " + merchant_id;
           
            return select.Data(search, "warehouse");
        }

        //根据仓库面积查询
        public DataSet SearchByArea(double area) {
           
            string search = "select * from warehouse where area = " + area;
            
            return select.Data(search, "warehouse");
        }

        //根据员工ID查询
        public DataSet SearchByStaffID(string staff_id) {
           
            string search = "select * from warehouse where staff_id = " + staff_id;
            
            return select.Data(search,"warehouse");
        }

        //通过仓库ID查询
        public bool SearchAnEntryByID(string id) {
            try {
               
                string search = "select * from warehouse where warehouse_id = '" + id + "'";
                
                DataSet ds = select.Data(search, "warehouse");
               
                DataTableReader rdr = ds.CreateDataReader();
                this.warehouse_id = (string)ds.Tables["warehouse"].Rows[0]["warehouse_id"];
                this.area = Convert.ToDouble(ds.Tables["warehouse"].Rows[0]["area"]);
                this.full_capacity = Convert.ToDouble(ds.Tables["warehouse"].Rows[0]["full_capacity"]);
                this.left_capacity = Convert.ToDouble(ds.Tables["warehouse"].Rows[0]["left_capacity"]);
                this.merchant_id = (string)(ds.Tables["warehouse"].Rows[0]["merchant_id"]);
                this.staff_id = (string)(ds.Tables["warehouse"].Rows[0]["staff_id"]);
                return true;
              
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //修改一个表项
        public bool UpdateAnEntry(string id, double area1, double full_capacity, double left_capacity, string m_id, string s_id) {
            try {
               
                string update = "update warehouse set area = " + area1.ToString() 
                    + ", full_capacity = " + full_capacity.ToString() 
                    + ", left_capacity = " + left_capacity 
                    + ", merchant_id = '" + m_id 
                    +"', staff_id = '" + s_id 
                    + "' where warehouse_id = '" + id 
                    + "'";
               
                execute.Do(update);
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        private Warehouse() { }
        public static readonly Warehouse instance = new Warehouse();
    }
}
