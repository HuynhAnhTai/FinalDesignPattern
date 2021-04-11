using QuanLyCosmestic.mementoBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCosmestic.mementoBanHang
{
    class CardCareTaker
    {
        private List<MementoCard> saveCardStorage = new List<MementoCard>();

        public CardCareTaker()
        {

        }

        public void saveMememtoCard(MementoCard item)
        {
            saveCardStorage.Add(item);
        }

        public MementoCard popOutMememtoCard()
        {
            MementoCard mementoCard = new MementoCard(new List<ListViewItem>());
            if (saveCardStorage.Count > 0)
            {
                int lastIndex = saveCardStorage.Count - 1;
                mementoCard = saveCardStorage[lastIndex];
                saveCardStorage.RemoveAt(lastIndex);
            }
            return mementoCard;
        }

        public void clearAllMementoCard()
        {
             saveCardStorage.Clear();
        }
    }
}
