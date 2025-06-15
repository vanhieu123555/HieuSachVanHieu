using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theloai_dto;

namespace BLL
{
    public class PhieuNhapBLL
    {
        private PhieuNhap_DAL phieuNhapDAL = new PhieuNhap_DAL();
        private ChiTietPhieuNhapBLL chiTietPhieuNhapBLL = new ChiTietPhieuNhapBLL();


        public int ThemPhieuNhap(PhieuNhapDTO phieuNhap, List<ChiTietPhieuNhapDTO> danhSachChiTiet)
        {
            // Thêm phiếu nhập và lấy mã phiếu nhập vừa được tạo
            int maPhieuNhap = phieuNhapDAL.ThemPhieuNhap(phieuNhap);

            if (maPhieuNhap > 0)
            {
                // Thêm từng chi tiết phiếu nhập liên quan
                foreach (var chiTiet in danhSachChiTiet)
                {
                    chiTiet.MaPhieuNhap = maPhieuNhap; // Gán mã phiếu nhập
                    chiTietPhieuNhapBLL.ThemChiTietPhieuNhap(chiTiet);
                }
            }

            return maPhieuNhap;
        }
        public List<object> GetDanhSachPhieuNhapChiTiet()
        {
            return phieuNhapDAL.GetDanhSachPhieuNhapChiTiet();
        }


        public bool XoaPhieuNhap(int maPhieuNhap)
        {
            try
            {
                // Xóa chi tiết phiếu nhập trước
                var chiTietPhieuNhapBLL = new ChiTietPhieuNhapBLL();
                bool chiTietDeleted = chiTietPhieuNhapBLL.XoaChiTietPhieuNhap(maPhieuNhap);

                if (!chiTietDeleted)
                {
                    return false;
                }

                // Xóa phiếu nhập
                return phieuNhapDAL.XoaPhieuNhap(maPhieuNhap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa phiếu nhập: " + ex.Message);
            }
        }

        public List<PhieuNhapDTO> TimKiemPhieuNhap(string keyword)
        {
            return phieuNhapDAL.TimKiemPhieuNhap(keyword);
        }
    }

}
