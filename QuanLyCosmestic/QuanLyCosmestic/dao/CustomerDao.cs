using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyCosmestic.dao
{
    class CustomerDao
    {
        private helper.CustomerHelper customer_helper;
        private static CustomerDao instance;
        private static readonly object padlock = new object();

        private CustomerDao()
        {
            customer_helper = helper.CustomerHelper.getInstance();
        }

        //Signleton
        public static CustomerDao getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new CustomerDao();
                }
            }
            return instance;
        }

        public DataTable loadData()
        {
            String sql = "select * from CUSTOMER";
            return customer_helper.loadData(sql);
        }

        public DataTable findCustomerByTelephone(String telephone_number)
        {
            String sql = "select * from CUSTOMER where PHONE_NUMBER_CUSTOMER like @telephone";
            SqlParameter param1 = new SqlParameter("@telephone", telephone_number);

            SqlParameter[] parameters = { param1 };
            return customer_helper.findCustomer(sql, parameters);
        }

        //Add new Customer
        public bool addCustomer(model.Customer customer)
        {
            String sql = "insert into CUSTOMER values(@phoneNumber, @name, @address)";

            SqlParameter param1 = new SqlParameter("@phoneNumber", customer.phone_customer);
            SqlParameter param2 = new SqlParameter("@name", customer.name_customer);
            SqlParameter param3 = new SqlParameter("@address", customer.address_customer);

            SqlParameter[] parameters = { param1, param2, param3 };

            int rows = customer_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //Delete Customer by phone number
        public bool deleteByPhone(String phone_number)
        {
            String sql = "delete from CUSTOMER where PHONE_NUMBER_CUSTOMER like @phoneNumber";

            SqlParameter param1 = new SqlParameter("@phoneNumber", phone_number);
            SqlParameter[] parameters = { param1 };

            int rows = customer_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //update customer by telephone
        public bool updateByTelephone(model.Customer customer, String phoneOld)
        {
            String sql = "update CUSTOMER set PHONE_NUMBER_CUSTOMER = @phoneNew, CUSTOMERNAME = @name, "+
                          "CUSTOMER_ADDRESS = @address where PHONE_NUMBER_CUSTOMER like @phoneOld ";

            SqlParameter param1 = new SqlParameter("@phoneNew", customer.phone_customer);
            SqlParameter param2 = new SqlParameter("@name", customer.name_customer);
            SqlParameter param3 = new SqlParameter("@address", customer.address_customer);
            SqlParameter param4 = new SqlParameter("@phoneOld", phoneOld);
            SqlParameter[] parameters = { param1, param2, param3, param4 };

            int rows = customer_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

    }
}
