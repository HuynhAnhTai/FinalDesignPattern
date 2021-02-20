using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.model
{
    class ReceiveNote
    {
        public ReceiveNote()
        {

        }

        public int id_receive { get; set; }

        public int id_employee { get; set; }

        public String id_product { get; set; }

        public int amount { get; set; }

        public float total_price_receive { get; set; }

        public DateTime date_receive { get; set; }

        public String name_provider { get; set; }

        public String address_provider { get; set; }

        public String phone_number_provider { get; set; }
    }
}
