using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHieuSach
{
    public partial class frmInPhieuNhap : Form
    {
        private int maPhieuNhap; // Lưu mã phiếu nhập được truyền
        public frmInPhieuNhap(int maPhieuNhap)
        {
            InitializeComponent();
            this.maPhieuNhap = maPhieuNhap;
        }

        private void frmInPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadReport(maPhieuNhap);
            this.reportViewer1.RefreshReport();
        }
        private void LoadReport(int maPhieuNhap)
        {
            //try
            //{
            //    // Sử dụng TableAdapter để lấy dữ liệu
            //    var tableAdapter = new BOOKSTOREDataSet4TableAdapters.DataTable1TableAdapter();
            //    var dataTable = tableAdapter.GetDataByMaPhieuNhap(maPhieuNhap);

            //    // Gán dữ liệu vào ReportViewer
            //    this.reportViewer1.LocalReport.DataSources.Clear();
            //    var reportDataSource = new ReportDataSource("PhieuNhapChiTiet", (DataTable)dataTable);
            //    this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            //    this.reportViewer1.RefreshReport();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            try
            {
                // Sử dụng TableAdapter để lấy dữ liệu
                var tableAdapter = new BOOKSTOREDataSet4TableAdapters.DataTable1TableAdapter();
                var dataTable = tableAdapter.GetDataByMaPhieuNhap(maPhieuNhap);

                // Kiểm tra dữ liệu trả về
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu cho mã phiếu nhập: " + maPhieuNhap, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu vào ReportViewer
                this.reportViewer1.LocalReport.DataSources.Clear();
                var reportDataSource = new ReportDataSource("PhieuNhapChiTiet", (DataTable)dataTable);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception /*ex*/)
            {
                MessageBox.Show("Không thể in phiếu nhập 2 chi tiết " , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reportViewer1.Visible = false;
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
