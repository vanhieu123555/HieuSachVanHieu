using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theloai_dto
{
    public class NhanVienDTO
    {
        public int MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public string MatKhau { get; set; }
        public int MaVaiTro { get; set; }
        public NhanVienDTO(int maNhanVien, string hoTen, string soDienThoai, string email, string chucVu, string matKhau, int maVaiTro)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            Email = email;
            ChucVu = chucVu;
            MatKhau = matKhau;
            MaVaiTro = maVaiTro;
        }
        // Constructor mặc định
        public NhanVienDTO() { }

    }
}
