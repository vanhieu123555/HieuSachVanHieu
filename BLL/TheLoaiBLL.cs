using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theloai_dto;

namespace BLL
{
    public class TheLoaiBLL
    {
        TheLoaiDAL dal = new TheLoaiDAL();
        public List<TheLoaiDTO> GetAllTheLoai()
        {
            List<TheLoaiDTO> list = new List<TheLoaiDTO>();
            DataTable dt = dal.GetAllTheLoai();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TheLoaiDTO(
                    Convert.ToInt32(row["MaTheLoai"]),
                    row["TenTheLoai"].ToString()
                ));
            }
            return list;
        }
    }
}
