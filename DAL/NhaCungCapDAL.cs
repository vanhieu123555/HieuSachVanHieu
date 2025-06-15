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
    public class NhaCungCapDAL
    {
        public List<NhaCungCapDTO> GetDSNhaCC()
        {
            List<NhaCungCapDTO> danhSachNhaCC = new List<NhaCungCapDTO>();

            try
            {
                string query = "SELECT MaNCC, TenNCC, SoDienThoai, DiaChi FROM NhaCungCap";
                DataTable dt = DataProvider.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    NhaCungCapDTO nhaCC = new NhaCungCapDTO
                    {
                        MaNCC = Convert.ToInt32(row["MaNCC"]),
                        TenNCC = row["TenNCC"].ToString(),
                        SoDienThoai = row["SoDienThoai"].ToString(),
                        DiaChi = row["DiaChi"].ToString()
                    };
                    danhSachNhaCC.Add(nhaCC);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhà cung cấp: " + ex.Message);
            }

            return danhSachNhaCC;
        }
        public void ThemNhaCC(string tenNCC, string soDienThoai, string diaChi)
        {
            string query = "INSERT INTO NhaCungCap (TenNCC, SoDienThoai, DiaChi) VALUES (@TenNCC, @SoDienThoai, @DiaChi)";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@TenNCC", tenNCC),
                new SqlParameter("@SoDienThoai", soDienThoai),
                new SqlParameter("@DiaChi", diaChi)
            };
            DataProvider.ExecuteNonQuery(query, parameters.ToArray());
        }
    }
}
