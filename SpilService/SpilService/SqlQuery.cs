using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SpilService.Models;

namespace SpilService
{
    public class SqlQuery
    {
        private SqlConnection conn = null;
        public SqlQuery()
        {
            conn = DBConn.GetConn();
        }
        public List<Ven> HentVenner(int id)
        {
            conn.Open();
            List<Ven> venner = new List<Ven>();
            string selectSQL = "Select Id, Fornavn, Efternavn from Bruger "+
                                "where (Bruger.Id in (Select AcceptId from Venner where AnsøgId = '"+id+"' and Godkendt = '1'))"+
                                " or(Bruger.Id in (Select AnsøgId from Venner where AcceptId = '"+id+"' and Godkendt = '1'))";
            SqlCommand com = new SqlCommand(selectSQL, conn);
            SqlDataReader myReader = com.ExecuteReader();// NB new method used here
            try
            {   // loop through the ResultSet, one tuple at the time:
                while (myReader.Read()) // first advance the curser to the next tuple.
                {
                    Ven ven = new Ven();
                    ven.Id = myReader.GetInt32(0);
                    ven.Fornavn = myReader.GetString(1);
                    ven.Efternavn = myReader.GetString(2);
                    venner.Add(ven);
                }
            }
            catch { }
            finally
            {
                myReader.Close(); // close nicely the ResultSet
                conn.Close();
            }
            return venner;

        }

        internal List<Regelsæt> HentAlleRegler()
        {
            List<Regelsæt> regelsæts = new List<Regelsæt>();
            conn.Open();
            string selectSQL = "select Id from Regelsæt";
            SqlCommand com = new SqlCommand(selectSQL, conn);
            SqlDataReader myReader = com.ExecuteReader();// NB new method used here
            try
            {   // loop through the ResultSet, one tuple at the time:
                while (myReader.Read()) // first advance the curser to the next tuple.
                {
                    regelsæts.Add(HentSpecifikkeRegler(myReader.GetInt32(0)));
                }
            }
            catch { }
            finally
            {
                myReader.Close(); // close nicely the ResultSet
                conn.Close();
            }


            return regelsæts;
        }

        public List<Ven> HentVennerSpecifikSpil(int id)
        {
                conn.Open();
            
            List<Ven> venner = new List<Ven>();
            string selectSQL = "Select Id, Fornavn, Efternavn from Bruger " +
                                "where Id in(Select BrugerId from SpilBruger where SpilId ='" + id + "')";
            SqlCommand com = new SqlCommand(selectSQL, conn);
            SqlDataReader myReader = com.ExecuteReader();// NB new method used here
            try
            {   // loop through the ResultSet, one tuple at the time:
                while (myReader.Read()) // first advance the curser to the next tuple.
                {
                    Ven ven = new Ven();
                    ven.Id = myReader.GetInt32(0);
                    ven.Fornavn = myReader.GetString(1);
                    ven.Efternavn = myReader.GetString(2);
                    venner.Add(ven);
                }
            }
            catch { }
            finally
            {
                myReader.Close(); // close nicely the ResultSet
                conn.Close();
            }
            return venner;

        }

        public Regelsæt HentSpecifikkeRegler(int id)
        {

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            Regelsæt regelsæt = new Regelsæt();

            string selectSQL = "select Base,MultiplyTab,BaseVip from Regelsæt where Id = "+id+" ";
            SqlCommand com = new SqlCommand(selectSQL, conn);
            SqlDataReader myReader = com.ExecuteReader();// NB new method used here
            try
            {   // loop through the ResultSet, one tuple at the time:
                while (myReader.Read()) // first advance the curser to the next tuple.
                {
                    regelsæt.Base = myReader.GetInt32(0);
                    regelsæt.MultiplyTab = myReader.GetDouble(1);
                    regelsæt.BaseVip=myReader.GetDouble(2);
                }
            }
            catch { }
            finally
            {
                myReader.Close(); // close nicely the ResultSet
                conn.Close();
            }
            regelsæt.Pluser = HentSpecifikkePlusser(id);
            return regelsæt;

        }
        private List<Plus> HentSpecifikkePlusser(int id)
        {
            conn.Open();
            List<Plus> plusser = new List<Plus>();

            string selectSQL = "select * from Plus where Id in (select PlusId from RegelsætPlus where RegelId = "+id+") ";
            SqlCommand com = new SqlCommand(selectSQL, conn);
            SqlDataReader myReader = com.ExecuteReader();// NB new method used here
            try
            {   // loop through the ResultSet, one tuple at the time:
                while (myReader.Read()) // first advance the curser to the next tuple.
                {
                    Plus plus = new Plus();
                    plus.Id = myReader.GetInt32(0);
                    plus.Navn = myReader.GetString(1);
                    plusser.Add(plus);
                }
            }
            catch { }
            finally
            {
                myReader.Close(); // close nicely the ResultSet
                conn.Close();
            }
            return plusser;

        }


    }
}
