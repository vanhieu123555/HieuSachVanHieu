namespace QuanLyHieuSach
{
    partial class ucQuanLyHangTon
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
            this.label1 = new System.Windows.Forms.Label();
            this.chkSapHet = new System.Windows.Forms.CheckBox();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.dgvHangTon = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTongSoLuong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lọc theo thể loại";
            // 
            // chkSapHet
            // 
            this.chkSapHet.AutoSize = true;
            this.chkSapHet.Location = new System.Drawing.Point(12, 191);
            this.chkSapHet.Name = "chkSapHet";
            this.chkSapHet.Size = new System.Drawing.Size(152, 20);
            this.chkSapHet.TabIndex = 1;
            this.chkSapHet.Text = "Hiển thị sách sắp hết";
            this.chkSapHet.UseVisualStyleBackColor = true;
            this.chkSapHet.CheckedChanged += new System.EventHandler(this.chkSapHet_CheckedChanged);
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(191, 60);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(185, 24);
            this.cboTheLoai.TabIndex = 3;
            this.cboTheLoai.SelectedIndexChanged += new System.EventHandler(this.cboTheLoai_SelectedIndexChanged);
            // 
            // dgvHangTon
            // 
            this.dgvHangTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangTon.Location = new System.Drawing.Point(-3, 217);
            this.dgvHangTon.Name = "dgvHangTon";
            this.dgvHangTon.RowHeadersWidth = 51;
            this.dgvHangTon.RowTemplate.Height = 24;
            this.dgvHangTon.Size = new System.Drawing.Size(983, 393);
            this.dgvHangTon.TabIndex = 24;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(359, 158);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 43);
            this.btnLamMoi.TabIndex = 98;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(868, 165);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 100;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(629, 168);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(231, 22);
            this.txtTimKiem.TabIndex = 99;
            // 
            // lblTongSoLuong
            // 
            this.lblTongSoLuong.AutoSize = true;
            this.lblTongSoLuong.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblTongSoLuong.Location = new System.Drawing.Point(549, 52);
            this.lblTongSoLuong.Name = "lblTongSoLuong";
            this.lblTongSoLuong.Size = new System.Drawing.Size(0, 32);
            this.lblTongSoLuong.TabIndex = 101;
            // 
            // ucQuanLyHangTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTongSoLuong);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvHangTon);
            this.Controls.Add(this.cboTheLoai);
            this.Controls.Add(this.chkSapHet);
            this.Controls.Add(this.label1);
            this.Name = "ucQuanLyHangTon";
            this.Size = new System.Drawing.Size(980, 627);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangTon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSapHet;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.DataGridView dgvHangTon;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTongSoLuong;
    }
}
