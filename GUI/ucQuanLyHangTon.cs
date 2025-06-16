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
    public partial class ucQuanLyHangTon : UserControl
    {
        private SachBLL sachBLL = new SachBLL();
        TheLoaiBLL theloaiBLL = new TheLoaiBLL();
        public ucQuanLyHangTon()
        {
            InitializeComponent();
            LoadTheLoai();
            ConfigureDataGridView();
        }
        private void LoadTheLoai()
        {
            try
            {
                List<TheLoaiDTO> theLoaiList = theloaiBLL.GetAllTheLoai();

                if (theLoaiList == null || theLoaiList.Count == 0)
                {
                    MessageBox.Show("Không có thể loại nào để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Thêm mục "Tất cả" vào danh sách
                theLoaiList.Insert(0, new TheLoaiDTO(-1, "Tất cả"));

                cboTheLoai.DisplayMember = "TenTheLoai";
                cboTheLoai.ValueMember = "MaTheLoai"; // Đảm bảo thiết lập đúng
                cboTheLoai.DataSource = theLoaiList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thể loại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureDataGridView()
        {
            dgvHangTon.AutoGenerateColumns = false;
            dgvHangTon.Columns.Clear();

            dgvHangTon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSach",
                HeaderText = "Mã Sách",
                Width = 100
            });

            dgvHangTon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSach",
                HeaderText = "Tên Sách",
                Width = 200
            });
            dgvHangTon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaTheLoai",
                HeaderText = "Mã Thể Loại",
                Width = 150
            });

            dgvHangTon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TheLoai",
                HeaderText = "Thể Loại",
                Width = 150
            });

            dgvHangTon.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuongTon",
                HeaderText = "Số Lượng Tồn",
                Width =500
            });
        }
        private void LoadHangTon()
        {
            try
            {
                int maTheLoai = cboTheLoai.SelectedValue != null ? Convert.ToInt32(cboTheLoai.SelectedValue) : -1;
                bool chiHienHet = chkSapHet.Checked;
                string tuKhoa = txtTimKiem.Text.Trim().ToLower();

                DataTable danhSach = sachBLL.GetSachWithTheLoai();

                // Xây dựng filter string cho DataView
                List<string> filters = new List<string>();

                if (maTheLoai != -1)
                    filters.Add($"MaTheLoai = {maTheLoai}");

                if (chiHienHet)
                    filters.Add("SoLuongTon < 5");

                if (!string.IsNullOrEmpty(tuKhoa))
                    filters.Add($"TenSach LIKE '%{tuKhoa}%'");


                string filterString = string.Join(" AND ", filters);

                DataView dv = danhSach.DefaultView;
                dv.RowFilter = filterString;

                dgvHangTon.DataSource = dv;

                // Tính tổng số lượng tồn
                int tongSoLuong = 0;
                foreach (DataRowView row in dv)
                {
                    tongSoLuong += Convert.ToInt32(row["SoLuongTon"]);
                }
                lblTongSoLuong.Text = $"Tổng số lượng tồn: {tongSoLuong}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hàng tồn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            chkSapHet.Checked = false;
            cboTheLoai.SelectedIndex = 0;
            LoadHangTon();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadHangTon();
        }

        private void cboTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHangTon();
        }

        private void chkSapHet_CheckedChanged(object sender, EventArgs e)
        {
            LoadHangTon();
        }
    }
}
