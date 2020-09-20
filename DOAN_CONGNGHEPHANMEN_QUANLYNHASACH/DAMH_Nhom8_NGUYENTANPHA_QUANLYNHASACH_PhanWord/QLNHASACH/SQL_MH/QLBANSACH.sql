/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     8/5/2020 2:08:11 PM                          */
/*==============================================================*/

create database QLBANSACH
use QLBANSACH


create table CTHOADON (
   MAHD                 char(50)             not null,
   MASACH               char(10)             not null,
   SOLUONG              int                  null,
   TONGTIEN             float                null,
   constraint PK_CTHOADON primary key (MAHD, MASACH)
)
go

/*==============================================================*/
/* Index: Relationship_6_FK                                     */
/*==============================================================*/
create index Relationship_6_FK on CTHOADON (
MAHD ASC
)
go

/*==============================================================*/
/* Index: Relationship_7_FK                                     */
/*==============================================================*/
create index Relationship_7_FK on CTHOADON (
MASACH ASC
)
go

/*==============================================================*/
/* Table: HOADON                                                */
/*==============================================================*/
create table HOADON (
   MAHD                 char(50)             not null,
   MANV                 char(10)             null,
   MAKH                 char(10)             null,
   NGAYLAP              date             null,
   constraint PK_HOADON primary key nonclustered (MAHD)
)
go

/*==============================================================*/
/* Index: Relationship_4_FK                                     */
/*==============================================================*/
create index Relationship_4_FK on HOADON (
MAKH ASC
)
go

/*==============================================================*/
/* Index: Relationship_5_FK                                     */
/*==============================================================*/
create index Relationship_5_FK on HOADON (
MANV ASC
)
go

/*==============================================================*/
/* Table: KHACHHANG                                             */
/*==============================================================*/
create table KHACHHANG (
   MAKH                 char(10)             not null,
   TENKH                nvarchar(50)          null,
   NGAYSINH             date             null,
   GIOITINH             int                  null,
   CMT                  char(10)             null,
   SDT                  char(10)             null,
   DIACHI               nvarchar(200)         null,
   constraint PK_KHACHHANG primary key nonclustered (MAKH)
)
go

/*==============================================================*/
/* Table: NHANVIEN                                              */
/*==============================================================*/
create table NHANVIEN (
   MANV                 char(10)             not null,
   IDPASS				varchar(40),
   TENNV                nvarchar(50)          null,
   NGAYSINH             date             null,
   GIOITINH             int                  null,
   CMT                  char(10)             null,
   SDT                  char(10)             null,
   DIACHI               nvarchar(200)         null,
   CHUCVU               int                  null,
   constraint PK_NHANVIEN primary key nonclustered (MANV)
)
go

/*==============================================================*/
/* Table: NHAXUATBAN                                            */
/*==============================================================*/
create table NHAXUATBAN (
   MANXB                char(10)             not null,
   TENNXB               nvarchar(50)          null,
   constraint PK_NHAXUATBAN primary key nonclustered (MANXB)
)
go

/*==============================================================*/
/* Table: SACH                                                  */
/*==============================================================*/
create table SACH (
   MASACH               char(10)             not null,
   MATL                 char(10)             null,
   MATG                 char(10)             null,
   MANXB                char(10)             null,
   TENSACH              nvarchar(50)          null,
   NGAYPH               date             null,
   DONGIA               float                null,
   constraint PK_SACH primary key nonclustered (MASACH)
)
go

/*==============================================================*/
/* Index: Relationship_1_FK                                     */
/*==============================================================*/
create index Relationship_1_FK on SACH (
MATL ASC
)
go

/*==============================================================*/
/* Index: Relationship_8_FK                                     */
/*==============================================================*/
create index Relationship_8_FK on SACH (
MANXB ASC
)
go

/*==============================================================*/
/* Index: Relationship_9_FK                                     */
/*==============================================================*/
create index Relationship_9_FK on SACH (
MATG ASC
)
go

/*==============================================================*/
/* Table: TACGIA                                                */
/*==============================================================*/
create table TACGIA (
   MATG                 char(10)             not null,
   TENTG                nvarchar(50)          null,
   constraint PK_TACGIA primary key nonclustered (MATG)
)
go

/*==============================================================*/
/* Table: THELOAI                                               */
/*==============================================================*/
create table THELOAI (
   MATL                 char(10)             not null,
   TENTHELOAI           nvarchar(50)          null,
   constraint PK_THELOAI primary key nonclustered (MATL)
)
go

alter table CTHOADON
   add constraint FK_CTHOADON_RELATIONS_HOADON foreign key (MAHD)
      references HOADON (MAHD)
go

alter table CTHOADON
   add constraint FK_CTHOADON_RELATIONS_SACH foreign key (MASACH)
      references SACH (MASACH)
go

alter table HOADON
   add constraint FK_HOADON_RELATIONS_KHACHHAN foreign key (MAKH)
      references KHACHHANG (MAKH)
go

alter table HOADON
   add constraint FK_HOADON_RELATIONS_NHANVIEN foreign key (MANV)
      references NHANVIEN (MANV)
go

alter table SACH
   add constraint FK_SACH_RELATIONS_THELOAI foreign key (MATL)
      references THELOAI (MATL)
go

alter table SACH
   add constraint FK_SACH_RELATIONS_NHAXUATB foreign key (MANXB)
      references NHAXUATBAN (MANXB)
go

alter table SACH
   add constraint FK_SACH_RELATIONS_TACGIA foreign key (MATG)
      references TACGIA (MATG)
go


select * from NHAXUATBAN

select * from THELOAI

select * from TACGIA

select * from NHANVIEN
set dateformat dmy

delete from NHANVIEN

delete from SACH
insert into NHANVIEN values
('123','1',N'Nguyễn Quốc Danh','7/3/2000',0,'291218929','0978350541',N'Tây Ninh',1),
('1412','1',N'Nguyễn Quốc Danh','7/3/2000',0,'291218929','0978350541',N'Tây Ninh',0)

select *,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH

select TENTHELOAI from THELOAI where MATL=1

select * from THELOAI,SACH,NHAXUATBAN where THELOAI.MATL=SACH.MATL AND SACH.MANXB=NHAXUATBAN.MANXB

select *
from NHAXUATBAN

where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB
select * ,DAY(NGAYPH)as 'day',MONTH(NGAYPH)as 'thang',YEAR(NGAYPH)as 'nam' from SACH,THELOAI,NHAXUATBAN,TACGIA where THELOAI.MATL=SACH.MATL and SACH.MANXB=NHAXUATBAN.MANXB and SACH.MATG=TACGIA.MATG



select * from KHACHHANG

update NHANVIEN set MANV='931', TENNV=@tennv, NGAYSINH=@ngaysinh, GIOITINH=,CMT='931',SDT=@sdt,DIACHI=@diachi,CHUCVU=@cv

select * from KHACHHANG, HOADON, NHANVIEN where HOADON.MAKH=KHACHHANG.MAKH and HOADON.MANV=NHANVIEN.MANV

update KHACHHANG HOADON set MAKH='721' where MAKH='932'

select MAKH+DAY(NGAYLAP)+MONTH(NGAYLAP)+YEAR(NGAYLAP) from HOADON

select DONGIA from SACH where MASACH='1'

select * from HOADON,CTHOADON where HOADON.MAHD=CTHOADON.MAHD and HOADON.MAHD='923848982020'