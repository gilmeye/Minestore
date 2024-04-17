using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;

namespace _328419122
{
    public class DbService
    {
        public DbService()
        {

        } 



        public static DataTable selectFromDb(string sqlStr)
        {
            OleDbConnection myConnection = new OleDbConnection();
            myConnection.ConnectionString = Connect.GetConnectionString();
            OleDbCommand myCmd = new OleDbCommand(sqlStr, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }


        public static void sqlUdi(string sqlStr)
        {
            OleDbConnection myConnection = new OleDbConnection();
            myConnection.ConnectionString = Connect.GetConnectionString();
            OleDbCommand myCmd = new OleDbCommand(sqlStr, myConnection);
            myConnection.Open();
            myCmd.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}