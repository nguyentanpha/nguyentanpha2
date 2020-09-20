CREATE DATABASE QuanLyQuanCafe
GO

USE QuanLyQuanCafe
GO

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- Bill info
CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	ten NVARCHAR(100)	NOT NULL DEFAULT N'Bàn Có Người ', -- t thay Name = ten
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'-- Trống || Có Người
)
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Kter',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL DEFAULT 0 -- 1: admin && 0: staff
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	ten NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	ten NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0

	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: đã thanh toán && 0: chưa thanh toán

	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO
--acc của thang pha
INSERT INTO Account
(
	UserName,
	DisplayName,
	PassWord,
	Type
)
values ( N'tanpha',-- UserName - nvarchar(100)
		 N'tanpha',-- DisplayName - nvarchar(100)
		 N'1',-- PassWord - nvarchar(1100)
		 1 -- Type - int		
		)


--Acc cua vu
INSERT INTO Account
(
	UserName,
	DisplayName,
	PassWord,
	Type
)
values ( N'vu',-- UserName - nvarchar(100)
		 N'vu',-- DisplayName - nvarchar(100)
		 N'1',-- PassWord - nvarchar(1100)
		 1 -- Type - int
		)
--Acc cua Tri Map
INSERT INTO Account
(
	UserName,
	DisplayName,
	PassWord,
	Type
)
values ( N'ct',-- UserName - nvarchar(100)
		 N'Cao Trí',-- DisplayName - nvarchar(100)
		 N'1',-- PassWord - nvarchar(1100)
		 1 -- Type - int
		)

-- nhân viên 
INSERT INTO Account
(
	UserName,
	DisplayName,
	PassWord,
	Type
)
values ( N'nhanvien',-- UserName - nvarchar(100)
		 N'Tên Nhân Viên',-- DisplayName - nvarchar(100)
		 N'1',-- PassWord - nvarchar(1100)
		 0 -- Type - int
		)

GO

CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS
BEGIN
	SELECT * FROM Account WHERE UserName = @userName
END
GO

CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

-- tạo bàn 
DECLARE @i int = 0
while @i <=10
begin
		insert dbo.TableFood (Ten) values (N'Bàn '+CAST(@i as nvarchar(100)))
		set @i = @i +1
end
select * from dbo.TableFood

go

Create proc USP_GetTableList
As select * from dbo.TableFood
go

update dbo.TableFood set status =N'Có người' where id =1
update dbo.TableFood set status =N'Có người' where id =3



exec dbo.USP_GetTableList

--HIỂN THỊ HÓA ĐƠN THEO BÀN
--thêm category
INSERT dbo.FoodCategory
        ( ten )
VALUES  ( N'Cà Phê'  -- ten - nvarchar(100)
          )
INSERT dbo.FoodCategory
        ( ten )
VALUES  ( N'Trà' )
INSERT dbo.FoodCategory
        ( ten )
VALUES  ( N'Soda' )
INSERT dbo.FoodCategory
        ( ten )
VALUES  ( N'Ice Blended' )
INSERT dbo.FoodCategory
        ( ten )
VALUES  ( N'Trái Cây Dầm' )
INSERT dbo.FoodCategory
        ( ten )
VALUES  ( N'Yaourt' )
INSERT dbo.FoodCategory
        ( ten )
VALUES  ( N'Nước Ngọt' )
INSERT dbo.FoodCategory
        ( ten )
VALUES  ( N'Sinh Tố' )
INSERT dbo.FoodCategory
        ( ten )
VALUES  ( N'Nước Ép' )

--thêm món ăn thức uống
-- cà phê
insert dbo.Food
		(ten,idCategory,price)
values (N'Cà phê sữa nóng/ đá',1,23000) 
insert dbo.Food
		(ten,idCategory,price)
values (N'Cà phê nóng/đá',1,21000)
-- Trà
insert dbo.Food
		(ten,idCategory,price)
values (N'Trà Lipton trái cây đá ',2,37000)
insert dbo.Food
		(ten,idCategory,price)
values (N'Trà (Bạc Hà/ Gừng/ Hoa Cúc/ Mật Ong) nóng/đá',2,35000)
-- Soda
insert dbo.Food
		(ten,idCategory,price)
values (N'Soda Strawberry',3,35000)
insert dbo.Food
		(ten,idCategory,price)
values (N'Chanh Dây/Phúc Bồn Tử',3,35000)
--Ice Blended
insert dbo.Food
		(ten,idCategory,price)
values (N'Matcha đá xay',4,41000)
insert dbo.Food
		(ten,idCategory,price)
values (N'Chocolate đá xay',4,41000)
-- Trái Cây Dầm
insert dbo.Food
		(ten,idCategory,price)
values (N'Dưa Gang Dầm Sữa',5,37000)
insert dbo.Food
		(ten,idCategory,price)
values (N'Trái Cây Tự Chọn ',5,41000)
-- Yaourt
insert dbo.Food
		(ten,idCategory,price)
values (N'Yaourt nếp cẩm hạt đác',6,41000)
insert dbo.Food
		(ten,idCategory,price)
values (N'Yaourt các loại',6,39000)
--Nước Ngọt
insert dbo.Food
		(ten,idCategory,price)
values (N'RellBull (Thái Lan)',7,32000)
insert dbo.Food
		(ten,idCategory,price)
values (N'Sting Dâu',7,31000)
-- Sinh Tố 

insert dbo.Food
		(ten,idCategory,price)
values (N'Sinh Tố Tự Chọn',8,41000)
insert dbo.Food
		(ten,idCategory,price)
values (N'Sinh Tố Bơ',8,39000)
-- Nước Ép
insert dbo.Food
		(ten,idCategory,price)
values (N'Nước ép hỗn hợp',9,39000)
insert dbo.Food
		(ten,idCategory,price)
values (N'Dừa tươi',9,31000)

-- HÀNG BILL & BILL INFOR KHÔNG CẦN THÊM (CHỈ CẦN THÊM KHI TEST)
-- thêm bill
insert dbo.Bill
		(DateCheckIn,DateCheckOut,idTable,status)
values ( GETDATE(),
		 NULL,
		 1,
		 0
)
insert dbo.Bill
		(DateCheckIn,DateCheckOut,idTable,status)
values ( GETDATE(),
		 NULL,
		 2,
		 0
)
insert dbo.Bill
		(DateCheckIn,DateCheckOut,idTable,status)
values ( GETDATE(),
		 GETDATE(),
		 2,
		 1
)
insert dbo.Bill
		(DateCheckIn,DateCheckOut,idTable,status)
values ( GETDATE(),
		 GETDATE(),
		 3,
		 1
)

--thêm bill info
INSERT	BillInfo
		(idBill,idFood,count)
values (1,
		1,
		2)
INSERT	BillInfo
		(idBill,idFood,count)
values (1,
		2,
		2)
INSERT	BillInfo
		(idBill,idFood,count)
values (2,
		1,
		2)
INSERT	BillInfo
		(idBill,idFood,count)
values (2,
		3,
		1)
INSERT	BillInfo
		(idBill,idFood,count)
values (3,
		4,
		5)
--
select * from dbo.BillInfo where idBill = 1 
select f.ten, bi.count, f.price, f.price * bi.count as totalPrice from dbo.BillInfo as bi, dbo.Bill as b, dbo.Food as f
where bi.idBill = b.id and bi.idFood = f.id and b.idTable = 2
-- Xử lý button thêm bớt món cho hóa đơn
-- tạo Proc để insert lấy giá trị của bill vào insert bill để truy xuất dữ liệu ra mỗi khi thực hiện click vào bàn ăn bao gồm ngày ăn và ID 
go

-- tạo thêm giảm giá 
alter table dbo.Bill
add discount int
update dbo.Bill set discount = 0
select * from Bill
go
--
CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill 
	        ( DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status,
			  discount
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0,  -- status - int
			  0
	        ) 
END
GO--DROP PROCEDURE USP_InsertBill

--  tạo proc xử lý bill infor
/*
	CHÚ THÍCH XỬ LÝ 
	Xảy ra 2 trường hợp khi insert bill 
	TH1: nếu bàn lấy được bill nhưng bill không tồn tại thì BẮT BUỘC PHẢI TẠO 1 BILL MỚI TRÊN CÁI BÀN ĐẤY RỒI INSERT BILL INFO VÀO 
	TH2: nếu bàn đã tồn tại bill thì mình INSERT BILL INFO VÀO THÔI với trường hợp là THỨC ĂN CHƯA TỒN TẠI 
	TH3: nếu thức ăn đã tồn tại rồi thì cập nhật lại dữ liệu 
*/
GO
drop proc USP_InsertBillInfo
CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN

	DECLARE @isExitsBillInfo INT
	DECLARE @foodCount INT = 0
	
	SELECT @isExitsBillInfo = id, @foodCount = b.count 
	FROM dbo.BillInfo AS b 
	WHERE idBill = @idBill AND idFood = @idFood

	IF (@isExitsBillInfo > 0)
	BEGIN -- xử lý tăng giảm number tăng số lượng nếu số lượng thêm vào lớn hơn 0 thì tăng ngược lại thì trừ đi số lượng của món đó 
		DECLARE @newCount INT = @foodCount + @count 
		IF (@newCount > 0)
			UPDATE dbo.BillInfo	SET count = @foodCount + @count WHERE idFood = @idFood
		ELSE
			DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
	END
	ELSE
	BEGIN
		INSERT	dbo.BillInfo
        ( idBill, idFood, count )
		VALUES  ( @idBill, -- idBill - int
          @idFood, -- idFood - int
          @count  -- count - int
          )
	END
END
GO
-- Câu select để lấy id bill max do thuật toán tự tăng lên id khi mà thêm bàn mới 
select max(id) from dbo.Bill

--
select * from dbo.Bill
select * from dbo.BillInfo
select * from dbo.Food
select * from dbo.FoodCategory

-- Thanh Toán hóa đơn
update dbo.Bill set status =1 where id =1

-- update để thay đổi status bàn ăn 
DELETE dbo.BillInfo

DELETE dbo.Bill
--
go
CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = idBill FROM Inserted
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0
	DECLARE @count int
	SELECT @count = COUNT (*) FROM dbo.BillInfo WHERE idBill = @idBill
	IF (@count >0)
	UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
	ELSE
	UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO
-- Chuyển bàn
go
CREATE PROC USP_SwitchTabel
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	
	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idSeconrdBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	UPDATE dbo.BillInfo SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
END
GO
EXEC dbo.USP_SwitchTabel @idTable1 =8, @idTable2 =1
--Doanh Thu
--thêm bảng tổng tiền cho cái doanh thu
select * from Bill
ALTER TABLE dbo.Bill ADD totalPrice FLOAT
GO
CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.ten AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
-- set quyền admin
select* from Account
-- Cập nhật tài khoản thay đổi thông tin tài khoản
GO
CREATE PROC USP_UpdateAccount
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(100), @newPassword NVARCHAR(100)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE UserName = @userName AND PassWord = @password
	
	IF (@isRightPass = 1)
	BEGIN
		IF (@newPassword = NULL OR @newPassword = '')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END		
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	end
END
GO

CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = id, @idBill= deleted.idBill FROM deleted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE id= @idBill

	DECLARE @count INT =0
	
	SELECT @count= COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id= bi.idBill AND b.id=@idBill AND b.status = 0

	IF (@count=0 )
		UPDATE dbo.TableFood Set status = N'Trống' WHERE id = @idTable   
END
GO

