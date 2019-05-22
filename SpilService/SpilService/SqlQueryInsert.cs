using SpilService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SpilService
{
    public class SqlQueryInsert
    {
        private SqlConnection conn = null;
        public SqlQueryInsert()
        {
            conn = DBConn.GetConn();
        }

        public void RunderInsert(Runde item)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("INSERT INTO Runder " +
                "Values (" + item.SpilId + "," + item.RundeNr + "," + item.Melder + "," + item.Melding + "," +
                item.PlusId + "," + item.Makker + "," + item.Vundet + "," + item.Beløb + "," +
                item.Spiller1 + "," + item.Spiller2 + "," + item.Spiller3 + "," + item.Spiller4 + ")", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void RunderDelete(Runde item)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("delete Runder where SpilId = "+item.SpilId+" and RundeNr = "+item.RundeNr+" ", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
