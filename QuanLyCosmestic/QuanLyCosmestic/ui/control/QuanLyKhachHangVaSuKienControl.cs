using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCosmestic.ui.templatePattern;
using QuanLyCosmestic.ui.command;

namespace QuanLyCosmestic.ui
{
    public partial class QuanLyKhachHangVaSuKienControl : ControlScreen
    {
        private dao.CustomerDao customer_dao;
        private dao.EventDao event_dao;
        private CommandButtonManagement commandButtonManagementKhachHang;
        private CommandButtonManagement commandButtonManagementEvent;

        private String phone_customer;
        private int id_event;
        public QuanLyKhachHangVaSuKienControl()
        {
            InitializeComponent();

            customer_dao = dao.CustomerDao.getInstance();
            event_dao = dao.EventDao.getInstance();

            commandButtonManagementKhachHang = new
              CommandButtonImp(bt_themKhachHang_quanLyKhachHangVaSuKien, bt_refreshKhachHang_quanLyKhachHangVaSuKien,
              bt_xoaKhachHang_quanLyKhachHangVaSuKien, bt_capNhatKhachHang_quanLyKhachHangVaSuKien, dgv_khachHang_quanLyKhachHangVaSuKien);

            commandButtonManagementEvent = new
              CommandButtonImp(bt_themSuKien_quanLyKhachHangVaSuKien, bt_refreshSuKien_quanLyKhachHangVaSuKien,
              bt_xoaSuKien_quanLyKhachHangVaSuKien, bt_capNhatSuKien_quanLyKhachHangVaSuKien, dgv_suKien_quanLyKhachHangVaSuKien);
            loadData();
        }

        /*
         - Xóa các lựa chọn ở dgv_khachHang và dgv_suKien
         */
        public override void clear()
        {
            dgv_khachHang_quanLyKhachHangVaSuKien.ClearSelection();
            dgv_suKien_quanLyKhachHangVaSuKien.ClearSelection();
        }

        /*
         - Đổ dữ liệu khách hàng vào dgv_khachHang qua class CustomerDao và đổ dữ liệu vào dgv_suKien vào dgv_suKien qua class EventDao
         */
        public override void loadData()
        {
            dgv_khachHang_quanLyKhachHangVaSuKien.DataSource = customer_dao.loadData();
            dgv_khachHang_quanLyKhachHangVaSuKien.Columns[0].HeaderText = "Số điện thoại khách hàng";
            dgv_khachHang_quanLyKhachHangVaSuKien.Columns[1].HeaderText = "Tên khách hàng";
            dgv_khachHang_quanLyKhachHangVaSuKien.Columns[2].HeaderText = "Địa chỉ";

            dgv_suKien_quanLyKhachHangVaSuKien.DataSource = event_dao.loadData();
            dgv_suKien_quanLyKhachHangVaSuKien.Columns[0].HeaderText = "Mã sự kiện";
            dgv_suKien_quanLyKhachHangVaSuKien.Columns[1].HeaderText = "Tên sự kiện";
            dgv_suKien_quanLyKhachHangVaSuKien.Columns[2].HeaderText = "Giảm giá(%)";
            dgv_suKien_quanLyKhachHangVaSuKien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            commandButtonManagementKhachHang.notAdjustItem();
            commandButtonManagementEvent.notAdjustItem();
        }

        /*
         - Khi thêm một khách hàng thì phải check mọi thông tin đủ chưa nếu chưa thì xuất ra MessageBox
         - Khi đã đủ thông tin thì bắt đầu lưu mọi thông tin ở textBox liên quan và lưu ở model customer và thực hiện việc thêm khách hàng.
         - Nếu thêm khách hàng thành công thì sẽ xóa các lựa chọn ở 2 dataGridview và thực hiện method setEdingtModeCustomer(false)
         */
        private void bt_themKhachHang_quanLyKhachHangVaSanPham_Click(object sender, EventArgs e)
        {
            if (checkInfoCustomer())
            {
                model.Customer customer = new model.Customer();
                customer.phone_customer = tb_sdt_quanLyKhachHangVaSuKien.Text;
                customer.name_customer = tb_hoVaTen_quanLyKhachHangVaSuKien.Text;

                customer.address_customer = tb_diaChi_quanLyKhachHangVaSuKien.Text;

                if (customer_dao.addCustomer(customer))
                {
                    MessageBox.Show("Thêm khách hàng thành công");
                    dgv_khachHang_quanLyKhachHangVaSuKien.ClearSelection();
                    loadData();
                    dgv_suKien_quanLyKhachHangVaSuKien.ClearSelection();
                    bt_refreshKhachHang_quanLyKhachHangVaSuKien_Click(null, null);
                    commandButtonManagementKhachHang.notAdjustItem();

                    return;
                }
                else
                {
                    MessageBox.Show("Số điện thoại khách hàng đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đủ  và chính xác thông tin");
                return;
            }
        }

        /*
         - Khi bấm cập nhật khách thì sẽ kiểm tra thông tin đầy đủ với chính xác chưa nếu chưa thì sẽ xuất ra messagbox
         - Ngược lại sẽ lưu dữ liệu vào model customer và thực hiện việc cập nhật qua class CustomerDao
         - Nếu thực hiện thành công thì sẽ load lại dữ liệu và trả lại trạng thái ban đầu của các textbox và button
         - Nếu thực hiện không thành công thì sẽ xuất ra MessageBox
         */
        private void bt_capNhatKhachHang_quanLyKhachHangVaSuKien_Click(object sender, EventArgs e)
        {
            if (!checkInfoCustomer())
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
            else
            {
                model.Customer customer = new model.Customer();
                customer.phone_customer = tb_sdt_quanLyKhachHangVaSuKien.Text;
                customer.name_customer = tb_hoVaTen_quanLyKhachHangVaSuKien.Text;

                customer.address_customer = tb_diaChi_quanLyKhachHangVaSuKien.Text;

                if (customer_dao.updateByTelephone(customer,phone_customer))
                {
                    MessageBox.Show("Cập nhật khách hàng thành công");
                    dgv_khachHang_quanLyKhachHangVaSuKien.ClearSelection();
                    loadData();
                    dgv_suKien_quanLyKhachHangVaSuKien.ClearSelection();
                    bt_refreshKhachHang_quanLyKhachHangVaSuKien_Click(null, null);
                    commandButtonManagementKhachHang.notAdjustItem();

                    return;
                }
                else
                {
                    MessageBox.Show("Số điện thoại đã tồn tại");
                    return;
                }
            }
        }

        /*
         - Trước khi xóa khách hàng thì phải kiểm tra coi trên dgv_khachHang có select dòng nào hay chưa nếu chưa thì sẽ xuất ra MessageBox
         - Ngược lại sẽ lấy dữ liệu số điện thoại của dòng đó truyền qua class CustomerDao để xóa khách hàng.
         - Nếu thực hiện thành công thì trả lại trạng thái ban đầu của control ngược lại sẽ xuất ra messageBox không thành công
         */
        private void bt_xoaKhachHang_quanLyKhachHangVaSuKien_Click(object sender, EventArgs e)
        {
            if (dgv_khachHang_quanLyKhachHangVaSuKien.SelectedCells.Count == 0)
            {
                MessageBox.Show("Hãy chọn khách hàng");
                return;
            }
            int index = dgv_khachHang_quanLyKhachHangVaSuKien.SelectedCells[0].RowIndex;
            if (index < 0 || index >= dgv_khachHang_quanLyKhachHangVaSuKien.RowCount)
            {
                MessageBox.Show("Hãy chọn khách hàng");
                return;
            }

            DataGridViewRow row = dgv_khachHang_quanLyKhachHangVaSuKien.Rows[index];
            
            String phone_number = row.Cells[0].Value.ToString();
            if (customer_dao.deleteByPhone(phone_number))
            {
                dgv_khachHang_quanLyKhachHangVaSuKien.ClearSelection();
                loadData();
                dgv_suKien_quanLyKhachHangVaSuKien.ClearSelection();
                bt_refreshKhachHang_quanLyKhachHangVaSuKien_Click(null, null);
                commandButtonManagementKhachHang.notAdjustItem();

                MessageBox.Show("Xóa Khách hàng thành công");

                return;
            }
            else
            {
                MessageBox.Show("Xóa khách hàng không thành công");
            }
        }

        /*
         - Khi bấm nút refresh Khách hàng thì sẽ trả lại trạng thái ban đầu của các textBox liên quan tới khách hàng
         */
        private void bt_refreshKhachHang_quanLyKhachHangVaSuKien_Click(object sender, EventArgs e)
        {
            tb_hoVaTen_quanLyKhachHangVaSuKien.Text = "";
            tb_sdt_quanLyKhachHangVaSuKien.Text = "";
            tb_diaChi_quanLyKhachHangVaSuKien.Text = "";
            commandButtonManagementKhachHang.notAdjustItem();
        }

        /*
         - Khi bấm chọn trên dgv_khachHang thì sẽ lấy dữ liệu của dòng đó và đổ dữ liệu vào các textBox khách hàng tương ứng
         */
        private void dgv_khachHang_quanLyKhachHangVaSuKien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0 || index >= dgv_khachHang_quanLyKhachHangVaSuKien.RowCount)
            {
                return;
            }

            DataGridViewRow row = dgv_khachHang_quanLyKhachHangVaSuKien.Rows[index];

            phone_customer = row.Cells[0].Value.ToString();

            tb_sdt_quanLyKhachHangVaSuKien.Text = row.Cells[0].Value.ToString();
            tb_hoVaTen_quanLyKhachHangVaSuKien.Text = row.Cells[1].Value.ToString();
            tb_diaChi_quanLyKhachHangVaSuKien.Text = row.Cells[2].Value.ToString();
            commandButtonManagementKhachHang.adjustItem();
        }

        /*
         - Khi bấm chọn trên dgv_suKien thì sẽ lấy dữ liệu của dòng đó và đổ dữ liệu vào các textBox sự kiện tương ứng
         */
        private void dgv_suKien_quanLyKhachHangVaSuKien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0 || index >= dgv_suKien_quanLyKhachHangVaSuKien.RowCount)
            {
                return;
            }

            DataGridViewRow row = dgv_suKien_quanLyKhachHangVaSuKien.Rows[index];

            id_event = int.Parse(row.Cells[0].Value.ToString());

            tb_tenSuKien_quanLyKhachHangVaControl.Text = row.Cells[1].Value.ToString();
            tb_giamGia_quanLyKhachHangVaSuKien.Text = row.Cells[2].Value.ToString();
            commandButtonManagementEvent.adjustItem();
        }

        /*
         - Kiểm tra thông tin khách hàng đầy đủ chưa, nếu chưa thì return false ngược lại return true
         */
        private Boolean checkInfoCustomer()
        {
            if (tb_sdt_quanLyKhachHangVaSuKien.Text.Equals("") || tb_sdt_quanLyKhachHangVaSuKien.Text.Length > 12)
            {
                return false;
            }
            else if (tb_hoVaTen_quanLyKhachHangVaSuKien.Text.Equals("") || tb_sdt_quanLyKhachHangVaSuKien.Text.Length > 100)
            {
                return false;
            }
            return true;
        }

        /*
         - Kiểm tra thông tin sự kiện đầy đủ chưa, nếu chưa thì return false ngược lại return true
         */
        private Boolean checkInfoEvent()
        {
            if (tb_tenSuKien_quanLyKhachHangVaControl.Text.Equals("") || tb_tenSuKien_quanLyKhachHangVaControl.Text.Length > 100)
            {
                return false;
            }
            else if (tb_giamGia_quanLyKhachHangVaSuKien.Text.Equals("") || tb_giamGia_quanLyKhachHangVaSuKien.Text.Length > 2)
            {
                return false;
            }
            return true;
        }

        /*
         - Chỉ cho người dùng nhập vào số nguyên ở tb_giamGia
         */
        private void tb_giamGia_quanLyKhachHangVaControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

       /*
        - Tìm kiếm khách hàng bằng tên khách hàng.
        - Chương trình sẽ duyệt toàn bộ các phần tử ở dgv_khachHang để tìm ra khách hàng có tên trùng với tên khách hàng cần tìm kiếm
        - Nếu có thì sẽ select dòng đó  và đổ dữ liệu của dòng đó vào các textBox của khách hàng ngược lại sẽ xuất ra MessageBox
        */
        private void bt_timKiem_quanLyKhachHangVaSuKien_Click(object sender, EventArgs e)
        {
            String search_value_user_name = tb_timKiemKhachHang_quanLyKhachHangVaSuKien.Text;

            try
            {
                foreach (DataGridViewRow row in dgv_khachHang_quanLyKhachHangVaSuKien.Rows)
                {
                    if (row.Cells[1].Value.ToString().ToLower().Equals(search_value_user_name.ToLower()))
                    {
                        row.Selected = true;
                        phone_customer = row.Cells[0].Value.ToString();

                        tb_sdt_quanLyKhachHangVaSuKien.Text = row.Cells[0].Value.ToString();
                        tb_hoVaTen_quanLyKhachHangVaSuKien.Text = row.Cells[1].Value.ToString();
                        tb_diaChi_quanLyKhachHangVaSuKien.Text = row.Cells[2].Value.ToString();

                        commandButtonManagementKhachHang.adjustItem();
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
         - Khi bấm nút enter ở tb_timKiem thì sẽ tự động kích hoạt nút tìm kiếm khách hàng
         */
        private void tb_timKiemKhachHang_quanLyKhachHangVaSuKien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_timKiem_quanLyKhachHangVaSuKien_Click(null, null);
            }
        }

        /*
         - Khi thêm một sự kiện thì phải check mọi thông tin đủ chưa nếu chưa thì xuất ra MessageBox
         - Khi đã đủ thông tin thì bắt đầu lưu mọi thông tin ở textBox liên quan và lưu ở model dis_evnet và thực hiện việc thêm sự kiện.
         - Nếu thêm sự kiện thành công thì sẽ xóa các lựa chọn ở 2 dataGridview và thực hiện method setEdingtModeEvent(false)
         */
        private void bt_themSuKien_quanLyKhachHangVaSuKien_Click(object sender, EventArgs e)
        {
            if (checkInfoEvent())
            {
                model.DiscountEvent dis_event = new model.DiscountEvent();
                dis_event.name_event = tb_tenSuKien_quanLyKhachHangVaControl.Text;
                dis_event.discount = int.Parse(tb_giamGia_quanLyKhachHangVaSuKien.Text);

                if (event_dao.addEvent(dis_event))
                {
                    MessageBox.Show("Thêm sự kiện thành công");
                    dgv_suKien_quanLyKhachHangVaSuKien.ClearSelection();
                    loadData();
                    dgv_khachHang_quanLyKhachHangVaSuKien.ClearSelection();
                    bt_refreshSuKien_quanLyKhachHangVaSuKien_Click(null, null);
                    commandButtonManagementEvent.notAdjustItem();

                    return;
                }
                else
                {
                    MessageBox.Show("Thêm sự kiện không thành công");
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
        }

        /*
         - Khi bấm cập sự kiện thì sẽ kiểm tra thông tin đầy đủ với chính xác chưa nếu chưa thì sẽ xuất ra messagbox
         - Ngược lại sẽ lưu dữ liệu vào model dis_event và thực hiện việc cập nhật qua class EventDao
         - Nếu thực hiện thành công thì sẽ load lại dữ liệu và trả lại trạng thái ban đầu của các textbox và button
         - Nếu thực hiện không thành công thì sẽ xuất ra MessageBox
         */
        private void bt_capNhatSuKien_quanLyKhachHangVaSuKien_Click(object sender, EventArgs e)
        {
            if (!checkInfoEvent())
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
            else
            {
                model.DiscountEvent dis_event = new model.DiscountEvent();
                dis_event.name_event = tb_tenSuKien_quanLyKhachHangVaControl.Text;
                dis_event.discount = int.Parse(tb_giamGia_quanLyKhachHangVaSuKien.Text);

                if (event_dao.updateByTelephone(dis_event, id_event))
                {
                    MessageBox.Show("Cập nhật sự kiện thành công");
                    dgv_suKien_quanLyKhachHangVaSuKien.ClearSelection();
                    loadData();
                    dgv_khachHang_quanLyKhachHangVaSuKien.ClearSelection();
                    bt_refreshSuKien_quanLyKhachHangVaSuKien_Click(null, null);
                    commandButtonManagementEvent.notAdjustItem();

                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật sự kiện không thành công");
                    return;
                }
            }
        }

        /*
         - Trước khi xóa sự kiện thì phải kiểm tra coi trên dgv_suKien có select dòng nào hay chưa nếu chưa thì sẽ xuất ra MessageBox
         - Ngược lại sẽ dữ liệu id của dòng đó truyền qua class EventDao để xóa sự kiện.
         - Nếu thực hiện thành công thì trả lại trạng thái ban đầu của control ngược lại sẽ xuất ra messageBox không thành công
         */
        private void bt_xoaSuKien_quanLyKhachHangVaSuKien_Click(object sender, EventArgs e)
        {
            if (dgv_suKien_quanLyKhachHangVaSuKien.SelectedCells.Count == 0)
            {
                MessageBox.Show("Hãy chọn sự kiện");
                return;
            }
            int index = dgv_suKien_quanLyKhachHangVaSuKien.SelectedCells[0].RowIndex;
            if (index < 0 || index >= dgv_suKien_quanLyKhachHangVaSuKien.RowCount)
            {
                MessageBox.Show("Hãy chọn sự kiện");
                return;
            }

            DataGridViewRow row = dgv_suKien_quanLyKhachHangVaSuKien.Rows[index];

            int id = int.Parse(row.Cells[0].Value.ToString());
            if (event_dao.deleteById(id))
            {
                dgv_suKien_quanLyKhachHangVaSuKien.ClearSelection();
                loadData();
                dgv_khachHang_quanLyKhachHangVaSuKien.ClearSelection();
                bt_refreshSuKien_quanLyKhachHangVaSuKien_Click(null, null);
                commandButtonManagementEvent.notAdjustItem();

                MessageBox.Show("Xóa sự kiện thành công");
                return;
            }
            else
            {
                MessageBox.Show("Xóa sự kiện không thành công");
            }
        }

        /*
         - Khi bấm nút refresh sự kiện thì sẽ trả lại trạng thái ban đầu của các textBox liên quan tới sự kiện
         */
        private void bt_refreshSuKien_quanLyKhachHangVaSuKien_Click(object sender, EventArgs e)
        {
            tb_tenSuKien_quanLyKhachHangVaControl.Text = "";
            tb_giamGia_quanLyKhachHangVaSuKien.Text = "";
            commandButtonManagementEvent.notAdjustItem();
        }

        /*
        - Tìm kiếm sự kiện bằng tên sự kiện.
        - Chương trình sẽ duyệt toàn bộ các phần tử ở dgv_suKien để tìm ra sự kiện có tên trùng với tên sự kiện cần tìm kiếm
        - Nếu có thì sẽ select dòng đó và đổ dữ liệu của dòng đó vào các textBox của sự kiện ngược lại sẽ xuất ra MessageBox
        */
        private void bt_timKiemSuKien_quanLyKhachHangVaSuKien_Click(object sender, EventArgs e)
        {
            String search_value_name_event = tb_timKiemSuKien_quanLyKhachHangVaSuKien.Text;

            try
            {
                foreach (DataGridViewRow row in dgv_suKien_quanLyKhachHangVaSuKien.Rows)
                {
                    if (row.Cells[1].Value.ToString().ToLower().Equals(search_value_name_event.ToLower()))
                    {
                        row.Selected = true;
                        id_event = int.Parse(row.Cells[0].Value.ToString());

                        tb_tenSuKien_quanLyKhachHangVaControl.Text = row.Cells[1].Value.ToString();
                        tb_giamGia_quanLyKhachHangVaSuKien.Text = row.Cells[2].Value.ToString();

                        commandButtonManagementEvent.adjustItem();
                        return;
                    }
                }
                MessageBox.Show("Không tồn tại sự kiện");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         - Khi bấm enter ở tb_timKiemSuKien thì sẽ kích hoạt bt_timKiemSuKien
         */
        private void tb_timKiemSuKien_quanLyKhachHangVaSuKien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_timKiemSuKien_quanLyKhachHangVaSuKien_Click(null, null);
            }
        }
    }
}
