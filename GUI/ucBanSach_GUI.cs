using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using theloai_dto;

namespace QuanLyHieuSach
{
    public partial class ucBanSach_GUI : UserControl
    {
        KhachHangBLL khBLL = new KhachHangBLL();
        NhanVienBLL nvBLL = new NhanVienBLL();
        SachBLL sachBLL = new SachBLL();
        HoaDonBLL hoaDonBLL = new HoaDonBLL();
        ChiTietHoaDonBLL chiTietHoaDonBLL = new ChiTietHoaDonBLL();

        public ucBanSach_GUI()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            dgvGioHang.Columns.Add("maSach", "Mã Sách");
            dgvGioHang.Columns.Add("tenSach", "Tên Sách");
            dgvGioHang.Columns.Add("soLuong", "Số Lượng");
            dgvGioHang.Columns.Add("donGia", "Đơn Giá");
            dgvGioHang.Columns.Add("thanhTien", "Thành Tiền");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void LoadKhachHang()
        {
            cboKhachHang.DataSource = khBLL.LayDanhSachKhachHang();  // Trả về DataTable/List
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKhachHang";
        }
        private void LoadNhanVien()
        {
            cboNhanVien.DataSource = nvBLL.LayDanhSachNhanVien();  // Trả về DataTable/List
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNhanVien";
        }
        private void LoadSach()
        {
            
            cboSach.DataSource = sachBLL.GetDanhSachSach();
            cboSach.DisplayMember = "TenSach";
            cboSach.ValueMember = "MaSach";
        }
        private void LoadDanhSachSach()
        {
            dgvDanhSachSach.DataSource = sachBLL.GetDanhSachSach();
        }


        private void ucBanSach_GUI_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadNhanVien();
            LoadSach();
            LoadDanhSachSach();
            ResetForm();
        }

        private void btnKhachMoi_Click(object sender, EventArgs e)
        {
            frmThemKhachHang frm = new frmThemKhachHang();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadKhachHang();  // Load lại danh sách khách hàng sau khi thêm
            }
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || cboSach.SelectedIndex < 0)
            //    {
            //        MessageBox.Show("Vui lòng chọn sách và nhập số lượng hợp lệ.");
            //        return;
            //    }

            //    int maSach = Convert.ToInt32(cboSach.SelectedValue);
            //    string tenSach = cboSach.Text;
            //    int soLuong = Convert.ToInt32(txtSoLuong.Text);
            //    decimal donGia = sachBLL.LayDonGia(maSach);
            //    decimal thanhTien = soLuong * donGia;

            //    dgvGioHang.Rows.Add(maSach, tenSach, soLuong, donGia, thanhTien);

            //    TinhTongTien();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi thêm vào giỏ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            try
            {
                if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || cboSach.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn sách và nhập số lượng hợp lệ.");
                    return;
                }

                int soLuong;
                if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maSach = Convert.ToInt32(cboSach.SelectedValue);
                string tenSach = cboSach.Text;
                decimal donGia = sachBLL.LayDonGia(maSach);
                decimal thanhTien = soLuong * donGia;

                dgvGioHang.Rows.Add(maSach, tenSach, soLuong, donGia, thanhTien);

                TinhTongTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vào giỏ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }
        private void ResetForm()
        {
            dgvGioHang.Rows.Clear();
            lblTongTien.Text = "0 VNĐ";
            txtSoLuong.Clear();
            cboSach.SelectedIndex = 0;
            cboKhachHang.SelectedIndex = 0;
            LoadDanhSachSach();
        }
        private decimal LayTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            return tongTien;
        }


        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0 || (dgvGioHang.Rows.Count == 1 && dgvGioHang.Rows[0].IsNewRow))
            {
                MessageBox.Show("Giỏ hàng đang trống. Vui lòng thêm sản phẩm trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Tạo đối tượng HoaDonDTO mới
                HoaDonDTO hd = new HoaDonDTO
                {
                    MaKhachHang = Convert.ToInt32(cboKhachHang.SelectedValue),
                    MaNhanVien = Convert.ToInt32(cboNhanVien.SelectedValue), // Giả sử bạn có giá trị được chọn cho NhanVien
                    NgayLap = DateTime.Now,
                    TongTien = LayTongTien()
                };

                // Thêm hóa đơn mới vào cơ sở dữ liệu và lấy mã hóa đơn mới
                int maHD = hoaDonBLL.ThemHoaDon(hd); // Trả về mã hóa đơn mới tạo

                // Duyệt qua từng hàng trong DataGridView và tạo đối tượng ChiTietHoaDonDTO
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    if (row.IsNewRow) continue; // Bỏ qua hàng mới

                    ChiTietHoaDonDTO ct = new ChiTietHoaDonDTO
                    {
                        MaHoaDon = maHD,
                        MaSach = Convert.ToInt32(row.Cells["MaSach"].Value),
                        TenSach = row.Cells["TenSach"].Value.ToString(),
                        SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                        DonGia = Convert.ToDecimal(row.Cells["DonGia"].Value)
                    };

                    // Thêm chi tiết hóa đơn mới vào cơ sở dữ liệu
                    chiTietHoaDonBLL.ThemChiTietHoaDon(ct);
                }

                // Hiển thị thông báo thành công và đặt lại form
                MessageBox.Show("Thanh toán thành công!");
                ResetForm();
            }
            catch (SqlException ex)
            {
                // Kiểm tra nếu lỗi từ trigger (RAISERROR)
                if (ex.Number == 50000) // 50000 là mã lỗi mặc định từ RAISERROR
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSachSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu không phải header
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu của dòng đã chọn
                DataGridViewRow row = dgvDanhSachSach.Rows[e.RowIndex];

                // Cập nhật thông tin vào các TextBox tương ứng               
                cboSach.Text = row.Cells["TenSach"].Value.ToString();
            }
        }

        private void btnXoaKhoiGio_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvGioHang.SelectedRows)
                {
                    dgvGioHang.Rows.Remove(row);
                }
                TinhTongTien(); // Cập nhật lại tổng tiền sau khi xóa
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng để xóa.");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvDanhSachSach.DataSource = sachBLL.TimKiemSach(keyword);
        }
    }
}
