using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyKhoSieuThi
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*') // Nếu đang ẩn mật khẩu
            {
                txtPassword.PasswordChar = '\0'; // Hiển thị mật khẩu

            }
            else
            {
                txtPassword.PasswordChar = '*'; // Ẩn mật khẩu

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool AuthenticateUser(string username, string password)
        {
            try
            {
           
                XDocument doc = XDocument.Load("login.xml");

                // Tìm người dùng trong XML
                var user = doc.Descendants("User")
                              .FirstOrDefault(x => x.Element("Username")?.Value == username && x.Element("Password")?.Value == password);

                return user != null; // Nếu tìm thấy người dùng và mật khẩu đúng, trả về true
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi đọc file XML: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
