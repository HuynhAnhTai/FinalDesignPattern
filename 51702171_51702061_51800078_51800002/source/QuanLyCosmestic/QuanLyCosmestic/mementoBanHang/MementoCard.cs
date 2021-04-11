using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCosmestic.mementoBanHang
{
    class MementoCard
    {
        public List<ListViewItem> items { get; set; }

        public MementoCard(List<ListViewItem> items)
        {
            this.items = items;
        }
    }
}
