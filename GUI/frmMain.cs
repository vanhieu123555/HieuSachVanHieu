using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theloai_dto;
using BLL;
using DAL;
using System.Drawing.Drawing2D;


namespace QuanLyHieuSach
{
    public partial class frmMain : Form
    {
        private VaiTroDTO vaiTroNguoiDung;
        private VaiTroDTO vaiTro;
        private NhanVienBLL bllNV = new NhanVienBLL();
        private string emailNguoiDung;

        public frmMain(VaiTroDTO vaiTro, string email)
        {
            InitializeComponent();
            vaiTroNguoiDung = vaiTro;
            this.vaiTro = vaiTro;
            emailNguoiDung = email; // Lưu email người dùng
        }

        //public frmMain(VaiTroDTO vaiTro)
        //{
           
        //}

        private void panelSach_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PhanQuyenNguoiDung();
            //// Tạo instance của ucQuanLySach
            //ucQuanLySach_GUI ucSach = new ucQuanLySach_GUI();

            //// Đặt ucQuanLySach vào panelContent
            //ucSach.Dock = DockStyle.Fill;  // Đảm bảo UserControl chiếm toàn bộ diện tích Panel
            //panelSach.Controls.Clear(); // Xóa các điều khiển cũ trước khi thêm
            //panelSach.Controls.Add(ucSach); // Thêm ucQuanLySach vào panelContent
        }
        private void PhanQuyenNguoiDung()
        {
            // Hiển thị vai trò của người dùng trên tiêu đề form
            this.Text = $"Quản Lý Hiệu Sách - Vai Trò: {vaiTroNguoiDung.TenVaiTro}";

            // Nếu là Chủ quán (MaVaiTro = 1), không giới hạn quyền
            if (vaiTroNguoiDung.MaVaiTro == 1)
            {
                return; // Chủ quán có quyền truy cập tất cả các chức năng
            }

            // Nếu là Nhân viên (MaVaiTro != 1), giới hạn quyền
            btnQuanLySach.Enabled = true; // Vô hiệu hóa nút Quản lý sách
            btnQuanLyNhanVien.Enabled = false; // Vô hiệu hóa nút Quản lý nhân viên
            btnQuanLyKH.Enabled = false; // Vô hiệu hóa nút Quản lý khách hàng
            button5.Enabled = false; // Vô hiệu hóa nút Nhập sách
            button6.Enabled = true; // Vô hiệu hóa nút Quản lý hóa đơn
            button7.Enabled = false; // Vô hiệu hóa nút Quản lý phiếu nhập
            button8.Enabled = false; // Vô hiệu hóa nút Thống kê doanh thu
            button9.Enabled = false; // Vô hiệu hóa nút Quản lý hàng tồn
        }

        private void btnQuanLySach_Click(object sender, EventArgs e)
        {
            ucQuanLySach_GUI ucSach = new ucQuanLySach_GUI();
            ucSach.Dock = DockStyle.Fill;
            panelSach.Controls.Clear(); // Xóa các điều khiển cũ
            panelSach.Controls.Add(ucSach); // Thêm ucQuanLySach mới vào panelContent
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ucQuanLyNhanVien_GUI ucNhanVien = new ucQuanLyNhanVien_GUI();
            ucNhanVien.Dock = DockStyle.Fill;
            panelSach.Controls.Clear(); // Xóa các điều khiển cũ
            panelSach.Controls.Add(ucNhanVien); // Thêm ucQuanLySach mới vào panelContent
        }

        private void btnQuanLyKH_Click(object sender, EventArgs e)
        {
            ucQuanLyKhachHang_GUI ucQuanLyKhachHang = new ucQuanLyKhachHang_GUI();
            ucQuanLyKhachHang.Dock = DockStyle.Fill;
            panelSach.Controls.Clear(); // Xóa các điều khiển cũ
            panelSach.Controls.Add(ucQuanLyKhachHang); // Thêm ucQuanLySach mới vào panelContent
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ucBanSach_GUI ucBanSach_GUI = new ucBanSach_GUI();
            ucBanSach_GUI.Dock = DockStyle.Fill;
            panelSach.Controls.Clear(); // Xóa các điều khiển cũ
            panelSach.Controls.Add(ucBanSach_GUI); // Thêm ucQuanLySach mới vào panelContent
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ucQuanLyHoaDon ucQuanLyHoaDon = new ucQuanLyHoaDon();
            ucQuanLyHoaDon.Dock = DockStyle.Fill;
            panelSach.Controls.Clear(); // Xóa các điều khiển cũ
            panelSach.Controls.Add(ucQuanLyHoaDon); // Thêm ucQuanLySach mới vào panelContent
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ucQuanLyPhieuNhap ucQuanLyPhieuNhap = new ucQuanLyPhieuNhap();
            ucQuanLyPhieuNhap.Dock = DockStyle.Fill;
            panelSach.Controls.Clear(); // Xóa các điều khiển cũ
            panelSach.Controls.Add(ucQuanLyPhieuNhap); // Thêm ucQuanLySach mới vào panelContent
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ucNhapSach_GUI ucNhapSach = new ucNhapSach_GUI();
            ucNhapSach.Dock = DockStyle.Fill;
            panelSach.Controls.Clear(); // Xóa các điều khiển cũ
            panelSach.Controls.Add(ucNhapSach); // Thêm ucQuanLySach mới vào panelContent
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ucThongKeDoanhThu ucThongKeDoanhThu = new ucThongKeDoanhThu();
            ucThongKeDoanhThu.Dock = DockStyle.Fill;
            panelSach.Controls.Clear(); // Xóa các điều khiển cũ
            panelSach.Controls.Add(ucThongKeDoanhThu); // Thêm ucQuanLySach mới vào panelContent
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ucQuanLyHangTon ucHangTon = new ucQuanLyHangTon();
            ucHangTon.Dock = DockStyle.Fill;
            panelSach.Controls.Clear(); // Xóa các điều khiển cũ
            panelSach.Controls.Add(ucHangTon); // Thêm ucQuanLySach mới vào panelContent
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hiển thị lại form đăng nhập
            frmDangNhap frmDangNhap = Application.OpenForms.OfType<frmDangNhap>().FirstOrDefault();
            if (frmDangNhap != null)
            {
                frmDangNhap.Show(); // Hiển thị lại form đăng nhập
            }

            // Đóng form hiện tại (frmMain)
            this.Close();
        }

        private void doiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(emailNguoiDung); // Truyền email của người dùng hiện tại
            frm.ShowDialog();
        }

        private void heThongToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
