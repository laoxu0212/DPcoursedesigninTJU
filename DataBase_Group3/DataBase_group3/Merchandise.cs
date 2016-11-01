using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;

namespace DataBase {
    class Merchandise {

        //判断是否存在一条表项
        static public bool IsAnEntryExist(string merchant_id, string supplier_id, string batch_number, string id_in_batch) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select merchant_id from merchandise where merchant_id = '" + merchant_id 
                + "' and supplier_id = '" + supplier_id
                + "' and batch_number = '" + batch_number
                + "' and id_in_batch = '" + id_in_batch
                + "'";
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "merchandise");
            for (int i = 0; i < ds.Tables["merchandise"].Rows.Count; i++) {
                if (merchant_id == (string)ds.Tables["merchandise"].Rows[i]["merchant_id"]) {
                    return true;
                }
            }
            return false;
        }

        //判断修改表项时前后仓库ID是否一致
        static public bool IsWarehouseIDSame(string old_merchant_id, string old_supplier_id, string old_batch_number, string old_id_in_batch, string new_warehouse_id) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            dbcon.Open();

            string selectOldWarehouseID = "select warehouse_id from merchandise where merchant_id = '" + old_merchant_id
                + "' and supplier_id = '" + old_supplier_id
                + "' and batch_number = '" + old_batch_number
                + "' and id_in_batch = '" + old_id_in_batch
                + "'";
            OracleCommand cmd = new OracleCommand(selectOldWarehouseID, dbcon);
            string old_warehouse_id = cmd.ExecuteScalar().ToString();
            dbcon.Close();
            if (old_warehouse_id == new_warehouse_id) {
                return true;
            }
            return false;
        }

        //修改表项时前后仓库ID相同时使用此方法
        static public bool UpdateWhenIDSame(string merchant_id, string old_supplier_id, string old_batch_number, string old_id_in_batch, double new_amount) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            dbcon.Open();

            string selectOldAmount = "select amount from merchandise where merchant_id = '" + merchant_id
                + "' and supplier_id = '" + old_supplier_id
                + "' and batch_number = '" + old_batch_number
                + "' and id_in_batch = '" + old_id_in_batch
                + "'";
            OracleCommand cmd = new OracleCommand(selectOldAmount, dbcon);
            double old_amount = Convert.ToDouble(cmd.ExecuteScalar());

            double change_amount = new_amount - old_amount;

            string selectOldWarehouseID = "select warehouse_id from merchandise where merchant_id = '" + merchant_id
                + "' and supplier_id = '" + old_supplier_id
                + "' and batch_number = '" + old_batch_number
                + "' and id_in_batch = '" + old_id_in_batch
                + "'";
            OracleCommand cmd1 = new OracleCommand(selectOldWarehouseID, dbcon);
            string old_warehouse_id = cmd1.ExecuteScalar().ToString();

            string selectOldLeftCapacity = "select left_capacity from warehouse where warehouse_id = '" + old_warehouse_id + "'";
            OracleCommand cmd2 = new OracleCommand(selectOldLeftCapacity, dbcon);
            double old_left_capacity = Convert.ToDouble(cmd2.ExecuteScalar());

            double changed_left_capacity = old_left_capacity - change_amount;

            if (changed_left_capacity >= 0) {
                string updateOldLeftCapacity = "update warehouse set left_capacity = " + changed_left_capacity.ToString()
                    + " where warehouse_id = '" + old_warehouse_id + "'";
                OracleCommand cmd3 = new OracleCommand(updateOldLeftCapacity, dbcon);
                cmd3.ExecuteNonQuery();
                dbcon.Close();
                //MessageBox.Show("仓库剩余容量修改成功！");
                return true;
            }
            else {
                dbcon.Close();
                MessageBox.Show("仓库剩余容量不足！");
                return false;
            }
        }

        //更新时旧仓库剩余容量变化
        static public void UpdateOldCapacity(string merchant_id, string supplier_id, string batch_number, string id_in_batch) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            dbcon.Open();

            string selectOldAmount = "select amount from merchandise where merchant_id = '" + merchant_id 
                + "' and supplier_id = '" + supplier_id
                + "' and batch_number = '" + batch_number
                + "' and id_in_batch = '" + id_in_batch
                + "'";
            OracleCommand cmd = new OracleCommand(selectOldAmount, dbcon);
            double old_amount = Convert.ToDouble(cmd.ExecuteScalar());

            string selectOldWarehouseID = "select warehouse_id from merchandise where merchant_id = '" + merchant_id
                + "' and supplier_id = '" + supplier_id
                + "' and batch_number = '" + batch_number
                + "' and id_in_batch = '" + id_in_batch
                + "'";
            OracleCommand cmd1 = new OracleCommand(selectOldWarehouseID, dbcon);
            string old_warehouse_id = cmd1.ExecuteScalar().ToString();

            string selectOldLeftCapacity = "select left_capacity from warehouse where warehouse_id = '" + old_warehouse_id + "'";
            OracleCommand cmd2 = new OracleCommand(selectOldLeftCapacity, dbcon);
            double old_left_capacity = Convert.ToDouble(cmd2.ExecuteScalar());

            double new_left_capacity = old_left_capacity + old_amount;

            string updateOldLeftCapacity = "update warehouse set left_capacity = " + new_left_capacity.ToString()
                + " where warehouse_id = '" + old_warehouse_id + "'";
            OracleCommand cmd3 = new OracleCommand(updateOldLeftCapacity, dbcon);
            cmd3.ExecuteNonQuery();

            dbcon.Close();
        }

        //更新时新仓库剩余容量变化
        static public bool UpdateNewCapacity(string merchant_id, string new_supplier_id, string new_batch_number, string new_id_in_batch, double new_amount, string new_warehouse_id) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            dbcon.Open();

            string selectOldLeftCapacity = "select left_capacity from warehouse where warehouse_id = '" + new_warehouse_id + "'";
            OracleCommand cmd2 = new OracleCommand(selectOldLeftCapacity, dbcon);
            double old_left_capacity = Convert.ToDouble(cmd2.ExecuteScalar());

            double new_left_capacity = old_left_capacity - new_amount;

            if (new_left_capacity >= 0) {
                string updateOldLeftCapacity = "update warehouse set left_capacity = " + new_left_capacity.ToString()
                    + " where warehouse_id = '" + new_warehouse_id + "'";
                OracleCommand cmd3 = new OracleCommand(updateOldLeftCapacity, dbcon);
                cmd3.ExecuteNonQuery();
                dbcon.Close();
                return true;
            }
            else {
                MessageBox.Show("新仓库容量不足！");
                return false;
            }
        }

        //判断某仓库是否属于某商家
        static public bool IsWarehouseBelongToMerchant(string warehouse_id, string merchant_id) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select warehouse_id from warehouse where merchant_id = '" + merchant_id + "'";
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

        //判断某仓库是否有足够的空间
        static public double IsWarehouseCapacityEnough(string warehouse_id, double amount) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select left_capacity from warehouse where warehouse_id = '" + warehouse_id + "'";
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "warehouse");
            return (Convert.ToDouble(ds.Tables["warehouse"].Rows[0]["left_capacity"]) - amount);
        }

        //判断要取出的货物是否充足
        static public double IsMerchandiseEnough(string merchant_id, string supplier_id, string batch_number, string id_in_batch/*, string name*/, double amount_to_pick/*, string warehouse_id*/) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select amount from merchandise where merchant_id = '" + merchant_id 
                + "' and supplier_id = '" + supplier_id
                + "' and batch_number = '" + batch_number
                + "' and id_in_batch = '" + id_in_batch
                + "'";
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "merchandise");
            return (Convert.ToDouble(ds.Tables["merchandise"].Rows[0]["amount"]) - amount_to_pick);
        }

        //添加一条新货物表项(存货)
        static public bool AddAnEntry(string merchant_id, string supplier_id, string batch_number, string id_in_batch, string name, double amount, string warehouse_id) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            dbcon.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = dbcon;
            OracleTransaction trans = dbcon.BeginTransaction();
            try {
                string insert = "insert into merchandise (merchant_id, supplier_id, batch_number, id_in_batch, name, amount, warehouse_id) values ('"
                    + merchant_id + "', '"
                    + supplier_id + "', '"
                    + batch_number + "', '"
                    + id_in_batch + "', '"
                    + name + "', "
                    + amount.ToString() + ", '"
                    + warehouse_id + "')";
                cmd.CommandText = insert;
                cmd.ExecuteNonQuery();
                double new_left_capacity = IsWarehouseCapacityEnough(warehouse_id, amount);
                string update = "update warehouse set left_capacity = " + new_left_capacity.ToString() + "where warehouse_id = '" + warehouse_id + "'";
                cmd.CommandText = update;
                cmd.ExecuteNonQuery();
                trans.Commit();
                dbcon.Close();
                return true;
            }
            catch (Exception ex) {
                //MessageBox.Show(ex.ToString());
                trans.Rollback();
                return false;
            }
        }

        //修改一条货物表项
        static public bool UpdateAnEntry(string merchant_id, string old_supplier_id, string new_supplier_id, string old_batch_number, string new_batch_number, string old_id_in_batch, string new_id_in_batch, string name, double amount, string warehouse_id) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            dbcon.Open();
            try {
                string update = "update merchandise set supplier_id = '" + new_supplier_id
                    + "', batch_number = '" + new_batch_number
                    + "', id_in_batch = '" + new_id_in_batch
                    + "', name = '" + name
                    + "', amount = " + amount.ToString()
                    + ", warehouse_id = '" + warehouse_id
                    + "' where merchant_id = '" + merchant_id
                    + "' and supplier_id = '" + old_supplier_id
                    + "' and batch_number = '" + old_batch_number
                    + "' and id_in_batch = '" + old_id_in_batch
                    + "'";
                OracleCommand cmd = new OracleCommand(update, dbcon);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Successful");
                dbcon.Close();
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //取货
        static public bool PickUpMerchandise(string merchant_id, string supplier_id, string batch_number, string id_in_batch, /*string name, */double amount_to_pick/* string warehouse_id*/) {            
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            dbcon.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = dbcon;
            OracleTransaction trans = dbcon.BeginTransaction();

            //查找warehouse_id
            string search = "select warehouse_id from merchandise where merchant_id = '" + merchant_id
                + "' and supplier_id = '" + supplier_id
                + "' and batch_number = '" + batch_number
                + "' and id_in_batch = '" + id_in_batch
                + "'";
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "merchandise");
            string warehouse_id = Convert.ToString(ds.Tables["merchandise"].Rows[0]["warehouse_id"]);

            double left_amount = IsMerchandiseEnough(merchant_id, supplier_id, batch_number, id_in_batch, amount_to_pick);
            if (left_amount > 0) {
                try {
                    string updateMerchandise = "update merchandise set amount = " + left_amount.ToString() 
                        + " where merchant_id = '" + merchant_id
                        + "' and supplier_id = '" + supplier_id
                        + "' and batch_number = '" + batch_number
                        + "' and id_in_batch = '" + id_in_batch
                        + "'";
                    cmd.CommandText = updateMerchandise;
                    cmd.ExecuteNonQuery();

                    //更新仓库剩余容量
                    double new_left_capacity = amount_to_pick + IsWarehouseCapacityEnough(warehouse_id, 0);
                    string update = "update warehouse set left_capacity = " + new_left_capacity.ToString() + "where warehouse_id = '" + warehouse_id + "'";
                    cmd.CommandText = update;
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    dbcon.Close();
                    return true;
                }
                catch (Exception ex) {
                    //MessageBox.Show(ex.ToString());
                    trans.Rollback();
                    return false;
                }
            }
            else {
                try {
                    string deleteMerchandise = "delete from merchandise where merchant_id = '" + merchant_id
                        + "' and supplier_id = '" + supplier_id
                        + "' and batch_number = '" + batch_number
                        + "' and id_in_batch = '" + id_in_batch
                        + "'";
                    cmd.CommandText = deleteMerchandise;
                    cmd.ExecuteNonQuery();
                    double new_left_capacity = amount_to_pick + IsWarehouseCapacityEnough(warehouse_id, 0);
                    string update = "update warehouse set left_capacity = " + new_left_capacity.ToString() + " where warehouse_id = '" + warehouse_id + "'";
                    cmd.CommandText = update;
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    dbcon.Close();
                    return true;
                }
                catch (Exception ex) {
                    //MessageBox.Show(ex.ToString());
                    trans.Rollback();
                    return false;
                }
            }
        }

        //查看商家所有货物数量信息
        static public DataSet ShowAllMerchandiseNumber(string merchant_id) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select name, sum(amount) as sum_amount from merchandise where merchant_id = '" + merchant_id + "' group by name";
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "merchandise");
            return ds;
        }

        //查看商家所有货物详细信息
        static public DataSet ShowAllMerchandiseInfo(string merchant_id) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select * from merchandise where merchant_id = '" + merchant_id + "'";
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "merchandise");
            return ds;
        }

        //通过货物名称查询
        static public DataSet SearchByName(string merchant_id, string name) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            string search = "select * from merchandise where merchant_id = '" + merchant_id + "' and name = '" + name + "'";
            OracleDataAdapter oda = new OracleDataAdapter(search, dbcon);
            DataSet ds = new DataSet();
            oda.Fill(ds, "merchandise");
            return ds;
        }

        //获取货物名称
        static public string GetName(string merchant_id, string supplier_id, string batch_number, string id_in_batch) {
            string db = " DATA SOURCE=localhost:1521/orcl.microdone.cn;USER ID=C##tc; password = byebye88";
            OracleConnection dbcon = new OracleConnection(db);
            dbcon.Open();
            string selectName = "select name from merchandise where merchant_id = '" + merchant_id
                + "' and supplier_id = '" + supplier_id
                + "' and batch_number = '" + batch_number
                + "' and id_in_batch = '" + id_in_batch
                + "'";
            OracleCommand cmd = new OracleCommand(selectName, dbcon);
            if (cmd.ExecuteScalar() == null) {
                return "";
            }
            string name = cmd.ExecuteScalar().ToString();
            return name;
        }
    }
}
