using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theloai_dto
{
    public class VaiTroDTO
    {
        public int MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }
       
        public VaiTroDTO(int maVaiTro, string tenVaiTro)
        {
            MaVaiTro = maVaiTro;
            TenVaiTro = tenVaiTro;
           
        }
    }
}
