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

namespace QuanLyHieuSach
{
    public partial class ucQuanLyPhieuNhap : UserControl
    {
        private PhieuNhapBLL phieuNhapBLL = new PhieuNhapBLL();
        private ChiTietPhieuNhapBLL chiTietPhieuNhapBLL = new ChiTietPhieuNhapBLL();
        private int selectedMaPhieuNhap; // Biến lưu mã phiếu nhập được chọn


        public ucQuanLyPhieuNhap()
        {
            InitializeComponent();
            LoadPhieuNhap();
            ClearText();
        }
        private void LoadPhieuNhap()
        {
            try
            {
                List<object> danhSachPhieuNhapChiTiet = phieuNhapBLL.GetDanhSachPhieuNhapChiTiet();
                dgvPhieuNhap.DataSource = danhSachPhieuNhapChiTiet;

                // Tùy chỉnh tên cột hiển thị
                dgvPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã Phiếu Nhập";
                dgvPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dgvPhieuNhap.Columns["MaNCC"].HeaderText = "Mã Nhà CC"; // Đảm bảo cột MaNCC được hiển thị
                dgvPhieuNhap.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dgvPhieuNhap.Columns["MaChiTiet"].HeaderText = "Mã Chi Tiết";
                dgvPhieuNhap.Columns["MaSach"].HeaderText = "Mã Sách";
                dgvPhieuNhap.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvPhieuNhap.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvPhieuNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phiếu nhập chi tiết: " + ex.Message);
            }
        }

        private void ClearText()
        {
            txtMaPhieuNhap.Clear();
            txtNhaCungCap.Clear();
            txtTongTien.Clear();
            txtDonGia.Clear();
            txtTenSach.Clear();
            txtNhanVien.Clear();
            LoadPhieuNhap(); // Tải lại danh sách phiếu nhập sau khi xóa dữ liệu
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuNhap.Rows[e.RowIndex];
                // Lấy dữ liệu từ các cột và hiển thị vào TextBox
                txtMaPhieuNhap.Text = row.Cells["MaPhieuNhap"].Value?.ToString();
                txtNhaCungCap.Text = row.Cells["MaNCC"].Value?.ToString();
                txtNhanVien.Text = row.Cells["MaNhanVien"].Value?.ToString();
                txtTongTien.Text = row.Cells["TongTien"].Value?.ToString();
                txtTenSach.Text = row.Cells["MaSach"].Value?.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value?.ToString();

                // Lấy mã phiếu nhập từ dòng được chọn
                if (row.Cells["MaPhieuNhap"].Value != null && int.TryParse(row.Cells["MaPhieuNhap"].Value.ToString(), out int maPhieuNhap))
                {
                    selectedMaPhieuNhap = maPhieuNhap; // Lưu mã phiếu nhập
                }
                else
                {
                    selectedMaPhieuNhap = 0; // Reset nếu không hợp lệ
                    MessageBox.Show("Dữ liệu mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã chọn phiếu nhập nào chưa
                if (dgvPhieuNhap.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn phiếu nhập cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã phiếu nhập từ dòng được chọn
                var cellValue = dgvPhieuNhap.SelectedRows[0].Cells["MaPhieuNhap"].Value;
                if (cellValue == null || !int.TryParse(cellValue.ToString(), out int maPhieuNhap))
                {
                    MessageBox.Show("Dữ liệu mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu nhập có mã {maPhieuNhap} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Gọi BLL để xóa phiếu nhập và các chi tiết liên quan
                bool isDeleted = phieuNhapBLL.XoaPhieuNhap(maPhieuNhap);

                if (isDeleted)
                {
                    MessageBox.Show("Xóa phiếu nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhieuNhap(); // Tải lại danh sách phiếu nhập
                }
                else
                {
                    MessageBox.Show("Xóa phiếu nhập thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            try
            {
                // Lấy danh sách phiếu nhập chi tiết (đã join)
                var danhSach = phieuNhapBLL.GetDanhSachPhieuNhapChiTiet();

                // Lọc theo keyword (ví dụ: theo mã phiếu nhập, tên sách, tên nhà cung cấp, ...)
                var ketQua = danhSach;
                if (!string.IsNullOrEmpty(keyword))
                {
                    ketQua = danhSach.Where(item =>
                        item.ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                    ).ToList();
                }

                dgvPhieuNhap.DataSource = ketQua;
                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập phù hợp.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count > 0)
            {
                int maPhieuNhap = Convert.ToInt32(dgvPhieuNhap.SelectedRows[0].Cells["MaPhieuNhap"].Value);
                frmInPhieuNhap frm = new frmInPhieuNhap(maPhieuNhap);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
