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
    public class NhanVienBLL
    {
        NhanVienDAL dalNV = new NhanVienDAL();

        public bool DangNhap(string email, string matkhau)
        {
            return dalNV.KiemTraDangNhap(email, matkhau);
        }
        public DataTable LayDanhSachNhanVien()
        {
            return dalNV.LayDanhSachNhanVien();
        }
        public bool ThemNhanVien(NhanVienDTO nv)
        {
            return dalNV.ThemNhanVien(nv);
        }
        public bool XoaNhanVien(int maNV)
        {
            return dalNV.XoaNhanVien(maNV);
        }
        public bool CapNhatNhanVien(NhanVienDTO nv)
        {
            return dalNV.CapNhatNhanVien(nv);
        }
        public VaiTroDTO LayVaiTroNhanVien(string email)
        {
            return dalNV.LayVaiTroNhanVien(email);
        }
        public bool DoiMatKhau(string email, string matKhauCu, string matKhauMoi)
        {
            return dalNV.DoiMatKhau(email, matKhauCu, matKhauMoi);
        }
        public string LayEmailNguoiDung(int maVaiTro)
        {
            return dalNV.LayEmailNguoiDung(maVaiTro);
        }
    }
}
