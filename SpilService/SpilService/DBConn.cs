using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SpilService
{
    public class DBConn
    {
        private static SqlConnection conn = null;

        public static SqlConnection GetConn()
        {
           /* if (conn == null)
            {*/
                OpretConn();
            //}
            return conn;
        }
        private static void OpretConn()
        {
            string connstring = "User id =WhistDbAdgang; " + // \\ to get \
                    "Password=Whist; " +
                    "Database=WhistDb;" +
                    //"Server=LAPTOP-4TKUM7H1;" + // Anders
                    //"Server=LAPTOP-OBRE2MJE;" + // Kristine
                    "Server=LAPTOP-Q4Q4J29C;" + // Steen
                    //"Server=DESKTOP-7IFDN7G;" + // Tomas
                    "Connect Timeout=60";
            conn = new SqlConnection(connstring);

        }
    }
}
