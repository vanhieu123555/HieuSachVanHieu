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
    public class KhachHangBLL
    {
        KhachHangDAL dalKH = new KhachHangDAL();

        public DataTable LayDanhSachKhachHang()
        {
            return dalKH.GetDanhSachKhachHang();
        }

        public bool ThemKhachHang(KhachHangDTO kh)
        {
            return dalKH.Insert(kh);
        }

        public bool CapNhatKhachHang(KhachHangDTO kh)
        {
            return dalKH.Update(kh);
        }

        public bool XoaKhachHang(int maKH)
        {
            return dalKH.Delete(maKH);
        }
    }
}
