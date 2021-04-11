namespace QuanLyCosmestic.ui.control
{
    partial class LichSuXuatHoaDonControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_ngayBatDau_lichSuXuatHoaDon = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp_ngayKetThuc_lichSuXuatHoaDon = new System.Windows.Forms.DateTimePicker();
            this.dtv_hoaDon_lichSuXuatHoaDon = new System.Windows.Forms.DataGridView();
            this.bt_timKiem_lichSuXuatHoaDonControl = new System.Windows.Forms.Button();
            this.dtv_suKien_lichSuXuatHoaDonControl = new System.Windows.Forms.DataGridView();
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl = new System.Windows.Forms.DataGridView();
            this.bt_refresh_lichSuXuatHoaDonControl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtv_hoaDon_lichSuXuatHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtv_suKien_lichSuXuatHoaDonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày bắt đầu:";
            // 
            // dtp_ngayBatDau_lichSuXuatHoaDon
            // 
            this.dtp_ngayBatDau_lichSuXuatHoaDon.Location = new System.Drawing.Point(97, 29);
            this.dtp_ngayBatDau_lichSuXuatHoaDon.Name = "dtp_ngayBatDau_lichSuXuatHoaDon";
            this.dtp_ngayBatDau_lichSuXuatHoaDon.Size = new System.Drawing.Size(200, 20);
            this.dtp_ngayBatDau_lichSuXuatHoaDon.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày kết thúc:";
            // 
            // dtp_ngayKetThuc_lichSuXuatHoaDon
            // 
            this.dtp_ngayKetThuc_lichSuXuatHoaDon.Location = new System.Drawing.Point(410, 28);
            this.dtp_ngayKetThuc_lichSuXuatHoaDon.Name = "dtp_ngayKetThuc_lichSuXuatHoaDon";
            this.dtp_ngayKetThuc_lichSuXuatHoaDon.Size = new System.Drawing.Size(200, 20);
            this.dtp_ngayKetThuc_lichSuXuatHoaDon.TabIndex = 3;
            // 
            // dtv_hoaDon_lichSuXuatHoaDon
            // 
            this.dtv_hoaDon_lichSuXuatHoaDon.AllowUserToAddRows = false;
            this.dtv_hoaDon_lichSuXuatHoaDon.AllowUserToDeleteRows = false;
            this.dtv_hoaDon_lichSuXuatHoaDon.AllowUserToResizeRows = false;
            this.dtv_hoaDon_lichSuXuatHoaDon.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtv_hoaDon_lichSuXuatHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtv_hoaDon_lichSuXuatHoaDon.Location = new System.Drawing.Point(19, 71);
            this.dtv_hoaDon_lichSuXuatHoaDon.MultiSelect = false;
            this.dtv_hoaDon_lichSuXuatHoaDon.Name = "dtv_hoaDon_lichSuXuatHoaDon";
            this.dtv_hoaDon_lichSuXuatHoaDon.ReadOnly = true;
            this.dtv_hoaDon_lichSuXuatHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtv_hoaDon_lichSuXuatHoaDon.Size = new System.Drawing.Size(459, 544);
            this.dtv_hoaDon_lichSuXuatHoaDon.TabIndex = 4;
            this.dtv_hoaDon_lichSuXuatHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtv_hoaDon_lichSuXuatHoaDon_CellClick);
            // 
            // bt_timKiem_lichSuXuatHoaDonControl
            // 
            this.bt_timKiem_lichSuXuatHoaDonControl.Location = new System.Drawing.Point(630, 28);
            this.bt_timKiem_lichSuXuatHoaDonControl.Name = "bt_timKiem_lichSuXuatHoaDonControl";
            this.bt_timKiem_lichSuXuatHoaDonControl.Size = new System.Drawing.Size(75, 23);
            this.bt_timKiem_lichSuXuatHoaDonControl.TabIndex = 7;
            this.bt_timKiem_lichSuXuatHoaDonControl.Text = "Tìm kiếm";
            this.bt_timKiem_lichSuXuatHoaDonControl.UseVisualStyleBackColor = true;
            this.bt_timKiem_lichSuXuatHoaDonControl.Click += new System.EventHandler(this.bt_timKiem_lichSuXuatHoaDonControl_Click);
            // 
            // dtv_suKien_lichSuXuatHoaDonControl
            // 
            this.dtv_suKien_lichSuXuatHoaDonControl.AllowUserToAddRows = false;
            this.dtv_suKien_lichSuXuatHoaDonControl.AllowUserToDeleteRows = false;
            this.dtv_suKien_lichSuXuatHoaDonControl.AllowUserToResizeRows = false;
            this.dtv_suKien_lichSuXuatHoaDonControl.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtv_suKien_lichSuXuatHoaDonControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtv_suKien_lichSuXuatHoaDonControl.Location = new System.Drawing.Point(499, 71);
            this.dtv_suKien_lichSuXuatHoaDonControl.MultiSelect = false;
            this.dtv_suKien_lichSuXuatHoaDonControl.Name = "dtv_suKien_lichSuXuatHoaDonControl";
            this.dtv_suKien_lichSuXuatHoaDonControl.ReadOnly = true;
            this.dtv_suKien_lichSuXuatHoaDonControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtv_suKien_lichSuXuatHoaDonControl.Size = new System.Drawing.Size(432, 209);
            this.dtv_suKien_lichSuXuatHoaDonControl.TabIndex = 8;
            // 
            // dtv_chiTietHoaDon_lichSuXuatHoaDonControl
            // 
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.AllowUserToAddRows = false;
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.AllowUserToDeleteRows = false;
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.AllowUserToResizeRows = false;
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.Location = new System.Drawing.Point(499, 302);
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.MultiSelect = false;
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.Name = "dtv_chiTietHoaDon_lichSuXuatHoaDonControl";
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.ReadOnly = true;
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.Size = new System.Drawing.Size(432, 313);
            this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl.TabIndex = 9;
            // 
            // bt_refresh_lichSuXuatHoaDonControl
            // 
            this.bt_refresh_lichSuXuatHoaDonControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_refresh_lichSuXuatHoaDonControl.Location = new System.Drawing.Point(720, 29);
            this.bt_refresh_lichSuXuatHoaDonControl.Name = "bt_refresh_lichSuXuatHoaDonControl";
            this.bt_refresh_lichSuXuatHoaDonControl.Size = new System.Drawing.Size(75, 23);
            this.bt_refresh_lichSuXuatHoaDonControl.TabIndex = 10;
            this.bt_refresh_lichSuXuatHoaDonControl.Text = "Refresh";
            this.bt_refresh_lichSuXuatHoaDonControl.UseVisualStyleBackColor = false;
            this.bt_refresh_lichSuXuatHoaDonControl.Click += new System.EventHandler(this.bt_refresh_lichSuXuatHoaDonControl_Click);
            // 
            // LichSuXuatHoaDonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.Controls.Add(this.bt_refresh_lichSuXuatHoaDonControl);
            this.Controls.Add(this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl);
            this.Controls.Add(this.dtv_suKien_lichSuXuatHoaDonControl);
            this.Controls.Add(this.bt_timKiem_lichSuXuatHoaDonControl);
            this.Controls.Add(this.dtv_hoaDon_lichSuXuatHoaDon);
            this.Controls.Add(this.dtp_ngayKetThuc_lichSuXuatHoaDon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_ngayBatDau_lichSuXuatHoaDon);
            this.Controls.Add(this.label1);
            this.Name = "LichSuXuatHoaDonControl";
            this.Size = new System.Drawing.Size(950, 636);
            ((System.ComponentModel.ISupportInitialize)(this.dtv_hoaDon_lichSuXuatHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtv_suKien_lichSuXuatHoaDonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtv_chiTietHoaDon_lichSuXuatHoaDonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_ngayBatDau_lichSuXuatHoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp_ngayKetThuc_lichSuXuatHoaDon;
        private System.Windows.Forms.DataGridView dtv_hoaDon_lichSuXuatHoaDon;
        private System.Windows.Forms.Button bt_timKiem_lichSuXuatHoaDonControl;
        private System.Windows.Forms.DataGridView dtv_suKien_lichSuXuatHoaDonControl;
        private System.Windows.Forms.DataGridView dtv_chiTietHoaDon_lichSuXuatHoaDonControl;
        private System.Windows.Forms.Button bt_refresh_lichSuXuatHoaDonControl;
    }
}
