using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCosmestic.ui
{
    public partial class QuanLySanPhamControl : UserControl
    {
        private dao.ProductDao product_dao;
        private dao.CategoryDao category_dao;

        private string id_product;
        private int id_category;

        public QuanLySanPhamControl()
        {
            InitializeComponent();
            product_dao = new dao.ProductDao();
            category_dao = new dao.CategoryDao();
            loadData();
        }

        /*
         - Xóa các lựa chọn ở dtv_loaiSanPham và dtv_sanPham
         */
        public void clear()
        {
            tb_maSanPham_quanLySanPhamControl.Focus();
            dtv_loaiSanPham_quanLySanPhamControl.ClearSelection();
            dtv_sanPham_quanLySanPhamControl.ClearSelection();
        }

        /*
         - Lấy dữ liệu ở CategoryDao và ProductDao đổ vào dtv_loaiSanPham, dtv_sanPham và cb_loai
         */
        public void loadData()
        {
            dtv_loaiSanPham_quanLySanPhamControl.DataSource = category_dao.loadData();
            dtv_loaiSanPham_quanLySanPhamControl.Columns[0].HeaderText = "Mã loại sản phẩm";
            dtv_loaiSanPham_quanLySanPhamControl.Columns[1].HeaderText = "Tên loại sản phẩm";
            dtv_loaiSanPham_quanLySanPhamControl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtv_sanPham_quanLySanPhamControl.DataSource = product_dao.loadData();
            dtv_sanPham_quanLySanPhamControl.Columns[0].HeaderText = "Mã sản phẩm";
            dtv_sanPham_quanLySanPhamControl.Columns[1].HeaderText = "Tên sản phẩm";
            dtv_sanPham_quanLySanPhamControl.Columns[2].HeaderText = "Đặc tính";
            dtv_sanPham_quanLySanPhamControl.Columns[3].HeaderText = "Số lượng";
            dtv_sanPham_quanLySanPhamControl.Columns[4].HeaderText = "Đơn giá";
            dtv_sanPham_quanLySanPhamControl.Columns[5].HeaderText = "Mã loại sản phẩm";

            cb_loai_quanLySanPhamControl.DataSource = category_dao.loadData();
            cb_loai_quanLySanPhamControl.DisplayMember = "NAME_CATEGORY";
            cb_loai_quanLySanPhamControl.ValueMember = "ID_CATEGORY";
        }

        /*
         - Khi bấm nút refresh thì trả lại trạng thái ban đầu của các textBox sản phẩm
         */
        private void bt_refresh_quanLySanPhamControl_Click(object sender, EventArgs e)
        {
            tb_maSanPham_quanLySanPhamControl.Text = "";
            tb_tenSanPham_quanLySanPhamControl.Text = "";
            tb_size_quanLySanPhamControl.Text = "";
            tb_giaSanPham_quanLySanPhamControl.Text = "";
            cb_loai_quanLySanPhamControl.SelectedIndex = 0;

            setEditingModeProduct(false);
        }

        /*
         - Khi bấm nút refresh thì trả lại trạng thái ban đầu của các textBox loại
         */
        private void bt_refreshLoai_quanLySanPhamControl_Click(object sender, EventArgs e)
        {
            tb_tenLoai_quanLySanPhamControl.Text = "";
            setEditingModeCategory(false);
        }

        /*
         - Set trạng thái cho các button, dtv sản phẩm
         */
        private void setEditingModeProduct(bool enable)
        {
            bt_themSanPham_quanLySanPhamControl.Enabled = !enable;
            bt_refresh_quanLySanPhamControl.Enabled = enable;
            bt_xoaSanPham_quanLySanPhamControl.Enabled = enable;
            bt_capNhatSanPham_quanLySanPhamControl.Enabled = enable;
            if (!enable)
            {
                dtv_sanPham_quanLySanPhamControl.ClearSelection();
            }
        }

        /*
         - Set trạng thái cho các button, dtv loại
         */
        private void setEditingModeCategory(bool enable)
        {
            bt_themLoaiSanPham_quanLySanPhamControl.Enabled = !enable;
            bt_refreshLoai_quanLySanPhamControl.Enabled = enable;
            bt_xoaLoaiSanPham_quanLySanPhamControl.Enabled = enable;
            bt_capNhatLoai_quanLySanPhamControl.Enabled = enable;
            if (!enable)
            {
                dtv_loaiSanPham_quanLySanPhamControl.ClearSelection();
            }
        }

        /*
         - Kiểm tra thông tin sản phẩm
         */
        private Boolean checkInfoProduct()
        {
            if (tb_maSanPham_quanLySanPhamControl.Text.Equals("") || tb_maSanPham_quanLySanPhamControl.Text.Length > 50)
            {
                return false;
            }
            else if (tb_tenSanPham_quanLySanPhamControl.Text.Equals("") || tb_tenSanPham_quanLySanPhamControl.Text.Length > 100)
            {
                return false;
            }
            else if (tb_size_quanLySanPhamControl.Text.Length > 20)
            {
                return false;
            }
            else if (tb_giaSanPham_quanLySanPhamControl.Text.Equals(""))
            {
                return false;
            }
            return true;
        }

        /*
         - Kiểm tra thông tin loại
         */
        private Boolean checkInfoCategory()
        {
            if (tb_tenLoai_quanLySanPhamControl.Text.Equals("") || tb_tenLoai_quanLySanPhamControl.Text.Length > 100)
            {
                return false;
            }
            return true;
        }

        /*
         - Cho phép người dùng nhập vào số nguyên vào giá sản phẩm
         */
        private void tb_giaSanPham_quanLySanPhamControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        /*
        - Tìm kiếm sản phẩm bằng id sản phẩm.
        - Chương trình sẽ duyệt toàn bộ các phần tử ở dtv_sanPham để tìm ra sản phẩm có id trùng với id sản phẩm cần tìm kiếm
        - Nếu có thì sẽ select dòng đó và đổ dữ liệu của dòng đó vào các textBox của khách hàng ngược lại sẽ xuất ra MessageBox
        */
        private void bt_timKiemSanPham_quanLySanPhamControl_Click(object sender, EventArgs e)
        {
            String search_value_id_product = tb_timKiemSanPham_quanLySanPhamControl.Text;

            try
            {
                foreach (DataGridViewRow row in dtv_sanPham_quanLySanPhamControl.Rows)
                {
                    if (row.Cells[0].Value.ToString().ToLower().Equals(search_value_id_product.ToLower()))
                    {
                        row.Selected = true;
                        id_product = row.Cells[0].Value.ToString();

                        tb_maSanPham_quanLySanPhamControl.Text = row.Cells[0].Value.ToString();
                        tb_tenSanPham_quanLySanPhamControl.Text = row.Cells[1].Value.ToString();
                        tb_size_quanLySanPhamControl.Text = row.Cells[2].Value.ToString();
                        tb_giaSanPham_quanLySanPhamControl.Text = row.Cells[3].Value.ToString();
                        int index = int.Parse(row.Cells[5].Value.ToString()) - 1;
                        cb_loai_quanLySanPhamControl.SelectedIndex = index;
                        

                        setEditingModeProduct(true);
                        return;
                    }
                }
                MessageBox.Show("Không tồn tại sản phẩm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*
         - Khi bấm nút enter ở tb_timKiemSanPham thì sẽ kích hoạt bt_timKiemSanPham
         */
        private void tb_timKiemSanPham_quanLySanPhamControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_timKiemSanPham_quanLySanPhamControl_Click(null, null);
            }
        }

        /*
         - Khi bấm chọn trên dtv_sanPham thì sẽ lấy dữ liệu của dòng đó và đổ dữ liệu vào các textBox sản phẩm tương ứng
         */
        private void dtv_sanPham_quanLySanPhamControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0 || index >= dtv_sanPham_quanLySanPhamControl.RowCount)
            {
                return;
            }

            DataGridViewRow row = dtv_sanPham_quanLySanPhamControl.Rows[index];

            id_product = row.Cells[0].Value.ToString();

            tb_maSanPham_quanLySanPhamControl.Text = row.Cells[0].Value.ToString();
            tb_tenSanPham_quanLySanPhamControl.Text = row.Cells[1].Value.ToString();
            tb_size_quanLySanPhamControl.Text = row.Cells[2].Value.ToString();
            tb_giaSanPham_quanLySanPhamControl.Text = row.Cells[4].Value.ToString();
            int index2 = int.Parse(row.Cells[5].Value.ToString()) - 1;
            cb_loai_quanLySanPhamControl.SelectedIndex = index2;

            setEditingModeProduct(true);
        }

        /*
         - Khi bấm chọn trên dtv_loaiSanPham thì sẽ lấy dữ liệu của dòng đó và đổ dữ liệu vào các textBox loại sản phẩm tương ứng
         */
        private void dtv_loaiSanPham_quanLySanPhamControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0 || index >= dtv_loaiSanPham_quanLySanPhamControl.RowCount)
            {
                return;
            }

            DataGridViewRow row = dtv_loaiSanPham_quanLySanPhamControl.Rows[index];

            id_category = int.Parse(row.Cells[0].Value.ToString());

            tb_tenLoai_quanLySanPhamControl.Text = row.Cells[1].Value.ToString();

            setEditingModeCategory(true);
        }

        /*
         - Khi thêm một sản phẩm thì phải check mọi thông tin đủ chưa nếu chưa thì xuất ra MessageBox
         - Khi đã đủ thông tin thì bắt đầu lưu mọi thông tin ở textBox liên quan và lưu ở model product và thực hiện việc thêm sản phẩm.
         - Nếu thêm sản phẩm thành công thì sẽ xóa các lựa chọn ở 2 dataGridview và thực hiện method setEdingtModeProduct(false)
         */
        private void bt_themSanPham_quanLySanPhamControl_Click(object sender, EventArgs e)
        {
            if (checkInfoProduct())
            {
                model.Product product = new model.Product();
                product.id_product = tb_maSanPham_quanLySanPhamControl.Text;
                product.name_product = tb_tenSanPham_quanLySanPhamControl.Text;
                product.specification = tb_size_quanLySanPhamControl.Text;
                product.amount = 0;
                product.price = int.Parse(tb_giaSanPham_quanLySanPhamControl.Text);
                product.id_category = cb_loai_quanLySanPhamControl.SelectedIndex+1;

                if (product_dao.addProduct(product))
                {
                    MessageBox.Show("Thêm sản phẩm thành công");
                    dtv_sanPham_quanLySanPhamControl.ClearSelection();
                    loadData();
                    bt_refresh_quanLySanPhamControl_Click(null, null);
                    dtv_loaiSanPham_quanLySanPhamControl.ClearSelection();
                    setEditingModeProduct(false);

                    return;
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm không thành công");
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
        }

        /*
         - Khi bấm cập sản phẩm thì sẽ kiểm tra thông tin đầy đủ với chính xác chưa nếu chưa thì sẽ xuất ra messagbox
         - Ngược lại sẽ lưu dữ liệu vào model product và thực hiện việc cập nhật qua class ProductDao
         - Nếu thực hiện thành công thì sẽ load lại dữ liệu và trả lại trạng thái ban đầu của các textbox và button
         - Nếu thực hiện không thành công thì sẽ xuất ra MessageBox
         */
        private void bt_capNhatSanPham_quanLySanPhamControl_Click(object sender, EventArgs e)
        {
            if (!checkInfoProduct())
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
            else
            {
                model.Product product = new model.Product();
                product.id_product = tb_maSanPham_quanLySanPhamControl.Text;
                product.name_product = tb_tenSanPham_quanLySanPhamControl.Text;
                product.specification = tb_size_quanLySanPhamControl.Text;
                product.amount = 0;
                product.price = int.Parse(tb_giaSanPham_quanLySanPhamControl.Text);
                product.id_category = cb_loai_quanLySanPhamControl.SelectedIndex + 1;

                if (product_dao.updateById(product, id_product))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công");
                    dtv_sanPham_quanLySanPhamControl.ClearSelection();
                    loadData();
                    bt_refresh_quanLySanPhamControl_Click(null, null);
                    dtv_loaiSanPham_quanLySanPhamControl.ClearSelection();
                    setEditingModeProduct(false);

                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm không thành công");
                    return;
                }
            }
        }

        /*
         - Trước khi xóa sản phẩm thì phải kiểm tra coi trên dtv_sanPham có select dòng nào hay chưa nếu chưa thì sẽ xuất ra MessageBox
         - Ngược lại sẽ dữ liệu id của dòng đó truyền qua class ProductDao để xóa sản phẩm.
         - Nếu thực hiện thành công thì trả lại trạng thái ban đầu của control ngược lại sẽ xuất ra messageBox không thành công
         */
        private void bt_xoaSanPham_quanLySanPhamControl_Click(object sender, EventArgs e)
        {
            if (dtv_sanPham_quanLySanPhamControl.SelectedCells.Count == 0)
            {
                MessageBox.Show("Hãy chọn sản phẩm");
                return;
            }
            int index = dtv_sanPham_quanLySanPhamControl.SelectedCells[0].RowIndex;
            if (index < 0 || index >= dtv_sanPham_quanLySanPhamControl.RowCount)
            {
                MessageBox.Show("Hãy chọn sản phẩm");
                return;
            }

            DataGridViewRow row = dtv_sanPham_quanLySanPhamControl.Rows[index];

            String id = row.Cells[0].Value.ToString();
            if (product_dao.deleteById(id))
            {
                dtv_sanPham_quanLySanPhamControl.ClearSelection();
                loadData();
                bt_refresh_quanLySanPhamControl_Click(null, null);
                dtv_loaiSanPham_quanLySanPhamControl.ClearSelection();
                setEditingModeProduct(false);

                MessageBox.Show("Xóa sản phẩm thành công");

                return;
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm không thành công");
            }
        }

        /*
         - Khi thêm một loại sản phẩm thì phải check mọi thông tin đủ chưa nếu chưa thì xuất ra MessageBox
         - Khi đã đủ thông tin thì bắt đầu lưu mọi thông tin ở textBox liên quan và lưu ở model category và thực hiện việc thêm loại sản phẩm.
         - Nếu thêm loại sản phẩm thành công thì sẽ xóa các lựa chọn ở 2 dataGridview và thực hiện method setEdingtModeCategory(false)
         */
        private void bt_themLoaiSanPham_quanLySanPhamControl_Click(object sender, EventArgs e)
        {
            if (checkInfoCategory())
            {
                model.Category category = new model.Category();
                category.name_category = tb_tenLoai_quanLySanPhamControl.Text;

                if (category_dao.addCategory(category))
                {
                    MessageBox.Show("Thêm loại sản phẩm thành công");
                    dtv_loaiSanPham_quanLySanPhamControl.ClearSelection();
                    loadData();
                    bt_refreshLoai_quanLySanPhamControl_Click(null, null);
                    dtv_sanPham_quanLySanPhamControl.ClearSelection();
                    setEditingModeCategory(false);

                    return;
                }
                else
                {
                    MessageBox.Show("Thêm loại sản phẩm không thành công");
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
        }

        /*
         - Khi bấm cập loại sản phẩm thì sẽ kiểm tra thông tin đầy đủ với chính xác chưa nếu chưa thì sẽ xuất ra messagbox
         - Ngược lại sẽ lưu dữ liệu vào model category và thực hiện việc cập nhật qua class CategoryDao
         - Nếu thực hiện thành công thì sẽ load lại dữ liệu và trả lại trạng thái ban đầu của các textbox và button
         - Nếu thực hiện không thành công thì sẽ xuất ra MessageBox
         */
        private void bt_capNhatLoai_quanLySanPhamControl_Click(object sender, EventArgs e)
        {
            if (!checkInfoCategory())
            {
                MessageBox.Show("Hãy điền đủ và chính xác thông tin");
                return;
            }
            else
            {
                model.Category category = new model.Category();
                category.id_category = id_category;
                category.name_category = tb_tenLoai_quanLySanPhamControl.Text;

                if (category_dao.updateById(category))
                {
                    MessageBox.Show("Cập nhật loại sản phẩm thành công");
                    dtv_loaiSanPham_quanLySanPhamControl.ClearSelection();
                    loadData();
                    bt_refreshLoai_quanLySanPhamControl_Click(null, null);
                    dtv_sanPham_quanLySanPhamControl.ClearSelection();
                    setEditingModeCategory(false);
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm không thành công");
                    return;
                }
            }
        }

        /*
         - Trước khi xóa loại sản phẩm thì phải kiểm tra coi trên dtv_loaiSanPham có select dòng nào hay chưa nếu chưa thì sẽ xuất ra MessageBox
         - Ngược lại sẽ dữ liệu id của dòng đó truyền qua class CategoryDao để xóa loại sản phẩm.
         - Nếu thực hiện thành công thì trả lại trạng thái ban đầu của control ngược lại sẽ xuất ra messageBox không thành công
         */
        private void bt_xoaLoaiSanPham_quanLySanPhamControl_Click(object sender, EventArgs e)
        {
            if (dtv_loaiSanPham_quanLySanPhamControl.SelectedCells.Count == 0)
            {
                MessageBox.Show("Hãy chọn loại sản phẩm");
                return;
            }
            int index = dtv_loaiSanPham_quanLySanPhamControl.SelectedCells[0].RowIndex;
            if (index < 0 || index >= dtv_loaiSanPham_quanLySanPhamControl.RowCount)
            {
                MessageBox.Show("Hãy chọn loại sản phẩm");
                return;
            }

            DataGridViewRow row = dtv_loaiSanPham_quanLySanPhamControl.Rows[index];

            String id = row.Cells[0].Value.ToString();
            if (category_dao.deleteById(id))
            {
                dtv_loaiSanPham_quanLySanPhamControl.ClearSelection();
                loadData();
                bt_refreshLoai_quanLySanPhamControl_Click(null, null);
                dtv_sanPham_quanLySanPhamControl.ClearSelection();
                setEditingModeCategory(false);

                MessageBox.Show("Xóa loại sản phẩm thành công");

                return;
            }
            else
            {
                MessageBox.Show("Xóa loại sản phẩm không thành công");
            }
        }
    }
}
