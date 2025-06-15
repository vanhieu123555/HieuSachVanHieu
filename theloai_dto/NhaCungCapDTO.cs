using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theloai_dto
{
    public class NhaCungCapDTO
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public NhaCungCapDTO(int maNCC, string tenNCC, string soDienThoai, string diaChi)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
        }
        public NhaCungCapDTO() { } // Constructor mặc định
    }
}
