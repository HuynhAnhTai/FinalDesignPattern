using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCosmestic.frontController
{
    class FormFactory
    {
        public FormFactory(){
        
        }

        public Form getForm(String nameForm)
        {
            if(nameForm == "LOGIN")
            {
                return new ui.FormLogin();
            }else if (nameForm == "HOME")
            {
                return new ui.FormHome();
            }
            return null;
        }


    }
}
