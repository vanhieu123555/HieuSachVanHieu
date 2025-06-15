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
    public class PhieuNhap_DAL
    {
        public int ThemPhieuNhap(PhieuNhapDTO pn)
        {
            //        string query = "INSERT INTO PhieuNhap (MaNCC, MaNhanVien, NgayNhap, TongTien) " +
            //                       "OUTPUT INSERTED.MaPhieuNhap VALUES (@MaNCC, @MaNhanVien, @NgayNhap, @TongTien)";
            //        SqlParameter[] parameters = {
            //    new SqlParameter("@MaNCC", pn.MaNCC),
            //    new SqlParameter("@MaNhanVien", pn.MaNhanVien),
            //    new SqlParameter("@NgayNhap", pn.NgayNhap),
            //    new SqlParameter("@TongTien", pn.TongTien)
            //};

            //        return (int)DataProvider.ExecuteScalar1(query, parameters);
            // Nếu NgayNhap là null hoặc nhỏ hơn 1753-01-01 thì không truyền vào, để SQL tự lấy GETDATE()
            if (pn.NgayNhap == null || pn.NgayNhap < new DateTime(1753, 1, 1))
            {
                string query = "INSERT INTO PhieuNhap (MaNCC, MaNhanVien, TongTien) " +
                               "OUTPUT INSERTED.MaPhieuNhap VALUES (@MaNCC, @MaNhanVien, @TongTien)";
                SqlParameter[] parameters = {
            new SqlParameter("@MaNCC", pn.MaNCC),
            new SqlParameter("@MaNhanVien", pn.MaNhanVien),
            new SqlParameter("@TongTien", pn.TongTien)
        };
                return (int)DataProvider.ExecuteScalar1(query, parameters);
            }
            else
            {
                string query = "INSERT INTO PhieuNhap (MaNCC, MaNhanVien, NgayNhap, TongTien) " +
                               "OUTPUT INSERTED.MaPhieuNhap VALUES (@MaNCC, @MaNhanVien, @NgayNhap, @TongTien)";
                SqlParameter[] parameters = {
            new SqlParameter("@MaNCC", pn.MaNCC),
            new SqlParameter("@MaNhanVien", pn.MaNhanVien),
            new SqlParameter("@NgayNhap", pn.NgayNhap),
            new SqlParameter("@TongTien", pn.TongTien)
        };
                return (int)DataProvider.ExecuteScalar1(query, parameters);
            }
        }


        public List<object> GetDanhSachPhieuNhapChiTiet()
        {
            string query = @"
                    SELECT 
                        pn.MaPhieuNhap, pn.NgayNhap, pn.TongTien, pn.MaNCC, pn.MaNhanVien, 
                        ctpn.MaChiTiet, ctpn.MaSach, ctpn.SoLuong, ctpn.DonGia
                    FROM PhieuNhap pn
                    INNER JOIN ChiTietPhieuNhap ctpn ON pn.MaPhieuNhap = ctpn.MaPhieuNhap";

            var dataTable = DataProvider.ExecuteQuery(query);
            var danhSach = new List<object>();

            foreach (DataRow row in dataTable.Rows)
            {
                danhSach.Add(new
                {
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    NgayNhap = Convert.ToDateTime(row["NgayNhap"]),
                    MaNCC = Convert.ToInt32(row["MaNCC"]),
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    TongTien = Convert.ToDecimal(row["TongTien"]),
                    MaChiTiet = Convert.ToInt32(row["MaChiTiet"]),
                    MaSach = Convert.ToInt32(row["MaSach"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"])
                });
            }

            return danhSach;
        }

        public bool XoaPhieuNhap(int maPhieuNhap)
        {
            try
            {
                // Xóa chi tiết phiếu nhập trước
                string queryChiTiet = "DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap";
                SqlParameter[] parametersChiTiet = { new SqlParameter("@MaPhieuNhap", maPhieuNhap) };
                DataProvider.ExecuteNonQuery(queryChiTiet, parametersChiTiet);

                // Xóa phiếu nhập
                string queryPhieuNhap = "DELETE FROM PhieuNhap WHERE MaPhieuNhap = @MaPhieuNhap";
                SqlParameter[] parametersPhieuNhap = { new SqlParameter("@MaPhieuNhap", maPhieuNhap) };
                int rowsAffected = DataProvider.ExecuteNonQuery(queryPhieuNhap, parametersPhieuNhap);

                return rowsAffected > 0; // Trả về true nếu có bản ghi bị xóa
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa phiếu nhập: " + ex.Message);
            }
        }

        public List<PhieuNhapDTO> TimKiemPhieuNhap(string keyword)
        {
            string query = "SELECT * FROM PhieuNhap WHERE MaPhieuNhap LIKE @Keyword OR MaNCC LIKE @Keyword";
            SqlParameter[] parameters = { new SqlParameter("@Keyword", "%" + keyword + "%") };
            var dataTable = DataProvider.ExecuteQuery(query, parameters);
            var danhSach = new List<PhieuNhapDTO>();

            foreach (DataRow row in dataTable.Rows)
            {
                danhSach.Add(new PhieuNhapDTO
                {
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    MaNCC = Convert.ToInt32(row["MaNCC"]),
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    NgayNhap = Convert.ToDateTime(row["NgayNhap"]),
                    TongTien = Convert.ToDecimal(row["TongTien"])
                });
            }

            return danhSach;
        }
    }

}
