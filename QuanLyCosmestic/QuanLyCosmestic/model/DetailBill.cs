using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.model
{
    class DetailBill
    {
        public DetailBill()
        {

        }

        public int id_bill { get; set; }

        public String id_product { get; set; }

        public int amount { get; set; }

        public int price { get; set; }
    }
}
