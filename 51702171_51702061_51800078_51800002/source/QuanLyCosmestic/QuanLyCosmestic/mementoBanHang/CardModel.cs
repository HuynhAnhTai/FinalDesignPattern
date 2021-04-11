using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCosmestic.mementoBanHang
{
    class CardModel
    {
        public List<ListViewItem> items { get; set; }

        public CardModel(List<ListViewItem> items)
        {
            this.items = items;
        }

        public MementoCard save()
        {
            return new MementoCard(items);
        }

        public void undo(MementoCard mem)
        {
            this.items = mem.items;
        }
    }
}
