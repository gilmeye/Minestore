using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace _328419122
{
    public class AdminService
    {


        public static DataTable ShowProducts()
        {
            string st;
            DataTable dt;
            st = @"SELECT tblProducts.ProductID, tblProducts.ProductName, tblCategory.CategoryName, tblProducts.Price, tblProducts.Stock
                    FROM tblCategory INNER JOIN tblProducts ON tblCategory.CategoryID = tblProducts.Category;";
            dt = DbService.selectFromDb(st);
            return dt;
        }


        public static void AddUser(string uname, string pass, string fname, string lname, string email)
        {
            string stsql;

            stsql = string.Format(@"INSERT INTO tblUsers(UserName, UserPassword, FirstName, LastName, Email) 
            VALUES ('{0}','{1}','{2}','{3}','{4}')", uname, pass, fname, lname, email);
            DbService.sqlUdi(stsql);
        }


        public static void AddProduct(string name, int category, int price, int stock)
        {
            string stsql;

            stsql = string.Format(@"INSERT INTO tblProducts(ProductName, Category, Price, Stock) 
            VALUES ('{0}',{1}, {2}, {3})", name, category, price, stock);
            DbService.sqlUdi(stsql);
        }

        public static int SelectCategoryID(string name)
        {
            string stsql;
            DataTable dt;
            stsql = string.Format(@"SELECT tblCategory.CategoryID FROM tblCategory 
            WHERE tblCategory.CategoryName = '{0}'", name);
            dt = DbService.selectFromDb(stsql);
            int cat = int.Parse(dt.Rows[0][0].ToString());
            return cat;
        }

        public static DataTable ShowOrders()
        {
            string st;
            DataTable dt;
            st = @"SELECT tblUsers.UserName, tblOrders.OrderID
                   FROM tblUsers INNER JOIN tblOrders ON tblUsers.UserID = tblOrders.UserID;";
            dt = DbService.selectFromDb(st);
            return dt;
        }


        public static DataTable ShowOrdersByUsers()
        {
            string st;
            DataTable dt;
            st = @"SELECT tblUsers.UserName, tblOrders.OrderID
                 FROM tblUsers INNER JOIN tblOrders ON tblUsers.UserID = tblOrders.UserID ORDER BY tblUsers.UserName;";
            dt = DbService.selectFromDb(st);
            return dt;
        }

        public static DataTable ShowOrdersByOrderID()
        {
            string st;
            DataTable dt;
            st = @"SELECT tblOrders.OrderID, tblProducts.ProductName, tblOrderDetails.Kamut, tblProducts.Price*tblOrderDetails.Kamut AS TotalPrice
                 FROM tblProducts INNER JOIN (tblOrders INNER JOIN tblOrderDetails ON tblOrders.OrderID = tblOrderDetails.OrderID) 
                 ON tblProducts.ProductID = tblOrderDetails.ProductID
                 ORDER BY tblOrders.OrderID;";
            dt = DbService.selectFromDb(st);
            return dt;

        }


        public static void DeleteUser(int id)
        {
            string st = string.Format(@"DELETE * FROM tblUsers WHERE tblUsers.UserID = {0}", id);
            DbService.sqlUdi(st);
        }

        public static void DeleteProduct(int id)
        {
            string st = string.Format(@"DELETE * FROM tblProducts WHERE tblProducts.ProductID = {0}", id);
            DbService.sqlUdi(st);
        }


        public static void UpdateProduct(int id, int price, int stock, string name) 
        {
            string st = string.Format(@"update tblProducts set tblProducts.Price = {0}, tblProducts.Stock = {1}, 
            tblProducts.ProductName = '{2}' WHERE tblProducts.ProductID = {3}", price, stock, name, id);
            DbService.sqlUdi(st);
        }

        public static void UpdateUser(int id, string uname, string pass, string fname, string lname, string email, bool isAdmin)
        {
            string st = string.Format(@"update tblUsers set tblUsers.UserName = '{0}', tblUsers.UserPassword = '{1}',
            tblUsers.FirstName = '{2}', tblUsers.LastName = '{3}', tblUsers.Email = '{4}', tblUsers.IsAdmin = {5} 
            WHERE tblUsers.UserID = {6}", uname, pass, fname, lname, email, isAdmin, id);
            DbService.sqlUdi(st);
        }


        public static DataTable ShowOrdersByOrderID(int id)
        {
            string st;
            DataTable dt;
            st = string.Format(@"SELECT tblOrders.OrderID, tblUsers.UserID, tblUsers.UserName, tblUsers.FirstName, tblUsers.LastName, 
            tblUsers.Email, tblProducts.ProductID, tblProducts.ProductName, tblProducts.Price, tblOrderDetails.Kamut, 
            tblProducts.Price*tblOrderDetails.Kamut AS TotalPrice FROM tblProducts INNER JOIN (tblUsers INNER JOIN 
            (tblOrders INNER JOIN tblOrderDetails ON tblOrders.OrderID = tblOrderDetails.OrderID) ON tblUsers.UserID = tblOrders.UserID) ON 
            tblProducts.ProductID = tblOrderDetails.ProductID WHERE tblOrders.OrderID = {0}
            GROUP BY tblOrders.OrderID, tblUsers.UserID, tblUsers.UserName, tblUsers.FirstName, tblUsers.LastName, tblUsers.Email, 
            tblProducts.ProductID, tblProducts.ProductName, tblProducts.Price, tblOrderDetails.Kamut;", id);
            dt = DbService.selectFromDb(st);
            return dt;
        }

        public static DataTable ShowOrdersByUser(string uname)
        {
            string st;
            DataTable dt;
            st = string.Format(@"SELECT tblUsers.UserName, tblUsers.UserID AS User_ID, tblOrders.OrderID AS Order_ID, Sum(tblOrderDetails.Kamut) AS Amount_Of_Products,
            Sum(tblProducts.Price*tblOrderDetails.Kamut) AS Total_Price
            FROM tblProducts INNER JOIN ((tblUsers INNER JOIN tblOrders ON tblUsers.UserID = tblOrders.UserID) INNER JOIN tblOrderDetails ON tblOrders.OrderID = tblOrderDetails.OrderID)
            ON tblProducts.ProductID = tblOrderDetails.ProductID WHERE tblUsers.UserName = '{0}'
            GROUP BY tblUsers.UserName, tblUsers.UserID, tblOrders.OrderID;", uname);
            dt = DbService.selectFromDb(st);
            return dt;
        }


        public static DataTable ShowUsers()
        {
            string st;
            DataTable dt;
            st = @"SELECT * FROM tblUsers;";
            dt = DbService.selectFromDb(st);
            return dt;
        }

        public static DataTable ShowInfoByMonth(int month)
        {
            string st = string.Format(@"SELECT Sum(tblOrderDetails.Kamut) AS Amount_Of_Products,
            Sum(tblProducts.Price*tblOrderDetails.Kamut) AS Total_Price
            FROM tblProducts INNER JOIN ((tblUsers INNER JOIN tblOrders ON tblUsers.UserID = tblOrders.UserID) 
            INNER JOIN tblOrderDetails ON tblOrders.OrderID = tblOrderDetails.OrderID)
            ON tblProducts.ProductID = tblOrderDetails.ProductID WHERE MONTH(tblOrders.OrderDate) = {0}
            GROUP BY tblUsers.UserName, tblUsers.UserID;", month);
            DataTable dt = DbService.selectFromDb(st);  
            return dt;
        }

        public static DataTable ProductAmount(int month) 
        {
            string st;
            DataTable dt;
            st = string.Format(@"SELECT tblProducts.ProductName, Sum(tblOrderDetails.Kamut)
            FROM tblProducts INNER JOIN (tblOrders INNER JOIN tblOrderDetails ON tblOrders.OrderID = tblOrderDetails.OrderID) 
            ON tblProducts.ProductID = tblOrderDetails.ProductID WHERE MONTH(tblOrders.OrderDate) = {0} 
            GROUP by tblProducts.ProductName;", month);
            dt = DbService.selectFromDb(st);
            return dt;
        }

        public static DataTable UsersWhoOrdered()
        {
            string st;
            st = @"SELECT tblUsers.UserName FROM tblUsers Where tblUsers.UserID IN(Select tblOrders.UserID From tblOrders)";
            DataTable dt = DbService.selectFromDb(st);
            return dt;
        }


    }
}