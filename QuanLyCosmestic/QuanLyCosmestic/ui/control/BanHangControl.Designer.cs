namespace QuanLyCosmestic.ui
{
    partial class BanHangControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_sanPham_banHangControl = new System.Windows.Forms.DataGridView();
            this.bt_timKiemSanPham_banHangControl = new System.Windows.Forms.Button();
            this.tb_timKiemSanPham_banHangControl = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_nhapSoLuongSanPham_banHang = new System.Windows.Forms.TextBox();
            this.lb_tongTien_banHangControl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lb_giamGia_banHangControl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_thanhTien_banHangControl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lv_hoaDon_banHangControl = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtp_ngayNhap_banHangControl = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_suKien_banHangControl = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_sdtKhachHang_banHangControl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_nhanVienBanHang_banHangControl = new System.Windows.Forms.Label();
            this.tb_hoTenKhachHang_banHangControl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_refresh_banHangControl = new System.Windows.Forms.Button();
            this.bt_xoa_banHangControl = new System.Windows.Forms.Button();
            this.bt_thanhToan_banHangControl = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanPham_banHangControl)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgv_sanPham_banHangControl);
            this.panel1.Controls.Add(this.bt_timKiemSanPham_banHangControl);
            this.panel1.Controls.Add(this.tb_timKiemSanPham_banHangControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 636);
            this.panel1.TabIndex = 0;
            // 
            // dgv_sanPham_banHangControl
            // 
            this.dgv_sanPham_banHangControl.AllowUserToAddRows = false;
            this.dgv_sanPham_banHangControl.AllowUserToDeleteRows = false;
            this.dgv_sanPham_banHangControl.AllowUserToResizeRows = false;
            this.dgv_sanPham_banHangControl.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_sanPham_banHangControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sanPham_banHangControl.Location = new System.Drawing.Point(3, 76);
            this.dgv_sanPham_banHangControl.MultiSelect = false;
            this.dgv_sanPham_banHangControl.Name = "dgv_sanPham_banHangControl";
            this.dgv_sanPham_banHangControl.ReadOnly = true;
            this.dgv_sanPham_banHangControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_sanPham_banHangControl.Size = new System.Drawing.Size(432, 543);
            this.dgv_sanPham_banHangControl.TabIndex = 3;
            this.dgv_sanPham_banHangControl.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sanPham_banHangControl_CellClick);
            // 
            // bt_timKiemSanPham_banHangControl
            // 
            this.bt_timKiemSanPham_banHangControl.Location = new System.Drawing.Point(360, 30);
            this.bt_timKiemSanPham_banHangControl.Name = "bt_timKiemSanPham_banHangControl";
            this.bt_timKiemSanPham_banHangControl.Size = new System.Drawing.Size(75, 23);
            this.bt_timKiemSanPham_banHangControl.TabIndex = 1;
            this.bt_timKiemSanPham_banHangControl.Text = "Tìm Kiếm";
            this.bt_timKiemSanPham_banHangControl.UseVisualStyleBackColor = true;
            this.bt_timKiemSanPham_banHangControl.Click += new System.EventHandler(this.bt_timKiemSanPham_banHangControl_Click);
            // 
            // tb_timKiemSanPham_banHangControl
            // 
            this.tb_timKiemSanPham_banHangControl.Location = new System.Drawing.Point(3, 31);
            this.tb_timKiemSanPham_banHangControl.Name = "tb_timKiemSanPham_banHangControl";
            this.tb_timKiemSanPham_banHangControl.Size = new System.Drawing.Size(352, 20);
            this.tb_timKiemSanPham_banHangControl.TabIndex = 0;
            this.tb_timKiemSanPham_banHangControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_timKiemSanPham_banHangControl_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tb_nhapSoLuongSanPham_banHang);
            this.panel2.Controls.Add(this.lb_tongTien_banHangControl);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lb_giamGia_banHangControl);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lb_thanhTien_banHangControl);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lv_hoaDon_banHangControl);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(549, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 636);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nhập số lượng sản phẩm:";
            // 
            // tb_nhapSoLuongSanPham_banHang
            // 
            this.tb_nhapSoLuongSanPham_banHang.Location = new System.Drawing.Point(142, 194);
            this.tb_nhapSoLuongSanPham_banHang.Name = "tb_nhapSoLuongSanPham_banHang";
            this.tb_nhapSoLuongSanPham_banHang.Size = new System.Drawing.Size(100, 20);
            this.tb_nhapSoLuongSanPham_banHang.TabIndex = 12;
            this.tb_nhapSoLuongSanPham_banHang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_nhapSoLuongSanPham_banHang_KeyDown);
            // 
            // lb_tongTien_banHangControl
            // 
            this.lb_tongTien_banHangControl.AutoSize = true;
            this.lb_tongTien_banHangControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tongTien_banHangControl.ForeColor = System.Drawing.Color.Red;
            this.lb_tongTien_banHangControl.Location = new System.Drawing.Point(97, 601);
            this.lb_tongTien_banHangControl.Name = "lb_tongTien_banHangControl";
            this.lb_tongTien_banHangControl.Size = new System.Drawing.Size(56, 18);
            this.lb_tongTien_banHangControl.TabIndex = 11;
            this.lb_tongTien_banHangControl.Text = "0 VND";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(3, 601);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 18);
            this.label11.TabIndex = 10;
            this.label11.Text = "Tổng Tiền:";
            // 
            // lb_giamGia_banHangControl
            // 
            this.lb_giamGia_banHangControl.AutoSize = true;
            this.lb_giamGia_banHangControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_giamGia_banHangControl.Location = new System.Drawing.Point(99, 578);
            this.lb_giamGia_banHangControl.Name = "lb_giamGia_banHangControl";
            this.lb_giamGia_banHangControl.Size = new System.Drawing.Size(27, 16);
            this.lb_giamGia_banHangControl.TabIndex = 8;
            this.lb_giamGia_banHangControl.Text = "0%";
            this.lb_giamGia_banHangControl.TextChanged += new System.EventHandler(this.lb_giamGia_banHangControl_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 578);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 7;
            this.label10.Text = "Giảm Giá:";
            // 
            // lb_thanhTien_banHangControl
            // 
            this.lb_thanhTien_banHangControl.AutoSize = true;
            this.lb_thanhTien_banHangControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_thanhTien_banHangControl.Location = new System.Drawing.Point(99, 553);
            this.lb_thanhTien_banHangControl.Name = "lb_thanhTien_banHangControl";
            this.lb_thanhTien_banHangControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_thanhTien_banHangControl.Size = new System.Drawing.Size(47, 16);
            this.lb_thanhTien_banHangControl.TabIndex = 6;
            this.lb_thanhTien_banHangControl.Text = "0 VND";
            this.lb_thanhTien_banHangControl.TextChanged += new System.EventHandler(this.lb_thanhTien_banHangControl_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 553);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Thành Tiền:";
            // 
            // lv_hoaDon_banHangControl
            // 
            this.lv_hoaDon_banHangControl.BackColor = System.Drawing.SystemColors.Window;
            this.lv_hoaDon_banHangControl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader1});
            this.lv_hoaDon_banHangControl.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lv_hoaDon_banHangControl.FullRowSelect = true;
            this.lv_hoaDon_banHangControl.HideSelection = false;
            this.lv_hoaDon_banHangControl.Location = new System.Drawing.Point(1, 220);
            this.lv_hoaDon_banHangControl.MultiSelect = false;
            this.lv_hoaDon_banHangControl.Name = "lv_hoaDon_banHangControl";
            this.lv_hoaDon_banHangControl.Size = new System.Drawing.Size(392, 316);
            this.lv_hoaDon_banHangControl.TabIndex = 1;
            this.lv_hoaDon_banHangControl.UseCompatibleStateImageBehavior = false;
            this.lv_hoaDon_banHangControl.View = System.Windows.Forms.View.Details;
            this.lv_hoaDon_banHangControl.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 1;
            this.columnHeader7.Text = "";
            this.columnHeader7.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 1;
            this.columnHeader8.Text = "Tên SP";
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 2;
            this.columnHeader9.Text = "Đặc tính";
            this.columnHeader9.Width = 83;
            // 
            // columnHeader10
            // 
            this.columnHeader10.DisplayIndex = 3;
            this.columnHeader10.Text = "Đơn giá";
            this.columnHeader10.Width = 77;
            // 
            // columnHeader11
            // 
            this.columnHeader11.DisplayIndex = 4;
            this.columnHeader11.Text = "Số lượng";
            // 
            // columnHeader12
            // 
            this.columnHeader12.DisplayIndex = 5;
            this.columnHeader12.Text = "Thành tiền";
            this.columnHeader12.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dtp_ngayNhap_banHangControl);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cb_suKien_banHangControl);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tb_sdtKhachHang_banHangControl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lb_nhanVienBanHang_banHangControl);
            this.groupBox1.Controls.Add(this.tb_hoTenKhachHang_banHangControl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Thông tin hóa đơn";
            // 
            // dtp_ngayNhap_banHangControl
            // 
            this.dtp_ngayNhap_banHangControl.Location = new System.Drawing.Point(122, 99);
            this.dtp_ngayNhap_banHangControl.Name = "dtp_ngayNhap_banHangControl";
            this.dtp_ngayNhap_banHangControl.Size = new System.Drawing.Size(189, 20);
            this.dtp_ngayNhap_banHangControl.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Ngày Nhập:";
            // 
            // cb_suKien_banHangControl
            // 
            this.cb_suKien_banHangControl.FormattingEnabled = true;
            this.cb_suKien_banHangControl.Location = new System.Drawing.Point(122, 72);
            this.cb_suKien_banHangControl.Name = "cb_suKien_banHangControl";
            this.cb_suKien_banHangControl.Size = new System.Drawing.Size(189, 21);
            this.cb_suKien_banHangControl.TabIndex = 8;
            this.cb_suKien_banHangControl.SelectedIndexChanged += new System.EventHandler(this.cb_suKien_banHangControl_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Sự Kiện:";
            // 
            // tb_sdtKhachHang_banHangControl
            // 
            this.tb_sdtKhachHang_banHangControl.Location = new System.Drawing.Point(122, 23);
            this.tb_sdtKhachHang_banHangControl.Name = "tb_sdtKhachHang_banHangControl";
            this.tb_sdtKhachHang_banHangControl.Size = new System.Drawing.Size(189, 20);
            this.tb_sdtKhachHang_banHangControl.TabIndex = 4;
            this.tb_sdtKhachHang_banHangControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_sdtKhachHang_banHangControl_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số Điện Thoại:";
            // 
            // lb_nhanVienBanHang_banHangControl
            // 
            this.lb_nhanVienBanHang_banHangControl.AutoSize = true;
            this.lb_nhanVienBanHang_banHangControl.Location = new System.Drawing.Point(119, 131);
            this.lb_nhanVienBanHang_banHangControl.Name = "lb_nhanVienBanHang_banHangControl";
            this.lb_nhanVienBanHang_banHangControl.Size = new System.Drawing.Size(35, 13);
            this.lb_nhanVienBanHang_banHangControl.TabIndex = 4;
            this.lb_nhanVienBanHang_banHangControl.Text = "label5";
            // 
            // tb_hoTenKhachHang_banHangControl
            // 
            this.tb_hoTenKhachHang_banHangControl.Location = new System.Drawing.Point(122, 46);
            this.tb_hoTenKhachHang_banHangControl.Name = "tb_hoTenKhachHang_banHangControl";
            this.tb_hoTenKhachHang_banHangControl.ReadOnly = true;
            this.tb_hoTenKhachHang_banHangControl.Size = new System.Drawing.Size(189, 20);
            this.tb_hoTenKhachHang_banHangControl.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nhân viên bán hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khách Hàng :";
            // 
            // bt_refresh_banHangControl
            // 
            this.bt_refresh_banHangControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_refresh_banHangControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_refresh_banHangControl.Location = new System.Drawing.Point(451, 391);
            this.bt_refresh_banHangControl.Name = "bt_refresh_banHangControl";
            this.bt_refresh_banHangControl.Size = new System.Drawing.Size(87, 65);
            this.bt_refresh_banHangControl.TabIndex = 3;
            this.bt_refresh_banHangControl.Text = "Làm mới đơn hàng";
            this.bt_refresh_banHangControl.UseVisualStyleBackColor = false;
            this.bt_refresh_banHangControl.Click += new System.EventHandler(this.bt_refresh_banHangControl_Click);
            // 
            // bt_xoa_banHangControl
            // 
            this.bt_xoa_banHangControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_xoa_banHangControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_xoa_banHangControl.Location = new System.Drawing.Point(451, 475);
            this.bt_xoa_banHangControl.Name = "bt_xoa_banHangControl";
            this.bt_xoa_banHangControl.Size = new System.Drawing.Size(87, 84);
            this.bt_xoa_banHangControl.TabIndex = 5;
            this.bt_xoa_banHangControl.Text = "    Xóa       sản phẩm trong đơn hàng";
            this.bt_xoa_banHangControl.UseVisualStyleBackColor = false;
            this.bt_xoa_banHangControl.Click += new System.EventHandler(this.bt_xoa_banHangControl_Click);
            // 
            // bt_thanhToan_banHangControl
            // 
            this.bt_thanhToan_banHangControl.BackColor = System.Drawing.Color.Tomato;
            this.bt_thanhToan_banHangControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_thanhToan_banHangControl.Location = new System.Drawing.Point(451, 579);
            this.bt_thanhToan_banHangControl.Name = "bt_thanhToan_banHangControl";
            this.bt_thanhToan_banHangControl.Size = new System.Drawing.Size(87, 39);
            this.bt_thanhToan_banHangControl.TabIndex = 6;
            this.bt_thanhToan_banHangControl.Text = "THANH TOÁN";
            this.bt_thanhToan_banHangControl.UseVisualStyleBackColor = false;
            this.bt_thanhToan_banHangControl.Click += new System.EventHandler(this.bt_thanhToan_banHangControl_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "Mã SP";
            this.columnHeader1.Width = 0;
            // 
            // BanHangControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.Controls.Add(this.bt_thanhToan_banHangControl);
            this.Controls.Add(this.bt_xoa_banHangControl);
            this.Controls.Add(this.bt_refresh_banHangControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BanHangControl";
            this.Size = new System.Drawing.Size(950, 636);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanPham_banHangControl)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_timKiemSanPham_banHangControl;
        private System.Windows.Forms.TextBox tb_timKiemSanPham_banHangControl;
        private System.Windows.Forms.DataGridView dgv_sanPham_banHangControl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lv_hoaDon_banHangControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_sdtKhachHang_banHangControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_hoTenKhachHang_banHangControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_nhanVienBanHang_banHangControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_thanhTien_banHangControl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_suKien_banHangControl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtp_ngayNhap_banHangControl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_giamGia_banHangControl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_tongTien_banHangControl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bt_refresh_banHangControl;
        private System.Windows.Forms.Button bt_xoa_banHangControl;
        private System.Windows.Forms.Button bt_thanhToan_banHangControl;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_nhapSoLuongSanPham_banHang;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
