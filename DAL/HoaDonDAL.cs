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
    public class HoaDonDAL
    {
        public int ThemHoaDon(HoaDonDTO hoaDon)
        {
            int maHoaDon = 0;
            string query = "INSERT INTO HoaDon (MaKhachHang, MaNhanVien, NgayLap, TongTien) OUTPUT INSERTED.MaHoaDon VALUES (@MaKhachHang, @MaNhanVien, @NgayLap, @TongTien)";

            using (SqlConnection conn = DataProvider.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaKhachHang", hoaDon.MaKhachHang);
                cmd.Parameters.AddWithValue("@MaNhanVien", hoaDon.MaNhanVien);
                cmd.Parameters.AddWithValue("@NgayLap", hoaDon.NgayLap);
                cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);

                try
                {
                    conn.Open();
                    maHoaDon = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm hóa đơn: " + ex.Message);
                }
            }

            return maHoaDon;
        }
        public List<HoaDonDTO> GetDanhSachHoaDon()
        {
            string query = "SELECT * FROM HoaDon";
            DataTable dt = DataProvider.ExecuteQuery(query);

            List<HoaDonDTO> danhSachHoaDon = new List<HoaDonDTO>();
            foreach (DataRow row in dt.Rows)
            {
                HoaDonDTO hoaDon = new HoaDonDTO
                {
                    MaHoaDon = Convert.ToInt32(row["MaHoaDon"]),
                    MaKhachHang = Convert.ToInt32(row["MaKhachHang"]),
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    NgayLap = Convert.ToDateTime(row["NgayLap"]),
                    TongTien = Convert.ToDecimal(row["TongTien"])
                };
                danhSachHoaDon.Add(hoaDon);
            }
            return danhSachHoaDon;
        }
        public bool XoaHoaDon(int maHoaDon)
        {
            string query = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            int result = DataProvider.ExecuteNonQuery(query, new SqlParameter("@MaHoaDon", maHoaDon));
            return result > 0;
        }
        public DataTable GetHoaDonByMa(int maHoaDon)
        {
            string query = "SELECT * FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@MaHoaDon", maHoaDon)
            };

            return DataProvider.ExecuteQuery(query, parameters);
        }






    }
}
