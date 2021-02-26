using QuanLyCosmestic.ui.strategyPatternMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCosmestic.ui.templatePattern
{
    public abstract class ControlScreen: UserControl
    {
        public ControlScreen()
        {

        }
        public abstract void loadData();
        public abstract void clear();

        public void screenClick()
        {
            this.BringToFront();
            this.Focus();
            loadData();
            clear();
        }

        public void fristActive()
        {
            this.BringToFront();
            this.Select();
            this.Focus();
            clear();
        }
    }
}
