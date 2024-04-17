using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Xml.Linq;

namespace _328419122
{
    public class UserService
    {


        public static bool DoesExist(string name, string pass) 
        {
            string st;
            st = string.Format(@"SELECT tblUsers.UserPassword FROM tblUsers WHERE tblUsers.UserName = '{0}'", name);
            DataTable dt = DbService.selectFromDb(st);
            if(dt.Rows.Count == 0)
            {
                return false;
            }
            string p = dt.Rows[0][0].ToString();
            return p.Equals(pass);


        }


        public static void Register(string uname, string pass, string fname, string lname, string email) 
        {
            string stsql;
            stsql = string.Format(@"INSERT INTO tblUsers(UserName, UserPassword, FirstName, LastName, Email) 
            VALUES ('{0}','{1}','{2}','{3}','{4}')", uname, pass, fname, lname, email);
            DbService.sqlUdi(stsql);
        }


        public static bool IsAdmin(string name)
        {
            string st;
            st = string.Format(@"SELECT tblUsers.IsAdmin FROM tblUsers WHERE tblUsers.UserName = '{0}'", name);
            DataTable dt = DbService.selectFromDb(st);
            string p = dt.Rows[0][0].ToString();
            return p.Equals("True");
        }


        public static int SelectIDbyName(string name)
        {
            string st;
            st = string.Format(@"SELECT tblUsers.UserID FROM tblUsers WHERE tblUsers.UserName = '{0}'", name);
            DataTable dt = DbService.selectFromDb(st);
            int id = int.Parse(dt.Rows[0][0].ToString());
            return id;
        }





        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }


        public static DataTable SelectUserByID(int id) 
        {
            string st;
            DataTable dt;
            st = string.Format(@"SELECT tblUsers.UserName, tblUsers.UserPassword, tblUsers.FirstName,
            tblUsers.LastName, tblUsers.Email FROM tblUsers WHERE tblUsers.UserID = {0};", id);
            dt = DbService.selectFromDb(st);
            return dt;
        }

        public static void UpdateUserInfo(int id, string uname, string pass, string fname, string lname, string mail)
        {
            string st = string.Format(@"Update tblUsers SET tblUsers.UserName = '{0}', tblUsers.UserPassword = '{1}', tblUsers.FirstName = '{2}',
            tblUsers.LastName = '{3}', tblUsers.Email = '{4}' WHERE tblUsers.UserID = {5}", uname, pass, fname, lname, mail, id);
            DbService.sqlUdi(st);

        }


    }
}