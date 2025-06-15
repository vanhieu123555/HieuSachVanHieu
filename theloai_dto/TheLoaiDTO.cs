using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theloai_dto
{
    public class TheLoaiDTO
    {
        public int MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }

        public TheLoaiDTO(int maTheLoai, string tenTheLoai)
        {
            MaTheLoai = maTheLoai;
            TenTheLoai = tenTheLoai;
        }
    }
}
