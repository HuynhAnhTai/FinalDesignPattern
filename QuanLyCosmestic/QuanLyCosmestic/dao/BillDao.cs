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
    class BillDao
    {
        private helper.BillHelper bill_helper;
        private static BillDao instance;
        private DatabaseFactory df = new DatabaseMySql();
        private static readonly object padlock = new object();

        private BillDao()
        {
            bill_helper = helper.BillHelper.getInstance();
        }

        //Signleton
        public static BillDao getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new BillDao();
                }
            }
            return instance;
        }

        public DataTable loadData()
        {
            String sql = "select * from BILL";
            return bill_helper.loadData(sql);
        }

        public DataTable loadDataFromDateToDate(DateTime start, DateTime end)
        {
            String sql = "select * from BILL where INVOICE_DAY between @start and @end";
            DbParameter param1 = df.createParam("@start", start.Date);
            DbParameter param2 = df.createParam("@end", end.Date);

            DbParameter[] parameters = { param1, param2 };
            return bill_helper.loadDataFromDateToDate(sql, parameters);
        }

        //Add new Bill
        public bool addBill(model.Bill bill)
        {
            String sql = "insert into BILL values(@totalPrice, @invoiceDay, @idEmployee, @phoneNumber, @idEvent)";

            DbParameter param1 = df.createParam("@totalPrice", bill.total_price);
            DbParameter param2 = df.createParam("@invoiceDay", bill.invoice_day);
            DbParameter param3 = df.createParam("@idEmployee", bill.id_employee);
            DbParameter param4 = df.createParam("@phoneNumber", bill.phone_number_customer);
            DbParameter param5 = df.createParam("@idEvent", bill.id_envent);

            DbParameter[] parameters = { param1, param2, param3, param4, param5 };

            int rows = bill_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        public int getMaxID()
        {
            String sql = "select MAX(ID_BILL) as MAX_NUMBER from BILL";
            DataTable dt = bill_helper.loadData(sql);
            int max = int.Parse(dt.Rows[0]["MAX_NUMBER"].ToString());
            return max;
        }
    }
}
