using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections;
using QuanLyCosmestic.ui.templatePattern;
using QuanLyCosmestic.mediatorControlScreen;
using QuanLyCosmestic.mementoBanHang;

namespace QuanLyCosmestic.ui
{
    public partial class BanHangControl : ControlScreen
    {
        private dao.ProductDao product_dao;
        private dao.EventDao event_dao;
        private dao.CustomerDao customer_dao;
        private dao.BillDao bill_dao;
        private dao.DetailBillDao detail_bill;

        private DataTable dis_event_data;

        private bool dataProductChange = true;
        private bool dataEventChange = true;

        private int position;
        private int max = -1;

        private CardCareTaker cardCareTaker;
        private CardModel cardModel;

        public BanHangControl()
        {
            InitializeComponent();
   
            cardModel = new CardModel(new List<ListViewItem>());
            cardCareTaker = new CardCareTaker();

            product_dao = dao.ProductDao.getInstance();
            event_dao = dao.EventDao.getInstance();
            customer_dao = dao.CustomerDao.getInstance();
            bill_dao = dao.BillDao.getInstance();
            detail_bill = dao.DetailBillDao.getInstance();
            lb_nhanVienBanHang_banHangControl.Text = Program.currentEmployee.name_employee;
            loadData();
            dgv_sanPham_banHangControl.ClearSelection();
        }

        private List<ListViewItem> getListItemInCard()
        {
            List<ListViewItem> items = new List<ListViewItem>();
            foreach (ListViewItem item in lv_hoaDon_banHangControl.Items)
            {
                items.Add(item);
            }
            return items;
        }

        /*
         - Làm sạch các lựa chọn ở dataGridview_sanPham và chuyển focus vào tb_sdt
        */
        public override void clear()
        {
            dgv_sanPham_banHangControl.ClearSelection();
            tb_sdtKhachHang_banHangControl.Focus(); 
        }

        public override void dataOfOtherControlChange(TypeDataChange typeUpdate)
        {
            if (typeUpdate == TypeDataChange.PRODUCT)
            {
                dataProductChange = true;
            }
            else if (typeUpdate == TypeDataChange.EVENT)
            {
                dataEventChange = true;
            }
        }

        /*
         - Dữ liệu của dgv_sanPham sẽ được lấy qua câu lệnh truy vấn ở class ProductDao
         - dis_event sẽ có dữ liệu qua câu lệnh truy vấn ở class EventDao sau đó sẽ lấy tên dữ liệu của cột "NAM_EVENT" xuất hiện trên cb_suKien
        */
        public override void loadData()
        {
            if (dataProductChange)
            {
                dgv_sanPham_banHangControl.DataSource = product_dao.loadDataSomething();
                dataProductChange = false;
            }
            
            dgv_sanPham_banHangControl.Columns[0].HeaderText = "Mã sản phẩm";
            dgv_sanPham_banHangControl.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_sanPham_banHangControl.Columns[2].HeaderText = "Đặc tính";
            dgv_sanPham_banHangControl.Columns[3].HeaderText = "Đơn giá";

            if (dataEventChange)
            {
                dis_event_data = event_dao.loadData();
                dataEventChange = false;
            }     
            cb_suKien_banHangControl.DataSource = dis_event_data;
            cb_suKien_banHangControl.DisplayMember = "NAME_EVENT";
            tb_sdtKhachHang_banHangControl.Focus();
        }

        /*
         - Khi bấm nút refresh thì các textbox sẽ được làm trống, đồng thời clear các selection ở dgv_sanPham
         */
        private void bt_refresh_banHangControl_Click(object sender, EventArgs e)
        {
            tb_sdtKhachHang_banHangControl.Text = "";
            tb_hoTenKhachHang_banHangControl.Text = "";
            cb_suKien_banHangControl.SelectedIndex = 0;
            dtp_ngayNhap_banHangControl.Value = DateTime.Now;
            tb_nhapSoLuongSanPham_banHang.Text = "";
            lb_giamGia_banHangControl.Text = "0%";
            lb_thanhTien_banHangControl.Text = "0 VND";
            lb_tongTien_banHangControl.Text = "0 VND";
            tb_sdtKhachHang_banHangControl.Focus();
            foreach (ListViewItem items in lv_hoaDon_banHangControl.Items)
            {
                lv_hoaDon_banHangControl.Items.Remove(items);
            }
            //memento
            cardCareTaker.clearAllMementoCard();
            dgv_sanPham_banHangControl.ClearSelection();

        }

        /*
         - Khi select ở cb_suKien thay đổi thì đồng thời cũng thay đổi dữ liệu ở lb_giamGia cho phù hợp với mỗi event giảm giá khác nhau
         */
        private void cb_suKien_banHangControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cb_suKien_banHangControl.SelectedItem;
            lb_giamGia_banHangControl.Text = drv["DISCOUNT"].ToString() + "%";
        }

        /*
         - Kiểm tra số điện thoại khách hàng có phải 9 số hoặc 12 số không, nếu đúng thì tả về true, ngược lại là false
         */
        private Boolean checkInfo()
        {
            if (tb_sdtKhachHang_banHangControl.Text.Length == 12 || tb_sdtKhachHang_banHangControl.Text.Length == 9)
            {
                return true;
            }
            return false;
        }

        /*
        -Cài đặt nút enter cho tb_sdt, khi bấm enter, và khi bấm enter thì sẽ chạy đến method findCustomerByTelephone
        */
        private void tb_sdtKhachHang_banHangControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_sdtKhachHang_banHangControl.Text.Length == 9 || tb_sdtKhachHang_banHangControl.Text.Length == 12 )
                {
                    findCustomerByTelephone(tb_sdtKhachHang_banHangControl.Text);
                }
                else
                {
                    MessageBox.Show("Hãy điền số điện thoại khách hàng");
                    return;
                }
            }
        }

        /*
        - Kiểm tra khách hàng coi đã đăng ký ở cửa hàng chưa qua class CustomerDao có câu lệnh truy vấn sql để thực hiện.
        - Nếu trả về số cột bằng 0 thì khách hàng chưa đăng ký và xuất ra messagbox, ngược lại sẽ lấy dữ liệu ở cột "CUSTOMERNAME" và
        gán vô tb_hoTenKhachHang
        */
        private void findCustomerByTelephone(String telephone_number)
        {
            DataTable customer = customer_dao.findCustomerByTelephone(telephone_number);
            if (customer.Rows.Count == 0)
            {
                MessageBox.Show("Khách hàng chưa đăng ký");
                return;
            }
            else
            {
                tb_hoTenKhachHang_banHangControl.Text = customer.Rows[0]["CUSTOMERNAME"].ToString();
            }
        }

        /*
         - Khi bấm nút tìm kiếm thì biến search_value_id_product dùng để lưu lại id cần tìm kiếm
         - Sau đó sẽ duyệt hết dữ liệu ở dgv_sanPham_banHangControl, nếu thấy id nào giống id cần tìm thì select dòng đó và return
         - Nếu duyệt hết mà chưa return thì sẽ xuất ra MessageBox không tồn tại sản phẩm
        */
        private void bt_timKiemSanPham_banHangControl_Click(object sender, EventArgs e)
        {
            String search_value_id_product = tb_timKiemSanPham_banHangControl.Text;

            try
            {
                foreach (DataGridViewRow row in dgv_sanPham_banHangControl.Rows)
                {
                    if (row.Cells[0].Value.ToString().ToLower().Equals(search_value_id_product.ToLower()))
                    {
                        dgv_sanPham_banHangControl.ClearSelection();
                        row.Selected = true;
                        bt_xoa_banHangControl.Enabled = false;

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
        - Set enter cho tb_timKiem
        - Nếu bấm nút enter ở tb_timKiem thì sẽ kích hoạt nút bt_timKiem để tìm kiếm sản phẩm 
        */
        private void tb_timKiemSanPham_banHangControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_timKiemSanPham_banHangControl_Click(null, null);
            }
        }

        /*
        - Khi click vào mỗi hàng ở  dgv_sanPham nếu lv_hoaDon_banHangControl chưa tồn tại sản phẩm nào có Name giống vậy thì sẽ thêm sản phẩm đó
        ở dgv_sanPham vào listview ngược lại thì sẽ select lại sản phẩm đó ở lv_hoaDon, cả 2 trường hợp đều lưu lại vị trí select
        */
        private void dgv_sanPham_banHangControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0 || index >= dgv_sanPham_banHangControl.RowCount)
            {
                return;
            }

            DataGridViewRow row = dgv_sanPham_banHangControl.Rows[index];

            ListViewItem lvItem = new ListViewItem();
            lvItem.Name = row.Cells["ID_PRODUCT"].Value.ToString();
            lvItem.SubItems.Add(row.Cells["NAME_PRODUCT"].Value.ToString());
            lvItem.SubItems.Add(row.Cells["SPECIFICATION"].Value.ToString());
            lvItem.SubItems.Add(row.Cells["PRICE"].Value.ToString());
            lvItem.SubItems.Add("1");
            lvItem.SubItems.Add(row.Cells["PRICE"].Value.ToString());
            lvItem.SubItems.Add(row.Cells["ID_PRODUCT"].Value.ToString());

            if (lv_hoaDon_banHangControl.Items.ContainsKey(row.Cells["ID_PRODUCT"].Value.ToString()))
            {
                position = lv_hoaDon_banHangControl.Items.IndexOfKey(row.Cells["ID_PRODUCT"].Value.ToString());
                lv_hoaDon_banHangControl.Items[position].Selected = true;      
            }
            else
            {
                lv_hoaDon_banHangControl.Items.Add(lvItem);
                String temp = lb_thanhTien_banHangControl.Text.Replace(" VND", "");
                float price = float.Parse(temp) + float.Parse(row.Cells["PRICE"].Value.ToString());
                lb_thanhTien_banHangControl.Text = price.ToString() + " VND";
                position = lv_hoaDon_banHangControl.Items.IndexOfKey(row.Cells["ID_PRODUCT"].Value.ToString());
                lv_hoaDon_banHangControl.Items[position].Selected = true;
            }
            //memento
            cardCareTaker.saveMememtoCard(cardModel.save());
            cardModel.items = getListItemInCard();


            tb_nhapSoLuongSanPham_banHang.Focus();
        }

        /*
        - Khi select ở listView thay đổi thì sẽ chạy duyệt hết list view coi dòng nào được select và lấy số lượng hàng ở dòng đó in lên tb_nhapSoLuong
        - Và lưu lại vị trí select
        */
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem items in lv_hoaDon_banHangControl.SelectedItems)
            {
                tb_nhapSoLuongSanPham_banHang.Text = items.SubItems[4].Text;
                position = lv_hoaDon_banHangControl.Items.IndexOfKey(items.Name);
            }
        }

        /*
        - Kiểm tra số lượng khi bấm nút enter ở tb_nhapSoLuong
        - Nếu số lượng ở tb_nhapSoLuong bằng 0 hoặc "" thì sẽ xuất ra MessageBox
        - Ngược lại thì sẽ duyệt hết các phần tử lv_hoaDon kiếm hàng nào có id trùng với id cần tìm và xóa phần tử đó, đồng thời thêm phần tử mới
        vô số lượng được cập nhật 
        */
        private void tb_nhapSoLuongSanPham_banHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_nhapSoLuongSanPham_banHang.Text.Equals("0") || tb_nhapSoLuongSanPham_banHang.Text.Equals(""))
                {
                    MessageBox.Show("Hãy nhập số lượng sản phẩm lớn hơn không");
                    return;
                }
                foreach (ListViewItem items in lv_hoaDon_banHangControl.SelectedItems)
                {
                    //memento
                    cardCareTaker.saveMememtoCard(cardModel.save());

                    ListViewItem lvItem2 = new ListViewItem();
                    lvItem2.Name = items.Name;
                    lvItem2.SubItems.Add(items.SubItems[1].Text);
                    lvItem2.SubItems.Add(items.SubItems[2].Text);
                    lvItem2.SubItems.Add(items.SubItems[3].Text);


                    int amount = int.Parse(tb_nhapSoLuongSanPham_banHang.Text) ;
                    lvItem2.SubItems.Add(amount.ToString());

                    long price = int.Parse(items.SubItems[3].Text) * amount;
                    lvItem2.SubItems.Add(price.ToString());

                    String temp = lb_thanhTien_banHangControl.Text.Replace(" VND", "");
                    float price_label = float.Parse(temp) + float.Parse(price.ToString()) - float.Parse(items.SubItems[5].Text);
                    lb_thanhTien_banHangControl.Text = price_label.ToString() + " VND";

                    lv_hoaDon_banHangControl.Items.RemoveAt(position);
                    lv_hoaDon_banHangControl.Items.Insert(position, lvItem2);
                    position = lv_hoaDon_banHangControl.Items.IndexOfKey(items.Name);
                    lv_hoaDon_banHangControl.Items[position].Selected = true;

                    //memento
                    cardModel.items = getListItemInCard();
                }
            }
        }

        /*
         - Khi lb_thanhTien thay đổi dữ liệu thì đồng thời cũng tính lại lb_tongTien
         */
        private void lb_thanhTien_banHangControl_TextChanged(object sender, EventArgs e)
        {
            if (lb_thanhTien_banHangControl.Text.Equals(""))
            {
                return;
            }
            else
            {
                float thanh_tien = float.Parse(lb_thanhTien_banHangControl.Text.Replace(" VND", ""));
                float giam_gia = float.Parse(lb_giamGia_banHangControl.Text.Replace("%", ""));
                float total = thanh_tien - thanh_tien * (giam_gia / 100);
                lb_tongTien_banHangControl.Text = total.ToString() + " VND";
            }
        }

        /*
        - Khi dữ liệu ở lb_giamGia thay đổi thì cũng tính lại lb_tongTien 
        */
        private void lb_giamGia_banHangControl_TextChanged(object sender, EventArgs e)
        {
            if (lb_thanhTien_banHangControl.Text.Equals(""))
            {
                return;
            }
            else
            {
                float thanh_tien = float.Parse(lb_thanhTien_banHangControl.Text.Replace(" VND", ""));
                float giam_gia = float.Parse(lb_giamGia_banHangControl.Text.Replace("%", ""));
                float total = thanh_tien - thanh_tien * (giam_gia / 100);
                lb_tongTien_banHangControl.Text = total.ToString() + " VND";
            }
        }

        /*
         - Khi bấm nút xóa thì sẽ duyệt hết lv_hoaDon kiếm hàng nào được select và xóa dòng đó, đồng thời phải trừ đi số tiền của sản phẩm đó ra
         và cập nhật lại lb_thanhTien và lưu lại vị trí position trước phần tử đó.
         */
        private void bt_xoa_banHangControl_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem items in lv_hoaDon_banHangControl.SelectedItems)
            {
                //memento
                cardCareTaker.saveMememtoCard(cardModel.save());

                String temp = lb_thanhTien_banHangControl.Text.Replace(" VND", "");
                float price_label = float.Parse(temp)  - float.Parse(items.SubItems[5].Text);
                lb_thanhTien_banHangControl.Text = price_label.ToString() + " VND";

                lv_hoaDon_banHangControl.Items.RemoveAt(position);
                position = lv_hoaDon_banHangControl.Items.IndexOfKey(items.Name);

                //memento
                cardModel.items = getListItemInCard();
                if (position - 1 < 0)
                {
                    return;
                }
                else
                {
                    lv_hoaDon_banHangControl.Items[position - 1].Selected = true;
                }
            }
        }

        /*
         - Khi bấm nút thanh toán thì sẽ kiểm tra trong lv_hoaDon có phần tử nào không nếu không thì xuất ra MessageBox còn nếu có thì chuyển xuống
         hàm checkInfo() để kiểm tra thông tin trước khi thanh toán và sau đó là thêm hóa đơn qua hàm addBill()
        */
        private void bt_thanhToan_banHangControl_Click(object sender, EventArgs e)
        {
            if (lv_hoaDon_banHangControl.Items.Count > 0)
            {
                if (checkInfo())
                {
                    addBill();
                    //memento
                    cardCareTaker.clearAllMementoCard();
                }
                else
                {
                    MessageBox.Show("Hãy điền đầy đủ và chính xác thông tin");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Không có sản phẩm cần thanh toán");
                return;
            }
            
        }

        /*
         - Trước khi thêm hóa đơn thì kiểm tra số điện thoại đúng chưa và sau đó thêm bill qua class BillDao
         - Nếu thêm hóa đơn thành công thì sẽ lấy số ID lớn nhất ở bảng BILL qua class BillDap và bắt đầu thêm chi tiết hóa đơn qua hàm addDetailBill()
        */
        private void addBill()
        {
            model.Bill bill = new model.Bill();
            bill.total_price = float.Parse(lb_tongTien_banHangControl.Text.Replace(" VND", ""));
            bill.invoice_day = dtp_ngayNhap_banHangControl.Value;
            bill.id_employee = Program.currentEmployee.id_employee;

            if (tb_sdtKhachHang_banHangControl.Text.Equals(""))
            {
                bill.phone_number_customer = "";
            }
            else
            {
                bill.phone_number_customer = tb_sdtKhachHang_banHangControl.Text;
            }
            bill.id_envent = int.Parse(dis_event_data.Rows[cb_suKien_banHangControl.SelectedIndex]["ID_EVENT"].ToString());

            if (bill_dao.addBill(bill))
            {
                max = bill_dao.getMaxID();

                lb_thanhTien_banHangControl.Text = "0 VND";
                lb_tongTien_banHangControl.Text = "0 VND";
                MessageBox.Show("Thanh toán thành công");
                addDetailBill();
                notifyOtherControlDataChange(TypeDataChange.BILL);
                notifyOtherControlDataChange(TypeDataChange.PRODUCT);
                return;
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn không thành công");
                return;
            }
        }

        /*
         - Duyệt từng phần tử ở trong lv_hoaDon và lấy dữ liệu từng dòng thêm vào chi tiết hóa đơn qua class DetailBillDao và sau khi thêm mỗi dòng
         thì đồng thời thực hiện việc xóa dòng đó ở lv_hoaDon.
         - Nếu việc thêm chi tiết hóa đơn không thành công thì sẽ xuất ra MessageBox
         */
        private void addDetailBill()
        {
            foreach (ListViewItem items in lv_hoaDon_banHangControl.Items)
            {

                model.DetailBill detailBill = new model.DetailBill();
                detailBill.id_bill = max;
                detailBill.id_product = items.Name;
                detailBill.amount = int.Parse(items.SubItems[4].Text);
                detailBill.price = int.Parse(items.SubItems[5].Text);
                
                if (!detail_bill.addDetailBill(detailBill))
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn không thành công");
                }

                updateAmountProduct(items.Name, detailBill.amount);

                lv_hoaDon_banHangControl.Items.Remove(items);
            }
            bt_refresh_banHangControl_Click(null, null);
        }

        /*
         - Cập nhật lại kho sản phẩm 
        */
        private void updateAmountProduct(String id, int amount)
        {
            product_dao.updateAmountProduct(id, amount, 0);
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            //memento
            cardModel.undo(cardCareTaker.popOutMememtoCard());
            lv_hoaDon_banHangControl.Items.Clear();
            float totalPrice = 0f;
            foreach (ListViewItem listViewItem in cardModel.items)
            {
                lv_hoaDon_banHangControl.Items.Add(listViewItem);
                totalPrice += float.Parse(listViewItem.SubItems[5].Text);
            }
            lb_thanhTien_banHangControl.Text = totalPrice.ToString() + " VND";

        }
    }
}
