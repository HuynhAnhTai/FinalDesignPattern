using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.model
{
    class Product
    {
        public Product()
        {

        }

        public String id_product { get; set; }

        public String name_product { get; set; }

        public String specification { get; set; }

        public int amount { get; set; }

        public int price { get; set; }

        public int id_category { get; set; }
    }
}
