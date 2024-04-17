using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace _328419122
{
    public class ProductService
    {
        public ProductService()
        {

        }

        public static DataTable SelectFromProducts()
        {
            string st;
            DataTable dt;
            st = @"SELECT tblProducts.ProductID,
                tblProducts.ProductName,tblProducts.Category,
                tblProducts.Price, tblproducts.Stock
                FROM tblProducts Order By tblProducts.ProductID";
            dt = DbService.selectFromDb(st);
            return dt;
        }



        public static bool IsInStock(int pID, int salNum)
        {
            string st;
            DataTable dt;
            st = string.Format(@" SELECT tblProducts.Stock FROM tblProducts WHERE tblProducts.ProductID = {0};", pID);
            dt = DbService.selectFromDb(st);
            int stock = int.Parse(dt.Rows[0][0].ToString());
            return stock >= salNum;
                
        }


        public static void LowerStock(int id, int num) 
        {
            string st = string.Format(@"update tblProducts set tblProducts.Stock = tblProducts.Stock - {0} WHERE tblProducts.ProductID = {1}", num, id);
            DbService.sqlUdi(st);
        }


    }
}