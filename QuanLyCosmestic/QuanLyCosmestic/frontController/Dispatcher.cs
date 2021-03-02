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
        private ui.FormLogin formLogin;
        private ui.FormHome formHome;

        public Dispatcher()
        {
            
        }

        public void dispatch(String request, Form formFrom)
        {
            formFrom.Hide();
            if (request.Equals("LOGIN"))
            {
                formLogin = new ui.FormLogin();
                formLogin.ShowDialog();    
            }
            else
            {
                formHome = new ui.FormHome();
                formHome.ShowDialog();
            }
            formFrom.Close();
        }
    }
}
