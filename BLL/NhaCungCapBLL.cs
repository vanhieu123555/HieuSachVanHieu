using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theloai_dto;

namespace BLL
{
    public class NhaCungCapBLL
    {
        private NhaCungCapDAL nhaCungCapDAL = new NhaCungCapDAL();

        public List<NhaCungCapDTO> GetDanhSachNhaCungCap()
        {
            try
            {
                return nhaCungCapDAL.GetDSNhaCC();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhà cung cấp: " + ex.Message);
            }
        }
        public bool ThemNhaCungCap(string tenNCC, string soDienThoai, string diaChi)
        {
            try
            {
                nhaCungCapDAL.ThemNhaCC(tenNCC, soDienThoai, diaChi);
                return true; // Thêm thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                Console.WriteLine("Lỗi khi thêm nhà cung cấp: " + ex.Message);
                return false; // Thêm thất bại
            }
        }

    }
}
