using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using theloai_dto;

namespace QuanLyHieuSach
{
    public partial class ucNhapSach_GUI : UserControl
    {
        private PhieuNhapBLL phieuNhapBLL = new PhieuNhapBLL();
        private ChiTietPhieuNhapBLL chiTietPhieuNhapBLL = new ChiTietPhieuNhapBLL();
        private NhaCungCapBLL nhaCungCapBLL = new NhaCungCapBLL();
        NhanVienBLL nvBLL = new NhanVienBLL();
        SachBLL sachBLL = new SachBLL();
        private List<ChiTietPhieuNhapDTO> danhSachChiTiet = new List<ChiTietPhieuNhapDTO>();
        //private DateTime ngayNhap;

        public ucNhapSach_GUI()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            dgvChiTietPhieuNhap.Columns.Add("MaSach", "Mã Sách");
            dgvChiTietPhieuNhap.Columns.Add("TenSach", "Tên Sách");
            dgvChiTietPhieuNhap.Columns.Add("SoLuong", "Số Lượng");
            dgvChiTietPhieuNhap.Columns.Add("DonGia", "Đơn Giá");
            dgvChiTietPhieuNhap.Columns.Add("ThanhTien", "Thành Tiền");

            dgvChiTietPhieuNhap.Columns["MaSach"].ValueType = typeof(int);
            dgvChiTietPhieuNhap.Columns["SoLuong"].ValueType = typeof(int);
            dgvChiTietPhieuNhap.Columns["DonGia"].ValueType = typeof(decimal);
            dgvChiTietPhieuNhap.Columns["ThanhTien"].ValueType = typeof(decimal);

            // Ensure the DataGridView is bound to the list of ChiTietPhieuNhapDTO
            
        }

        private void LoadNhaCungCap()
        {
            cboNhaCC.DataSource = nhaCungCapBLL.GetDanhSachNhaCungCap();  // Trả về DataTable/List
            cboNhaCC.DisplayMember = "TenNCC";
            cboNhaCC.ValueMember = "MaNCC";
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
        private void ClearText()
        {
            cboNhaCC.SelectedIndex = -1;
            txtSoLuong.Clear();
            dgvChiTietPhieuNhap.Rows.Clear();
            lblTongTien.Text = "0 VNĐ";
            cboSach.SelectedIndex = -1;
            cboNhaCC.SelectedIndex = -1;
            cboNhanVien.SelectedIndex = -1;
            LoadDanhSachSach();
        }

        private void ucNhapSach_GUI_Load(object sender, EventArgs e)
        {
            LoadDanhSachSach();
            LoadNhaCungCap();
            LoadNhanVien();
            LoadSach();
            ClearText();
        }

        private void btnNhaCCMoi_Click(object sender, EventArgs e)
        {
            frmThemNhaCC frm = new frmThemNhaCC();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadNhaCungCap();  // Load lại danh sách khách hàng sau khi thêm
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThemSach frm = new frmThemSach();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadSach();  // Load lại danh sách sách sau khi thêm
                LoadDanhSachSach();
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvDanhSachSach.DataSource = sachBLL.TimKiemSach(keyword);
        }

        private void btnThemVaoDS_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Kiểm tra dữ liệu đầu vào
            //    if (cboSach.SelectedValue == null || string.IsNullOrWhiteSpace(txtSoLuong.Text))
            //    {
            //        MessageBox.Show("Vui lòng chọn sách và nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    // Lấy thông tin từ giao diện
            //    int maSach = Convert.ToInt32(cboSach.SelectedValue);
            //    string tenSach = cboSach.Text; // Lấy tên sách từ ComboBox
            //    int soLuong = Convert.ToInt32(txtSoLuong.Text);
            //    decimal donGia = sachBLL.LayDonGia(maSach); // Lấy đơn giá từ BLL
            //    decimal thanhTien = soLuong * donGia; // Tính thành tiền

            //    // Thêm dữ liệu vào DataGridView
            //    dgvChiTietPhieuNhap.Rows.Add(maSach, tenSach, soLuong, donGia, thanhTien);

            //    // Thêm dữ liệu vào danh sách chi tiết phiếu nhập
            //    danhSachChiTiet.Add(new ChiTietPhieuNhapDTO
            //    {
            //        MaSach = maSach,

            //        SoLuong = soLuong,
            //        DonGia = donGia,

            //    });

            //    // Xóa dữ liệu nhập sau khi thêm
            //    txtSoLuong.Clear();
            //    cboSach.SelectedIndex = -1;

            //    // Tính lại tổng tiền
            //    TinhTongTien();
            //}
            //catch (FormatException)
            //{
            //    MessageBox.Show("Dữ liệu nhập không hợp lệ! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (cboSach.SelectedValue == null || string.IsNullOrWhiteSpace(txtSoLuong.Text))
                {
                    MessageBox.Show("Vui lòng chọn sách và nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soLuong;
                if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin từ giao diện
                int maSach = Convert.ToInt32(cboSach.SelectedValue);
                string tenSach = cboSach.Text; // Lấy tên sách từ ComboBox
                decimal donGia = sachBLL.LayDonGia(maSach); // Lấy đơn giá từ BLL
                decimal thanhTien = soLuong * donGia; // Tính thành tiền

                // Thêm dữ liệu vào DataGridView
                dgvChiTietPhieuNhap.Rows.Add(maSach, tenSach, soLuong, donGia, thanhTien);

                // Thêm dữ liệu vào danh sách chi tiết phiếu nhập
                danhSachChiTiet.Add(new ChiTietPhieuNhapDTO
                {
                    MaSach = maSach,
                    SoLuong = soLuong,
                    DonGia = donGia,
                });

                // Xóa dữ liệu nhập sau khi thêm
                txtSoLuong.Clear();
                cboSach.SelectedIndex = -1;

                // Tính lại tổng tiền
                TinhTongTien();
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Kiểm tra danh sách chi tiết phiếu nhập
            //    if (danhSachChiTiet == null || danhSachChiTiet.Count == 0)
            //    {
            //        MessageBox.Show("Danh sách chi tiết phiếu nhập trống. Vui lòng thêm sách vào danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    // Lấy thông tin từ giao diện
            //    int maNCC = Convert.ToInt32(cboNhaCC.SelectedValue);
            //    int maNhanVien = Convert.ToInt32(cboNhanVien.SelectedValue);
            //    decimal tongTien = LayTongTien();

            //    // Tạo đối tượng PhieuNhapDTO
            //    var phieuNhap = new PhieuNhapDTO
            //    {
            //        MaNCC = maNCC,
            //        MaNhanVien = maNhanVien,
            //        NgayNhap = DateTime.Now, // Lấy thời gian hiện tại
            //        TongTien = tongTien
            //    };

            //    // Gọi BLL để thêm phiếu nhập và chi tiết phiếu nhập
            //    int maPhieuNhap = phieuNhapBLL.ThemPhieuNhap(phieuNhap, danhSachChiTiet);

            //    if (maPhieuNhap > 0)
            //    {
            //        MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        // Làm mới giao diện
            //        danhSachChiTiet.Clear();
            //        dgvChiTietPhieuNhap.Rows.Clear();
            //        ClearText();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Lưu phiếu nhập thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            // Kiểm tra danh sách chi tiết có dữ liệu không
            // Kiểm tra danh sách chi tiết
            if (danhSachChiTiet == null || danhSachChiTiet.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sách vào danh sách chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra dữ liệu từng chi tiết
            foreach (var ct in danhSachChiTiet)
            {
                if (ct.SoLuong <= 0)
                {
                    MessageBox.Show($"Sách mã {ct.MaSach}: Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ct.DonGia < 0)
                {
                    MessageBox.Show($"Sách mã {ct.MaSach}: Đơn giá phải >= 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ct.MaSach <= 0)
                {
                    MessageBox.Show($"Sách mã không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                // Lấy thông tin từ giao diện
                int maNCC = Convert.ToInt32(cboNhaCC.SelectedValue);
                int maNhanVien = Convert.ToInt32(cboNhanVien.SelectedValue);
                decimal tongTien = danhSachChiTiet.Sum(x => x.ThanhTien);

                // Không set NgayNhap, database sẽ tự động lấy GETDATE()
                var phieuNhap = new PhieuNhapDTO
                {
                    MaNCC = maNCC,
                    MaNhanVien = maNhanVien,
                    TongTien = tongTien
                };

                // Lưu phiếu nhập
                int maPhieuNhap = phieuNhapBLL.ThemPhieuNhap(phieuNhap, danhSachChiTiet);

                if (maPhieuNhap > 0)
                {
                    MessageBox.Show("Lưu phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearText();
                    danhSachChiTiet.Clear();
                    dgvChiTietPhieuNhap.Rows.Clear();
                    TinhTongTien();
                }
                else
                {
                    MessageBox.Show("Lưu phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lệ. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TinhTongTien()
        {
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
            {
                if (!row.IsNewRow)
                {
                    tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }

            lblTongTien.Text = tongTien.ToString("N2") + " VNĐ";
        }

        private decimal LayTongTien()
        {
            return Convert.ToDecimal(lblTongTien.Text);
        }


        private void btnXoaKhoiDS_Click(object sender, EventArgs e)
        {
            try
    {
        // Kiểm tra xem có dòng nào được chọn không
        if (dgvChiTietPhieuNhap.SelectedRows.Count > 0)
        {
            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Xóa dòng được chọn
                foreach (DataGridViewRow row in dgvChiTietPhieuNhap.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvChiTietPhieuNhap.Rows.Remove(row);
                    }
                }

                // Tính lại tổng tiền sau khi xóa
                TinhTongTien();
            }
        }
        else
        {
            MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
        }
    }
}
