using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;  // Sử dụng DAL để thực hiện các thao tác với cơ sở dữ liệu
using theloai_dto;  // Sử dụng DTO để lưu trữ dữ liệu

namespace BLL
{
    public class SachBLL
    {
        private SachDAL sachDAL = new SachDAL();

        // Lấy danh sách sách
        public List<SachDTO> GetDanhSachSach()
        {
            return sachDAL.GetDanhSachSach();
        }

        // Thêm sách
        public void ThemSach(string tenSach, string tacGia, int maTheLoai, int namXuatBan, decimal giaBan, int soLuongTon)
        {
            sachDAL.ThemSach(tenSach, tacGia, maTheLoai, namXuatBan, giaBan, soLuongTon);
        }

        // Sửa sách
        public void SuaSach(int maSach, string tenSach, string tacGia, int maTheLoai, int namXuatBan, decimal giaBan, int soLuongTon)
        {
            sachDAL.SuaSach(maSach, tenSach, tacGia, maTheLoai, namXuatBan, giaBan, soLuongTon);
        }

        // Xóa sách
        public void XoaSach(int maSach)
        {
            sachDAL.XoaSach(maSach);
        }
        // Tìm kiếm sách
        public List<SachDTO> TimKiemSach(string keyword)
        {
            DataTable dt = sachDAL.TimKiemSach(keyword);
            List<SachDTO> listSach = new List<SachDTO>();

            foreach (DataRow row in dt.Rows)
            {
                SachDTO sach = new SachDTO(
                    Convert.ToInt32(row["MaSach"]),
                    row["TenSach"].ToString(),
                    row["TacGia"].ToString(),
                    Convert.ToInt32(row["MaTheLoai"]),
                    Convert.ToInt32(row["NamXuatBan"]),
                    Convert.ToDecimal(row["GiaBan"]),
                    Convert.ToInt32(row["SoLuongTon"])
                );
                listSach.Add(sach);
            }

            return listSach;
        }
        public decimal LayDonGia(int maSach)
        {
            return sachDAL.LayGiaSach(maSach);  // Gọi lớp DAL để truy vấn giá sách
        }
        public DataTable GetSachWithTheLoai()
        {
            return sachDAL.GetSachWithTheLoai();
        }


    }
}
