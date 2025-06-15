using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theloai_dto
{
    public class HoaDonDTO
    {
        public int MaHoaDon { get; set; }
        public int MaKhachHang { get; set; }
        public int MaNhanVien { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        

        // Constructor
        public HoaDonDTO(int maHoaDon, int maKhachHang, int maNhanVien, DateTime ngayLap, decimal tongTien )
        {
            MaHoaDon = maHoaDon;
            MaKhachHang = maKhachHang;
            MaNhanVien = maNhanVien;
            NgayLap = ngayLap;
            TongTien = tongTien;
            
        }
        public HoaDonDTO() { } // Constructor mặc định
    }
}
