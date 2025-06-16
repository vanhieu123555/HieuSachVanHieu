using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using theloai_dto;
using DAL;

namespace QuanLyHieuSach
{
    public partial class ucThongKeDoanhThu : UserControl
    {
        public ucThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void ucThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            cboLoaiThongKe.Items.AddRange(new string[] {
        "Tổng doanh thu", "Top sách bán chạy", "Doanh thu theo nhân viên", "Tổng số hóa đơn"
    });
            cboLoaiThongKe.SelectedIndex = 0;
            cboThang.Items.Add("1");
            cboThang.Items.Add("2");
            cboThang.Items.Add("3");
            cboThang.Items.Add("4");
            cboThang.Items.Add("5");
            cboThang.Items.Add("6");
            cboThang.Items.Add("7");
            cboThang.Items.Add("8");
            cboThang.Items.Add("9");
            cboThang.Items.Add("10");
            cboThang.Items.Add("11");
            cboThang.Items.Add("12");
            cboThang.SelectedIndex = 0;

            cboLoaiThongKe.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cboThang.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loaiThongKe = cboLoaiThongKe.SelectedItem.ToString();
            int thang = int.Parse(cboThang.SelectedItem.ToString());
            HienThiThongKe(loaiThongKe, thang);
        }
        private void HienThiThongKe(string loai, int thang)
        {
            chartThongKe.Series.Clear();
            chartThongKe.Titles.Clear();

            if (loai == "Tổng doanh thu")
            {
                // Truy vấn tổng doanh thu
                string query = "SELECT SUM(TongTien) AS TongDoanhThu FROM HoaDon WHERE MONTH(NgayLap) = @thang";
                var parameters = new SqlParameter[] { new SqlParameter("@thang", thang) };

                DataTable dt = DataProvider.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    decimal tong = dt.Rows[0]["TongDoanhThu"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["TongDoanhThu"]) : 0;
                    lblKetQua.Text = $"Tổng doanh thu tháng {thang}: {tong:N0} VNĐ";
                }
                else
                {
                    lblKetQua.Text = $"Không có dữ liệu doanh thu cho tháng {thang}.";
                }
            }
            else if (loai == "Top sách bán chạy")
            {
                // Truy vấn top sách bán chạy
                string query = @"
            SELECT S.TenSach, SUM(CT.SoLuong) AS TongSoLuong
            FROM ChiTietHoaDon CT
            JOIN HoaDon H ON CT.MaHoaDon = H.MaHoaDon
            JOIN Sach S ON CT.MaSach = S.MaSach
            WHERE MONTH(H.NgayLap) = @thang
            GROUP BY S.TenSach
            ORDER BY TongSoLuong DESC";

                var parameters = new SqlParameter[] { new SqlParameter("@thang", thang) };
                DataTable dt = DataProvider.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    Series series = new Series("Sách bán chạy");
                    series.ChartType = SeriesChartType.Column;

                    foreach (DataRow row in dt.Rows)
                    {
                        string tenSach = row["TenSach"].ToString();
                        int tongSoLuong = Convert.ToInt32(row["TongSoLuong"]);
                        series.Points.AddXY(tenSach, tongSoLuong);
                    }

                    chartThongKe.Series.Add(series);
                    chartThongKe.Titles.Add($"Top sách bán chạy - Tháng {thang}");
                }
                else
                {
                    lblKetQua.Text = $"Không có dữ liệu sách bán chạy cho tháng {thang}.";
                }
            }
            else if (loai == "Doanh thu theo nhân viên")
            {
                // Truy vấn doanh thu theo nhân viên
                string query = @"
            SELECT NV.HoTen, SUM(H.TongTien) AS TongDoanhThu
            FROM HoaDon H
            JOIN NhanVien NV ON H.MaNhanVien = NV.MaNhanVien
            WHERE MONTH(H.NgayLap) = @thang
            GROUP BY NV.HoTen
            ORDER BY TongDoanhThu DESC";

                var parameters = new SqlParameter[] { new SqlParameter("@thang", thang) };
                DataTable dt = DataProvider.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    Series series = new Series("Doanh thu theo nhân viên");
                    series.ChartType = SeriesChartType.Pie;

                    foreach (DataRow row in dt.Rows)
                    {
                        string tenNhanVien = row["HoTen"].ToString();
                        decimal tongDoanhThu = Convert.ToDecimal(row["TongDoanhThu"]);
                        series.Points.AddXY(tenNhanVien, tongDoanhThu);
                    }

                    chartThongKe.Series.Add(series);
                    chartThongKe.Titles.Add($"Doanh thu theo nhân viên - Tháng {thang}");
                }
                else
                {
                    lblKetQua.Text = $"Không có dữ liệu doanh thu theo nhân viên cho tháng {thang}.";
                }
            }
            else if (loai == "Tổng số hóa đơn")
            {
                // Truy vấn tổng số hóa đơn
                string query = "SELECT COUNT(*) AS TongSoHoaDon FROM HoaDon WHERE MONTH(NgayLap) = @thang";
                var parameters = new SqlParameter[] { new SqlParameter("@thang", thang) };

                DataTable dt = DataProvider.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    int tongSoHoaDon = Convert.ToInt32(dt.Rows[0]["TongSoHoaDon"]);
                    lblKetQua.Text = $"Tổng số hóa đơn tháng {thang}: {tongSoHoaDon}";
                }
                else
                {
                    lblKetQua.Text = $"Không có dữ liệu hóa đơn cho tháng {thang}.";
                }
            }
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
