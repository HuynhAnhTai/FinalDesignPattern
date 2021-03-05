using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyCosmestic.database;
using System.Data.Common;

namespace QuanLyCosmestic.dao
{
    class CustomerDao
    {
        private helper.CustomerHelper customer_helper;
        private static CustomerDao instance;
        private static readonly object padlock = new object();
        private DatabaseFactory df = new DatabaseMySql();

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
            DbParameter param1 = df.createParam("@telephone", telephone_number);

            DbParameter[] parameters = { param1 };
            return customer_helper.findCustomer(sql, parameters);
        }

        //Add new Customer
        public bool addCustomer(model.Customer customer)
        {
            String sql = "insert into CUSTOMER values(@phoneNumber, @name, @address)";

            DbParameter param1 = df.createParam("@phoneNumber", customer.phone_customer);
            DbParameter param2 = df.createParam("@name", customer.name_customer);
            DbParameter param3 = df.createParam("@address", customer.address_customer);

            DbParameter[] parameters = { param1, param2, param3 };

            int rows = customer_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //Delete Customer by phone number
        public bool deleteByPhone(String phone_number)
        {
            String sql = "delete from CUSTOMER where PHONE_NUMBER_CUSTOMER like @phoneNumber";

            DbParameter param1 = df.createParam("@phoneNumber", phone_number);
            DbParameter[] parameters = { param1 };

            int rows = customer_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //update customer by telephone
        public bool updateByTelephone(model.Customer customer, String phoneOld)
        {
            String sql = "update CUSTOMER set PHONE_NUMBER_CUSTOMER = @phoneNew, CUSTOMERNAME = @name, "+
                          "CUSTOMER_ADDRESS = @address where PHONE_NUMBER_CUSTOMER like @phoneOld ";

            DbParameter param1 = df.createParam("@phoneNew", customer.phone_customer);
            DbParameter param2 = df.createParam("@name", customer.name_customer);
            DbParameter param3 = df.createParam("@address", customer.address_customer);
            DbParameter param4 = df.createParam("@phoneOld", phoneOld);
            DbParameter[] parameters = { param1, param2, param3, param4 };

            int rows = customer_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

    }
}
