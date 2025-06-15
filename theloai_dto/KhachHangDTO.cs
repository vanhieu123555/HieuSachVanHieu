using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theloai_dto
{
    public class KhachHangDTO
    {
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; } 
        public KhachHangDTO(int maKhachHang, string hoTen, string soDienThoai, string diaChi)
        {
            MaKhachHang = maKhachHang;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
        }
        // Constructor mặc định
        public KhachHangDTO() { }
    }
}
