﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RundeService
{
    public class MainDbConnection
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
                    "Server=DESKTOP-7IFDN7G;" + // not localhost
                    "Connect Timeout=60";
            conn = new SqlConnection(connstring);
        }
    }
}