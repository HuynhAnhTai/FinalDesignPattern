using QuanLyCosmestic.ui.strategyPatternMenu;
using System;
using System.Windows.Forms;

namespace QuanLyCosmestic.ui
{
    public partial class FormHome : Form
    {
        private MenuItemClick menuItemClick;
        private frontController.FrontController frontControl;

        public FormHome()
        {
            InitializeComponent();
            frontControl = frontController.FrontController.getInstance();
            menuItemClick = new MenuItemClickImp();
        }
        
        /*
         - Khi bấm các button thì phải điều kiểm tra role trước rồi mới thay đổi control với các button tương ứng.
        */
        private void bt_banHang_home_Click(object sender, EventArgs e)
        {
            if (Program.currentEmployee.role.Equals("Quản lý") || Program.currentEmployee.role.Equals("Nhân viên bán hàng"))
            {
                panel_switch_home.Height = bt_banHang_home.Height;
                panel_switch_home.Top = bt_banHang_home.Top;
                //template method
                menuItemClick.clickScreen(banHangControl1);
            }
            else
            {
                MessageBox.Show("Chỉ dành cho quản lý và nhân viên bán hàng");
                return;
            }
               
            
        }

        private void bt_quanLySanPham_home_Click(object sender, EventArgs e)
        {
            if (Program.currentEmployee.role.Equals("Quản lý") || Program.currentEmployee.role.Equals("Nhân viên kho"))
            {
                panel_switch_home.Height = bt_quanLySanPham_home.Height;
                panel_switch_home.Top = bt_quanLySanPham_home.Top;
                //template method, strategy pattern 
                menuItemClick.clickScreen(quanLySanPhamControl1);
            }
            else
            {
                MessageBox.Show("Chỉ dành cho quản lý và nhân viên kho");
                return;
            }
        }

        private void bt_quanLyNhanVien_home_Click(object sender, EventArgs e)
        {
            if (Program.currentEmployee.role.Equals("Quản lý"))
            {
                panel_switch_home.Height = bt_quanLyNhanVien_home.Height;
                panel_switch_home.Top = bt_quanLyNhanVien_home.Top;
                //template method, strategy pattern 
                menuItemClick.clickScreen(quanLyNhanVien1);
            }
            else
            {
                MessageBox.Show("Chỉ dành cho quản lý");
                return;
            }
           
        }

        private void bt_lichSuHoaDon_home_Click(object sender, EventArgs e)
        {
            if (Program.currentEmployee.role.Equals("Quản lý"))
            {
                panel_switch_home.Height = bt_lichSuHoaDon_home.Height;
                panel_switch_home.Top = bt_lichSuHoaDon_home.Top;
                //template method, strategy pattern 
                menuItemClick.clickScreen(lichSuXuatHoaDonControl1);
            }
            else
            {
                MessageBox.Show("Chỉ dành cho quản lý");
                return;
            }
        }

        private void bt_quanLyKhachHangVaSuKien_home_Click(object sender, EventArgs e)
        {
            if (Program.currentEmployee.role.Equals("Quản lý") || Program.currentEmployee.role.Equals("Nhân viên bán hàng"))
            {
                panel_switch_home.Height = bt_quanLyKhachHangVaSuKien_home.Height;
                panel_switch_home.Top = bt_quanLyKhachHangVaSuKien_home.Top;
                //template method, strategy pattern 
                menuItemClick.clickScreen(quanLyKhachHangVaSuKienControl1);
            }
            else
            {
                MessageBox.Show("Chỉ dành cho quản lý và nhân viên bán hàng ");
                return;
            }
            
        }

        private void bt_quanLyNhapSanPham_home_Click(object sender, EventArgs e)
        {
            if (Program.currentEmployee.role.Equals("Quản lý") || Program.currentEmployee.role.Equals("Nhân viên kho"))
            {
                panel_switch_home.Height = bt_quanLyNhapSanPham_home.Height;
                panel_switch_home.Top = bt_quanLyNhapSanPham_home.Top;
                //template method, strategy pattern 
                menuItemClick.clickScreen(quanLyNhapSanPhamControl1);
            }
            else
            {
                MessageBox.Show("Chỉ dành cho quản lý và nhân viên kho ");
                return;
            }
            
        }

        private void bt_dangXuat_home_Click(object sender, EventArgs e)
        {
            //front controller
            frontControl.dispatchRequest("LOGIN", this);
        }

        /*
            - Khi truy cập vào formHome thì kiểm tra role của currentEmployee để xuất hiện control đầu tiên cho phù hợp, đồng thời điều chỉnh 
            panel_switch_home đúng button chuyển qua control đó.
        */
        private void FormHome_Activated(object sender, EventArgs e)
        {
            if (Program.newForm == 0)
            {
                if (Program.currentEmployee.role.Equals("Nhân viên kho"))
                {
                    panel_switch_home.Height = bt_quanLySanPham_home.Height;
                    panel_switch_home.Top = bt_quanLySanPham_home.Top;

                    menuItemClick.firstActive(quanLySanPhamControl1);
                    Program.newForm = 1;
                }
                else
                {
                    panel_switch_home.Height = bt_banHang_home.Height;
                    panel_switch_home.Top = bt_banHang_home.Top;

                    menuItemClick.firstActive(banHangControl1);
                    Program.newForm = 1;
                }
            }
        }
    }
}
