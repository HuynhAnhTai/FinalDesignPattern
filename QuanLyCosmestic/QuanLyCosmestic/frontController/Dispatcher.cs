using QuanLyCosmestic.frontController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCosmestic.dispatcher
{
    class Dispatcher
    {
        private FormFactory formFactory;

        public Dispatcher()
        {
            formFactory = new FormFactory();
        }

        public void dispatch(String request, Form formFrom)
        {
            formFrom.Hide();
            //Factory pattern
            formFactory.getForm(request).ShowDialog();
            formFrom.Close();
        }
    }
}
