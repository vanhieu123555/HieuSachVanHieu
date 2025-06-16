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
    public partial class frmThemSach : Form
    {
        SachBLL sachBLL = new SachBLL();
        TheLoaiBLL theloaiBLL = new TheLoaiBLL();
        public frmThemSach()
        {
            InitializeComponent();
        }
        private void LoadCmbTheLoai()
        {
            cmbTheLoai.DataSource = theloaiBLL.GetAllTheLoai();
            cmbTheLoai.DisplayMember = "TenTheLoai";  // Cái hiển thị
            cmbTheLoai.ValueMember = "MaTheLoai";     // Giá trị lấy ra
        }

        private void frmThemSach_Load(object sender, EventArgs e)
        {
            LoadCmbTheLoai();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các trường nhập liệu
                string tenSach = txtTenSach.Text.Trim();
                string tacGia = txtTacGia.Text.Trim();
                int maTheLoai = Convert.ToInt32(cmbTheLoai.SelectedValue);
                int namXuatBan = Convert.ToInt32(txtNamXuatBan.Text.Trim());
                decimal giaBan = Convert.ToDecimal(txtGiaBan.Text.Trim());
                int soLuongTon = Convert.ToInt32(txtSoLuongTon.Text.Trim());

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(tenSach) || string.IsNullOrEmpty(tacGia))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi BLL để thêm sách
                sachBLL.ThemSach(tenSach, tacGia, maTheLoai, namXuatBan, giaBan, soLuongTon);

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đóng form sau khi thêm thành công
                this.DialogResult = DialogResult.OK;
                this.Close();
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
    }
}
