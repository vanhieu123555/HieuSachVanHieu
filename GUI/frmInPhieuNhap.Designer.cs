namespace QuanLyHieuSach
{
    partial class frmInPhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInPhieuNhap));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bOOKSTOREDataSet4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bOOKSTOREDataSet4 = new QuanLyHieuSach.BOOKSTOREDataSet4();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bOOKSTOREDataSet4BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKSTOREDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyHieuSach.Reportphieunhap.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-4, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1050, 522);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // bOOKSTOREDataSet4BindingSource
            // 
            this.bOOKSTOREDataSet4BindingSource.DataSource = this.bOOKSTOREDataSet4;
            this.bOOKSTOREDataSet4BindingSource.Position = 0;
            // 
            // bOOKSTOREDataSet4
            // 
            this.bOOKSTOREDataSet4.DataSetName = "BOOKSTOREDataSet4";
            this.bOOKSTOREDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.bOOKSTOREDataSet4;
            // 
            // frmInPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 528);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInPhieuNhap";
            this.Text = "In phiếu nhập";
            this.Load += new System.EventHandler(this.frmInPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bOOKSTOREDataSet4BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKSTOREDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bOOKSTOREDataSet4BindingSource;
        private BOOKSTOREDataSet4 bOOKSTOREDataSet4;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
    }
}