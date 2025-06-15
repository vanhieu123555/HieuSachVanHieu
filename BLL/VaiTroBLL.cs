using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theloai_dto;
using DAL;
using System.Data;

namespace BLL
{
    public class VaiTroBLL
    {
        VaiTroDAL vaiTroDAL = new VaiTroDAL();
        public List<VaiTroDTO> GetAllVaiTro()
        {
            List<VaiTroDTO> list = new List<VaiTroDTO>();
            DataTable dt = vaiTroDAL.GetAllVaiTro();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new VaiTroDTO(
                    Convert.ToInt32(row["MaVaiTro"]),
                    row["TenVaiTro"].ToString()
                ));
            }
            return list;
        }
    }
}
