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
    class DetailBillDao
    {
        private helper.DetailBillHelper detail_helper;
        private static DetailBillDao instance;
        private static readonly object padlock = new object();
        private DatabaseFactory df = new DatabaseMySql();

        private DetailBillDao()
        {
            detail_helper = helper.DetailBillHelper.getInstance();
        }

        //Signleton
        public static DetailBillDao getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new DetailBillDao();
                }
            }
            return instance;
        }

        public DataTable loadData()
        {
            String sql = "select * from DETAILBILL";
            return detail_helper.loadData(sql);
        }

        public DataTable loadDataById(int id)
        {
            String sql = "select * from DETAILBILL where ID_BILL = @id";
            DbParameter param1 = df.createParam("@id", id);

            DbParameter[] parameters = { param1 };
            return detail_helper.loadDataById(sql, parameters);
        }

        //Add new detail bill
        public bool addDetailBill(model.DetailBill detail_bill)
        {
            String sql = "insert into DETAILBILL values(@id, @idProduct, @amount, @price)";

            DbParameter param1 = df.createParam("@id", detail_bill.id_bill);
            DbParameter param2 = df.createParam("@idProduct", detail_bill.id_product);
            DbParameter param3 = df.createParam("@amount", detail_bill.amount);
            DbParameter param4 = df.createParam("@price", detail_bill.price);

            DbParameter[] parameters = { param1, param2, param3, param4 };

            int rows = detail_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }
    }
}
