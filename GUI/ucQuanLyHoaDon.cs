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
using theloai_dto;

namespace QuanLyHieuSach
{
    public partial class ucQuanLyHoaDon : UserControl
    {
        private HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private ChiTietHoaDonBLL chiTietHoaDonBLL = new ChiTietHoaDonBLL();
        private int selectedMaHoaDon; // Biến lưu mã hóa đơn được chọn
        public ucQuanLyHoaDon()
        {
            InitializeComponent();
            LoadHoaDon();
            ClearText();

        }
        private void LoadHoaDon()
        {
            try
            {
                List<object> danhSachHoaDonChiTiet = hoaDonBLL.GetDanhSachHoaDonChiTiet();
                dgvHoaDon.DataSource = danhSachHoaDonChiTiet;

                // Tùy chỉnh tên cột hiển thị
                dgvHoaDon.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                dgvHoaDon.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                dgvHoaDon.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày Lập";
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvHoaDon.Columns["MaChiTiet"].HeaderText = "Mã Chi Tiết";
                dgvHoaDon.Columns["MaSach"].HeaderText = "Mã Sách";
                dgvHoaDon.Columns["TenSach"].HeaderText = "Tên Sách";
                dgvHoaDon.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvHoaDon.Columns["DonGia"].HeaderText = "Đơn Giá";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn chi tiết: " + ex.Message);
            }
        }
        



        private void ClearText()
        {
            txtMaHoaDon.Clear();
            txtKhachHang.Clear();
            txtNhanVien.Clear();
            txtTongTien.Clear();
            txtDonGia.Clear();
            txtTenSach.Clear();
            LoadHoaDon(); // Tải lại danh sách hóa đơn sau khi xóa dữ liệu
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã chọn hóa đơn nào chưa
                if (dgvHoaDon.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã hóa đơn từ dòng được chọn
                var cellValue = dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value;
                if (cellValue == null || !int.TryParse(cellValue.ToString(), out int maHoaDon))
                {
                    MessageBox.Show("Dữ liệu mã hóa đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn có mã {maHoaDon} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Gọi BLL để xóa hóa đơn và các chi tiết liên quan
                bool isDeleted = hoaDonBLL.XoaHoaDon(maHoaDon);

                if (isDeleted)
                {
                    MessageBox.Show("Xóa hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoaDon(); // Tải lại danh sách hóa đơn
                }
                else
                {
                    MessageBox.Show("Xóa hóa đơn thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                // Lấy dữ liệu từ các cột và hiển thị vào TextBox
                txtMaHoaDon.Text = row.Cells["MaHoaDon"].Value?.ToString();
                txtKhachHang.Text = row.Cells["MaKhachHang"].Value?.ToString();
                txtNhanVien.Text = row.Cells["MaNhanVien"].Value?.ToString();
                txtTongTien.Text = row.Cells["TongTien"].Value?.ToString();
                txtTenSach.Text = row.Cells["TenSach"].Value?.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value?.ToString();

                // Lấy mã hóa đơn từ dòng được chọn
                if (row.Cells["MaHoaDon"].Value != null && int.TryParse(row.Cells["MaHoaDon"].Value.ToString(), out int maHoaDon))
                {
                    selectedMaHoaDon = maHoaDon; // Lưu mã hóa đơn
                }
                else
                {
                    selectedMaHoaDon = 0; // Reset nếu không hợp lệ
                    MessageBox.Show("Dữ liệu mã hóa đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim().ToLower();

                // Lấy danh sách hóa đơn chi tiết từ BLL
                List<object> danhSachHoaDonChiTiet = hoaDonBLL.GetDanhSachHoaDonChiTiet();

                // Lọc danh sách theo từ khóa
                var ketQuaTimKiem = danhSachHoaDonChiTiet.Where(hd =>
                {
                    var hoaDon = hd.GetType();
                    return hoaDon.GetProperty("MaHoaDon").GetValue(hd).ToString().Contains(keyword) ||
                           hoaDon.GetProperty("TenSach").GetValue(hd).ToString().ToLower().Contains(keyword);
                }).ToList();

                // Hiển thị kết quả tìm kiếm
                dgvHoaDon.DataSource = ketQuaTimKiem;

                if (ketQuaTimKiem.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedMaHoaDon > 0) // Kiểm tra mã hóa đơn đã được chọn
            {
                frmInHoaDon formIn = new frmInHoaDon(selectedMaHoaDon);
                formIn.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn trước khi in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
