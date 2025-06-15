using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using theloai_dto;
using System.Data.SqlClient;

namespace DAL
{
    public class ChiTietHoaDonDAL
    {
        public void ThemChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDon)
        {
            string query = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSach, SoLuong, DonGia, TenSach) VALUES (@MaHoaDon, @MaSach, @SoLuong, @DonGia, @TenSach)";

            using (SqlConnection conn = DataProvider.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHoaDon", chiTietHoaDon.MaHoaDon);
                cmd.Parameters.AddWithValue("@MaSach", chiTietHoaDon.MaSach);
                cmd.Parameters.AddWithValue("@SoLuong", chiTietHoaDon.SoLuong);
                cmd.Parameters.AddWithValue("@DonGia", chiTietHoaDon.DonGia);
                cmd.Parameters.AddWithValue("@TenSach", chiTietHoaDon.TenSach);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi SQL khi thêm chi tiết hóa đơn: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                }
            }
        }
        public List<ChiTietHoaDonDTO> GetDanhSachChiTietHoaDon()
        {
            string query = "SELECT * FROM ChiTietHoaDon";
            DataTable dt = DataProvider.ExecuteQuery(query);

            List<ChiTietHoaDonDTO> danhSachChiTiet = new List<ChiTietHoaDonDTO>();
            foreach (DataRow row in dt.Rows)
            {
                ChiTietHoaDonDTO chiTiet = new ChiTietHoaDonDTO
                {
                    MaChiTiet = Convert.ToInt32(row["MaChiTiet"]),
                    MaHoaDon = Convert.ToInt32(row["MaHoaDon"]),
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"]),
                    TenSach = row["TenSach"].ToString()
                };
                danhSachChiTiet.Add(chiTiet);
            }
            return danhSachChiTiet;
        }
        public bool XoaChiTietHoaDon(int maHoaDon)
        {
            string query = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            int result = DataProvider.ExecuteNonQuery(query, new SqlParameter("@MaHoaDon", maHoaDon));
            return result > 0;
        }


    }
}
