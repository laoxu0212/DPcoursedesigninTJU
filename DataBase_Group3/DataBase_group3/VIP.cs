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
    class VIP
    {
        Doselect select = Doselect.instance;
        Doexecute execute = Doexecute.instance;
        public bool new_VIP(string merchant_id,string client_id,string level)
        {
            try
            {
                
                string sql = "insert into client_VIP(merchant_id,client_id,grade) values('" + merchant_id+"','"+client_id+"',"+level+")";
                execute.Do(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public bool new_VIPgrade(string merchant_id, string  grade, string  discount)
        {
            try
            {
                
                string sql = "insert into merchant_VIP(merchant_id, grade, discount) values('" + merchant_id + "'," + grade + "," + discount + ")";

                execute.Do(sql);
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
    
        public bool update_discount(string merchant_id, string  grade, string newdiscount)
        {
            try
            {
                                
                string sql = "update merchant_VIP set discount = " + newdiscount + " where merchant_ID = '" + merchant_id + "' and grade = "+grade;
                execute.Do(sql);
                sql = "select discount from merchant_VIP where merchant_ID = '" + merchant_id + "' and grade = " + grade;
                string client_id = "";
                client_id = select.Do(sql).ToString();
                if (client_id == "") return false;
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool update_gradewithID(string merchant_id, string client_id, string newgrade)
        {
            try
            {
                
                string sql = "update client_VIP set grade = " + newgrade.ToString() + " where merchant_ID = '" + merchant_id + "' and client_ID = '" + client_id+"'";
                execute.Do(sql);

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public bool update_grade(string merchant_id, string name, string phone, string newgrade)
        {
            string client_id="";

            try
            {
                
                string sql = "select client_ID from client where phone_number = '" + phone + "' and name='"+name+"'";
                              
                client_id = select.Do(sql).ToString();
            }
            catch (Exception ex)
            {
            }
            if (client_id == "") return false;
            return update_gradewithID(merchant_id, client_id, newgrade);
        }

        public DataSet display(string merchant_ID)
        {
            try
            {
                string sql = "select client_id, grade, discount from client_VIP natural join merchant_vip where merchant_ID = '" + merchant_ID + "'";


               

                return select.Data(sql, "client_VIP natural join merchant_vip");
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet check_discountwithID(string merchant_ID, string client_ID)
        {
            try
            {
              
                string sql = "select merchant_id, grade, discount from client_VIP natural join merchant_vip where client_ID = '" + client_ID + "' and merchant_ID = '"+merchant_ID+"'";
             
                return select.Data(sql, "client_VIP natural join merchant_vip");
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataSet check_discount(string merchant_id, string name, string phone)
        {
            string client_id = "";

            try
            {
                
                string sql = "select client_ID from client where phone_number = '" + phone + "' and name='" + name + "'";
              

                client_id = select.Do(sql).ToString();
                
            }
            catch (Exception ex)
            {
            }

            return check_discountwithID(merchant_id, client_id);
        }

        public DataSet check_merchantgrade(string merchant_ID)
        {
            try
            {
                
                string sql = "select grade, discount from  merchant_vip where merchant_ID = '" + merchant_ID + "'";
              

                return select.Data(sql, "merchant_vip");
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
