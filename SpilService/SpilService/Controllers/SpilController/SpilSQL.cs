using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SpilService.Models;

namespace SpilService.Controllers.SpilController
{
    public class SpilSQL
    {
        private SqlConnection conn = null;
        public SpilSQL()
        {
            conn = DBConn.GetConn();
        }


        public int OpretSpil(Ven[] spillere, Regelsæt regler)
        {
            int spilId;

            conn.Open();

            spilId = OpretSpilIDb(regler);
            InsertSpillereISpil(spillere, spilId);

            conn.Close();

            return spilId;
        }

        private int OpretSpilIDb(Regelsæt regler)
        {
            
            SqlCommand cmd = new SqlCommand();

            cmd = new SqlCommand("INSERT INTO Spil " +
                "Values (" + regler.Id + "); SELECT SCOPE_IDENTITY();", conn);

            int spilId = Convert.ToInt32(cmd.ExecuteScalar());

            return spilId;
        }

        private void InsertSpillereISpil(Ven[] spillere, int spilId)
        {
            SqlCommand cmd = new SqlCommand();

            foreach (Ven spiller in spillere)
            {
                cmd = new SqlCommand("INSERT INTO SpilBruger " +
                    "Values (" + spilId + "," + spiller.Id + ")", conn);
                
                cmd.ExecuteNonQuery();
            }
        }
    }
}
