using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using theloai_dto;

namespace DAL
{
    public class SachDAL
    {
        // Lấy danh sách sách
        public List<SachDTO> GetDanhSachSach()
        {
            string query = "SELECT * FROM Sach";
            DataTable dt = DataProvider.ExecuteQuery(query);
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

        // Thêm sách
        public void ThemSach(string tenSach, string tacGia, int maTheLoai, int namXuatBan, decimal giaBan, int soLuongTon)
        {
            string query = "INSERT INTO Sach (TenSach, TacGia, MaTheLoai, NamXuatBan, GiaBan, SoLuongTon) VALUES (@TenSach, @TacGia, @MaTheLoai, @NamXuatBan, @GiaBan, @SoLuongTon)";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@TenSach", tenSach),
                new SqlParameter("@TacGia", tacGia),
                new SqlParameter("@MaTheLoai", maTheLoai),
                new SqlParameter("@NamXuatBan", namXuatBan),
                new SqlParameter("@GiaBan", giaBan),
                new SqlParameter("@SoLuongTon", soLuongTon)
            };
            DataProvider.ExecuteNonQuery(query, parameters.ToArray());
        }

        // Sửa sách
        public void SuaSach(int maSach, string tenSach, string tacGia, int maTheLoai, int namXuatBan, decimal giaBan, int soLuongTon)
        {
            string query = "UPDATE Sach SET TenSach = @TenSach, TacGia = @TacGia, MaTheLoai = @MaTheLoai, NamXuatBan = @NamXuatBan, GiaBan = @GiaBan, SoLuongTon = @SoLuongTon WHERE MaSach = @MaSach";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@MaSach", maSach),
                new SqlParameter("@TenSach", tenSach),
                new SqlParameter("@TacGia", tacGia),
                new SqlParameter("@MaTheLoai", maTheLoai),
                new SqlParameter("@NamXuatBan", namXuatBan),
                new SqlParameter("@GiaBan", giaBan),
                new SqlParameter("@SoLuongTon", soLuongTon)
            };
            DataProvider.ExecuteNonQuery(query, parameters.ToArray());
        }

        // Xóa sách
        public void XoaSach(int maSach)
        {
            string query = "DELETE FROM Sach WHERE MaSach = @MaSach";
            SqlParameter parameter = new SqlParameter("@MaSach", maSach);
            DataProvider.ExecuteNonQuery(query, parameter);
        }
        // Tìm kiếm sách
        public DataTable TimKiemSach(string keyword)
        {
            string query = "SELECT * FROM Sach WHERE TenSach LIKE @Keyword OR MaSach LIKE @Keyword OR TacGia LIKE @Keyword";
            SqlParameter[] param = { new SqlParameter("@Keyword", "%" + keyword + "%") };
            return DataProvider.ExecuteQuery(query, param);
        }
        // Hàm truy vấn giá sách từ cơ sở dữ liệu
        public decimal LayGiaSach(int maSach)
        {
            decimal giaBan = 0;
            string query = "SELECT GiaBan FROM Sach WHERE MaSach = @MaSach";

            using (SqlConnection conn = DataProvider.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaSach", maSach);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        giaBan = Convert.ToDecimal(result);  // Lấy giá sách từ cơ sở dữ liệu
                    }
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi hoặc ném ngoại lệ
                    throw new Exception("Lỗi khi truy vấn giá sách: " + ex.Message);
                }
            }

            return giaBan;  // Trả về giá sách
        }
        public DataTable GetSachWithTheLoai()
        {
            string query = @"SELECT s.MaSach, s.TenSach, t.MaTheLoai, t.TenTheLoai AS TheLoai, s.SoLuongTon
                     FROM Sach s
                     INNER JOIN TheLoai t ON s.MaTheLoai = t.MaTheLoai";
            return DataProvider.ExecuteQuery(query);
        }
        

    }
}
