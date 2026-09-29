-- Tạo database QLBanMatKinh
CREATE DATABASE QLBanMatKinh
GO

USE QLBanMatKinh
GO

-- ========================================
-- TẠO CÁC BẢNG CHÍNH
-- ========================================

CREATE TABLE Suppliers (
    SupplierID INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(100),
    Address NVARCHAR(255),
    Phone NVARCHAR(20)
);

CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100),
    Description NVARCHAR(255)
);

CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(200),
    ManufactureYear INT,
    StockQuantity INT,
    Price DECIMAL(18,2),
    ShortDescription NVARCHAR(MAX),
    Avatar NVARCHAR(255),
    CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
    SupplierID INT FOREIGN KEY REFERENCES Suppliers(SupplierID)
);

CREATE TABLE ProductImages (
    ImageID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    ImageName NVARCHAR(255)
);

CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    Password NVARCHAR(100),
    Gender NVARCHAR(10),
    BirthYear INT,
    Avatar NVARCHAR(255),
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    Address NVARCHAR(255)
);

CREATE TABLE Roles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50),
    Description NVARCHAR(255)
);

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    Password NVARCHAR(100),
    FullName NVARCHAR(100),
    Gender NVARCHAR(10),
    BirthYear INT,
    RoleID INT FOREIGN KEY REFERENCES Roles(RoleID)
);

CREATE TABLE OrderStatuses (
    StatusID INT IDENTITY(1,1) PRIMARY KEY,
    StatusName NVARCHAR(50)
);

-- Bảng Màu sắc mắt kính
CREATE TABLE Colors (
    ColorID INT IDENTITY(1,1) PRIMARY KEY,
    ColorName NVARCHAR(50) NOT NULL,
    HexCode VARCHAR(10) NULL
);

-- Bảng Độ cận / Độ khúc xạ
CREATE TABLE Diopters (
    DiopterID INT IDENTITY(1,1) PRIMARY KEY,
    DiopterValue DECIMAL(4,2) NOT NULL,
    Description NVARCHAR(100) NULL
);

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
    OrderDate DATETIME,
    TotalAmount DECIMAL(18,2),
    StatusID INT FOREIGN KEY REFERENCES OrderStatuses(StatusID),
    ShippingAddress NVARCHAR(255),
    IsPaid BIT
);

CREATE TABLE OrderDetails (
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT,
    UnitPrice DECIMAL(18,2),
    ColorID INT NULL FOREIGN KEY REFERENCES Colors(ColorID),
    DiopterID INT NULL FOREIGN KEY REFERENCES Diopters(DiopterID),
    PRIMARY KEY (OrderID, ProductID)
);

-- ========================================
-- DỮ LIỆU MẪU 
-- ========================================

-- 1. Nhà cung cấp
INSERT INTO Suppliers (SupplierName, Address, Phone)
VALUES 
(N'Công ty Tập đoàn EssilorLuxottica Việt Nam', N'TP. Hồ Chí Minh', '02838221122'),
(N'Công ty Phân phối Mắt kính Kính Hải Triều', N'Hà Nội', '02439887766'),
(N'Công ty TNHH Mắt kính Việt Long', N'Đà Nẵng', '02363554433');

-- 2. Loại sản phẩm
INSERT INTO Categories (CategoryName, Description)
VALUES 
(N'Kính râm / Kính mát', N'Các loại kính mát thời trang chống tia UV'),
(N'Gọng kính cận', N'Gọng kính thời trang cao cấp bằng titan, nhựa mỏng nhẹ'),
(N'Tròng kính', N'Tròng kính chống ánh sáng xanh, đổi màu, chống bám nước'),
(N'Phụ kiện & Chăm sóc', N'Nước lau kính, hộp đựng, khăn lau chuyên dụng, dây đeo');

select * from Categories

-- 3. 20 Sản phẩm mắt kính
INSERT INTO Products (ProductName, ManufactureYear, StockQuantity, Price, ShortDescription, CategoryID, Avatar, SupplierID)
VALUES
(N'Kính mát Ray-Ban Aviator Classic RB3025', 2024, 50, 4850000, N'Gọng kim loại mạ vàng sang trọng, tròng kính chống 100% tia UV, phong cách phi công huyền thoại.', 1, N'h1.jpg', 1),
(N'Kính mát Ray-Ban Wayfarer Classic RB2140', 2023, 40, 4550000, N'Thiết kế nhựa Acetate đen bóng kinh điển, phong cách hiện đại cá tính.', 1, N'h2.jpg', 1),
(N'Kính mát Oakley Holbrook OO9102', 2024, 35, 3950000, N'Kính mát thể thao, tròng Prizm cải thiện màu sắc và độ tương phản.', 1, N'h3.jpg', 1),
(N'Kính mát Gucci GG0036S', 2024, 20, 9200000, N'Gọng vuông acetate đen sang trọng cho nữ, logo Gucci mạ vàng nổi bật.', 1, N'h4.jpg', 2),
(N'Kính mát Dior BlackSuit S3I', 2024, 15, 12500000, N'Thương hiệu thời trang xa xỉ Dior, thiết kế vuông thời thượng.', 1, N'h5.jpg', 2),
(N'Gọng kính Bolon BJ7180', 2024, 60, 2680000, N'Thiết kế gọng titan siêu nhẹ, thanh lịch phù hợp cho dân văn phòng.', 2, N'h6.jpg', 2),
(N'Gọng kính Gentle Monster South Side', 2024, 45, 6100000, N'Gọng vuông nhựa Acetate màu đen, xu hướng thời trang Hàn Quốc.', 2, N'h7.jpg', 2),
(N'Gọng kính Charmant Titanium Z ZT2230', 2024, 30, 4950000, N'Chất liệu Titanium cao cấp siêu bền, chống gỉ sét, trọng lượng nhẹ.', 2, N'h8.jpg', 3),
(N'Gọng kính Vogue VO5312', 2023, 55, 1980000, N'Gọng nhựa trẻ trung đa dạng màu sắc dành cho nữ giới.', 2, N'h9.jpg', 1),
(N'Gọng kính Exfash EF38210', 2024, 80, 1150000, N'Gọng dẻo Ultem đàn hồi tốt, chịu lực, thích hợp sử dụng hàng ngày.', 2, N'h10.jpg', 3),
(N'Tròng kính Essilor Crizal Rock 1.56', 2024, 100, 1280000, N'Tăng cường khả năng chống trầy xước gấp 3 lần, chống bám bụi và dấu vân tay.', 3, N'h11.jpg', 1),
(N'Tròng kính Chemi U2 1.60 Hi-Index', 2024, 150, 630000, N'Tròng mỏng siêu trong, phủ lớp U2 chống bám nước, chống tia UV400.', 3, N'h12.jpg', 3),
(N'Tròng kính đổi màu Hoya Transition Classic 1.55', 2024, 70, 1850000, N'Đổi màu nhanh chóng khi ra nắng và trong suốt khi ở trong nhà.', 3, N'h13.jpg', 3),
(N'Tròng kính chống ánh sáng xanh Element 1.61', 2024, 120, 850000, N'Lọc ánh sáng xanh có hại từ máy tính, điện thoại, giảm mỏi mắt.', 3, N'h14.jpg', 3),
(N'Chai xịt vệ sinh mắt kính chuyên dụng 50ml', 2024, 300, 45000, N'Làm sạch vết bẩn, dầu mỡ trên tròng kính, bảo vệ lớp phủ tròng.', 4, N'h15.jpg', 3),
(N'Khăn lau kính Nano chống mờ sương', 2024, 500, 35000, N'Công nghệ Nano chống đọng hơi nước khi đeo khẩu trang hoặc ăn đồ nóng.', 4, N'h16.jpg', 3),
(N'Hộp đựng kính bọc da cao cấp', 2024, 200, 150000, N'Hộp da cứng bảo vệ kính chống va đập, trầy xước.', 4, N'h17.jpg', 2),
(N'Dây đeo giữ kính thể thao Silicone', 2024, 250, 50000, N'Giữ kính không bị rơi khi vận động mạnh hoặc chơi thể thao.', 4, N'h18.jpg', 3),
(N'Kính mát Prada PR17WS', 2024, 25, 8900000, N'Gọng hình chữ nhật cách điệu, sang trọng thời thượng.', 1, N'h19.jpg', 1),
(N'Gọng kính cận Parim 83611', 2024, 90, 890000, N'Kiểu dáng phi công thời trang, hợp kim mỏng nhẹ.', 2, N'h20.jpg', 3);

-- 4. Hình ảnh phụ của sản phẩm
INSERT INTO ProductImages (ProductID, ImageName)
VALUES
(1, N'rayban_rb3025_side.jpg'), (1, N'rayban_rb3025_case.jpg'),
(2, N'rayban_rb2140_side.jpg'),
(6, N'bolon_bj7180_front.jpg'), (6, N'bolon_bj7180_detail.jpg'),
(7, N'gm_southside_box.jpg'),
(11, N'trong_essilor_cert.jpg'),
(13, N'trong_hoya_outdoor.jpg');

-- 5. Khách hàng, Vai trò & Nhân viên
INSERT INTO Customers (FullName, Password, Gender, BirthYear, Avatar, Phone, Email, Address)
VALUES 
(N'Trần Minh Hoàng', N'123456', N'Nam', 1996, N'kh1.jpg', '0908123456', 'hoang.tm@gmail.com', N'Quận 1, TP. Hồ Chí Minh'),
(N'Nguyễn Phương Anh', N'abcdef', N'Nữ', 1999, N'kh2.jpg', '0912345678', 'p.anh99@gmail.com', N'Cầu Giấy, Hà Nội'),
(N'Lê Hoàng Nam', N'pass123', N'Nam', 2001, N'kh3.jpg', '0988776655', 'nam.lh@yahoo.com', N'Hải Châu, Đà Nẵng');

INSERT INTO Roles (RoleName, Description)
VALUES 
(N'Admin', N'Quản lý hệ thống cửa hàng'),
(N'Nhân viên bán hàng', N'Tư vấn và lập hóa đơn bán hàng');

INSERT INTO Employees (Password, FullName, Gender, BirthYear, RoleID)
VALUES 
(N'admin123', N'Phạm Quang Huy', N'Nam', 1992, 1),
(N'nv123', N'Đỗ Thị Thảo', N'Nữ', 1997, 2),
(N'nv456', N'Nguyễn Văn Tuấn', N'Nam', 1995, 2);

-- 6. Tình trạng đơn hàng
INSERT INTO OrderStatuses (StatusName)
VALUES 
(N'Đang chờ xử lý'),
(N'Đã giao hàng'),
(N'Đã hủy');

-- 7. Danh sách Màu sắc
INSERT INTO Colors (ColorName, HexCode)
VALUES 
(N'Đen tuyền (Black)', '#000000'),
(N'Vàng kim (Gold)', '#FFD700'),
(N'Bạc (Silver)', '#C0C0C0'),
(N'Xám khói (Smoke Grey)', '#708090'),
(N'Nâu đồi mồi (Tortoise)', '#8B4513'),
(N'Trong suốt (Clear)', '#FFFFFF'),
(N'Xanh rêu (G-15 Green)', '#2E8B57'),
(N'Tráng gương xanh (Blue Mirror)', '#1E90FF');

-- 8. Danh sách Độ cận
INSERT INTO Diopters (DiopterValue, Description)
VALUES 
(0.00, N'Không độ (Thời trang / Chống ánh sáng xanh)'),
(-0.50, N'Cận nhẹ 0.50 độ'),
(-0.75, N'Cận nhẹ 0.75 độ'),
(-1.00, N'Cận 1.00 độ'),
(-1.25, N'Cận 1.25 độ'),
(-1.50, N'Cận 1.50 độ'),
(-1.75, N'Cận 1.75 độ'),
(-2.00, N'Cận 2.00 độ'),
(-2.25, N'Cận 2.25 độ'),
(-2.50, N'Cận 2.50 độ'),
(-2.75, N'Cận 2.75 độ'),
(-3.00, N'Cận 3.00 độ'),
(-3.50, N'Cận 3.50 độ'),
(-4.00, N'Cận 4.00 độ'),
(-4.50, N'Cận 4.50 độ'),
(-5.00, N'Cận 5.00 độ'),
(-6.00, N'Cận nặng 6.00 độ');

-- 9. Đơn hàng
INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, TotalAmount, StatusID, ShippingAddress, IsPaid)
VALUES 
(1, 2, '2024-08-10 09:15:00', 6130000, 2, N'Quận 1, TP. Hồ Chí Minh', 1),
(2, 2, '2024-08-12 14:30:00', 9200000, 2, N'Cầu Giấy, Hà Nội', 1),
(3, 3, '2024-08-15 16:00:00', 3530000, 1, N'Hải Châu, Đà Nẵng', 0);

-- 10. Chi tiết đơn hàng (có lưu thông tin Màu & Độ cận đã chọn)
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice, ColorID, DiopterID)
VALUES 
(1, 1, 1, 4850000, 2, 1),   -- 1 Kính Ray-Ban Aviator (Màu Vàng kim, Không độ)
(1, 11, 1, 1280000, NULL, 10),-- 1 Tròng Essilor (Độ cận -2.50 độ)
(2, 4, 1, 9200000, 1, 1),   -- 1 Kính Gucci (Màu Đen tuyền, Không độ)
(3, 6, 1, 2680000, 3, NULL), -- 1 Gọng Bolon (Màu Bạc)
(3, 14, 1, 850000, NULL, 6);  -- 1 Tròng lọc ánh sáng xanh (Độ cận -1.50 độ)

