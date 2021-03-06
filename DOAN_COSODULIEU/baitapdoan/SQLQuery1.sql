﻿-- BÀI TẬP ĐỒ ÁN ĐỀ TÀI 4.1 
--NGUYỄN TẤN PHA 22/04/2000 3001181179 TỈ LỆ LÀM:60% 18CDTH1
--PHẠM TRƯỜNG PHÚC 13/09/2000 3001180848 TỈ LỆ LÀM:20% 18CDTH1
--LÊ HOÀNG PHÚC 12/06/2000 3001181854 TỈ LỆ LÀM:20% 18CDTH1
--PHẦN TRĂM LÀM BÀI CHÚNG EM ĐÃ CHIA RA LUÔN CẢ PHẦN CHUYỂN DỮ LIỆU TỪ SQL SANG EXCEL VÀ TỪ EXCEL SANG SQL
-- CHUYỂN DỮ LIỆU TỪ FILE SQL SANG EXCEL VÀ TỪ EXCEL SANG SQL EM LÀM BÊN TRANG MỚI CÓ TÊN LÀ: CHUYENDL

	CREATE DATABASE QL_THICCNGANHAN ON PRIMARY 
(  
	NAME = 'DL_THICCNGANHAN',
	FILENAME = 'E:\baitapdoan\QL_THICCNGANHAN_PRIMARY.mdf',
    SIZE = 5 MB,  MAXSIZE = 10 MB,  FILEGROWTH = 10% 
)
 LOG ON 
(  
	NAME = 'DL_THICCNGANHAN_LOG',
	FILENAME = 'E:\baitapdoan\QL_THICCNGANHAN_LOG.ldf',
	SIZE = 2 MB,
	MAXSIZE = 5 MB, 
	FILEGROWTH = 15%
) 
CREATE TABLE LOAICC
(
	MALOAICC NCHAR(10) NOT NULL,
	TENLOAICC NVARCHAR (50),
	SOMONTP INT,  
	TGIANTHICC INT,
	TIEN MONEY,
	CONSTRAINT PK_LOAICC PRIMARY KEY (MALOAICC) 
)
CREATE TABLE MONTHANHPHAN
(
	MAMONTP NCHAR(10) NOT NULL,
	TENMON NVARCHAR (50),
	THOIGIANTHI INT,
	MALOAICC NCHAR(10),
	CONSTRAINT PK_MONTHANHPHAN PRIMARY KEY (MAMONTP),
	CONSTRAINT FK_MONTHANHPHAN_LOAICC FOREIGN KEY (MALOAICC) REFERENCES LOAICC(MALOAICC)
)
CREATE TABLE THISINH
(
    MATS NCHAR(10) NOT NULL,
	HOTEN NVARCHAR(50),
	NGAYSINH DATE,
	PHAI NCHAR(10),
	DIEMTB INT,
	KQ INT,
	XEPLOAI NCHAR(10),
	CONSTRAINT PK_THISINH PRIMARY KEY (MATS),
)
CREATE TABLE THONGBAO
(
	TGPHATHOSO TIME,
	TGNOPHOSO TIME,
	TGDUKIENTHI TIME,
	NGAYTHI DATETIME,
	MATS NCHAR(10),
	CONSTRAINT FK_THONGBAO FOREIGN KEY (MATS) REFERENCES THISINH (MATS),
)
CREATE TABLE TRUNGTAM
(
	MALOAICC NCHAR (10) NOT NULL,
	MATS NCHAR(10) NOT NULL,
	SOHOSOPHATRA INT,
	CONSTRAINT PK_TRUNGTAM PRIMARY KEY (MALOAICC,MATS),
	CONSTRAINT FK_TRUNGTAM_LOAICC FOREIGN KEY (MALOAICC) REFERENCES LOAICC (MALOAICC),
	CONSTRAINT FK_TRUNGTAM_THISINH FOREIGN KEY (MATS) REFERENCES THISINH (MATS),
)
CREATE TABLE PHANCONGNV
(
	MATS NCHAR(10) NOT NULL,
	MALOAICC NCHAR(10) NOT NULL,
	MANV NCHAR (10) NOT NULL,
	HOTENNV NCHAR(50),
	NGAYSINH DATE,
	PHAI NCHAR(10),
		CONSTRAINT PK_PHANCONGNV PRIMARY KEY (MANV),
	CONSTRAINT FK_PHANCONGNV_THISINH FOREIGN KEY (MATS) REFERENCES THISINH (MATS),
	CONSTRAINT FK_PHANCONGNV_LOAICC FOREIGN KEY (MALOAICC) REFERENCES LOAICC (MALOAICC),
)
CREATE TABLE KETQUATHI
(
	MATS NCHAR(10) NOT NULL,
	MAMONTP NCHAR(10) NOT NULL,
	MADOTTHI NCHAR (10) NOT NULL,
	CONSTRAINT PK_KETQUATHI PRIMARY KEY (MADOTTHI),
	CONSTRAINT FK_KETQUATHI_THISINH FOREIGN KEY (MATS) REFERENCES THISINH (MATS),
	CONSTRAINT FK_KETQUATHI_MONTHANHPHAN FOREIGN KEY (MAMONTP) REFERENCES MONTHANHPHAN (MAMONTP),
)
--tao rang buoc toan ven
ALTER TABLE LOAICC
ADD CONSTRAINT CHK_SOMONTP CHECK (SOMONTP >0)

ALTER TABLE MONTHANHPHAN
ADD CONSTRAINT UNI_TENMON UNIQUE (TENMON)

 ALTER TABLE THISINH
 ADD CONSTRAINT CHK_NGAYSINH CHECK  ((YEAR(GETDATE())-YEAR(NGAYSINH)) > 18)

 ALTER TABLE TRUNGTAM
 ADD CONSTRAINT CHK_SOHOSOPHATRA CHECK (SOHOSOPHATRA >0)
 --nhap lieu
INSERT INTO LOAICC
VALUES ('MCC001',N'CHỨNG CHỈ A1',2,60,1200000),
		('MCC002',N'CHỨNG CHỈ A2',1,60,1000000),
		('MCC003',N'CHỨNG CHỈ ANH VĂN B1',2,45,1100000)

INSERT INTO MONTHANHPHAN
VALUES ('MTP01',N'NGHE',15,'MCC001'),
		('MTP02',N'NÓI',20,'MCC002'),
		('MTP03',N'VIẾT',40,'MCC003')

SET DATEFORMAT DMY
INSERT INTO THISINH
VALUES ('MATS01',N'NGUYỄN TẤN PHA','22/04/2000','NAM',5,NULL,NULL),
		('MATS02',N'NGUYỄN QUỐC DANH','01/05/1999','NAM',8,NULL,NULL),
		('MATS03',N'NGUYỄN VĂN TRỌNG','02/06/2000',N'NỮ',6,NULL,NULL)

INSERT INTO THONGBAO
VALUES ('12:00','12:30','13:30','02/03/2019','MATS01'),
		('12:00','13:20','14:00','03/03/2019','MATS02'),
		('13:00','14:30','15:30','04/03/2019','MATS03')


INSERT INTO TRUNGTAM
VALUES ('MCC001','MATS01',2),
		('MCC002','MATS02',3),
		('MCC003','MATS03',2)
SET DATEFORMAT DMY
INSERT INTO PHANCONGNV
VALUES ('MATS01','MCC001','MANV01',N'LÊ HOÀNG NAM','22/4/1996','NAM'),
		('MATS02','MCC002','MANV02',N'ĐẶNG THỊ YẾN','03/02/1989',N'NỮ'),
		('MATS03','MCC003','MANV03',N'LÊ THỊ THU HÀ','10/01/1987',N'NỮ')
INSERT INTO KETQUATHI
VALUES ('MATS01','MTP01','MADTHI01'),
		('MATS02','MTP02','MADTHI02'),
		('MATS03','MTP03','MADTHI03')
-- tạo bản ảo gồm MATS,HOTEN,NGAYSINH = 2000
CREATE VIEW BANAO
AS
SELECT MATS,HOTEN,NGAYSINH
FROM THISINH
WHERE YEAR(NGAYSINH) = 2000

SELECT * FROM BANAO
-- XÓA BẢN AO TRÊN
DROP VIEW BANAO
--cau: cho biet thong tin thi sinh co MÁT01
SELECT *
FROM THISINH
WHERE MATS ='MATS01'
--CAU CHO BIET THI SINH THI SINH THI NGAY 02
SELECT *
FROM THISINH, THONGBAO
WHERE THISINH.MATS = THONGBAO.MATS AND DAY(NGAYTHI) =02

-- CHO BIET DANH SACH THI SINH THI MÔN NÓI HIỂN THỊ MATS,HOTEN,NGAYSINH,PHAI,TENMON
SELECT A.MATS,HOTEN,NGAYSINH,PHAI,TENMON
FROM THISINH A, MONTHANHPHAN B, KETQUATHI C
WHERE A.MATS = C.MATS AND B.MAMONTP = C.MAMONTP AND TENMON = N'NÓI'

-- SẮP DIEMTB TĂNG DẦN TRONG BẢNG THISINH
SELECT *
FROM THISINH
ORDER BY DIEMTB ASC
--HIỆN DANH SÁCH THỊ THÍ SINH CÓ KẾT QUẢ LỚN HƠN 5
SELECT A.MATS,A.HOTEN,B.MAMONTP,A.KQ
FROM THISINH A,KETQUATHI B,.MONTHANHPHAN C
WHERE A.MATS=B.MATS AND B.MAMONTP = C.MAMONTP AND KQ >=5 
--CHO BIẾT SỐ LƯỢNG MÀ NHÂN VIÊN PHÂN CÔNG QUẢN LÝ 
SELECT COUNT(*) N'SỐ LƯỢNG'
FROM THISINH A,PHANCONGNV B 
WHERE A.MATS = B.MATS
GROUP BY MANV 
--cau 1:Khai báo 4 biến để lưu trữ mã loại chứng chỉ (@malcc), tên loại chứng chỉ (@tenlcc), số môn thành phần (@somtp), thời gian thi chứng chỉ (@tgthicc)

	

declare @tenlcc nvarchar(50)
declare @somtp int
declare @tgthicc int
--cau 2. Dùng lệnh set để gán tên loại chứng chỉ, số môn thành phần, thời gian thi chứng chỉ, có mã chứng chỉlà “MCC001” vào 3 biến @tenlcc, @somtp, @tgthicc

set @tenlcc =(select TENLOAICC  from LOAICC where MALOAICC ='MCC001    ' )  
set @somtp = (select SOMONTP from loaicc where MALOAICC ='MCC001')
set @tgthicc = (select TGIANTHICC from LOAICC where MALOAICC ='MCC001' )
--CAU 3 Dùng lệnh select để in ra các giá trị của các biến vừa gán.
select @tenlcc as N'TÊN LOẠI CHỨNG CHỈ',@somtp AS N'SỐ MÔN THÀNH PHẦN',@tgthicc AS N'THỜI GIAN THI CHỨNG CHỈ'
--CAU 4: viết câu lệnh thêm thí sinh thi

CREATE PROC THEM
AS
BEGIN	
	SET DATEFORMAT DMY
	INSERT INTO THISINH
	VALUES ('MATS04',N'LÊ THỊ NGỌC HÀ','03/02/2000',N'NỮ',9,NULL,NULL)
END 
EXEC THEM
DROP PROC THEM
--CAU 5: CHO BIẾT SỐ LƯỢNG THI SINH ĐĂNG KÝ THI
CREATE PROC SOLUONGTHISINH
AS
BEGIN 
	SELECT COUNT(*) AS N'SỐ LƯỢNG THÍ SINH'
	FROM THISINH
END
DROP PROC SOLUONGTHISINH
EXEC SOLUONGTHISINH
--CAU 6: VIẾT THỦ TỤC CẬP NHẬT XẾP LOẠI CHO BẢNG THÍ SINH
CREATE PROC CAPNHATXEPLOAI
AS
BEGIN
	DECLARE @DIEMTB INT
	SET @DIEMTB = (SELECT DIEMTB FROM THISINH)
	IF @DIEMTB >= 8
	BEGIN
		UPDATE THISINH
		SET XEPLOAI = N'GIỎI'
	END
	ELSE IF @DIEMTB >=7 AND @DIEMTB <8 
	BEGIN
		UPDATE THISINH
		SET XEPLOAI ='KHÁ'
	END
	ELSE IF @DIEMTB >=5 AND @DIEMTB <7 
	BEGIN
		UPDATE THISINH
		SET XEPLOAI ='TRUNG BÌNH' 
	END
	ELSE 
	BEGIN
		UPDATE THISINH
		SET XEPLOAI = N'KÉM' 
	END
END
 EXEC CAPNHATXEPLOAI
 DROP PROC CAPNHATXEPLOAI
	
--VIẾT HÀM CHO BIẾT SỐ LƯỢNG MÀ NHÂN VIÊN PHÂN CÔNG QUẢN LÝ KHI TRUYỀN VÀO MANV
CREATE FUNCTION HAMVOHUONG1 (@MANV NCHAR (10))
RETURNS INT
AS
BEGIN
	DECLARE @SL INT
	SET @SL=(SELECT COUNT(*)
	FROM THISINH,PHANCONGNV WHERE THISINH.MATS = PHANCONGNV.MATS AND MANV=@MANV GROUP BY MANV )
	RETURN @SL
END
-- GỌI HÀM 
SELECT DBO.HAMVOHUONG1 ('MANV01')
--XÓA HÀM
DROP FUNCTION HAMVOHUONG1

--BIẾT HÀM HIỆN THỊ DANH SÁCH THÍ SINH CÓ KẾT QUẢ >= 5 KHI TRUYỀN VÀO MÃ MÔN THÀNH PHẦN 
CREATE FUNCTION HAMNOTUYEN1 (@MAMONTP NCHAR (10))
RETURNS TABLE 
AS
RETURN 
	SELECT A.MATS,A.HOTEN,B.MAMONTP,A.KQ
	FROM THISINH A,KETQUATHI B,.MONTHANHPHAN C
	WHERE A.MATS=B.MATS AND B.MAMONTP = C.MAMONTP AND KQ >=5  AND B.MAMONTP=@MAMONTP

SELECT *FROM HAMNOTUYEN1 ('MTP01')

DROP FUNCTION HAMNOTUYEN1

--VIẾT HÀM CHO BIẾT SỐ LƯỢNG THÍ SINH CÓ DIEMTB >=5
CREATE FUNCTION SOLUONGTHISINH1()
RETURNS INT
AS
BEGIN 
	DECLARE @SL1 INT
	SET @SL1 =(
	SELECT COUNT(*) 
	FROM THISINH
	WHERE DIEMTB>=5)
	RETURN @SL1
END

SELECT DBO.SOLUONGTHISINH1 ()

DROP FUNCTION SOLUONGTHHISINH1
--VIẾT TRIGGER KIỂM TRA KHI THÊM,SỬA BẢNG SINHVEN NGASINH KHÔNG ĐƯỢC LỚN HƠN NGÀY HIỆN TẠI
CREATE TRIGGER KiemTraNS
 ON THISINH 
FOR INSERT,UPDATE 
AS 
DECLARE @NGAYSINH DATE 
SET @NGAYSINH=(SELECT NGAYSINH FROM inserted) 
IF @NGAYSINH>GETDATE() 
	BEGIN  PRINT N' Ngày sinh phải < ngày hiện tại' 
	ROLLBACK TRAN 
END

-- VIẾT TRIGGER THỰC HIỆN KHI XÓA DỮ LIỆU TRONG BẢNG THISINH THÌ NHỮNG MATS TRONG BẢNG KETQUATHI CŨNG ĐƯỢC XÓA

CREATE TRIGGER XOADL 
ON THISINH
INSTEAD OF DELETE 
AS 
BEGIN  
	DELETE FROM KETQUATHI WHERE MATS IN (SELECT MATS FROM DELETED)  
	DELETE FROM THISINH WHERE MATS IN (SELECT MATS FROM DELETED) 
END

-- SUYỆT VÀ ĐỌC GIÁ TRỊ CURSOR VÀ CẬP NHẬT LẠI GIÁ TRỊ MATS = MANV + MATS HIỆN TẠI
--KHAI BÁO
DECLARE CUR_UPMATS CURSOR
FOR SELECT MANV FROM PHANCONGNV
--MỞ CURSOR
OPEN CUR_UPMATS
DECLARE @MANV NCHAR(10)
--NẠP CURSOR LẦN 1
FETCH NEXT FROM CUR_UPMATS INTO @MANV
-- FETCH LẦN 2
WHILE @@FETCH_STATUS = 0
BEGIN
	UPDATE THISINH
	SET MATS = MANV + MATS
	WHERE MANV = @MANV
	FETCH NEXT FROM CUR_UPMATS INTO @MANV
END
-- ĐÓNG CURSOR
CLOSE CUR_UPMATS
-- HỦY CURSOR
DEALLOCATE CUR_UPMATS

--KẾT HỢP CURSOR VIẾT HÀM TRẢ VỀ THÔNG TIN THISINH(MATS,HOTEN)
CREATE FUNCTION CUR_FUN_THONGTINTS()
RETURNS @DS TABLE(MATS NCHAR(10),HOTEN NVARCHAR (50))
AS
BEGIN
DECLARE CUR_THONGTINTS CURSOR SCROLL
FOR SELECT MATS,HOTEN FROM THISINH
DECLARE @MATS NCHAR(10),@HOTEN NVARCHAR(50)
OPEN CUR_THONGTINTS
FETCH NEXT FROM CUR_THONGTINTS INTO @MATS,@HOTEN
WHILE @@FETCH_STATUS=0
BEGIN
	INSERT INTO @DS
	VALUES (@MATS,@HOTEN)
	FETCH NEXT FROM CUR_THONGTINTS INTO @MATS,@HOTEN
END
CLOSE CUR_THONGTINTS
DEALLOCATE CUR_THONGTINTS
RETURN
END

--BACKUP DANG FULL 13
BACKUP DATABASE QL_THICCNGANHAN
TO DISK='E:\baitapdoan\BACKUP\QL_THICCNGANHAN.BAK'
--BACKUP DIFFERENTIAL
INSERT INTO LOAICC
VALUES ('MCC006',N'CHỨNG CHỈ C3',3,50,1300000)
BACKUP DATABASE QL_THICCNGANHAN
TO DISK='E:\baitapdoan\BACKUP\QL_THICCNGANHAN_DIFF1.BAK'
--BACKUP TRANSACTION LOG
BACKUP LOG QL_THICCNGANHAN
TO DISK='E:\baitapdoan\BACKUP\QL_THICCNGANHAN_TRAN1.trn'

--PHỤC HỒI BẢN FULL
RESTORE DATABASE QL_THICCNGANHAN
FROM DISK='E:\baitapdoan\BACKUP\QL_THICCNGANHAN.BAK'

SP_ADDLOGIN 'USER1' , '123'

SP_ADDUSER 'USER1','USER1'
--PHÂN QUYỀN 
GRANT SELECT 
ON THISINH
TO USER1



