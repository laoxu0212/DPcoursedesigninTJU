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
        public string warehouse_id;
        public double area;
        public double full_capacity;
        public double left_capacity;
        public string merchant_id;
        public string staff_id;

        //判断某仓库是否存在
        static public bool IsWarehouseExisted(string warehouse_id) {
            string db = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select warehouse_id from warehouse where warehouse_id = '" + warehouse_id + "'";
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "warehouse");
            for (int i = 0; i < ds.Tables["warehouse"].Rows.Count; i++) {
                if (warehouse_id == (string)ds.Tables["warehouse"].Rows[i]["warehouse_id"]) {
                    return true;
                }
            }
            return false;
        }

        //展示所有仓库信息
        static public DataSet ShowAllWarehouse() {
            string db = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select * from warehouse";
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "warehouse");
            return ds;
        }

        //添加一条新仓库表项
        static public bool AddAnEntry(/*string id,*/ double area1, double capacity, string m_id, string s_id) {
            try {
                string db = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection dbcon = new OracleConnection(db);
                dbcon.Open();
                string insert = "insert into warehouse (area, full_capacity, left_capacity, merchant_id, staff_id) values ("
                    + area1.ToString() + ","
                    + capacity.ToString() + ","
                    + capacity.ToString() + ",'"
                    + m_id + "','"
                    + s_id + "')";
                OracleCommand cmd = new OracleCommand(insert, dbcon);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succeed");
                dbcon.Close();
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //根据容量查询
        static public DataSet SearchByFullCapacity(double min_capacity, double max_capacity) {
            string db = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select * from warehouse where full_capacity >= " + min_capacity.ToString() + " and full_capacity <= " + max_capacity.ToString() ;
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "warehouse");
            return ds;
        }

        //根据商家ID查询
        static public DataSet SearchByMerchantID(string merchant_id) {
            string db = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select * from warehouse where merchant_id = " + merchant_id;
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "warehouse");
            return ds;
        }

        //根据仓库面积查询
        static public DataSet SearchByArea(double area) {
            string db = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select * from warehouse where area = " + area;
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "warehouse");
            return ds;
        }

        //根据员工ID查询
        static public DataSet SearchByStaffID(string staff_id) {
            string db = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select * from warehouse where staff_id = " + staff_id;
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "warehouse");
            return ds;
        }

        //通过仓库ID查询
        public bool SearchAnEntryByID(string id) {
            try {
                string db = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection dbcon = new OracleConnection(db);
                //dbcon.Open();
                string search = "select * from warehouse where warehouse_id = '" + id + "'";
                //OracleCommand cmd = new OracleCommand(search, dbcon);
                OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
                DataSet ds = new DataSet();
                oda.Fill(ds, "warehouse");
                DataTableReader rdr = ds.CreateDataReader();
                this.warehouse_id = (string)ds.Tables["warehouse"].Rows[0]["warehouse_id"];
                this.area = Convert.ToDouble(ds.Tables["warehouse"].Rows[0]["area"]);
                this.full_capacity = Convert.ToDouble(ds.Tables["warehouse"].Rows[0]["full_capacity"]);
                this.left_capacity = Convert.ToDouble(ds.Tables["warehouse"].Rows[0]["left_capacity"]);
                this.merchant_id = (string)(ds.Tables["warehouse"].Rows[0]["merchant_id"]);
                this.staff_id = (string)(ds.Tables["warehouse"].Rows[0]["staff_id"]);
                return true;
                //while (rdr.Read())//读取表中数据
                //{

                //    for (int i = 0; i < rdr.FieldCount; i++) {

                //        Console.Write(rdr.GetName(i) + "\t" + rdr.GetValue(i) + "\t");

                //    }

                //    Console.WriteLine();

                //}
                //cmd.ExecuteNonQuery();
                //MessageBox.Show("Successful");
                //dbcon.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //修改一个表项
        static public bool UpdateAnEntry(string id, double area1, double full_capacity, double left_capacity, string m_id, string s_id) {
            try {
                string db = "  DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88 ";
                OracleConnection dbcon = new OracleConnection(db);
                dbcon.Open();
                string update = "update warehouse set area = " + area1.ToString() 
                    + ", full_capacity = " + full_capacity.ToString() 
                    + ", left_capacity = " + left_capacity 
                    + ", merchant_id = '" + m_id 
                    +"', staff_id = '" + s_id 
                    + "' where warehouse_id = '" + id 
                    + "'";
                OracleCommand cmd = new OracleCommand(update, dbcon);
                cmd.ExecuteNonQuery();
                dbcon.Close();
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
