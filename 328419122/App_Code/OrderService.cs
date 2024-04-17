using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace _328419122
{
    public class OrderService
    {


        public static void InsertIntoOrders(string date, int userID) 
        {
            string stsql;
            stsql = string.Format(@"INSERT INTO tblOrders(OrderDate, userID) VALUES (#{0}#, {1})", date, userID);
            DbService.sqlUdi(stsql);
        }


        public static int GetMaxOrderId() 
        {
            string stsql;
            stsql = (@"SELECT Max(tblOrders.OrderID) FROM tblOrders");
            DataTable dt = DbService.selectFromDb(stsql);
            return int.Parse(dt.Rows[0][0].ToString());
        }


        public static void InsertIntoOrderDetails(int id, int kamut) 
        {
            int OrderId = GetMaxOrderId();
            string stsql;
            stsql = string.Format(@"INSERT INTO tblOrderDetails(OrderID, ProductID, kamut) VALUES ({0},{1},{2})", OrderId, id, kamut);
            DbService.sqlUdi(stsql);
        }



        public static void DeleteAllSal() 
        {
            string stsql;
            stsql = string.Format(@"DELETE tblSal.* FROM tblSal");
            DbService.sqlUdi(stsql);
        }


    }
}