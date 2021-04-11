using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.model
{
    class WorkShift
    {
        public WorkShift()
        {

        }

        public String id_shift { get; set; }

        public TimeSpan from_time { get; set; }

        public String to_time { get; set; }
    }
}
