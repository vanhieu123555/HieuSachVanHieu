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
    public partial class ucQuanLyNhanVien_GUI : UserControl
    {
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();
        VaiTroBLL vaiTroBLL = new VaiTroBLL();
        public ucQuanLyNhanVien_GUI()
        {
            InitializeComponent();
            LoadNhanVien();
            LoadcmbChucVu();
            LoadcmbVaiTro();
            ClearText();
        }

        private void ucQuanLyNhanVien_GUI_Load(object sender, EventArgs e)
        {

        }
        private void LoadNhanVien()
        {
            dgvNhanVien.DataSource = nhanVienBLL.LayDanhSachNhanVien();
        }
        private void LoadcmbChucVu()
        {
            var chucVuList = new List<string> { "Chủ cửa hàng", "Nhân viên bán hàng" };
            cmbChucVu.DataSource = chucVuList;
            cmbChucVu.SelectedIndex = -1;
        }
        private void LoadcmbVaiTro()
        {
            cmbVaiTro.DataSource = vaiTroBLL.GetAllVaiTro();
            cmbVaiTro.DisplayMember = "MaVaiTro";
            cmbVaiTro.ValueMember = "MaVaiTro";
        }
        private void ClearText()
        {
            txtMaNhanVien.Clear();
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtMatKhau.Clear();
            cmbChucVu.SelectedIndex = -1;
            cmbVaiTro.SelectedIndex = -1;
            LoadNhanVien();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i >= 0)
            {
                txtMaNhanVien.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
                txtHoTen.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
                txtSoDienThoai.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
                txtEmail.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
                txtMatKhau.Text = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
                cmbChucVu.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
                cmbVaiTro.Text = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin()) return;
            try
            {
                NhanVienDTO nv = new NhanVienDTO()
                {
                    HoTen = txtHoTen.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    Email = txtEmail.Text,
                    ChucVu = cmbChucVu.SelectedValue.ToString(),
                    MatKhau = txtMatKhau.Text,
                    MaVaiTro = int.Parse(cmbVaiTro.SelectedValue.ToString())
                };
                if (nhanVienBLL.ThemNhanVien(nv))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadNhanVien();
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin()) return;
            try
            {
                NhanVienDTO nv = new NhanVienDTO()
                {
                    MaNhanVien = int.Parse(txtMaNhanVien.Text),
                    HoTen = txtHoTen.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    Email = txtEmail.Text,
                    ChucVu = cmbChucVu.SelectedValue.ToString(),
                    MatKhau = txtMatKhau.Text,
                    MaVaiTro = int.Parse(cmbVaiTro.SelectedValue.ToString())
                };
                if (nhanVienBLL.CapNhatNhanVien(nv))
                {
                    MessageBox.Show("Sửa thành công");
                    LoadNhanVien();
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int maNV = int.Parse(txtMaNhanVien.Text);
                    if (nhanVienBLL.XoaNhanVien(maNV))
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadNhanVien();
                        ClearText();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string keyword = txtTimKiem.Text;
                DataTable dt = nhanVienBLL.LayDanhSachNhanVien();

                DataView dv = dt.DefaultView;
                dv.RowFilter = $"HoTen LIKE '%{keyword}%' OR Email LIKE '%{keyword}%'";

                dgvNhanVien.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool KiemTraThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbChucVu.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
                cmbVaiTro.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
