using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.dao
{
    class ReceiveNoteDao
    {
        private helper.ReceiveNoteHelper receive_note_helper;
        private static ReceiveNoteDao instance;
        private static readonly object padlock = new object();

        private ReceiveNoteDao()
        {
            receive_note_helper = helper.ReceiveNoteHelper.getInstance();
        }

        //Signleton
        public static ReceiveNoteDao getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new ReceiveNoteDao();
                }
            }
            return instance;
        }

        public DataTable loadData()
        {
            String sql = "select * from RECEIVEDNOTE";
            return receive_note_helper.loadData(sql);
        }

        //Add new receive note
        public bool addReceiveNote(model.ReceiveNote receive_note)
        {
            String sql = "insert into RECEIVEDNOTE values(@idEmployee, @idProduct, @amount, @price, @date, @nameProvider, @address, @phone)";

            SqlParameter param1 = new SqlParameter("@idEmployee", receive_note.id_employee);
            SqlParameter param2 = new SqlParameter("@idProduct", receive_note.id_product);
            SqlParameter param3 = new SqlParameter("@amount", receive_note.amount);
            SqlParameter param4 = new SqlParameter("@price", receive_note.total_price_receive);
            SqlParameter param5 = new SqlParameter("@date", receive_note.date_receive);
            SqlParameter param6 = new SqlParameter("@nameProvider", receive_note.name_provider);
            SqlParameter param7 = new SqlParameter("@address", receive_note.address_provider);
            SqlParameter param8 = new SqlParameter("@phone", receive_note.phone_number_provider);

            SqlParameter[] parameters = { param1, param2, param3, param4, param5, param6, param7, param8 };

            int rows = receive_note_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //update receive note by id receive note
        public bool updateById(model.ReceiveNote receive_note, int id)
        {
            String sql = "update RECEIVEDNOTE set ID_EMPLOYEE = @idEmployee, ID_PRODUCT = @idProduct, AMOUNT = @amount " +
                          ",TOTAL_PRICE_RECEIVE = @price, DATE_RECIVE = @date, NAME_PROVIDER = @nameProvider, PROVIDER_ADDRESS = @address,"+
                          "PHONE_NUMBER_PROVIDER = @phone where ID_RECEIVE like @id ";

            SqlParameter param1 = new SqlParameter("@idEmployee", receive_note.id_employee);
            SqlParameter param2 = new SqlParameter("@idProduct", receive_note.id_product);
            SqlParameter param3 = new SqlParameter("@amount", receive_note.amount);
            SqlParameter param4 = new SqlParameter("@price", receive_note.total_price_receive);
            SqlParameter param5 = new SqlParameter("@date", receive_note.date_receive);
            SqlParameter param6 = new SqlParameter("@nameProvider", receive_note.name_provider);
            SqlParameter param7 = new SqlParameter("@address", receive_note.address_provider);
            SqlParameter param8 = new SqlParameter("@phone", receive_note.phone_number_provider);
            SqlParameter param9 = new SqlParameter("@id", id);

            SqlParameter[] parameters = { param1, param2, param3, param4, param5, param6, param7, param8, param9 };

            int rows = receive_note_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //Delete Product by id
        public bool deleteById(int id)
        {
            String sql = "delete from RECEIVEDNOTE where ID_RECEIVE = @id";

            SqlParameter param1 = new SqlParameter("@id", id);
            SqlParameter[] parameters = { param1 };

            int rows = receive_note_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }
    }
}
