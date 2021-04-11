using QuanLyCosmestic.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.dao
{
    class EmployeeDAO
    {
        private helper.EmployeeHelper employee_helper;
        private static EmployeeDAO instance;
        private static readonly object padlock = new object();
        private DatabaseFactory df = new DatabaseMySql();

        private EmployeeDAO()
        {
            employee_helper = helper.EmployeeHelper.getInstance();
        }

        //Signleton
        public static EmployeeDAO getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new EmployeeDAO();
                }
            }
            return instance;
        }

        //add new employee to table employee
        public bool addEmployee(model.Employee employee)
        {
            String sql = "insert into EMPLOYEE values(@userName, @nameEmployee, @gender, @birth, @idNumber, @address, @phone, @email, @begin, @role, @shift, @salary)";

            DbParameter param1 = df.createParam("@userName", employee.user_name);
            DbParameter param2 = df.createParam("@nameEmployee", employee.name_employee);
            DbParameter param3 = df.createParam("@gender", employee.gender);
            DbParameter param4 = df.createParam("@birth", employee.birth);
            DbParameter param5 = df.createParam("@idNumber", employee.id_number);
            DbParameter param6 = df.createParam("@address", employee.address);
            DbParameter param7 = df.createParam("@phone", employee.phone_number);
            DbParameter param8 = df.createParam("@email", employee.email);
            DbParameter param9 = df.createParam("@begin", employee.begin_day);
            DbParameter param10 = df.createParam("@role", employee.role);
            DbParameter param11 = df.createParam("@shift", employee.id_shift);
            DbParameter param12 = df.createParam("@salary", employee.salary);

            DbParameter[] parameters = { param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12 };

            int rows = employee_helper.insertUpdateDelete(sql, parameters);

            return rows == 1 ;
        }

        //delete employee by id
        public bool deleteById(int id)
        {
            String sql = "delete from EMPLOYEE where ID_EMPLOYEE = @id";

            DbParameter param1 = df.createParam("@id", id);
            DbParameter[] parameters = { param1 };

            int rows = employee_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //update employee by id
        public bool updateByUserName(model.Employee employee)
        {
            String sql = "update EMPLOYEE set USERNAME = @userName ,NAME_EMPLOYEE = @nameEmployee ,GENDER = @gender ,BIRTH =  @birth"+
                                               ",ID_NUMBER = @idNumber ,EMPLOYEE_ADDRESS = @address ,PHONE_NUMBER = @phone ,"+
                                               "EMAIL = @email ,BEGIN_DAY = @begin ,NAME_ROLE = @role ,ID_SHIFT = @shift ,SALARY = @salary"+
                                               " where ID_EMPLOYEE = @id";

            DbParameter param1 = df.createParam("@userName", employee.user_name);
            DbParameter param2 = df.createParam("@nameEmployee", employee.name_employee);
            DbParameter param3 = df.createParam("@gender", employee.gender);
            DbParameter param4 = df.createParam("@birth", employee.birth);
            DbParameter param5 = df.createParam("@idNumber", employee.id_number);
            DbParameter param6 = df.createParam("@address", employee.address);
            DbParameter param7 = df.createParam("@phone", employee.phone_number);
            DbParameter param8 = df.createParam("@email", employee.email);
            DbParameter param9 = df.createParam("@begin", employee.begin_day);
            DbParameter param10 = df.createParam("@role", employee.role);
            DbParameter param11 = df.createParam("@shift", employee.id_shift);
            DbParameter param12 = df.createParam("@salary", employee.salary);
            DbParameter param13 = df.createParam("@id", employee.id_employee);

            DbParameter[] parameters = { param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13 };

            int rows = employee_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }


        public DataTable loadData()
        {
            String sql = "select * from EMPLOYEE";
            return employee_helper.loadData(sql);
        }
    }
}
