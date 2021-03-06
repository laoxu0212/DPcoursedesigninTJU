﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using System.Windows.Forms;
namespace Datebass
{
    class Stall
    {
        Doselect select = Doselect.instance;
        Doexecute execute = Doexecute.instance;

        //摊位标号
        public string stall_id;
        //摊位所属商家
        public string merchant_id;
        //管理摊位的员工编号
        public string staff_id;
        //摊位面积
        public string area;
        //租用摊位的开始时间
        public string start_time;
        //租用摊位的到期时间
        public string end_time;
        //租用金额
        public string rent_money;
        //标价
        public string price;


        //按stall_id显示摊位信息
        public bool showStall(string stallID)
        {
            try
            {
                string merchantID = "select merchant_id from stall where stall_id='" + stallID + "'";
                string staffID = "select staff_id from stall where stall_id='" + stallID + "'";
                string Area = "select area from stall where stall_id='" + stallID + "'";
                string startTime = "select to_char(start_time,'yyyy-mm-dd') from stall where stall_id='" + stallID + "'";
                string endTime = "select to_char(end_time,'yyyy-mm-dd') from stall where stall_id='" + stallID + "'";
                string rentMoney = "select rent_money from stall where stall_id='" + stallID + "'";
                string Price = "select price from stall natural join quotation where stall_id='" + stallID + "'";
               
                this.staff_id = select.Do(staffID).ToString();
                this.area = select.Do(Area).ToString();
                this.start_time = select.Do(startTime).ToString();
                this.end_time = select.Do(endTime).ToString();
                this.rent_money = select.Do(rentMoney).ToString();
                this.price = select.Do(Price).ToString();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //修改摊位信息
        public bool updateStall(string stallID, string merchantID, string staffID, string Area, string startTime, string endTime, string rentMoney)
        {
            try
            {
                string sqlmerchant = "update stall set merchant_id = '" + merchantID + "' where  stall_id = '" + stallID + "'";
                string sqlstaff = "update stall set staff_id = '" + staffID + "' where  stall_id = '" + stallID + "'";
                string sqlarea = "update stall set area = '" + Area + "' where  stall_id = '" + stallID + "'";
                string sqlstart_time = "update stall set start_time = to_date('" + startTime + "','yyyy-mm-dd') where  stall_id = '" + stallID + "'";
                string sqlend_time = "update stall set end_time = to_date('" + endTime + "','yyyy-mm-dd') where  stall_id = '" + stallID + "'";
                string sqlrentMoney = "update stall set rent_money = '" + rentMoney + "' where  stall_id = '" + stallID + "'";
               
                execute.Do(sqlmerchant);
                execute.Do(sqlstaff);
                execute.Do(sqlarea);
                execute.Do(sqlstart_time);
                execute.Do(sqlend_time);
                execute.Do(sqlrentMoney);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //显示全部摊位信息
        public DataSet selectStall()
        {
            try
            {
               
                string sql = "select * from stall,quotation where stall.area= quotation.area";
               
                return select.Data(sql, "stall,quotation");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //按stall_id查询
        public DataSet selectStallwithStall_id(string stallID)
        {
            try
            {
               
                string sql = "select * from stall where stall_id = '" + stallID + "'";
               
                return select.Data(sql, "stall");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        //通过merchan_id查询
        public DataSet selectStallwithMerchant_id(string merchantID)
        {
            try
            {
               
                string sql = "select * from stall where merchant_id = '" + merchantID + "'";
              
                return select.Data(sql, "stall");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        //按staff_id查找
        public DataSet selectStallwithStaff_id(string staffID)
        {
            try
            {
                
                string sql = "select * from stall where staff_id = '" + staffID + "'";
               
                return select.Data(sql, "stall");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //按面积查找
        public DataSet selectStallwithArea(string Area)
        {
            try
            {
                
                string sql = "select * from stall where area = '" + Area + "'";
                
                return select.Data(sql, "stall");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //按标价查找
        public DataSet selectStallwithPrice(string minPrice, string maxPrice)
        {
            try
            {
                
                string sql = "select * from stall,quotation where stall.area= quotation.area and price between '" + minPrice + "'and'" + maxPrice + "'";
               
                return select.Data(sql, "stall,quotation");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //按开始时间查找
        public DataSet selectStallwithStart_time(string minStart_time, string maxStart_time)
        {
            try
            {
               
                string sql = "select * from stall where start_time between to_date('" + minStart_time + "','yyyy-mm-dd')and to_date('" + maxStart_time + "','yyyy-mm-dd')";
                
                return select.Data(sql, "stall");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入正确的开始时间");
                return null;
            }
        }

        //按结束时间查找
        public DataSet selectStallwithEnd_time(string minEnd_time, string maxEnd_time)
        {
            try
            {
               
                string sql = "select * from stall where end_time between to_date('" + minEnd_time + "','yyyy-mm-dd')and to_date('" + maxEnd_time + "','yyyy-mm-dd')";
              
                return select.Data(sql, "stall");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入正确结束的时间");
                return null;
            }
        }
        //更改摊位面积价格
        public bool updateQuotation(string Area, string Price)
        {
            try
            {
               
                string sql = "update quotation set price ='" + Price + "'where area = '" + Area + "'";
               
                object i = execute.Do(sql);
                if (i == null)
                {
                    return false;
                }
                else
                    return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        //查询摊位标价
        public DataSet selectQuotation()
        {
            try
            {
               
                string sql = "select * from quotation";
               
                return select.Data(sql, "quotation");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        //判断摊位是否存在
        public bool stallexist(string stallID)
        {
           
            string sqlStallID = "select * from stall where stall_id='" + stallID + "'";
           
            if (select.Do(sqlStallID) == null)
            {
                //con.Close();
                return false;
            }
            else
            {
                //con.Close();
                return true;
            }
        }

        //判断摊位面积是否存在
        public bool areaexist(string Area)
        {
           
            string sqlarea = "select * from quotation where area='" + Area + "'";
          
            if (select.Do(sqlarea) == null)
            {
                //con.Close();
                return false;
            }
            else
            {
                //con.Close();
                return true;
            }
        }
        public bool staffexist(string staff_id)//检查员工id是否存在
        {
            
            string sql = "select * from staff where staff_id='" + staff_id + "'";
           
            if (select.Do(sql) == null)
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
