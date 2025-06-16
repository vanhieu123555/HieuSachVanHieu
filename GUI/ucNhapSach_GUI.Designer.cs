namespace QuanLyHieuSach
{
    partial class ucNhapSach_GUI
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSach = new System.Windows.Forms.ComboBox();
            this.btnNhaCCMoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboNhaCC = new System.Windows.Forms.ComboBox();
            this.dgvChiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.btnThemVaoDS = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoaKhoiDS = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvDanhSachSach = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(588, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 108;
            this.label5.Text = "Số lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(675, 72);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(231, 22);
            this.txtSoLuong.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 106;
            this.label2.Text = "Sản phẩm";
            // 
            // cboSach
            // 
            this.cboSach.FormattingEnabled = true;
            this.cboSach.Location = new System.Drawing.Point(101, 67);
            this.cboSach.Name = "cboSach";
            this.cboSach.Size = new System.Drawing.Size(231, 24);
            this.cboSach.TabIndex = 105;
            this.cboSach.Tag = "";
            // 
            // btnNhaCCMoi
            // 
            this.btnNhaCCMoi.Location = new System.Drawing.Point(352, 21);
            this.btnNhaCCMoi.Name = "btnNhaCCMoi";
            this.btnNhaCCMoi.Size = new System.Drawing.Size(94, 24);
            this.btnNhaCCMoi.TabIndex = 104;
            this.btnNhaCCMoi.Text = "Nhà CC mới";
            this.btnNhaCCMoi.UseVisualStyleBackColor = true;
            this.btnNhaCCMoi.Click += new System.EventHandler(this.btnNhaCCMoi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(588, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 103;
            this.label1.Text = "Nhân viên";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(675, 26);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(231, 24);
            this.cboNhanVien.TabIndex = 102;
            this.cboNhanVien.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 101;
            this.label4.Text = "Nhà CC";
            // 
            // cboNhaCC
            // 
            this.cboNhaCC.FormattingEnabled = true;
            this.cboNhaCC.Location = new System.Drawing.Point(101, 21);
            this.cboNhaCC.Name = "cboNhaCC";
            this.cboNhaCC.Size = new System.Drawing.Size(231, 24);
            this.cboNhaCC.TabIndex = 100;
            this.cboNhaCC.Tag = "";
            // 
            // dgvChiTietPhieuNhap
            // 
            this.dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuNhap.Location = new System.Drawing.Point(486, 218);
            this.dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            this.dgvChiTietPhieuNhap.RowHeadersWidth = 51;
            this.dgvChiTietPhieuNhap.RowTemplate.Height = 24;
            this.dgvChiTietPhieuNhap.Size = new System.Drawing.Size(493, 393);
            this.dgvChiTietPhieuNhap.TabIndex = 99;
            // 
            // btnThemVaoDS
            // 
            this.btnThemVaoDS.Location = new System.Drawing.Point(79, 167);
            this.btnThemVaoDS.Name = "btnThemVaoDS";
            this.btnThemVaoDS.Size = new System.Drawing.Size(75, 43);
            this.btnThemVaoDS.TabIndex = 98;
            this.btnThemVaoDS.Text = "Thêm vào DS";
            this.btnThemVaoDS.UseVisualStyleBackColor = true;
            this.btnThemVaoDS.Click += new System.EventHandler(this.btnThemVaoDS_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(433, 167);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 43);
            this.btnLamMoi.TabIndex = 97;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoaKhoiDS
            // 
            this.btnXoaKhoiDS.Location = new System.Drawing.Point(310, 167);
            this.btnXoaKhoiDS.Name = "btnXoaKhoiDS";
            this.btnXoaKhoiDS.Size = new System.Drawing.Size(75, 43);
            this.btnXoaKhoiDS.TabIndex = 96;
            this.btnXoaKhoiDS.Text = "Xóa khỏi ds";
            this.btnXoaKhoiDS.UseVisualStyleBackColor = true;
            this.btnXoaKhoiDS.Click += new System.EventHandler(this.btnXoaKhoiDS_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(831, 167);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 95;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(592, 170);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(231, 22);
            this.txtTimKiem.TabIndex = 94;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(510, 118);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(30, 32);
            this.lblTongTien.TabIndex = 93;
            this.lblTongTien.Text = "..";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(194, 167);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 43);
            this.btnLuu.TabIndex = 92;
            this.btnLuu.Text = "Lưu phiếu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvDanhSachSach
            // 
            this.dgvDanhSachSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachSach.Location = new System.Drawing.Point(1, 218);
            this.dgvDanhSachSach.Name = "dgvDanhSachSach";
            this.dgvDanhSachSach.RowHeadersWidth = 51;
            this.dgvDanhSachSach.RowTemplate.Height = 24;
            this.dgvDanhSachSach.Size = new System.Drawing.Size(479, 393);
            this.dgvDanhSachSach.TabIndex = 91;
            this.dgvDanhSachSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachSach_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(352, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 27);
            this.button1.TabIndex = 109;
            this.button1.Text = "Sách mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(364, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 32);
            this.label3.TabIndex = 110;
            this.label3.Text = "Tổng tiền:";
            // 
            // ucNhapSach_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSach);
            this.Controls.Add(this.btnNhaCCMoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboNhaCC);
            this.Controls.Add(this.dgvChiTietPhieuNhap);
            this.Controls.Add(this.btnThemVaoDS);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoaKhoiDS);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvDanhSachSach);
            this.Name = "ucNhapSach_GUI";
            this.Size = new System.Drawing.Size(980, 627);
            this.Load += new System.EventHandler(this.ucNhapSach_GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSach;
        private System.Windows.Forms.Button btnNhaCCMoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboNhaCC;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuNhap;
        private System.Windows.Forms.Button btnThemVaoDS;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoaKhoiDS;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvDanhSachSach;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}
