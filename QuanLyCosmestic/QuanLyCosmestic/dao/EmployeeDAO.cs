using System;
using System.Collections.Generic;
using System.Data;
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

            SqlParameter param1 = new SqlParameter("@userName", employee.user_name);
            SqlParameter param2 = new SqlParameter("@nameEmployee", employee.name_employee);
            SqlParameter param3 = new SqlParameter("@gender", employee.gender);
            SqlParameter param4 = new SqlParameter("@birth", employee.birth);
            SqlParameter param5 = new SqlParameter("@idNumber", employee.id_number);
            SqlParameter param6 = new SqlParameter("@address", employee.address);
            SqlParameter param7 = new SqlParameter("@phone", employee.phone_number);
            SqlParameter param8 = new SqlParameter("@email", employee.email);
            SqlParameter param9 = new SqlParameter("@begin", employee.begin_day);
            SqlParameter param10 = new SqlParameter("@role", employee.role);
            SqlParameter param11 = new SqlParameter("@shift", employee.id_shift);
            SqlParameter param12 = new SqlParameter("@salary", employee.salary);

            SqlParameter[] parameters = { param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12 };

            int rows = employee_helper.insertUpdateDelete(sql, parameters);

            return rows == 1 ;
        }

        //delete employee by id
        public bool deleteById(int id)
        {
            String sql = "delete from EMPLOYEE where ID_EMPLOYEE = @id";

            SqlParameter param1 = new SqlParameter("@id", id);
            SqlParameter[] parameters = { param1 };

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

            SqlParameter param1 = new SqlParameter("@userName", employee.user_name);
            SqlParameter param2 = new SqlParameter("@nameEmployee", employee.name_employee);
            SqlParameter param3 = new SqlParameter("@gender", employee.gender);
            SqlParameter param4 = new SqlParameter("@birth", employee.birth);
            SqlParameter param5 = new SqlParameter("@idNumber", employee.id_number);
            SqlParameter param6 = new SqlParameter("@address", employee.address);
            SqlParameter param7 = new SqlParameter("@phone", employee.phone_number);
            SqlParameter param8 = new SqlParameter("@email", employee.email);
            SqlParameter param9 = new SqlParameter("@begin", employee.begin_day);
            SqlParameter param10 = new SqlParameter("@role", employee.role);
            SqlParameter param11 = new SqlParameter("@shift", employee.id_shift);
            SqlParameter param12 = new SqlParameter("@salary", employee.salary);
            SqlParameter param13 = new SqlParameter("@id", employee.id_employee);

            SqlParameter[] parameters = { param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13 };

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
