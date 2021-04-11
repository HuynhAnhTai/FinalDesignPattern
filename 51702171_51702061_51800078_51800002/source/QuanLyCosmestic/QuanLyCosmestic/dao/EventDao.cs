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
    class EventDao
    {
        private helper.EventHelper event_helper;
        private static EventDao instance;
        private static readonly object padlock = new object();
        private DatabaseFactory df = new DatabaseMySql();

        private EventDao()
        {
            event_helper = helper.EventHelper.getInstance();
        }

        //Signleton
        public static EventDao getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new EventDao();
                }
            }
            return instance;
        }

        public DataTable loadData()
        {
            String sql = "select * from DISCOUNT_EVENT";
            return event_helper.loadData(sql);
        }

        public DataTable loadDataById(int id)
        {
            String sql = "select * from DISCOUNT_EVENT where ID_EVENT = @id";
            DbParameter param1 = df.createParam("@id", id);

            DbParameter[] parameters = { param1 };

            return event_helper.loadDataFromId(sql, parameters);
        }

        //Add new Event
        public bool addEvent(model.DiscountEvent dis_event)
        {
            String sql = "insert into DISCOUNT_EVENT values(@nameEvent, @discount)";

            DbParameter param1 = df.createParam("@nameEvent", dis_event.name_event);
            DbParameter param2 = df.createParam("@discount", dis_event.discount);

            DbParameter[] parameters = { param1, param2 };

            int rows = event_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //update event by id
        public bool updateByTelephone(model.DiscountEvent dis_event, int id_old)
        {
            String sql = "update DISCOUNT_EVENT set NAME_EVENT = @nameEvent, DISCOUNT = @discount " +
                          "where ID_EVENT = @idOld ";

            DbParameter param1 = df.createParam("@nameEvent", dis_event.name_event);
            DbParameter param2 = df.createParam("@discount", dis_event.discount);
            DbParameter param3 = df.createParam("@idOld", id_old);
            DbParameter[] parameters = { param1, param2, param3};

            int rows = event_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }

        //Delete event by id
        public bool deleteById(int id)
        {
            String sql = "delete from DISCOUNT_EVENT where ID_EVENT = @idOld";

            DbParameter param1 = df.createParam("@idOld", id);
            DbParameter[] parameters = { param1 };

            int rows = event_helper.insertUpdateDelete(sql, parameters);

            return rows == 1;
        }
    }
}
