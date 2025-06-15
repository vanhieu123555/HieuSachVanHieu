using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theloai_dto
{
    public class ChiTietPhieuNhapDTO
    {
        public int MaChiTiet { get; set; }
        public int MaPhieuNhap { get; set; }
        public int MaSach { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien
        {
            get
            {
                return SoLuong * DonGia;
            }
        }
        public ChiTietPhieuNhapDTO(int maChiTiet, int maPhieuNhap, int maSach, int soLuong, decimal donGia)
        {
            MaChiTiet = maChiTiet;
            MaPhieuNhap = maPhieuNhap;
            MaSach = maSach;
            SoLuong = soLuong;
            DonGia = donGia;
        }
        public ChiTietPhieuNhapDTO() { } // Constructor mặc định
    }
}
