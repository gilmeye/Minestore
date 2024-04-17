using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace _328419122
{
    public class CommentService
    {

        public static void AddComment(string name, string mail, string type, string date, string content)
        {
            string st = string.Format(@"INSERT INTO tblComments(UserName, Email, Type, CommentDate, Content) 
            Values('{0}', '{1}', '{2}', #{3}#, '{4}');", name, mail, type, date, content);
            DbService.sqlUdi(st);
        }

        public static DataTable ShowComments() 
        {
            string st = @"SELECT * FROM tblComments";
            DataTable dt = DbService.selectFromDb(st);
            return dt;
        }

        public static DataTable ShowCommentsByUser(string name)
        {
            string st = string.Format(@"SELECT * FROM tblComments WHERE tblComments.UserName = '{0}'", name);
            DataTable dt = DbService.selectFromDb(st);
            return dt;
        }

        public static DataTable ShowCommentsByDate(string date)
        {
            string st = string.Format(@"SELECT * FROM tblComments WHERE tblComments.CommentDate = #{0}#", date);
            DataTable dt = DbService.selectFromDb(st);
            return dt;
        }

        public static DataTable ShowCommentsByType(string type)
        {
            string st = string.Format(@"SELECT * FROM tblComments WHERE tblComments.Type = '{0}'", type);
            DataTable dt = DbService.selectFromDb(st);
            return dt;
        }






    }



    
}