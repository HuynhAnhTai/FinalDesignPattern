using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.model
{
    class DiscountEvent
    {
        public DiscountEvent()
        {

        }

        public int id_event { get; set; }

        public String name_event { get; set; }

        public int discount { get; set; }
    }
}
