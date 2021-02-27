using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyCosmestic.database;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace QuanLyCosmestic.helper
{
    class CategoryHelper
    {
        private DbConnection con;
        private DatabaseFactory df = new DatabaseMySql();
        public CategoryHelper()
        {
            con = df.createConnection();
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
