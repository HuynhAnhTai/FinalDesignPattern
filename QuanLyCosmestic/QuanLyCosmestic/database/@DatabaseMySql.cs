using System;
using System.Data.SqlClient;

namespace QuanLyCosmestic.database
{
    //abstract factory
    class DatabaseMySql : DatabaseFactory
    {
        private static readonly object padlock = new object();
        private SqlConnection con;


        //Signleton
        public SqlConnection createConnectionSql()
        {
            if (con == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    con = new SqlConnection(@"Data Source=DESKTOP-JRNC7GN\SQLEXPRESS;Initial Catalog=QLCOSMESTIC;Integrated Security=True");
                }
            }
            return con;
        }

        public SqlCommand createCommand(string sql)
        {
            return new SqlCommand(sql, con);
        }
    }
}
