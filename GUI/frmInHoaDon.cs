using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;
using BLL;
using theloai_dto;
using DAL;

namespace QuanLyHieuSach
{
    public partial class frmInHoaDon : Form
    {
        private int maHoaDon; // Lưu mã hóa đơn được truyề
        public frmInHoaDon(int maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {

            
            LoadReport(maHoaDon);
        }
        private void LoadReport(int maHoaDon)
        {
            try
            {
                // Sử dụng TableAdapter để lấy dữ liệu
                var tableAdapter = new BOOKSTOREDataSet5TableAdapters.DataTable1TableAdapter();

                var dataTable = tableAdapter.GetDataByMaHoaDon(maHoaDon);

                // Gán dữ liệu vào ReportViewer
                this.reportViewer1.LocalReport.DataSources.Clear();
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("HoaDonChiTiet", (DataTable)dataTable);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
