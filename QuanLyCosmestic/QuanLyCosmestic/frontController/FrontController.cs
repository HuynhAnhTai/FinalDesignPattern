using QuanLyCosmestic.dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCosmestic.frontController
{
    class FrontController
    {
        private Dispatcher dispatcher;
        private static readonly object padlock = new object();
        private static FrontController instance;

        private FrontController()
        {
            dispatcher = new Dispatcher();
        }

        //Signleton AccountHelper
        public static FrontController getInstance()
        {
            if (instance == null)
            {
                //lock == synchronized
                lock (padlock)
                {
                    instance = new FrontController();
                }
            }
            return instance;
        }

        public void dispatchRequest(String request, Form formFrom)
        {
           dispatcher.dispatch(request, formFrom);
        }

    }
}
