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
            if (conn == null)
            {
                OpretConn();
            }
            return conn;
        }
        private static void OpretConn()
        {
            string connstring = "User id =WhistDbAdgang; " + // \\ to get \
                    "Password=Whist; " +
                    "Database=WhistDb;" +
                    "Server=LAPTOP-OBRE2MJE;" + // not localhost
                    "Connect Timeout=60";
            conn = new SqlConnection(connstring);

        }
    }
}
