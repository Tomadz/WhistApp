﻿using System;
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

        internal List<Plus> HentAllePlusser()
        {
            List<Plus> Plusser = new List<Plus>();
            conn.Open();
            string selectSQL = "select * from Plus";
            SqlCommand com = new SqlCommand(selectSQL, conn);
            SqlDataReader myReader = com.ExecuteReader();// NB new method used here
            try
            {   // loop through the ResultSet, one tuple at the time:
                while (myReader.Read()) // first advance the curser to the next tuple.
                {
                    Plusser.Add(new Plus { Id = myReader.GetInt32(0), Navn = myReader.GetString(1) });
                }
            }
            catch { }
            finally
            {
                myReader.Close(); // close nicely the ResultSet
                conn.Close();
            }
            return Plusser;
        }

        internal List<Regelsæt> HentAlleRegler()
        {
            List<Regelsæt> regelsæts = new List<Regelsæt>();
            List<int> ids = new List<int>();
            conn.Open();
            string selectSQL = "select Id from Regelsæt";
            SqlCommand com = new SqlCommand(selectSQL, conn);
            SqlDataReader myReader = com.ExecuteReader();// NB new method used here
            try
            {   // loop through the ResultSet, one tuple at the time:
                while (myReader.Read()) // first advance the curser to the next tuple.
                {
                   ids.Add(myReader.GetInt32(0));
                }
            }
            catch { }
            finally
            {
                myReader.Close(); // close nicely the ResultSet
                conn.Close();
            }
            foreach(int n in ids)
            {
               regelsæts.Add( HentSpecifikkeRegler(n));
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
                    regelsæt.Id = id;
                    regelsæt.Base = Convert.ToDouble(myReader.GetDecimal(0));
                    regelsæt.MultiplyTab = Convert.ToDouble( myReader.GetDecimal(1));
                    regelsæt.BaseVip= Convert.ToDouble(myReader.GetDecimal(2));
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
