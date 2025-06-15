-- Bảng thể loại sách
CREATE TABLE TheLoai (
    MaTheLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenTheLoai NVARCHAR(100) NOT NULL
);

-- Bảng sách
CREATE TABLE Sach (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(255) NOT NULL,
    TacGia NVARCHAR(255) NOT NULL,
    MaTheLoai INT,  -- Liên kết với thể loại sách
    
    NamXuatBan INT,
    GiaBan DECIMAL(10,2),
    SoLuongTon INT DEFAULT 0,
    FOREIGN KEY (MaTheLoai) REFERENCES TheLoai(MaTheLoai)
	ALTER TABLE Sach
ADD CONSTRAINT CHK_GiaBan CHECK (GiaBan >= 0),
    CONSTRAINT CHK_SoLuongTon CHECK (SoLuongTon >= 0),
    CONSTRAINT CHK_NamXuatBan CHECK (NamXuatBan >= 0 AND NamXuatBan <= 3000);
	ALTER TABLE Sach DROP CONSTRAINT CHK_NamXuatBan
);

-- Bảng khách hàng
CREATE TABLE KhachHang (
    MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(255) NOT NULL,
    SoDienThoai VARCHAR(11) UNIQUE,
    DiaChi NVARCHAR(255);
	alter table khachhang
	add CONSTRAINT CHK_SoDienThoaikhachhang CHECK (SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
	ALTER TABLE khachhang DROP CONSTRAINT CHK_SoDienThoaikhachhang
);

-- Bảng nhân viên
CREATE TABLE NhanVien (
    MaNhanVien INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(255) NOT NULL,
    SoDienThoai VARCHAR(15) UNIQUE,
    Email NVARCHAR(255) UNIQUE,
    ChucVu NVARCHAR(50),
    MatKhau NVARCHAR(255) NOT NULL;
	alter table nhanvien
	add CONSTRAINT CHK_SoDienThoai CHECK (SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' OR SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    CONSTRAINT CHK_Email CHECK (Email LIKE '%_@_%._%')
	ALTER TABLE nhanvien DROP CONSTRAINT CHK_SoDienThoai
);

-- Bảng hóa đơn bán hàng
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang INT,
    MaNhanVien INT,
    NgayLap DATE DEFAULT GETDATE(),
    TongTien DECIMAL(10,2),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- Bảng chi tiết hóa đơn (Lưu chi tiết từng sách trong hóa đơn)
CREATE TABLE ChiTietHoaDon (
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaDon INT,
    MaSach INT,
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(10,2),
    ThanhTien AS (SoLuong * DonGia), -- Tự động tính tổng tiền của từng sách
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);

-- Bảng nhà cung cấp
CREATE TABLE NhaCungCap (
    MaNCC INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(255) NOT NULL,
    SoDienThoai VARCHAR(15) UNIQUE,
    DiaChi NVARCHAR(255)
);

-- Bảng phiếu nhập sách
CREATE TABLE PhieuNhap (
    MaPhieuNhap INT IDENTITY(1,1) PRIMARY KEY,
    MaNCC INT,
    MaNhanVien INT,
    NgayNhap DATE DEFAULT GETDATE(),
    TongTien DECIMAL(10,2),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- Bảng chi tiết phiếu nhập (Lưu sách nhập về)
CREATE TABLE ChiTietPhieuNhap (
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuNhap INT,
    MaSach INT,
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(10,2),
    ThanhTien AS (SoLuong * DonGia),
    FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);


-- Thêm thể loại sách
INSERT INTO TheLoai (TenTheLoai) VALUES ('Khoa học'), ('Tiểu thuyết'), ('Lịch sử');

-- Thêm sách
INSERT INTO Sach (TenSach, TacGia, MaTheLoai, NhaXuatBan, NamXuatBan, GiaBan, SoLuongTon)  
VALUES  
    ('Sapiens', 'Yuval Noah Harari', 1, 'NXB Tri Thức', 2018, 150000, 10),
    ('Sherlock Holmes', 'Arthur Conan Doyle', 2, 'NXB Kim Đồng', 2020, 120000, 5),
    (N'Lịch Sử Việt Nam', N'Nhiều tác giả', 3, 'NXB Giáo Dục', 2015, 200000, 8);

UPDATE TheLoai SET TenTheLoai= N'Khoa học' WHERE MaTheLoai = 1;
UPDATE TheLoai SET TenTheLoai= N'Tiểu thuyết' WHERE MaTheLoai = 2;
UPDATE TheLoai SET TenTheLoai= N'Lịch sử' WHERE MaTheLoai = 3;

select * from TheLoai;
SELECT TenSach, TacGia, GiaBan, SoLuongTon FROM Sach WHERE SoLuongTon > 0;

SELECT MONTH(NgayLap) AS Thang, SUM(TongTien) AS DoanhThu  
FROM HoaDon  
GROUP BY MONTH(NgayLap)  
ORDER BY Thang;


ALTER TABLE Sach DROP COLUMN NhaXuatBan;

UPDATE Sach SET TacGia = N'Nhiều tác giả' WHERE MaSach = 3;

CREATE TABLE VaiTro (
    MaVaiTro INT IDENTITY(1,1) PRIMARY KEY,
    TenVaiTro NVARCHAR(50) UNIQUE NOT NULL  -- (Chủ cửa hàng, Nhân viên bán hàng, Quản lý kho)
);


ALTER TABLE NhanVien ADD MaVaiTro INT;

ALTER TABLE NhanVien ADD FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro);

INSERT INTO VaiTro (TenVaiTro) VALUES ('ChuCuaHang'), ('NhanVienBanHang'), ('QuanLyKho');

INSERT INTO NhanVien (HoTen, SoDienThoai, Email, ChucVu, MatKhau, MaVaiTro)  
VALUES  
    (N'Nguyễn Văn A', '0901234567', 'chu@hieusach.com', N'Chủ cửa hàng', '123456', 1),  
    (N'Trần Thị B', '0909876543', 'nvbh@hieusach.com',N'Nhân viên bán hàng', '123456', 2),  
    (N'Lê Văn C', '0912345678', 'qlkho@hieusach.com',N'Quản lý kho', '123456', 3);


SELECT NhanVien.HoTen, NhanVien.Email, VaiTro.TenVaiTro  
FROM NhanVien  
JOIN VaiTro ON NhanVien.MaVaiTro = VaiTro.MaVaiTro;

SELECT VaiTro.TenVaiTro
FROM NhanVien
JOIN VaiTro ON NhanVien.MaVaiTro = VaiTro.MaVaiTro
WHERE NhanVien.MaNhanVien = 1	;  -- @MaNhanVien là ID của nhân viên đăng nhập



-- Cập nhật nhân viên với các vai trò
UPDATE NhanVien SET MaVaiTro = 1 WHERE ChucVu = N'Chủ cửa hàng';
UPDATE NhanVien SET MaVaiTro = 2 WHERE ChucVu = N'Nhân viên bán hàng';
UPDATE NhanVien SET MaVaiTro = 3 WHERE ChucVu = N'Quản lý kho';

select *from NhanVien;

select* from VaiTro

select* from Sach

select* from KhachHang

select* from HoaDon
select * from ChiTietHoaDon
select* from NhaCungCap

select* from phieunhap

select* from chitietphieunhap




DELETE  FROM phieunhap
  WHERE Maphieunhap=1;

  DELETE  FROM HoaDon
  WHERE MaHoaDon=1010;

  DBCC CHECKIDENT ('PhieuNhap', RESEED, 0);
  DBCC CHECKIDENT ('chitietPhieuNhap', RESEED, 0);

       SELECT IDENT_CURRENT('PhieuNhap') AS CurrentIdentity;
	   SELECT IDENT_CURRENT('chitietPhieuNhap') AS CurrentIdentity;
     



ALTER TABLE ChiTiethoadon

ADD TenSach NVARCHAR(255);


CREATE TRIGGER trg_UpdateSoLuongTon
ON ChiTietPhieuNhap
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật SoLuongTon trong bảng Sach
    UPDATE Sach
    SET SoLuongTon = SoLuongTon + i.SoLuong
    FROM Sach s
    INNER JOIN Inserted i ON s.MaSach = i.MaSach;
END;



CREATE TRIGGER trg_UpdateSoLuongTon_AfterInsert
ON ChiTietHoaDon
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật SoLuongTon trong bảng Sach
    UPDATE Sach
    SET SoLuongTon = SoLuongTon - i.SoLuong
    FROM Sach s
    INNER JOIN Inserted i ON s.MaSach = i.MaSach;

    -- Kiểm tra nếu SoLuongTon bị âm
    IF EXISTS (
        SELECT 1
        FROM Sach
        WHERE SoLuongTon < 0
    )
    BEGIN
        -- Rollback giao dịch nếu số lượng tồn bị âm
        RAISERROR ('Số lượng tồn không đủ để bán!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;



