using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theloai_dto
{
    public class PhieuNhapDTO
    {
        public int MaPhieuNhap { get; set; }
        public int MaNCC { get; set; }
        public int MaNhanVien { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTien { get; set; }
        public PhieuNhapDTO(int maPhieuNhap, int maNCC, int maNhanVien, DateTime ngayNhap, decimal tongTien)
        {
            MaPhieuNhap = maPhieuNhap;
            MaNCC = maNCC;
            MaNhanVien = maNhanVien;
            NgayNhap = ngayNhap;
            TongTien = tongTien;
        }
        public PhieuNhapDTO() { } // Constructor mặc định
    }
}
