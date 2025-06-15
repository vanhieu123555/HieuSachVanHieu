using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theloai_dto;

namespace DAL
{
    public class ChiTietPhieuNhap_DAL
    {
        public bool ThemChiTietPhieuNhap(ChiTietPhieuNhapDTO ct)
        {
            string query = "INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaSach, SoLuong, DonGia) " +
                           "VALUES (@MaPhieuNhap, @MaSach, @SoLuong, @DonGia)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaPhieuNhap", ct.MaPhieuNhap),
                new SqlParameter("@MaSach", ct.MaSach),
                new SqlParameter("@SoLuong", ct.SoLuong),
                new SqlParameter("@DonGia", ct.DonGia)
            };
            return DataProvider.ExecuteNonQuery(query, parameters) > 0;
        }
        public List<ChiTietPhieuNhapDTO> GetDanhSachChiTietPhieuNhap()
        {
            string query = "SELECT * FROM ChiTietPhieuNhap";
            var dataTable = DataProvider.ExecuteQuery(query);
            var danhSach = new List<ChiTietPhieuNhapDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                danhSach.Add(new ChiTietPhieuNhapDTO
                {
                    MaChiTiet = Convert.ToInt32(row["MaChiTiet"]),
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"])
                });
            }

            return danhSach;
        }
        public bool XoaChiTietPhieuNhap(int maPhieuNhap)
        {
            string query = "DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap";
            SqlParameter parameter = new SqlParameter("@MaPhieuNhap", maPhieuNhap);
            return DataProvider.ExecuteNonQuery(query, parameter) > 0;
        }

    }

}
