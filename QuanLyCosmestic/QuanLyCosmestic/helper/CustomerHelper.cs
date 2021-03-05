using System;
using System.Data.SqlClient;
using QuanLyCosmestic.database;
using System.Data;
using System.Data.Common;

namespace QuanLyCosmestic.helper
{   
    class CustomerHelper
    {
        private DbConnection con;
        private DatabaseFactory df = new DatabaseMySql();
        private static CustomerHelper instance;
        private static readonly object padlock = new object();

        private CustomerHelper()
        {
            con = df.createConnection();
        }

        //Signleton
        public static CustomerHelper getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new CustomerHelper();
                }
            }
            return instance;
        }


        public int insertUpdateDelete(String sql, DbParameter[] parameters)
        {
            con.Open();
            int rows;
            try
            {
                DbCommand cmd = df.createCommand(sql, con);
                cmd.Parameters.AddRange(parameters);
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                rows = 0;
            }

            con.Close();

            return rows;
        }

        public DataTable loadData(String sql)
        {
            con.Open();
            DataTable table = new DataTable();
            try
            {
                DbCommand cmd = df.createCommand(sql, con);
                DbDataAdapter adapter = df.createDataAdapter(cmd);

                adapter.Fill(table);
            }
            catch (Exception ex)
            {
            }

            con.Close();

            return table;
        }

        public DataTable findCustomer(String sql, DbParameter[] parameters)
        {
            con.Open();
            DataTable table = new DataTable();
            try
            {
                DbCommand cmd = df.createCommand(sql, con);
                cmd.Parameters.AddRange(parameters);
                DbDataAdapter adapter = df.createDataAdapter(cmd);

                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                int row = 0;
            }

            con.Close();

            return table;
        }
    }
}
