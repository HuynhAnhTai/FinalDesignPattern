namespace QuanLyCosmestic.ui
{
    partial class FormLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.lb_userName_login = new System.Windows.Forms.Label();
            this.lb_password_login = new System.Windows.Forms.Label();
            this.tb_tenDangNhap_login = new System.Windows.Forms.TextBox();
            this.tb_matKhau_login = new System.Windows.Forms.TextBox();
            this.bt_thoat_login = new System.Windows.Forms.Button();
            this.bt_dangNhap_login = new System.Windows.Forms.Button();
            this.pb_logo_login = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo_login)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_userName_login
            // 
            this.lb_userName_login.AutoSize = true;
            this.lb_userName_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_userName_login.Location = new System.Drawing.Point(12, 155);
            this.lb_userName_login.Name = "lb_userName_login";
            this.lb_userName_login.Size = new System.Drawing.Size(58, 13);
            this.lb_userName_login.TabIndex = 0;
            this.lb_userName_login.Text = "User name";
            // 
            // lb_password_login
            // 
            this.lb_password_login.AutoSize = true;
            this.lb_password_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_password_login.Location = new System.Drawing.Point(17, 187);
            this.lb_password_login.Name = "lb_password_login";
            this.lb_password_login.Size = new System.Drawing.Size(53, 13);
            this.lb_password_login.TabIndex = 1;
            this.lb_password_login.Text = "Password";
            // 
            // tb_tenDangNhap_login
            // 
            this.tb_tenDangNhap_login.Location = new System.Drawing.Point(76, 152);
            this.tb_tenDangNhap_login.Name = "tb_tenDangNhap_login";
            this.tb_tenDangNhap_login.Size = new System.Drawing.Size(257, 20);
            this.tb_tenDangNhap_login.TabIndex = 2;
            this.tb_tenDangNhap_login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_tenDangNhap_login_KeyDown);
            // 
            // tb_matKhau_login
            // 
            this.tb_matKhau_login.Location = new System.Drawing.Point(76, 187);
            this.tb_matKhau_login.Name = "tb_matKhau_login";
            this.tb_matKhau_login.PasswordChar = '*';
            this.tb_matKhau_login.Size = new System.Drawing.Size(257, 20);
            this.tb_matKhau_login.TabIndex = 3;
            this.tb_matKhau_login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_matKhau_login_KeyDown);
            // 
            // bt_thoat_login
            // 
            this.bt_thoat_login.BackColor = System.Drawing.Color.AntiqueWhite;
            this.bt_thoat_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_thoat_login.ForeColor = System.Drawing.Color.Coral;
            this.bt_thoat_login.Location = new System.Drawing.Point(210, 229);
            this.bt_thoat_login.Name = "bt_thoat_login";
            this.bt_thoat_login.Size = new System.Drawing.Size(94, 34);
            this.bt_thoat_login.TabIndex = 4;
            this.bt_thoat_login.Text = "Thoát";
            this.bt_thoat_login.UseVisualStyleBackColor = false;
            this.bt_thoat_login.Click += new System.EventHandler(this.bt_thoat_login_Click);
            // 
            // bt_dangNhap_login
            // 
            this.bt_dangNhap_login.BackColor = System.Drawing.Color.Salmon;
            this.bt_dangNhap_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_dangNhap_login.ForeColor = System.Drawing.Color.PapayaWhip;
            this.bt_dangNhap_login.Location = new System.Drawing.Point(98, 229);
            this.bt_dangNhap_login.Name = "bt_dangNhap_login";
            this.bt_dangNhap_login.Size = new System.Drawing.Size(99, 34);
            this.bt_dangNhap_login.TabIndex = 5;
            this.bt_dangNhap_login.Text = "Đăng Nhập";
            this.bt_dangNhap_login.UseVisualStyleBackColor = false;
            this.bt_dangNhap_login.Click += new System.EventHandler(this.bt_dangNhap_login_Click);
            // 
            // pb_logo_login
            // 
            this.pb_logo_login.Image = ((System.Drawing.Image)(resources.GetObject("pb_logo_login.Image")));
            this.pb_logo_login.Location = new System.Drawing.Point(98, 22);
            this.pb_logo_login.Name = "pb_logo_login";
            this.pb_logo_login.Size = new System.Drawing.Size(156, 108);
            this.pb_logo_login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_logo_login.TabIndex = 7;
            this.pb_logo_login.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLyCosmestic.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(345, 302);
            this.Controls.Add(this.pb_logo_login);
            this.Controls.Add(this.bt_dangNhap_login);
            this.Controls.Add(this.bt_thoat_login);
            this.Controls.Add(this.tb_matKhau_login);
            this.Controls.Add(this.tb_tenDangNhap_login);
            this.Controls.Add(this.lb_password_login);
            this.Controls.Add(this.lb_userName_login);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo_login)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_userName_login;
        private System.Windows.Forms.Label lb_password_login;
        private System.Windows.Forms.TextBox tb_tenDangNhap_login;
        private System.Windows.Forms.TextBox tb_matKhau_login;
        private System.Windows.Forms.Button bt_thoat_login;
        private System.Windows.Forms.Button bt_dangNhap_login;
        private System.Windows.Forms.PictureBox pb_logo_login;
    }
}