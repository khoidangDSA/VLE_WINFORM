-- 1. Tạo cơ sở dữ liệu DBHocSinh
CREATE DATABASE DBHocSinh;
GO
USE DBHocSinh;
GO

-- 2. Tạo bảng Lop
CREATE TABLE Lop (
    MaLop VARCHAR(50) PRIMARY KEY,
    TenLop NVARCHAR(100),
    SiSo INT
);
GO

-- 3. Tạo bảng HocSinh (có khóa ngoại tham chiếu tới Lop)
CREATE TABLE HocSinh (
    MaHS VARCHAR(50) PRIMARY KEY,
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    Phai NVARCHAR(10),
    MaLop VARCHAR(50) FOREIGN KEY REFERENCES Lop(MaLop) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

-- 4. Chèn dữ liệu mẫu cho bảng Lop
INSERT INTO Lop (MaLop, TenLop, SiSo) VALUES 
('10A1', N'Lớp 10A1', 40),
('10A2', N'Lớp 10A2', 35),
('11B1', N'Lớp 11B1', 38);
GO

-- 5. Chèn dữ liệu mẫu cho bảng HocSinh
INSERT INTO HocSinh (MaHS, HoTen, NgaySinh, Phai, MaLop) VALUES 
('HS001', N'Đặng Nguyên Khôi', '2007-04-24', N'Nam', '10A1'),
('HS002', N'Nguyễn Văn A', '2007-08-15', N'Nam', '10A1'),
('HS003', N'Trần Thị B', '2007-12-01', N'Nữ', '10A2');
GO