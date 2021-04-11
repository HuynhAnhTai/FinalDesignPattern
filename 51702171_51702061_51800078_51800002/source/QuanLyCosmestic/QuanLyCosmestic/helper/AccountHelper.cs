using QuanLyCosmestic.database;
using System;
using System.Data.Common;
using System.Data.SqlClient;
namespace QuanLyCosmestic.helper
{
   
    class AccountHelper
    {
        private DbConnection con;
        private static AccountHelper instance;
        private DatabaseFactory df = new DatabaseMySql();
        private static readonly object padlock = new object();

        private AccountHelper()
        {
            //abstract factory
            con = df.createConnection();
        }

        //Signleton AccountHelper
        public static AccountHelper getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new AccountHelper();
                }
            }
            return instance;
        }

        //excute cmd check Account and return to AccountDAO
        public Boolean checkAccountExistDB(String sql, DbParameter[] parameters)
        {
            con.Open();

            //abstract factory
            DbCommand cmd = df.createCommand(sql);
            cmd.Parameters.AddRange(parameters);

            int totalRows = 0;
            totalRows = Convert.ToInt32(cmd.ExecuteScalar());

            if (totalRows > 0)
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        //get information of user access to windows form
        public void selectCurrentUser(String sql, DbParameter parameter)
        {
            con.Open();
            //abstract factory
            DbCommand cmd2 = df.createCommand(sql);
            
            cmd2.Parameters.Add(parameter);

            using (DbDataReader oReader = df.createDataReader(cmd2))
            {
                while (oReader.Read())
                {
                    Program.currentEmployee.id_employee = int.Parse(oReader["ID_EMPLOYEE"].ToString());
                    Program.currentEmployee.user_name = oReader["USERNAME"].ToString();
                    Program.currentEmployee.name_employee = oReader["NAME_EMPLOYEE"].ToString();
                    Program.currentEmployee.gender = oReader["GENDER"].ToString();
                    Program.currentEmployee.birth = Convert.ToDateTime(oReader["BIRTH"].ToString());
                    Program.currentEmployee.id_number = oReader["ID_NUMBER"].ToString();
                    Program.currentEmployee.address = oReader["EMPLOYEE_ADDRESS"].ToString();
                    Program.currentEmployee.phone_number = oReader["PHONE_NUMBER"].ToString();
                    Program.currentEmployee.email = oReader["EMAIL"].ToString();
                    Program.currentEmployee.begin_day = Convert.ToDateTime(oReader["BEGIN_DAY"].ToString());
                    Program.currentEmployee.role = oReader["NAME_ROLE"].ToString();
                    Program.currentEmployee.id_shift = oReader["ID_SHIFT"].ToString();
                    Program.currentEmployee.salary = float.Parse(oReader["SALARY"].ToString());
                }

            }
            con.Close();
        }

        //get Password database by userName
        public String getPasswordDB(String sql, DbParameter parameter)
        {
            con.Open();
            //abstract factory
            DbCommand cmd2 = df.createCommand(sql);

            cmd2.Parameters.Add(parameter);
            
            using (DbDataReader oReader = df.createDataReader(cmd2))
            {
                while (oReader.Read())
                {
                    String password = oReader["PASSWORD"].ToString();
                    con.Close();
                    return password;
                }

            }
            con.Close();
            return "Không có";
        }


        public int insertUpdateDelete(String sql, DbParameter[] parameters)
        {
            con.Open();
            int rows;
            try
            {
                //abstract factory
                DbCommand cmd = df.createCommand(sql);
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
    }
}
