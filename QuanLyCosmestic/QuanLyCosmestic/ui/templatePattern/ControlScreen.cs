
using QuanLyCosmestic.mediatorControlScreen;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuanLyCosmestic.ui.templatePattern
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<ControlScreen,UserControl>))]
    public abstract class ControlScreen: UserControl
    {
        private CenterMediatorControlScreen centerMediator;
        public ControlScreen()
        {
            centerMediator = CenterMediatorImpl.getInstance();
            centerMediator.addControlScreen(this);
        }
        public abstract void loadData();
        public abstract void clear();
        public abstract void dataOfOtherControlChange(TypeDataChange typeUpdate);
        

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

        public void dataChange(TypeDataChange typeDataChange)
        {
            centerMediator.notifyDataChange(typeDataChange, this);
        }
    }
}
