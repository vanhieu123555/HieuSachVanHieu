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
    public partial class frmThemNhaCC : Form
    {
        NhaCungCapBLL nhaCCBLL = new NhaCungCapBLL();
        public frmThemNhaCC()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenNCC = txtTenNhaCC.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string soDienThoai = txtSDT.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenNCC) ||
                string.IsNullOrWhiteSpace(diaChi) ||
                string.IsNullOrWhiteSpace(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (nhaCCBLL.ThemNhaCungCap(tenNCC, soDienThoai, diaChi))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
