using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.dao
{
    class EventDao
    {
        private helper.EventHelper event_helper;

        public EventDao()
        {
            event_helper = new helper.EventHelper();
        }

        public DataTable loadData()
        {
            String sql = "select * from DISCOUNT_EVENT";
            return event_helper.loadData(sql);
        }

        public DataTable loadDataById(int id)
        {
            String sql = "select * from DISCOUNT_EVENT where ID_EVENT = @id";
            SqlParameter param1 = new SqlParameter("@id", id);

            SqlParameter[] parameters = { param1 };

            return event_helper.loadDataFromId(sql, parameters);
        }

        //Add new Event
        public bool addEvent(model.DiscountEvent dis_event)
        {
            String sql = "insert into DISCOUNT_EVENT values(@nameEvent, @discount)";

            SqlParameter param1 = new SqlParameter("@nameEvent", dis_event.name_event);
            SqlParameter param2 = new SqlParameter("@discount", dis_event.discount);

            SqlParameter[] parameters = { param1, param2 };

            int rows = event_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //update event by id
        public bool updateByTelephone(model.DiscountEvent dis_event, int id_old)
        {
            String sql = "update DISCOUNT_EVENT set NAME_EVENT = @nameEvent, DISCOUNT = @discount " +
                          "where ID_EVENT = @idOld ";

            SqlParameter param1 = new SqlParameter("@nameEvent", dis_event.name_event);
            SqlParameter param2 = new SqlParameter("@discount", dis_event.discount);
            SqlParameter param3 = new SqlParameter("@idOld", id_old);
            SqlParameter[] parameters = { param1, param2, param3};

            int rows = event_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //Delete event by id
        public bool deleteById(int id)
        {
            String sql = "delete from DISCOUNT_EVENT where ID_EVENT = @idOld";

            SqlParameter param1 = new SqlParameter("@idOld", id);
            SqlParameter[] parameters = { param1 };

            int rows = event_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }
    }
}
