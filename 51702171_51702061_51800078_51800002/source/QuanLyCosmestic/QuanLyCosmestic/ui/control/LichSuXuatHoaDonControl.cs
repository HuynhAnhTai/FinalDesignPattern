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
using QuanLyCosmestic.mediatorControlScreen;

namespace QuanLyCosmestic.ui.control
{
    public partial class LichSuXuatHoaDonControl : ControlScreen
    {
        private dao.BillDao bill_dao;
        private dao.DetailBillDao detail_dao;
        private dao.EventDao event_dao;
        private bool dataBillChange = true;

        int id_bill;
        int id_event;

        public LichSuXuatHoaDonControl()
        {
            InitializeComponent();
            bill_dao = dao.BillDao.getInstance();
            detail_dao = dao.DetailBillDao.getInstance();
            event_dao = dao.EventDao.getInstance();
            loadData();
        }

        /*
         - Dùng xóa các lựa chọn ở dtv_hoaDon
         */
        public override void clear()
        {
            dtv_hoaDon_lichSuXuatHoaDon.ClearSelection();
        }

        public override void dataOfOtherControlChange(TypeDataChange typeUpdate)
        {
            if (typeUpdate == TypeDataChange.BILL)
            {
                dataBillChange = true;
            }
        }

        /*
         - Load dữ liệu đưa vào dtv_hoaDon
         */
        public override void loadData()
        {
            if (dataBillChange)
            {
                dtv_hoaDon_lichSuXuatHoaDon.DataSource = bill_dao.loadData();
                dataBillChange = false;
            }
            dtv_hoaDon_lichSuXuatHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            dtv_hoaDon_lichSuXuatHoaDon.Columns[1].HeaderText = "Tổng giá";
            dtv_hoaDon_lichSuXuatHoaDon.Columns[2].HeaderText = "Ngày xuất hóa đơn";
            dtv_hoaDon_lichSuXuatHoaDon.Columns[3].HeaderText = "Mã nhân viên";
            dtv_hoaDon_lichSuXuatHoaDon.Columns[4].HeaderText = "Số điện thoại khách hàng";
            dtv_hoaDon_lichSuXuatHoaDon.Columns[5].HeaderText = "Mã sự kiện";

            dtv_hoaDon_lichSuXuatHoaDon.ClearSelection();
        }

        /*
         - Khi click chọn mỗi dòng ở dtv_hoaDon thì lấy dữ liệu ở các dòng đó và thêm vào các textBox tương ứng
         - Đồng thời lấy id_bill của dòng đó để lấy dữ liệu chi tiết hóa đơn của bill đó qua class DetailBill và lấy id của sự kiện của dòng đó
         để lấy dữ liệu của sự kiện đó qua class EventDao
         */
        private void dtv_hoaDon_lichSuXuatHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index < 0 || index >= dtv_hoaDon_lichSuXuatHoaDon.RowCount)
            {
                return;
            }

            DataGridViewRow row = dtv_hoaDon_lichSuXuatHoaDon.Rows[index];

            id_bill = int.Parse(row.Cells[0].Value.ToString());
            id_event = int.Parse(row.Cells[5].Value.ToString());

            dtv_chiTietHoaDon_lichSuXuatHoaDonControl.DataSource = detail_dao.loadDataById(id_bill);
            dtv_chiTietHoaDon_lichSuXuatHoaDonControl.Columns[0].HeaderText = "Mã hóa đơn";
            dtv_chiTietHoaDon_lichSuXuatHoaDonControl.Columns[1].HeaderText = "Mã sản phẩm";
            dtv_chiTietHoaDon_lichSuXuatHoaDonControl.Columns[2].HeaderText = "Số lượng";
            dtv_chiTietHoaDon_lichSuXuatHoaDonControl.Columns[3].HeaderText = "Đơn giá";

            dtv_suKien_lichSuXuatHoaDonControl.DataSource = event_dao.loadDataById(id_event);
            dtv_suKien_lichSuXuatHoaDonControl.Columns[0].HeaderText = "Mã sự kiện";
            dtv_suKien_lichSuXuatHoaDonControl.Columns[1].HeaderText = "Tên sự kiện";
            dtv_suKien_lichSuXuatHoaDonControl.Columns[2].HeaderText = "Giảm giá(%)";

        }

        /*
         - Nếu dtp_ngayBatDau <= dtp_ngayKetThuc thì trả về true ngược lại thì false
         */
        public Boolean checkInfo()
        {
            if ((dtp_ngayBatDau_lichSuXuatHoaDon.Value.Ticks / TimeSpan.TicksPerSecond) > 
                (dtp_ngayKetThuc_lichSuXuatHoaDon.Value.Ticks / TimeSpan.TicksPerSecond))
            {
                return false;
            }
            return true;
        }

        /*
         - Khi bấm nút tìm kiếm thì sẽ lấy dữ liệu ở dtp_ngayBatDau gán vô start tương tự với dtp_ngayKetThuc gán vô end
         - Sau đó lấy tất cả các hóa đơn nằm trong khoảng ngày đó và đổ dữ liệu vào dtv_hoaDon
         */
        private void bt_timKiem_lichSuXuatHoaDonControl_Click(object sender, EventArgs e)
        {
            if (checkInfo())
            {
                DateTime start = dtp_ngayBatDau_lichSuXuatHoaDon.Value;
                DateTime end = dtp_ngayKetThuc_lichSuXuatHoaDon.Value;
                dtv_hoaDon_lichSuXuatHoaDon.DataSource = bill_dao.loadDataFromDateToDate(start, end);
            }
            else
            {
                MessageBox.Show("Kiếm tra thông tin ngày");
                return;
            }
        }

        /*
         - Khi bấm nút refresh thì sẽ lấy lại tất cả dữ liệu bill và đổ vào dtv_hoaDon và set lại ngày ở dtp_ngayBatDau và dtp_ngayKetThuc bằng thời gian hiện tại
         */
        private void bt_refresh_lichSuXuatHoaDonControl_Click(object sender, EventArgs e)
        {
            dtp_ngayBatDau_lichSuXuatHoaDon.Value = DateTime.Now;
            dtp_ngayKetThuc_lichSuXuatHoaDon.Value = DateTime.Now;
            loadData();
        }
    }
}
