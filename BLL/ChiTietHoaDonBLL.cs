using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using theloai_dto;

namespace BLL
{
    public class ChiTietHoaDonBLL
    {
        private ChiTietHoaDonDAL chiTietHoaDonDAL = new ChiTietHoaDonDAL();

        public void ThemChiTietHoaDon(ChiTietHoaDonDTO chiTietHoaDon)
        {
            chiTietHoaDonDAL.ThemChiTietHoaDon(chiTietHoaDon);
        }
    }
}
