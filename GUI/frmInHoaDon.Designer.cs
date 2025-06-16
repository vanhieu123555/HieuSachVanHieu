namespace QuanLyHieuSach
{
    partial class frmInHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInHoaDon));
            this.bOOKSTOREDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bOOKSTOREDataSet2 = new QuanLyHieuSach.BOOKSTOREDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKSTOREDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKSTOREDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // bOOKSTOREDataSet2BindingSource
            // 
            this.bOOKSTOREDataSet2BindingSource.DataSource = this.bOOKSTOREDataSet2;
            this.bOOKSTOREDataSet2BindingSource.Position = 0;
            // 
            // bOOKSTOREDataSet2
            // 
            this.bOOKSTOREDataSet2.DataSetName = "BOOKSTOREDataSet2";
            this.bOOKSTOREDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "hoadon";
            reportDataSource1.Value = this.bOOKSTOREDataSet2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyHieuSach.ReportHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-4, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1050, 522);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmInHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 528);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInHoaDon";
            this.Text = "In hóa đơn";
            this.Load += new System.EventHandler(this.frmInHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bOOKSTOREDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKSTOREDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bOOKSTOREDataSet2BindingSource;
        private BOOKSTOREDataSet2 bOOKSTOREDataSet2;
    }
}