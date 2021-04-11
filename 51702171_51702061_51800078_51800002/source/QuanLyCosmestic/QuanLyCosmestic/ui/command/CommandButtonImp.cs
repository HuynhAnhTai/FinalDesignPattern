using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCosmestic.ui.command
{
    class CommandButtonImp: CommandButtonManagement
    {
        private Button btnAdd, btnRefresh, btnDel, btnUpdate;
        private DataGridView tableItem;
        public CommandButtonImp(Button btnAdd, Button btnRefresh, Button btnDel, Button btnUpdate, DataGridView tableItem)
        {
            this.btnAdd = btnAdd;
            this.btnRefresh = btnRefresh;
            this.btnDel = btnDel;
            this.btnUpdate = btnUpdate;
            this.tableItem = tableItem;
        }

        public override void adjustItem()
        {
            btnAdd.Enabled = false;
            btnRefresh.Enabled = true;
            btnDel.Enabled = true;
            btnUpdate.Enabled = true;
        }

        public override void notAdjustItem()
        {
            btnAdd.Enabled = true;
            btnRefresh.Enabled = false;
            btnDel.Enabled = false;
            btnUpdate.Enabled = false;
            tableItem.ClearSelection();
        }
    }
}
