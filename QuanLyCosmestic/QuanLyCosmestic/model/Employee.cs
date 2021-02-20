using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.model
{
    class Employee
    {

        public Employee()
        {

        }

        public int id_employee { get; set; }

        public String user_name { get; set; }

        public String name_employee { get; set; }

        public String gender { get; set; }

        public DateTime birth { get; set; }

        public String id_number{ get; set; }

        public String address { get; set; }

        public String phone_number { get; set; }

        public String email { get; set; }

        public DateTime begin_day { get; set; }

        public String role { get; set; }

        public String id_shift { get; set; }

        public float salary { get; set; }

    }
}
