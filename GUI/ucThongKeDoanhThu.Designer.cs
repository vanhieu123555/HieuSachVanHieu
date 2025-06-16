namespace QuanLyHieuSach
{
    partial class ucThongKeDoanhThu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cboLoaiThongKe = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.chartThongKe = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblKetQua = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLoaiThongKe
            // 
            this.cboLoaiThongKe.FormattingEnabled = true;
            this.cboLoaiThongKe.Location = new System.Drawing.Point(199, 37);
            this.cboLoaiThongKe.Name = "cboLoaiThongKe";
            this.cboLoaiThongKe.Size = new System.Drawing.Size(233, 24);
            this.cboLoaiThongKe.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loại thống kê:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tháng:";
            // 
            // cboThang
            // 
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(199, 80);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(233, 24);
            this.cboThang.TabIndex = 2;
            this.cboThang.SelectedIndexChanged += new System.EventHandler(this.cboThang_SelectedIndexChanged);
            // 
            // chartThongKe
            // 
            chartArea3.Name = "ChartArea1";
            this.chartThongKe.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartThongKe.Legends.Add(legend3);
            this.chartThongKe.Location = new System.Drawing.Point(0, 185);
            this.chartThongKe.Name = "chartThongKe";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartThongKe.Series.Add(series3);
            this.chartThongKe.Size = new System.Drawing.Size(977, 439);
            this.chartThongKe.TabIndex = 4;
            this.chartThongKe.Text = "chartThongKe";
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblKetQua.Location = new System.Drawing.Point(85, 118);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(0, 32);
            this.lblKetQua.TabIndex = 5;
            // 
            // ucThongKeDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.chartThongKe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLoaiThongKe);
            this.Name = "ucThongKeDoanhThu";
            this.Size = new System.Drawing.Size(980, 627);
            this.Load += new System.EventHandler(this.ucThongKeDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartThongKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLoaiThongKe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThongKe;
        private System.Windows.Forms.Label lblKetQua;
    }
}
