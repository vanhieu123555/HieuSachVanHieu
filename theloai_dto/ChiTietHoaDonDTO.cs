using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theloai_dto
{
    public class ChiTietHoaDonDTO
    {
        public int MaChiTiet { get; set; }
        public int MaHoaDon { get; set; }
        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string TenSach { get; set; } // Thêm thuộc tính TenSach

        public ChiTietHoaDonDTO(int maChiTiet, int maHoaDon, int maSach, int soLuong, decimal donGia)
        {
            MaChiTiet = maChiTiet;
            MaHoaDon = maHoaDon;
            MaSach = maSach;
            SoLuong = soLuong;
            DonGia = donGia;
            TenSach = TenSach;
        }

        public ChiTietHoaDonDTO() { } // Constructor mặc định
    }
}
