using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCosmestic.database;

namespace QuanLyCosmestic.helper
{
    class BillHelper
    {
        private SqlConnection con;
        private DatabaseMySql dataMySql = new DatabaseMySql();
        public BillHelper()
        {
            con = dataMySql.createConnectionSql();
        }


        public int insertUpdateDelete(String sql, SqlParameter[] parameters)
        {
            con.Open();
            int rows;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
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
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddRange(parameters);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

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
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

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
