using QuanLyCosmestic.ui.templatePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCosmestic.mediatorControlScreen
{
    class CenterMediatorImpl: CenterMediatorControlScreen
    {
        private List<ControlScreen> listControlScreen;
        private static CenterMediatorImpl instance;
        private static readonly object padlock = new object();

        private CenterMediatorImpl()
        {
            listControlScreen = new List<ControlScreen>();
        }

        public static CenterMediatorImpl getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new CenterMediatorImpl();
                }
            }
            return instance;
        }

        public void addControlScreen(ControlScreen cs)
        {
            listControlScreen.Add(cs);
        }

        public void notifyDataChange(TypeDataChange typeUpdate, ControlScreen controlNotify)
        {
            foreach (ControlScreen controlScreen in this.listControlScreen)
            {
               if (controlScreen != controlNotify)
                {
                    controlScreen.dataOfOtherControlChange(typeUpdate);
                }
            }
        }
    }

}
