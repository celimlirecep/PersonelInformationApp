using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersonelList.Models.DataLayer
{
    public class DataAccessLayer
    {
        public DataAccessLayer( )
        {

        }
        private string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["PersonelInfoDB"].ConnectionString.ToString(); }
        }

        //public SqlConnection ConnectionDB
        //{
        //    get
        //    {
        //        if (ConnectionDB == null)
        //            ConnectionDB = new SqlConnection(ConnectionString);
        //        return ConnectionDB;
        //    }
        //    set { ConnectionDB = value; }
        //}
        public SqlConnection ConnectionDB { get; set; }
        
        public void ConnectionOpen()
        {
            try
            {
                ConnectionDB = new SqlConnection(ConnectionString);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


            if (ConnectionDB.State == ConnectionState.Closed)//*****************************
            {
                ConnectionDB.Open();
            }
            //if (ConnectionDB!=null)
            //if (ConnectionDB.State == ConnectionState.Closed)
            //    ConnectionDB.Open();
        }
        public void ConnectionClose()
        {
            if (ConnectionDB.State == ConnectionState.Open)
                ConnectionDB.Close();
            ConnectionDB = null;
        }

    }
}