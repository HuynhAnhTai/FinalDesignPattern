using QuanLyCosmestic.ui.templatePattern;
using System;
using System.Windows.Forms;

namespace QuanLyCosmestic.ui
{
    public partial class QuanLyNhanVien : ControlScreen
    {
        private dao.AccountDAO account_dao;
        private dao.EmployeeDAO employee_dao;

        private int id;
        private String user_name;

        public QuanLyNhanVien()
        {
            account_dao = dao.AccountDAO.getInstance();
            employee_dao = dao.EmployeeDAO.getInstance();

            InitializeComponent();
        }

        /*
         - Xóa các lựa chọn ở dtg_nhanVien
         */
        public override void clear()
        {
            dtg_nhanVien_quanLyNhanVienControl.ClearSelection();
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            cb_caLam_quanLyNhanVienControl.SelectedIndex = 0;
            cb_chucVu_quanLyNhanVienControl.SelectedIndex = 0;
            rb_gioiTinh_nam_quanLyNhanVienControl.Checked = true;

            dtg_nhanVien_quanLyNhanVienControl.ClearSelection();
            loadData();
            setEditingMode(false);

        }

        /*
        - Đổ dữ liệu nhân viên vào dtg_khachHang qua class EmployeeDao
        */
        public override void loadData()
        {
            dtg_nhanVien_quanLyNhanVienControl.DataSource = employee_dao.loadData();
            dtg_nhanVien_quanLyNhanVienControl.Columns[0].HeaderText = "Mã nhân viên";
            dtg_nhanVien_quanLyNhanVienControl.Columns[1].HeaderText = "User Name";
            dtg_nhanVien_quanLyNhanVienControl.Columns[2].HeaderText = "Tên nhân viên";
            dtg_nhanVien_quanLyNhanVienControl.Columns[3].HeaderText = "Giới tính";
            dtg_nhanVien_quanLyNhanVienControl.Columns[4].HeaderText = "Ngày sinh";
            dtg_nhanVien_quanLyNhanVienControl.Columns[5].HeaderText = "CMND";
            dtg_nhanVien_quanLyNhanVienControl.Columns[6].HeaderText = "Địa chỉ";
            dtg_nhanVien_quanLyNhanVienControl.Columns[7].HeaderText = "Số điện thoại";
            dtg_nhanVien_quanLyNhanVienControl.Columns[8].HeaderText = "Email";
            dtg_nhanVien_quanLyNhanVienControl.Columns[9].HeaderText = "Ngày bắt đầu làm việc";
            dtg_nhanVien_quanLyNhanVienControl.Columns[10].HeaderText = "Vai trò";
            dtg_nhanVien_quanLyNhanVienControl.Columns[11].HeaderText = "Mã ca làm";
            dtg_nhanVien_quanLyNhanVienControl.Columns[12].HeaderText = "Lương";
            dtg_nhanVien_quanLyNhanVienControl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }
        
        /*
        - Set các trạng thái cho các button và dtg_nhanVien
        */
        private void setEditingMode(bool enable)
        {
            bt_themNhanVien_quanLyNhanVienControl.Enabled = !enable;
            bt_refresh_quanLyNhanVienControl.Enabled = enable;
            bt_xoaNhanVien_quanLyNhanVienControl.Enabled = enable;
            bt_capNhatNhanVien_quanLyNhanVienControl.Enabled = enable;
            if (!enable)
            {
                dtg_nhanVien_quanLyNhanVienControl.ClearSelection();
            }
            
        }

        /*
         - Khi bấm chọn trên dtg_nhanVien thì sẽ lấy dữ liệu của dòng đó và đổ dữ liệu vào các textBox, radionButton tương ứng
         */
        private void dtg_nhanVien_quanLyNhanVienControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0 || index >= dtg_nhanVien_quanLyNhanVienControl.RowCount)
            {
                return;
            }

            DataGridViewRow row = dtg_nhanVien_quanLyNhanVienControl.Rows[index];

            id = int.Parse(row.Cells[0].Value.ToString());
            user_name = Convert.ToString(row.Cells[1].Value);

            tb_userName_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[1].Value);
            tb_hoTen_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[2].Value);

            String male = Convert.ToString(row.Cells[3].Value);
            if (male.Equals("Nam"))
            {
                rb_gioiTinh_nam_quanLyNhanVienControl.Checked = true;
                rb_gioiTinh_nu_quanLyNhanVienControl.Checked = false;
            }
            else
            {
                rb_gioiTinh_nam_quanLyNhanVienControl.Checked = false;
                rb_gioiTinh_nu_quanLyNhanVienControl.Checked = true;
            }

            dtp_ngaySinh_quanLyNhanVienControl.Value = Convert.ToDateTime(row.Cells[4].Value);
            tb_cmnd_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[5].Value);
            tb_diaChi_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[6].Value);
            tb_sdt_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[7].Value);
            tb_email_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[8].Value);
            dtp_ngayVaoLam_quanLyNhanVienControl.Value = Convert.ToDateTime(row.Cells[9].Value);
            cb_chucVu_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[10].Value);
            cb_caLam_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[11].Value);
            tb_luong_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[12].Value);
            tb_password_quanLyNhanVienControl.Text = account_dao.getPassword(Convert.ToString(row.Cells[1].Value));

            setEditingMode(true);
        }

        /*
         - Khi thêm một nhân viên thì phải check mọi thông tin đủ chưa nếu chưa thì xuất ra MessageBox
         - Ngược lại thì bắt đầu thêm tài khoản nhân viên bằng methodAddAccount() nếu hoàn tất thì sẽ thêm nhân viên bằng method addEmployee()
         - Nếu thất bại thì xuất ra MessageBox
         */
        private void bt_themNhanVien_quanLyNhanVienControl_Click(object sender, EventArgs e)
        {
            if (!checkInfo())
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
            else
            {
                if (addAccount())
                {
                    if (addEmployee())
                    {
                        MessageBox.Show("Thêm nhân viên thành công");
                        dtg_nhanVien_quanLyNhanVienControl.ClearSelection();
                        loadData();
                        bt_refresh_quanLyNhanVienControl_Click(null, null);
                        setEditingMode(false);

                        return;
                    }
                    else
                    {
                        if (deleteAccountByUserName())
                        {
                            MessageBox.Show("Thêm nhân viên không thành công");
                        }

                        return;
                    }
                }
                else
                {
                    MessageBox.Show("User Name đã tồn tại");
                    return;
                }
            }
        }
        
        /*
         - Lấy thông tin tài khoản nhân viên và thêm tài khoản nhân viên bằng class AccountDao
         */
        public bool addAccount()
        {
            model.Account account = new model.Account();

            user_name = tb_userName_quanLyNhanVienControl.Text;

            account.user_name = tb_userName_quanLyNhanVienControl.Text;
            account.password = tb_password_quanLyNhanVienControl.Text;

            return account_dao.addAccount(account);
        }

        /*
         - Lấy thông tin nhân viên và thêm nhân viên bằng class EmployeeDao
         */
        public bool addEmployee()
        {
            model.Employee employee = new model.Employee();

            employee.user_name = tb_userName_quanLyNhanVienControl.Text;
            employee.name_employee = tb_hoTen_quanLyNhanVienControl.Text;

            if (rb_gioiTinh_nam_quanLyNhanVienControl.Checked)
            {
                employee.gender = "Nam";
            }
            else
            {
                employee.gender = "Nữ";

            }

            employee.birth = dtp_ngaySinh_quanLyNhanVienControl.Value;
            employee.id_number = tb_cmnd_quanLyNhanVienControl.Text;
            employee.address = tb_diaChi_quanLyNhanVienControl.Text;
            employee.phone_number = tb_sdt_quanLyNhanVienControl.Text;
            employee.email = tb_email_quanLyNhanVienControl.Text;
            employee.begin_day = dtp_ngayVaoLam_quanLyNhanVienControl.Value;
            employee.role = cb_chucVu_quanLyNhanVienControl.SelectedItem.ToString();
            employee.id_shift = cb_caLam_quanLyNhanVienControl.SelectedItem.ToString();
            employee.salary = float.Parse(tb_luong_quanLyNhanVienControl.Text);

            return employee_dao.addEmployee(employee);
        }

        /*
         - Trước khi xóa nhân viên thì phải kiểm tra coi trên dtg_nhanVien có select dòng nào hay chưa nếu chưa thì sẽ xuất ra MessageBox
         - Ngược lại sẽ lấy dữ liệu id của dòng đó và thực hiện method deleteEmployeeById()
         - Nếu thất bại thì xuất ra MessageBox
         */
        private void bt_xoaNhanVien_quanLyNhanVienControl_Click(object sender, EventArgs e)
        {
            if (dtg_nhanVien_quanLyNhanVienControl.SelectedCells.Count == 0)
            {
                MessageBox.Show("Hãy chọn nhân viên");
                return;
            }
            int index = dtg_nhanVien_quanLyNhanVienControl.SelectedCells[0].RowIndex;
            if (index < 0 || index >= dtg_nhanVien_quanLyNhanVienControl.RowCount)
            {
                MessageBox.Show("Hãy chọn nhân viên");
                return;
            }

            DataGridViewRow row = dtg_nhanVien_quanLyNhanVienControl.Rows[index];
            id = int.Parse(row.Cells[0].Value.ToString());
            user_name = row.Cells[1].Value.ToString();

            if (deleteEmployeeById())
            {
                dtg_nhanVien_quanLyNhanVienControl.ClearSelection();
                loadData();
                bt_refresh_quanLyNhanVienControl_Click(null, null);
                setEditingMode(false);

                MessageBox.Show("Xóa nhân viên thành công");

                return;
            }
            else
            {
                MessageBox.Show("Xóa không thành công");
            }
        }

        /*
         - Xóa nhân viên bằng id nhân viên qua Class EmployeeDao nếu hoàn tất thì thực hiện method deleteAccountByUserName()
         */
        private Boolean deleteEmployeeById()
        {
            if (employee_dao.deleteById(id))
            {
                if (deleteAccountByUserName())
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }

        /*
         - Xóa tài khoản nhân viên bằng user name, nếu hoàn thành thì return true ngược lại return false
         */
        private bool deleteAccountByUserName()
        {
            if (account_dao.deleteByUserName(user_name))
            {
                return true;
            }
            return false;
        }

        /*
         - Khi bấm cập nhật nhân viên thì sẽ kiểm tra thông tin đầy đủ với chính xác chưa nếu chưa thì sẽ xuất ra messagbox
         - Ngược lại sẽ thực hiện method updateAccount() để cập nhật tài khoản nếu thực hiện thành công thì thực hiện method updateEmployee() để
         cập nhật thông tin nhân viên
         - Nếu thất bại thì xuất ra MessageBox
         */
        private void bt_capNhatNhanVien_quanLyNhanVienControl_Click(object sender, EventArgs e)
        {
            if (!checkInfo())
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
            else
            {
                if (updateAccount())
                {
                    if (updateEmployee())
                    {
                        MessageBox.Show("Cập nhật nhân viên thành công");
                        dtg_nhanVien_quanLyNhanVienControl.ClearSelection();
                        loadData();
                        bt_refresh_quanLyNhanVienControl_Click(null, null);
                        setEditingMode(false);

                        return;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật nhân viên không thành công");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("User Name đã tồn tại");
                    return;
                }
            }
        }

        /*
         - Lấy thông tin tài khoản nhân viên và cập nhật tài khoản nhân viên thông qua class AccountDao
         */
        private bool updateAccount()
        {
            String user_name1 = tb_userName_quanLyNhanVienControl.Text;
            String password = tb_password_quanLyNhanVienControl.Text;

            return account_dao.updateByUserName(user_name1, password, user_name);
        }

        /*
        - Lấy thông tin nhân viên và cập nhật nhân viên thông qua class EmployeeDao
        */
        private bool updateEmployee()
        {
            model.Employee employee = new model.Employee();

            employee.id_employee = id;
            employee.user_name = tb_userName_quanLyNhanVienControl.Text;
            employee.name_employee = tb_hoTen_quanLyNhanVienControl.Text;

            if (rb_gioiTinh_nam_quanLyNhanVienControl.Checked)
            {
                employee.gender = "Nam";
            }
            else
            {
                employee.gender = "Nữ";

            }

            employee.birth = dtp_ngaySinh_quanLyNhanVienControl.Value;
            employee.id_number = tb_cmnd_quanLyNhanVienControl.Text;
            employee.address = tb_diaChi_quanLyNhanVienControl.Text;
            employee.phone_number = tb_sdt_quanLyNhanVienControl.Text;
            employee.email = tb_email_quanLyNhanVienControl.Text;
            employee.begin_day = dtp_ngayVaoLam_quanLyNhanVienControl.Value;
            employee.role = cb_chucVu_quanLyNhanVienControl.SelectedItem.ToString();
            employee.id_shift = cb_caLam_quanLyNhanVienControl.SelectedItem.ToString();
            employee.salary = float.Parse(tb_luong_quanLyNhanVienControl.Text);

            return employee_dao.updateByUserName(employee);
        }

        /*
         - Khi bấm nút refresh thì sẽ trả lại trạng thái ban đầu cho các textbox, button, datagridview
         */
        private void bt_refresh_quanLyNhanVienControl_Click(object sender, EventArgs e)
        {
            tb_userName_quanLyNhanVienControl.Text = "";
            tb_hoTen_quanLyNhanVienControl.Text = "";
            rb_gioiTinh_nam_quanLyNhanVienControl.Checked = true;
            rb_gioiTinh_nu_quanLyNhanVienControl.Checked = false;
            dtp_ngaySinh_quanLyNhanVienControl.Value = DateTime.Now;
            tb_cmnd_quanLyNhanVienControl.Text = "";
            tb_diaChi_quanLyNhanVienControl.Text = "";
            tb_sdt_quanLyNhanVienControl.Text = "";
            tb_email_quanLyNhanVienControl.Text = "";
            dtp_ngayVaoLam_quanLyNhanVienControl.Value = DateTime.Now;
            tb_luong_quanLyNhanVienControl.Text = "";
            cb_caLam_quanLyNhanVienControl.SelectedIndex = 0;
            cb_chucVu_quanLyNhanVienControl.SelectedIndex = 0;
            tb_password_quanLyNhanVienControl.Text = "";

            tb_hoTen_quanLyNhanVienControl.Focus();

            setEditingMode(false);
        }

        /*
        - Tìm kiếm nhân viên bằng user name nhân viên.
        - Chương trình sẽ duyệt toàn bộ các phần tử ở dtg_nhanVien để tìm ra nhân viên có user name trùng với user name nhân viên cần tìm kiếm
        - Nếu có thì sẽ select dòng đó và đổ dữ liệu của dòng đó vào các textBox, radio button ngược lại sẽ xuất ra MessageBox
        */
        private void bt_findNhanVien_quanLyNhanVienControl_Click(object sender, EventArgs e)
        {
            String search_value_user_name = tb_timKiemNhanVien_quanLyNhanVienControl.Text;

            try
            {
                foreach (DataGridViewRow row in dtg_nhanVien_quanLyNhanVienControl.Rows)
                {
                    if (row.Cells[1].Value.ToString().ToLower().Equals(search_value_user_name.ToLower()))
                    {
                        row.Selected = true;

                        id = int.Parse(row.Cells[0].Value.ToString());
                        user_name = Convert.ToString(row.Cells[1].Value);

                        tb_userName_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[1].Value);
                        tb_hoTen_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[2].Value);

                        String male = Convert.ToString(row.Cells[3].Value);
                        if (male.Equals("Nam"))
                        {
                            rb_gioiTinh_nam_quanLyNhanVienControl.Checked = true;
                            rb_gioiTinh_nu_quanLyNhanVienControl.Checked = false;
                        }
                        else
                        {
                            rb_gioiTinh_nam_quanLyNhanVienControl.Checked = false;
                            rb_gioiTinh_nu_quanLyNhanVienControl.Checked = true;
                        }

                        dtp_ngaySinh_quanLyNhanVienControl.Value = Convert.ToDateTime(row.Cells[4].Value);
                        tb_cmnd_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[5].Value);
                        tb_diaChi_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[6].Value);
                        tb_sdt_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[7].Value);
                        tb_email_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[8].Value);
                        dtp_ngayVaoLam_quanLyNhanVienControl.Value = Convert.ToDateTime(row.Cells[9].Value);
                        cb_chucVu_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[10].Value);
                        cb_caLam_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[11].Value);
                        tb_luong_quanLyNhanVienControl.Text = Convert.ToString(row.Cells[12].Value);
                        tb_password_quanLyNhanVienControl.Text = account_dao.getPassword(Convert.ToString(row.Cells[1].Value));


                        setEditingMode(true);
                        return;
                    }
                }
                MessageBox.Show("Không tồn tại tài khoản");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         - Kiểm tra thông tin nhân viên đầy đủ và chính xác chưa
         */
        public Boolean checkInfo()
        {
            if (tb_userName_quanLyNhanVienControl.Text.Equals("") || tb_userName_quanLyNhanVienControl.Text.Length>20)
            {
                return false;
            }
            else if (tb_hoTen_quanLyNhanVienControl.Text.Equals("") || tb_hoTen_quanLyNhanVienControl.Text.Length>100)
            {
                return false;

            }
            else if (tb_cmnd_quanLyNhanVienControl.Text.Equals("") || tb_cmnd_quanLyNhanVienControl.Text.Length>12)
            {
                return false;

            }
            else if (tb_diaChi_quanLyNhanVienControl.Text.Equals("") || tb_diaChi_quanLyNhanVienControl.Text.Length>100)
            {
                return false;

            }
            else if (tb_sdt_quanLyNhanVienControl.Text.Equals("") || tb_sdt_quanLyNhanVienControl.Text.Length>12)
            {
                return false;

            }
            else if (!tb_email_quanLyNhanVienControl.Text.Contains("@gmail.com") || tb_email_quanLyNhanVienControl.Text.Length>50)
            {
                return false;

            }
            else if (tb_luong_quanLyNhanVienControl.Text.Equals(""))
            {
                return false;

            }
            else if (tb_password_quanLyNhanVienControl.Text.Equals(""))
            {
                return false;

            }

            return true;
        }

        /*
         - Cho phép người dùng chỉ nhập kiểu float vào tb_luong
         */
        private void tb_luong_quanLyNhanVienControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && tb_luong_quanLyNhanVienControl.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        /*
         - Cho phép người dùng chỉ nhập kiểu int vào tb_cmnd
         */
        private void tb_cmnd_quanLyNhanVienControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }

        }

        /*
         - Khi bấm nút enter ở tb_timKiem thì sẽ tự động kích hoạt button tim kiếm nhân viên
         */
        private void tb_timKiemNhanVien_quanLyNhanVienControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_findNhanVien_quanLyNhanVienControl_Click(null, null);
            }
        }
    }
}
