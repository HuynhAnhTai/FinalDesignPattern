using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.model
{
    class Bill
    {
        public Bill()
        {

        }

        public int id_bill { get; set; }

        public float total_price { get; set; }

        public DateTime invoice_day { get; set; }

        public int id_employee { get; set; }

        public String phone_number_customer { get; set; }

        public int id_envent { get; set; }
    }
}
