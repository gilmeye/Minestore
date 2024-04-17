using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace _328419122
{
    public class SalService
    {
        public SalService() 
        {
        
        
        }


        public static void InsertIntoSal(int id, string name, int num, int price) 
            {
                string stsql, stsql1, stsql2;
                stsql1 = string.Format(@"select tblSal.num, tblSal.ProductID, tblSal.ProductName from tblSal WHERE tblSal.ProductId={0}", id);
                DataTable dt = DbService.selectFromDb(stsql1);
                if (dt.Rows.Count == 0)
                {
                    stsql = String.Format(@"insert into tblSal (ProductID, ProductName, num, Price) values ({0}, '{1}', {2}, {3})", id, name, num, price);
                    DbService.sqlUdi(stsql);
                }
                else 
                {
                    stsql2 = String.Format(@"update tblSal set tblSal.num = tblSal.num+{0} where tblSal.ProductID = {1}", num, id);
                    DbService.sqlUdi(stsql2);
                }
            }

        public static DataTable SelectFromSal() 
        {
            string st;
            DataTable dt;
            st = @"SELECT tblSal.ProductID as ID, tblSal.ProductName as Name, tblSal.Price, tblSal.num as Amount FROM tblSal;";
            dt = DbService.selectFromDb(st);
            return dt;
        }


        public static int SelectKamutByID(int id)
        {
            string st;
            DataTable dt;
            st = string.Format(@"SELECT tblSal.num FROM tblSal WHERE tblSal.ProductID = {0};", id);
            dt = DbService.selectFromDb(st);
            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            int kamut = int.Parse(dt.Rows[0][0].ToString());
            return kamut;
        }



        public static void UpdateInSal(int id, int kamut)
        {
            string stsql = String.Format(@"update tblSal set tblSal.num = {0} where tblSal.ProductID = {1}", kamut, id);
            DbService.sqlUdi(stsql);
        }


        public static void DeleteFromSal(int id) 
        {
            string st = string.Format(@"DELETE * FROM tblSal WHERE tblSal.ProductID = {0}", id);
            DbService.sqlUdi(st);
        }






    }

    
}