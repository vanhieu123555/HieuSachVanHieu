using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using theloai_dto;

namespace DAL
{
    public class KhachHangDAL
    {
        DataProvider db = new DataProvider();
        public DataTable GetDanhSachKhachHang()
        {
            string query = "SELECT * FROM KhachHang";
            return DataProvider.ExecuteQuery(query);
        }
        public bool Insert(KhachHangDTO kh)
        {
            string query = $"INSERT INTO KhachHang VALUES (N'{kh.HoTen}', '{kh.SoDienThoai}', N'{kh.DiaChi}')";
            return DataProvider.ExecuteNonQuery(query) > 0;
        }
        public bool Update(KhachHangDTO kh)
        {
            string query = $"UPDATE KhachHang SET HoTen = N'{kh.HoTen}', SoDienThoai = '{kh.SoDienThoai}', DiaChi = N'{kh.DiaChi}' WHERE MaKhachHang = {kh.MaKhachHang}";
            return DataProvider.ExecuteNonQuery(query) > 0;
        }
        public bool Delete(int maKH)
        {
            string query = $"DELETE FROM KhachHang WHERE MaKhachHang = {maKH}";
            return DataProvider.ExecuteNonQuery(query) > 0;
        }

    }
}
