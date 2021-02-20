using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCosmestic.ui
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
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

                banHangControl1.BringToFront();
                banHangControl1.Focus();
                banHangControl1.loadData();
                banHangControl1.clear();
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

                quanLySanPhamControl1.BringToFront();
                quanLySanPhamControl1.Focus();
                quanLySanPhamControl1.loadData();

                quanLySanPhamControl1.clear();
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

                quanLyNhanVien1.BringToFront();
                quanLyNhanVien1.Focus();
                quanLyNhanVien1.clear();
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

                lichSuXuatHoaDonControl1.BringToFront();
                lichSuXuatHoaDonControl1.Focus();
                lichSuXuatHoaDonControl1.clear();
                lichSuXuatHoaDonControl1.loadData();
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

                quanLyKhachHangVaSuKienControl1.BringToFront();
                quanLyKhachHangVaSuKienControl1.Focus();
                quanLyKhachHangVaSuKienControl1.clear();
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

                quanLyNhapSanPhamControl1.BringToFront();
                quanLyNhapSanPhamControl1.Focus();
                quanLyNhapSanPhamControl1.loadData();
                quanLyNhapSanPhamControl1.clear();
            }
            else
            {
                MessageBox.Show("Chỉ dành cho quản lý và nhân viên kho ");
                return;
            }
            
        }

        private void bt_dangXuat_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            ui.FormLogin formLogin = new ui.FormLogin();
            formLogin.ShowDialog();
            this.Close();
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

                    quanLySanPhamControl1.BringToFront();
                    quanLySanPhamControl1.Select();
                    quanLySanPhamControl1.Focus();
                    quanLySanPhamControl1.clear();
                    Program.newForm = 1;
                }
                else
                {
                    panel_switch_home.Height = bt_banHang_home.Height;
                    panel_switch_home.Top = bt_banHang_home.Top;

                    banHangControl1.BringToFront();
                    banHangControl1.Select();
                    banHangControl1.Focus();
                    banHangControl1.clear();
                    Program.newForm = 1;
                }
            }
        }
    }
}
