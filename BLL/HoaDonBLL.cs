using System;
using theloai_dto;
using DAL;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL hoaDonDAL = new HoaDonDAL();

        public int ThemHoaDon(HoaDonDTO hoaDon)
        {
            return hoaDonDAL.ThemHoaDon(hoaDon);
        }
        public List<object> GetDanhSachHoaDonChiTiet()
        {
            var danhSachHoaDon = hoaDonDAL.GetDanhSachHoaDon();

            // Khởi tạo đối tượng ChiTietHoaDonDAL
            var chiTietHoaDonDAL = new ChiTietHoaDonDAL();
            var danhSachChiTiet = chiTietHoaDonDAL.GetDanhSachChiTietHoaDon();

            // Kết hợp dữ liệu từ hai danh sách
            var danhSachHoaDonChiTiet = (from hd in danhSachHoaDon
                                         join cthd in danhSachChiTiet
                                         on hd.MaHoaDon equals cthd.MaHoaDon
                                         select new
                                         {
                                             hd.MaHoaDon,
                                             hd.MaKhachHang,
                                             hd.MaNhanVien,
                                             hd.NgayLap,
                                             hd.TongTien,
                                             cthd.MaChiTiet,
                                             cthd.MaSach,
                                             cthd.TenSach,
                                             cthd.SoLuong,
                                             cthd.DonGia
                                         }).ToList();

            return danhSachHoaDonChiTiet.Cast<object>().ToList();
        }
        public bool XoaHoaDon(int maHoaDon)
        {
            try
            {
                // Tạo đối tượng ChiTietHoaDonDAL
                var chiTietHoaDonDAL = new ChiTietHoaDonDAL();

                // Xóa các chi tiết hóa đơn trước
                bool chiTietDeleted = chiTietHoaDonDAL.XoaChiTietHoaDon(maHoaDon);

                if (!chiTietDeleted)
                {
                    return false; // Nếu xóa chi tiết thất bại, dừng lại
                }

                // Xóa hóa đơn
                return hoaDonDAL.XoaHoaDon(maHoaDon);
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetHoaDonByMa(int maHoaDon)
        {
            // Gọi DAL để lấy dữ liệu từ cơ sở dữ liệu
            return hoaDonDAL.GetHoaDonByMa(maHoaDon);
        }




    }
}
