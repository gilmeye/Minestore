using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _328419122
{
    public class Connect
    {
        const String FileName = "Database32.accdb";
        public static string GetConnectionString()
        {
            string location = HttpContext.Current.Server.MapPath("~/App_Data/" + FileName);
            string connectionString = "provider=Microsoft.ACE.OleDb.12.0;data source=" + location;
            return connectionString;
        }
        public Connect()
        {
            
        }
    }
}