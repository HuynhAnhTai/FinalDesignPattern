using QuanLyCosmestic.ui.templatePattern;
using System;
using System.Windows.Forms;

namespace QuanLyCosmestic.ui.control
{
    public partial class QuanLyNhapSanPhamControl : ControlScreen
    {
        private dao.ReceiveNoteDao receive_note_dao;
        private dao.ProductDao product_dao;

        private int id, amount;

        public QuanLyNhapSanPhamControl()
        {
            InitializeComponent();
            receive_note_dao = new dao.ReceiveNoteDao();
            product_dao = new dao.ProductDao();
            lb_maNhanVien_quanLySanPhamNhanVien.Text = Program.currentEmployee.id_employee.ToString();
            loadData();
        }

        /*
         - Xóa lựa chọn ở dgv_sanPham
         */
        public override void clear()
        {
            tb_maSanPham_quanLyNhapSanPham.Focus();
            dgv_sanPham_quanLyNhapSanPham.ClearSelection();
        }

        /*
         - Đổ dữ liệu sản phẩm nhập vào dgv_khachHang qua class ReceiveDao
         */
        public override void loadData()
        {
            dgv_sanPham_quanLyNhapSanPham.DataSource = receive_note_dao.loadData();
            dgv_sanPham_quanLyNhapSanPham.Columns[0].HeaderText = "Mã phiếu nhập";
            dgv_sanPham_quanLyNhapSanPham.Columns[1].HeaderText = "Mã nhân viên";
            dgv_sanPham_quanLyNhapSanPham.Columns[2].HeaderText = "Mã sản phẩm";
            dgv_sanPham_quanLyNhapSanPham.Columns[3].HeaderText = "Số lượng nhập";
            dgv_sanPham_quanLyNhapSanPham.Columns[4].HeaderText = "Giá nhập";
            dgv_sanPham_quanLyNhapSanPham.Columns[5].HeaderText = "Ngày nhập";
            dgv_sanPham_quanLyNhapSanPham.Columns[6].HeaderText = "Nhà cung cấp";
            dgv_sanPham_quanLyNhapSanPham.Columns[7].HeaderText = "Địa chỉ";
            dgv_sanPham_quanLyNhapSanPham.Columns[8].HeaderText = "Số điện thoại nhà cung cấp";
        }

        /*
         - Khi bấm nút refresh thì sẽ trả lại trạng thái ban đầu của các buton, dateTimePicker, dataGridview
         */
        private void bt_refresh_quanLyNhapSanPham_Click(object sender, EventArgs e)
        {
            dtp_ngayNhap_quanLyNhapSanPham.Value = DateTime.Now;
            tb_maSanPham_quanLyNhapSanPham.Text = "";
            tb_gia_quanLyNhapSanPham.Text = "";
            tb_soLuong_quanLyNhapSanPham.Text = "";
            tb_nhaCungCap_quanLyNhapSanPham.Text = "";
            tb_sdtNhaCungCap_quanLyNhapSanPham.Text = "";
            tb_diaChi_quanLyNhapSanPham.Text = "";

            setEditingMode(false);
        }

        /*
         - Set trạng thái cho các button và data grid view
         */
        private void setEditingMode(bool enable)
        {
            bt_nhap_quanLyNhapSanPhamControl.Enabled = !enable;
            bt_refresh_quanLyNhapSanPham.Enabled = enable;
            bt_xoa_quanLyNhapSanPham.Enabled = enable;
            bt_capNhat_quanLyNhapSanPham.Enabled = enable;
            if (!enable)
            {
                dgv_sanPham_quanLyNhapSanPham.ClearSelection();
            }
        }

        /*
         - Kiểm tra thông tin sản phẩm
         */
        public Boolean checkInfo()
        {
            if (tb_maSanPham_quanLyNhapSanPham.Text.Equals("") || tb_maSanPham_quanLyNhapSanPham.Text.Length > 50)
            {
                return false;
            }
            else if (tb_soLuong_quanLyNhapSanPham.Text.Equals(""))
            {
                return false;
            }
            else if (tb_gia_quanLyNhapSanPham.Text.Equals(""))
            {
                return false;
            }
            else if (tb_nhaCungCap_quanLyNhapSanPham.Text.Equals("") || tb_nhaCungCap_quanLyNhapSanPham.Text.Length > 100)
            {
                return false;
            }
            else if (tb_sdtNhaCungCap_quanLyNhapSanPham.Text.Equals("") || tb_sdtNhaCungCap_quanLyNhapSanPham.Text.Length > 12)
            {
                return false;
            }
            else if (tb_diaChi_quanLyNhapSanPham.Text.Equals("") || tb_diaChi_quanLyNhapSanPham.Text.Length > 100)
            {
                return false;
            }
            return true;
        }

        /*
         - Chỉ cho người dùng nhập kiểu int vào số lượng sản phẩm
         */
        private void tb_soLuong_quanLyNhapSanPham_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        /*
         - Chỉ cho người dùng nhập kiểu float vào tổng giá sản phẩm
         */
        private void tb_gia_quanLyNhapSanPham_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && tb_gia_quanLyNhapSanPham.Text.IndexOf('.') != -1)
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
         - Khi bấm chọn trên dgv_sanPham thì sẽ lấy dữ liệu của dòng đó và đổ dữ liệu vào các textBox tương ứng
         */
        private void dgv_sanPham_quanLyNhapSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0 || index >= dgv_sanPham_quanLyNhapSanPham.RowCount)
            {
                return;
            }

            DataGridViewRow row = dgv_sanPham_quanLyNhapSanPham.Rows[index];

            id = int.Parse(row.Cells[0].Value.ToString());
            amount = int.Parse(row.Cells[3].Value.ToString());

            dtp_ngayNhap_quanLyNhapSanPham.Value = DateTime.Parse(row.Cells[5].Value.ToString());
            tb_maSanPham_quanLyNhapSanPham.Text = row.Cells[2].Value.ToString();
            tb_soLuong_quanLyNhapSanPham.Text = row.Cells[3].Value.ToString();
            tb_gia_quanLyNhapSanPham.Text = row.Cells[4].Value.ToString();
            tb_nhaCungCap_quanLyNhapSanPham.Text = row.Cells[6].Value.ToString();
            tb_diaChi_quanLyNhapSanPham.Text = row.Cells[7].Value.ToString();
            tb_sdtNhaCungCap_quanLyNhapSanPham.Text = row.Cells[8].Value.ToString();

            setEditingMode(true);
        }

        /*
         - Khi thêm một hóa đơn nhập sản phẩm thì phải check mọi thông tin đủ chưa nếu chưa thì xuất ra MessageBox
         - Khi đã đủ thông tin thì bắt đầu lưu mọi thông tin ở textBox liên quan và lưu ở model rv và thực hiện việc hóa đơn nhập sản phẩm.
         - Nếu thêm thành công thì sẽ xóa các lựa chọn ở dgv và thực hiện method setEdingtMode(false)
         */
        private void bt_nhap_quanLyNhapSanPhamControl_Click(object sender, EventArgs e)
        {
            if (checkInfo())
            {
                model.ReceiveNote rv = new model.ReceiveNote();
                rv.id_employee = int.Parse(lb_maNhanVien_quanLySanPhamNhanVien.Text.ToString());
                rv.id_product = tb_maSanPham_quanLyNhapSanPham.Text.ToString();
                rv.amount = int.Parse(tb_soLuong_quanLyNhapSanPham.Text.ToString());
                rv.total_price_receive = float.Parse(tb_gia_quanLyNhapSanPham.Text.ToString());
                rv.date_receive = dtp_ngayNhap_quanLyNhapSanPham.Value;
                rv.name_provider = tb_nhaCungCap_quanLyNhapSanPham.Text.ToString();
                rv.address_provider = tb_diaChi_quanLyNhapSanPham.Text.ToString();
                rv.phone_number_provider = tb_sdtNhaCungCap_quanLyNhapSanPham.Text.ToString();

                if (receive_note_dao.addReceiveNote(rv))
                {
                    if (product_dao.updateAmountProduct(rv.id_product, 0 , rv.amount))
                    {
                        MessageBox.Show("Thêm hóa đơn nhập sản phẩm thành công");
                        dgv_sanPham_quanLyNhapSanPham.ClearSelection();
                        loadData();
                        bt_refresh_quanLyNhapSanPham_Click(null, null);
                        setEditingMode(false);

                        return;
                    }
                    else
                    {
                        MessageBox.Show("Thêm hóa đơn nhập sản phẩm không thành công");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn nhập sản phẩm không thành công");
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
        }

        /*
         - Khi bấm cập nhật hóa đơn thêm sản phẩm thì sẽ kiểm tra thông tin đầy đủ với chính xác chưa nếu chưa thì sẽ xuất ra messagbox
         - Ngược lại sẽ lưu dữ liệu vào model rv và thực hiện việc cập nhật qua class ReceiveNoteDao
         - Nếu thực hiện thành công thì sẽ load lại dữ liệu và trả lại trạng thái ban đầu của các textbox và button
         - Nếu thực hiện không thành công thì sẽ xuất ra MessageBox
         */
        private void bt_capNhat_quanLyNhapSanPham_Click(object sender, EventArgs e)
        {
            if (!checkInfo())
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
            else
            {
                model.ReceiveNote rv = new model.ReceiveNote();
                rv.id_employee = int.Parse(lb_maNhanVien_quanLySanPhamNhanVien.Text.ToString());
                rv.id_product = tb_maSanPham_quanLyNhapSanPham.Text.ToString();
                rv.amount = int.Parse(tb_soLuong_quanLyNhapSanPham.Text.ToString());
                rv.total_price_receive = float.Parse(tb_gia_quanLyNhapSanPham.Text.ToString());
                rv.date_receive = dtp_ngayNhap_quanLyNhapSanPham.Value;
                rv.name_provider = tb_nhaCungCap_quanLyNhapSanPham.Text.ToString();
                rv.address_provider = tb_diaChi_quanLyNhapSanPham.Text.ToString();
                rv.phone_number_provider = tb_sdtNhaCungCap_quanLyNhapSanPham.Text.ToString();

                if (receive_note_dao.updateById(rv, id))
                {
                    if (product_dao.updateAmountProduct(rv.id_product, amount, rv.amount))
                    {
                        MessageBox.Show("Cập nhật hóa đơn nhập sản phẩm thành công");
                        dgv_sanPham_quanLyNhapSanPham.ClearSelection();
                        loadData();
                        bt_refresh_quanLyNhapSanPham_Click(null, null);
                        setEditingMode(false);

                        return;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật hóa đơn nhập sản phẩm không thành công");
                        return;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Cập nhật hóa đơn nhập sản phẩm không thành công");
                    return;
                }
            }
        }

        /*
         - Trước khi xóa hóa đơn nhập sản phẩm thì phải kiểm tra coi trên dgv_sanPham có select dòng nào hay chưa 
         nếu chưa thì sẽ xuất ra MessageBox
         - Ngược lại sẽ lấy dữ liệu id của dòng đó truyền qua class ReceiveNoteDao để xóa hóa đơn nhập sản phẩm.
         - Nếu thực hiện thành công thì trả lại trạng thái ban đầu của control ngược lại sẽ xuất ra messageBox không thành công
         */
        private void bt_xoa_quanLyNhapSanPham_Click(object sender, EventArgs e)
        {
            if (dgv_sanPham_quanLyNhapSanPham.SelectedCells.Count == 0)
            {
                MessageBox.Show("Hãy chọn hóa đơn nhập sản phẩm");
                return;
            }
            int index = dgv_sanPham_quanLyNhapSanPham.SelectedCells[0].RowIndex;
            if (index < 0 || index >= dgv_sanPham_quanLyNhapSanPham.RowCount)
            {
                MessageBox.Show("Hãy chọn hóa đơn nhập sản phẩm");
                return;
            }

            DataGridViewRow row = dgv_sanPham_quanLyNhapSanPham.Rows[index];

            int id = int.Parse(row.Cells[0].Value.ToString());
            String id_product = row.Cells[2].Value.ToString();
            int amount = int.Parse(row.Cells[3].Value.ToString());
            if (receive_note_dao.deleteById(id))
            {
                if (product_dao.updateAmountProduct(id_product, amount, 0))
                {
                    MessageBox.Show("Xóa hóa đơn nhập sản phẩm thành công");
                    dgv_sanPham_quanLyNhapSanPham.ClearSelection();
                    loadData();
                    bt_refresh_quanLyNhapSanPham_Click(null, null);
                    setEditingMode(false);

                    return;
                }
                else
                {
                    MessageBox.Show("Xóa hóa đơn nhập sản phẩm không thành công");
                }
                
            }
            else
            {
                MessageBox.Show("Xóa hóa đơn nhập sản phẩm không thành công");
            }
        }
    }
}
