using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theloai_dto;

namespace BLL
{
    public class ChiTietPhieuNhapBLL
    {
        private ChiTietPhieuNhap_DAL chiTietPhieuNhapDAL = new ChiTietPhieuNhap_DAL();

        public bool ThemChiTietPhieuNhap(ChiTietPhieuNhapDTO chiTietPhieuNhap)
        {
            return chiTietPhieuNhapDAL.ThemChiTietPhieuNhap(chiTietPhieuNhap);
        }
        public List<ChiTietPhieuNhapDTO> GetDanhSachChiTietPhieuNhap()
        {
            return chiTietPhieuNhapDAL.GetDanhSachChiTietPhieuNhap();
        }
        public bool XoaChiTietPhieuNhap(int maPhieuNhap)
        {
            return chiTietPhieuNhapDAL.XoaChiTietPhieuNhap(maPhieuNhap);
        }
    }
   

}
