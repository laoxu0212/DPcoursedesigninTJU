﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.Data;

namespace Datebass
{
    class Receipt
    {
        Doselect select = Doselect.instance;
        Doexecute execute = Doexecute.instance;
        public string supplier_id, batch_number, name, time, amount, total_price;
        public DataSet selectReceipt(string supplier_id, string batch_number)
        {
            try
            {
                
                string sql = "select * from receipt where supplier_id = '" + supplier_id + "' and batch_number = '" + batch_number + "' and merchant_id = '" + user_ifms.ID + "'";
                
                return select.Data(sql, "receipt");
            }
            catch
            {
                MessageBox.Show("查询失败。");
                return null;
            }

        }
       static public DataSet selectReceipt(string supplier_id)
        {
            try
            {
                Doselect select = Doselect.instance;
                Doexecute execute = Doexecute.instance;
               
                string sql = "select * from receipt where supplier_id = '" + supplier_id + "' and merchant_id = '" + user_ifms.ID + "'";
               
                return select.Data(sql, "receipt");
            }
            catch
            {
                MessageBox.Show("查询失败。");
                return null;
            }

        }
        public bool insertReceipt(string supplier_id, string batch_number, string merchant_id, string time, string amount, string name, string total_price)
        {
            try
            {
                
                string sql = "insert into receipt values('" + supplier_id + "','" + batch_number + "','" + merchant_id + "',to_date('" + time + "','yyyy-mm-dd'),'" + Convert.ToInt32(amount) + "','" + name + "','" + Convert.ToInt32(total_price) + "')";
                
                execute.Do(sql);
                MessageBox.Show("插入成功。");
               
            }
            catch
            {
                MessageBox.Show("插入失败。");
                return false;
            }
            return true;
        }
        public bool updateReceipt(string supplier_id, string batch_number, string merchant_id, string time, string amount, string name, string total_price)
        {
            try
            {
                

                string sql = "update receipt set time = to_date('" + time + "','yyyy-mm-dd') ,amount = '" + amount + "',name = '" + name + "',total_price = '" + total_price + "' where merchant_id = '" + merchant_id + "' and supplier_id = '" + supplier_id + "' and  batch_number ='" + batch_number + "'";
               
                execute.Do(sql);
                MessageBox.Show("修改成功。");
                return true;

            }
            catch
            {
                MessageBox.Show("修改失败。");
                return false;
            }
        }
        public DataSet selectReceiptByTime(string starttime,string endtime)
        {
            try
            {
               
                string sql = "select * from receipt where time between to_date('" + starttime + "','yyyy-mm-dd') and to_date('" + endtime + "','yyyy-mm-dd') and merchant_id = '"+user_ifms.ID+"'";
                
                return select.Data(sql, "receipt");
            }
            catch
            {
                return null;
            }
        }
        public bool showReceipt(string supplier_id,string batch_number)
        {
            try
            {
                
                string Supplier_ID = "select supplier_id from receipt where supplier_id='" + supplier_id + "' and batch_number = '"+batch_number+"'";
                string Batch_number = "select batch_number from receipt where supplier_id='" + supplier_id + "' and batch_number = '" + batch_number + "'";
                string Time = "select to_char(time,'yyyy-mm-dd') from receipt where supplier_id='" + supplier_id + "' and batch_number = '" + batch_number + "'";
                string Amount = "select amount from receipt where supplier_id='" + supplier_id + "' and batch_number = '" + batch_number + "'";
                string Name = "select name from receipt where supplier_id='" + supplier_id + "' and batch_number = '" + batch_number + "'";
                string Total_price = "select total_price from receipt where supplier_id='" + supplier_id + "' and batch_number = '" + batch_number + "'";
                
                this.supplier_id = select.Do(Supplier_ID).ToString();
                this.name = select.Do(name).ToString();
                this.time = select.Do(time).ToString();
                this.batch_number = select.Do(Batch_number).ToString();
                this.amount = select.Do(Amount).ToString();
                this.total_price = select.Do(Total_price).ToString();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string checkReceipt(string merchant_id, string order_id, string supplier_id)
        {

            try
            {
                
                string sql = "select amount from receipt where supplier_id = '" + supplier_id + "' and batch_number = '" + order_id + "' and merchant_id = '" + merchant_id + "'";
                
                string str = "";
                str = select.Do(sql).ToString();
                return str;
            }
            catch
            {
                return "";
            }
        }
    }
}
