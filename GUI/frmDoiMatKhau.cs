using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyHieuSach
{
    public partial class frmDoiMatKhau : Form
    {
        private string emailNguoiDung; // Email của người dùng hiện tại
        private NhanVienBLL bllNV = new NhanVienBLL();
        public frmDoiMatKhau(string email)
        {
            InitializeComponent();
            emailNguoiDung = email; // Lưu email người dùng
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhanMatKhau = txtXacNhanMatKhau.Text;

            // Kiểm tra mật khẩu mới và xác nhận mật khẩu
            if (matKhauMoi != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!");
                return;
            }

            // Gọi BLL để kiểm tra và đổi mật khẩu
            if (bllNV.DoiMatKhau(emailNguoiDung, matKhauCu, matKhauMoi))
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close(); // Đóng form đổi mật khẩu
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng hoặc có lỗi xảy ra!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form đổi mật khẩu
        }
    }
}
