using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace QuanLyCosmestic.database
{
    //Abstract Factory
    interface DatabaseFactory
    {
        DbConnection createConnection();
        DbCommand createCommand(String sql);
        DbCommand createCommand(String sql, DbConnection cn);
        DbDataAdapter createDataAdapter(DbCommand selectCmd);
        DbParameter createParam(String key, Object value);
        DbDataReader createDataReader(DbCommand cmd);
    }
}
