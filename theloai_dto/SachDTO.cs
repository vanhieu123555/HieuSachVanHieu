using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theloai_dto
{
    public class SachDTO
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public int MaTheLoai { get; set; }
        public int NamXuatBan { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }

        public SachDTO(int maSach, string tenSach, string tacGia, int maTheLoai, int namXuatBan, decimal giaBan, int soLuongTon)
        {
            MaSach = maSach;
            TenSach = tenSach;
            TacGia = tacGia;
            MaTheLoai = maTheLoai;
            NamXuatBan = namXuatBan;
            GiaBan = giaBan;
            SoLuongTon = soLuongTon;
        }
    }
}
