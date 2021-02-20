using System;
using System.Data.SqlClient;

namespace QuanLyCosmestic.database
{
    //Abstract Factory
    interface DatabaseFactory
    {
        SqlConnection createConnectionSql();
        SqlCommand createCommand(String sql);
    }
}
