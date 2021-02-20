using System;
using System.Windows.Forms;

namespace QuanLyCosmestic.ui
{
    public partial class FormLogin : Form
    {
        private dao.AccountDAO accountDAO;

        public FormLogin()
        {
            InitializeComponent();
            accountDAO = dao.AccountDAO.getInstance();
        }

        private void bt_dangNhap_login_Click(object sender, EventArgs e)
        {
            checkUser();
        }

        private void bt_thoat_login_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_tenDangNhap_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkUser();
            }
        }


        private void tb_matKhau_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkUser();
            }
        }

       /*
        - Kiểm tra người dùng có tồn tại hay không  
        - Bước đầu kiểm tra thông tin điền đầy đủ chưa nếu chưa thì xuất ra MessageBox  
        - Ngược lại thì gọi đến class AccountDao để dùng câu lệnh sql kiểm tra tài khoản có hợp lệ không nếu hợp lệ thì chuyển sang formHome 
        ngược lại xuất ra MessageBox
        */
        private void checkUser()
        {
            String userName = tb_tenDangNhap_login.Text;
            String password = tb_matKhau_login.Text;

            if (userName.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Hãy điền đủ thông tin");
                return;
            }
            else
            {
                Boolean check = accountDAO.checkAccountExist(userName, password);
                if (check)
                {
                    this.Hide();
                    ui.FormHome formHome = new ui.FormHome();
                    Program.newForm = 0;
                    formHome.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai thông tin");
                    return;
                }
            }
        }   
    }
}
