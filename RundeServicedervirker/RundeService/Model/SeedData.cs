using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RundeService.Model;
using RundeService.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace RundeService.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RundeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RundeContext>>()))
            {
                // Look for any movies.
                if (context.Runder.Any())
                {
                    return;   // DB has been seeded
                }

                List<Runde> RundeListe = GetMasterDbRunder();
                foreach (Runde ru in RundeListe)
                {
                    context.Runder.AddRange(
                    new Runde
                    {
                        Id = ru.Id,
                        SpilId = ru.SpilId,
                        RundeNr = ru.RundeNr,
                        Melder = ru.Melder,
                        Melding = ru.Melding,
                        PlusId = ru.PlusId,
                        Makker = ru.Makker,
                        Vundet = ru.Vundet,
                        Beløb = ru.Beløb,
                        Spiller1 = ru.Spiller1,
                        Spiller2 = ru.Spiller2,
                        Spiller3 = ru.Spiller3,
                        Spiller4 = ru.Spiller4
                    }
                );
                }

                context.SaveChanges();
            }
        }
        private static List<Runde> GetMasterDbRunder()
        {
            List<Runde> RundeListe = new List<Runde>();

            SqlConnection conn = MainDbConnection.GetConn();

            conn.Open();

            string selectSQL = "SELECT * FROM Runder;";
            SqlCommand com = new SqlCommand(selectSQL, conn);
            SqlDataReader myReader = com.ExecuteReader();// NB new method used here
            try
            {   // loop through the ResultSet, one tuple at the time:
                while (myReader.Read()) // first advance the curser to the next tuple.
                {
                    Runde r = new Runde();
                    r.Id = myReader.GetInt32(0);
                    r.SpilId = myReader.GetInt32(1);
                    r.RundeNr = myReader.GetInt32(2);
                    r.Melder = myReader.GetInt32(3);
                    r.Melding = myReader.GetInt32(4);
                    r.PlusId = myReader.GetInt32(5);
                    r.Makker = myReader.GetInt32(6);
                    r.Vundet = myReader.GetBoolean(7);
                    r.Beløb = Convert.ToDouble(myReader.GetDecimal(8));
                    r.Spiller1 = myReader.GetInt32(9);
                    r.Spiller2 = myReader.GetInt32(10);
                    r.Spiller3 = myReader.GetInt32(11);
                    r.Spiller4 = myReader.GetInt32(12);

                    RundeListe.Add(r);
                }
            }
            finally
            {
                myReader.Close(); // close nicely the ResultSet
            }

            return RundeListe;
        }
    }
}