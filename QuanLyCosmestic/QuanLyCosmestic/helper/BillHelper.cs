using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using QuanLyCosmestic.database;

namespace QuanLyCosmestic.helper
{
    class BillHelper
    {
        private DbConnection con;
        private DatabaseFactory df = new DatabaseMySql();
        private static BillHelper instance;
        private static readonly object padlock = new object();

        private BillHelper()
        {
            con = df.createConnection();
        }

        //Signleton
        public static BillHelper getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new BillHelper();
                }
            }
            return instance;
        }


        public int insertUpdateDelete(String sql, SqlParameter[] parameters)
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


        public DataTable loadDataFromDateToDate(String sql, SqlParameter[] parameters)
        {
            con.Open();
            int row;
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
                row = 0;
            }

            con.Close();

            return table;
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

    }
}
