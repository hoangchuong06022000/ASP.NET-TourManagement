--DESKTOP-K4N035T\SQLEXPRESS
--TAO CO SO DU LIEU
create database QUANLYTOURDULICH
--SU DUNG CO SO DU LIEU
use QUANLYTOURDULICH

--TAO CAC BANG
create table TOURDULICH
(
	MATOUR char(4) not null,
	TENGOI nvarchar(100) not null,
	DACDIEM nvarchar(100) not null,
	MALOAIHINH char(4) not null --FK
)
create table DIADIEM
(
	MADIADIEM char(4) not null,
	TENDIADIEM nvarchar(100) not null
)
create table CHITIETTOUR
(
	MATOUR char(4) not null,
	MADIADIEM char(4) not null, 
	THUTU int not null
)
create table LOAIHINHDULICH
(
	MALOAIHINH char(4) not null,
	TENLOAIHINH nvarchar(100) not null
)
create table GIATOUR
(
	MAGIA char(4) not null,
	MATOUR char(4) not null, --FK
	THANHTIEN float,
	TG_BATDAU datetime,
	TG_KETTHUC datetime
)
create table DOANDULICH
(
	MADOAN char(4) not null,
	MATOUR char(4) not null, --FK
	NGAYKHOIHANH datetime,
	NGAYKETTHUC datetime,
	DOANHTHU float not null  --Doanh thu = gia tour * so luong khach
)
create table CHITIETDOAN
(
	MADOAN char(4) not null,
	MAKH char(4) not null,
	VAITROKH nvarchar(100)
)
create table NOIDUNG
(
	MADOAN char(4) not null,
	HANHTRINH nvarchar(100),
	KHACHSAN nvarchar(100) not null
)
create table KHACH
(
	MAKH char(4) not null,
	HOTEN nvarchar(100) not null,
	CMND char(12),
	DIACHI nvarchar(100),
	GIOITINH nvarchar(3),
	SDT char(10),
	QUOCTICH nvarchar(100)
)
create table NHANVIEN
(
	MANV char(4) not null,
	TENNV nvarchar(100) not null
)
create table PHANBONHANVIEN
(
	MANV char(4) not null,
	MADOAN char(4) not null,
	NHIEMVU nvarchar(100)
)
create table CHIPHI
(
	MACHIPHI char(4) not null,
	MADOAN char(4) not null, 
	SOTIEN float
)
create table LOAICHIPHI
(
	MACHIPHI char(4) not null,
	TENLOAICHIPHI nvarchar(100) not null
)

--TAO KHOA
--TAO KHOA CHINH
alter table TOURDULICH add constraint PK_TOURDULICH primary key (MATOUR)
alter table DIADIEM add constraint PK_DIADIEM primary key (MADIADIEM)
alter table CHITIETTOUR add constraint PK_CHITIETTOUR primary key (MATOUR,MADIADIEM)
alter table LOAIHINHDULICH add constraint PK_LOAIHINHDULICH primary key (MALOAIHINH)
alter table GIATOUR add constraint PK_GIATOUR primary key (MAGIA)
alter table DOANDULICH add constraint PK_DOANDULICH primary key (MADOAN)
alter table CHITIETDOAN add constraint PK_CHITIETDOAN primary key (MADOAN,MAKH)
alter table NOIDUNG add constraint PK_NOIDUNG primary key (MADOAN)
alter table KHACH add constraint PK_KHACH primary key (MAKH)
alter table NHANVIEN add constraint PK_NHANVIEN primary key (MANV)
alter table PHANBONHANVIEN add constraint PK_PHANBONHANVIEN primary key (MANV,MADOAN)
alter table CHIPHI add constraint PK_CHIPHI primary key (MACHIPHI,MADOAN)
alter table LOAICHIPHI add constraint PK_LOAICHIPHI primary key (MACHIPHI)
--TAO KHOA NGOAI
alter table TOURDULICH add constraint FK_TOURDULICH foreign key (MALOAIHINH) references LOAIHINHDULICH(MALOAIHINH)
alter table CHITIETTOUR add constraint FK_CHITIETTOUR foreign key (MATOUR) references TOURDULICH(MATOUR)
alter table CHITIETTOUR add constraint FK_CHITIETTOUR1 foreign key (MADIADIEM) references DIADIEM(MADIADIEM)
alter table GIATOUR add constraint FK_GIATOUR foreign key (MATOUR) references TOURDULICH(MATOUR)
alter table DOANDULICH add constraint FK_DOANDULICH foreign key (MATOUR) references TOURDULICH(MATOUR)
alter table CHITIETDOAN add constraint FK_CHITIETDOAN foreign key (MADOAN) references DOANDULICH(MADOAN)
alter table CHITIETDOAN add constraint FK_CHITIETDOAN1 foreign key (MAKH) references KHACH(MAKH)
alter table NOIDUNG add constraint FK_NOIDUNG foreign key (MADOAN) references DOANDULICH(MADOAN)
alter table PHANBONHANVIEN add constraint FK_PHANBONHANVIEN foreign key (MANV) references NHANVIEN(MANV)
alter table CHIPHI add constraint FK_CHIPHI foreign key (MACHIPHI) references LOAICHIPHI(MACHIPHI)
alter table CHIPHI add constraint FK_CHIPHI1 foreign key (MADOAN) references DOANDULICH(MADOAN)

--THEM DU LIEU
--NHAP DU LIEU TABLE: TOURDULICH
insert into TOURDULICH(MATOUR,TENGOI,DACDIEM,MALOAIHINH) values ('T001',N'SÀI GÒN - NHA TRANG',N'2 ngày 1 đêm','LH01')
insert into TOURDULICH(MATOUR,TENGOI,DACDIEM,MALOAIHINH) values ('T002',N'SÀI GÒN - ĐÀ LẠT',N'2 ngày 1 đêm','LH02')
insert into TOURDULICH(MATOUR,TENGOI,DACDIEM,MALOAIHINH) values ('T003',N'SÀI GÒN - MIỀN TÂY',N'2 ngày 1 đêm','LH03')
insert into TOURDULICH(MATOUR,TENGOI,DACDIEM,MALOAIHINH) values ('T004',N'SÀI GÒN - TÂY NGUYÊN',N'2 ngày 1 đêm','LH04')
--NHAP DU LIEU TABLE: DIADIEM
insert into DIADIEM(MADIADIEM,TENDIADIEM) values ('D001',N'Đảo Hòn Mun')
insert into DIADIEM(MADIADIEM,TENDIADIEM) values ('D002',N'Đảo Bình Ba')
insert into DIADIEM(MADIADIEM,TENDIADIEM) values ('D003',N'Thác Datanla Đà Lạt')
insert into DIADIEM(MADIADIEM,TENDIADIEM) values ('D004',N'Núi Langbiang Đà Lạt')
insert into DIADIEM(MADIADIEM,TENDIADIEM) values ('D005',N'Chợ nổi Cái Răng')
insert into DIADIEM(MADIADIEM,TENDIADIEM) values ('D006',N'Bến Ninh Kiều')
insert into DIADIEM(MADIADIEM,TENDIADIEM) values ('D007',N'Hang Chư Bluk (Hang Dơi)')
insert into DIADIEM(MADIADIEM,TENDIADIEM) values ('D008',N'Khu du lịch sinh thái núi MĐrăk')
--NHAP DU LIEU TABLE: THAMQUAN
insert into CHITIETTOUR(MATOUR,MADIADIEM,THUTU) values ('T001','D001','1')
insert into CHITIETTOUR(MATOUR,MADIADIEM,THUTU) values ('T001','D002','2')
insert into CHITIETTOUR(MATOUR,MADIADIEM,THUTU) values ('T002','D003','1')
insert into CHITIETTOUR(MATOUR,MADIADIEM,THUTU) values ('T002','D004','2')
insert into CHITIETTOUR(MATOUR,MADIADIEM,THUTU) values ('T003','D005','1')
insert into CHITIETTOUR(MATOUR,MADIADIEM,THUTU) values ('T003','D006','2')
insert into CHITIETTOUR(MATOUR,MADIADIEM,THUTU) values ('T004','D007','1')
insert into CHITIETTOUR(MATOUR,MADIADIEM,THUTU) values ('T004','D008','2')
--NHAP DU LIEU TABLE: LOAIHINHDULICH
insert into LOAIHINHDULICH(MALOAIHINH,TENLOAIHINH) values ('LH01',N'Du lịch xã hội và gia đình')
insert into LOAIHINHDULICH(MALOAIHINH,TENLOAIHINH) values ('LH02',N'Du lịch cá nhân')
insert into LOAIHINHDULICH(MALOAIHINH,TENLOAIHINH) values ('LH03',N'Du lịch teambuilding')
insert into LOAIHINHDULICH(MALOAIHINH,TENLOAIHINH) values ('LH04',N'Du lịch sinh thái')
--NHAP DU LIEU TABLE: GIATOUR
insert into GIATOUR(MAGIA,MATOUR,THANHTIEN,TG_BATDAU,TG_KETTHUC) values ('GT01','T001','1200000','2022-02-22','2022-04-22')
insert into GIATOUR(MAGIA,MATOUR,THANHTIEN,TG_BATDAU,TG_KETTHUC) values ('GT02','T002','950000','2022-06-12','2022-08-12')
insert into GIATOUR(MAGIA,MATOUR,THANHTIEN,TG_BATDAU,TG_KETTHUC) values ('GT03','T003','600000','2022-01-05','2022-06-05')
insert into GIATOUR(MAGIA,MATOUR,THANHTIEN,TG_BATDAU,TG_KETTHUC) values ('GT04','T004','2000000','2022-05-17','2022-09-17')
--NHAP DU LIEU TABLE: DOANDULICH
insert into DOANDULICH(MADOAN,MATOUR,NGAYKHOIHANH,NGAYKETTHUC,DOANHTHU) values ('DO01','T001','2022-03-15','2022-03-17','6000000')
insert into DOANDULICH(MADOAN,MATOUR,NGAYKHOIHANH,NGAYKETTHUC,DOANHTHU) values ('DO02','T002','2022-06-25','2022-06-27','4750000')
insert into DOANDULICH(MADOAN,MATOUR,NGAYKHOIHANH,NGAYKETTHUC,DOANHTHU) values ('DO03','T003','2022-04-16','2022-04-18','3000000')
insert into DOANDULICH(MADOAN,MATOUR,NGAYKHOIHANH,NGAYKETTHUC,DOANHTHU) values ('DO04','T004','2022-05-19','2022-05-21','10000000')
--NHAP DU LIEU TABLE: CHITIETDOAN
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO01','KH01',N'Khách đi du lịch với gia đình')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO01','KH02',N'Khách đi du lịch với gia đình')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO01','KH03',N'Khách đi du lịch với gia đình')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO01','KH04',N'Khách đi du lịch với gia đình')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO01','KH05',N'Khách đi du lịch với gia đình')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO02','KH06',N'Khách đi du lịch cá nhân')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO02','KH07',N'Khách đi du lịch cá nhân')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO02','KH08',N'Khách đi du lịch cá nhân')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO02','KH09',N'Khách đi du lịch cá nhân')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO02','KH10',N'Khách đi du lịch cá nhân')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO03','KH11',N'Khách hàng đi du lịch theo công ty')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO03','KH12',N'Khách hàng đi du lịch theo công ty')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO03','KH13',N'Khách hàng đi du lịch theo công ty')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO03','KH14',N'Khách hàng đi du lịch theo công ty')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO03','KH15',N'Khách hàng đi du lịch theo công ty')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO04','KH16',N'Khách đi du lịch cá nhân')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO04','KH17',N'Khách đi du lịch cá nhân')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO04','KH18',N'Khách đi du lịch cá nhân')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO04','KH19',N'Khách đi du lịch cá nhân')
insert into CHITIETDOAN(MADOAN,MAKH,VAITROKH) values ('DO04','KH20',N'Khách đi du lịch cá nhân')
--NHAP DU LIEU TABLE: NOIDUNG
insert into NOIDUNG(MADOAN,HANHTRINH,KHACHSAN) values ('DO01','',N'Rex Hotel & Apartment')
insert into NOIDUNG(MADOAN,HANHTRINH,KHACHSAN) values ('DO02','',N'Lamie Hotel & Studio')
insert into NOIDUNG(MADOAN,HANHTRINH,KHACHSAN) values ('DO03','',N'ConVoi Hotel')
insert into NOIDUNG(MADOAN,HANHTRINH,KHACHSAN) values ('DO04','',N'Tay Nguyen Hotel')
--NHAP DU LIEU TABLE: KHACH
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH01',N'Nguyễn Thùy Chi','072145783465',N'Tỉnh Lộ 10, Quận Bình Tân, TP HCM',N'Nữ','0321589102',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH02',N'Nguyễn Đức Minh','072182374584',N'Tỉnh Lộ 10, Quận Bình Tân, TP HCM',N'Nam','0705145202',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH03',N'Nguyễn Tuyết Nhi','072148376014',N'Tỉnh Lộ 10, Quận Bình Tân, TP HCM',N'Nữ','0934123521',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH04',N'Nguyễn Gia An','072132459731',N'Tỉnh Lộ 10, Quận Bình Tân, TP HCM',N'Nam','0924151325',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH05',N'Nguyễn Thanh Nhật','072103502234',N'Tỉnh Lộ 10, Quận Bình Tân, TP HCM',N'Nam','0935120275',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH06',N'Phạm Ánh Dương','072147582390',N'Nguyễn Công Trứ, Quận Bình Thạnh, TP HCM',N'Nữ','0935120275',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH07',N'Phạm Thiên Ân','072177381353',N'Phan Văn Hớn, Huyện Hóc Môn, TP HCM',N'Nam','0950123589',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH08',N'Đặng Gia Hân','072131453401',N'Huỳnh Văn Nghệ, Quận Gò Vấp, TP HCM',N'Nữ','0795342467',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH09',N'Đặng Ngọc Gia Nguyên','072243531123',N'Nguyễn Văn Trỗi, Quận Phú Nhuận, TP HCM',N'Nam','0940567316',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH10',N'Đỗ Phương Thảo','072158301345',N'Bạch Đằng, Quận Tân Bình, TP HCM',N'Nữ','0775428796',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH11',N'Đỗ Quang Khải','072192843592',N'Phan Châu Trinh, Quận Tân Phú, TP HCM',N'Nam','0902464703',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH12',N'Phạm Diệu Linh','072132151233',N'Phạm Văn Sáng, Huyện Bình Chánh, TP HCM',N'Nữ','0762190538',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH13',N'Phạm Hùng Cường','072113857182',N'Nguyễn Huy Tưởng, Quận Bình Thạnh, TP HCM',N'Nam','0351298632',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH14',N'Đặng Trúc Lâm','072132183731',N'Cây Trâm, Quận Gò Vấp, TP HCM',N'Nữ','0924582906',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH15',N'Đặng Minh Quân','072100345812',N'Trần Quang Diệu, Quận Phú Nhuận, TP HCM',N'Nam','0705643219',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH16',N'Đỗ Đan Hạ','072153941753',N'Ngự Bình, Quận Tân Bình, TP HCM',N'Nữ','0399641785',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH17',N'Đỗ Thái Dương','072157601234',N'Phạm Văn Đồng, Quận Thủ Đức, TP HCM',N'Nam','0761297518',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH18',N'Hoàng Vân Khánh','072149502586',N'An Thới Đông, Huyện Cần Giờ, TP HCM',N'Nữ','0388127529',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH19',N'Đinh Nhã Uyên','072134151349',N'Quang Trung, Quận 12, TP HCM',N'Nữ','0937841679',N'Việt Nam')
insert into KHACH(MAKH,HOTEN,CMND,DIACHI,GIOITINH,SDT,QUOCTICH) values ('KH20',N'Vũ Hà My','072143178913',N'Tôn Đản, Quận 4, TP HCM',N'Nữ','0367189002',N'Việt Nam')
--NHAP DU LIEU TABLE: NHANVIEN
insert into NHANVIEN(MANV,TENNV) values ('NV01',N'Tô Ngọc Bích')
insert into NHANVIEN(MANV,TENNV) values ('NV02',N'Đặng Thiên Hương')
insert into NHANVIEN(MANV,TENNV) values ('NV03',N'Lý Thanh Hồng')
insert into NHANVIEN(MANV,TENNV) values ('NV04',N'Nguyễn Trung Kiên')
--NHAP DU LIEU TABLE: PHANBONHANVIEN
insert into PHANBONHANVIEN(MANV,MADOAN,NHIEMVU) values ('NV01','DO01',N'Hướng dẫn viên')
insert into PHANBONHANVIEN(MANV,MADOAN,NHIEMVU) values ('NV02','DO02',N'Hướng dẫn viên')
insert into PHANBONHANVIEN(MANV,MADOAN,NHIEMVU) values ('NV03','DO03',N'Hướng dẫn viên')
insert into PHANBONHANVIEN(MANV,MADOAN,NHIEMVU) values ('NV04','DO04',N'Hướng dẫn viên')
--NHAP DU LIEU TABLE: CHIPHI
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP01','DO01','600000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP02','DO01','500000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP03','DO01','100000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP01','DO02','450000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP02','DO02','400000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP03','DO02','100000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP01','DO03','300000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP02','DO03','200000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP03','DO03','100000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP01','DO04','1200000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP02','DO04','700000')
insert into CHIPHI(MACHIPHI,MADOAN,SOTIEN) values ('CP03','DO04','100000')
--NHAP DU LIEU TABLE: LOAICHIPHI
insert into LOAICHIPHI(MACHIPHI,TENLOAICHIPHI) values ('CP01',N'Chi phí trực tiếp')
insert into LOAICHIPHI(MACHIPHI,TENLOAICHIPHI) values ('CP02',N'Chi phí nhân viên hướng dẫn viên')
insert into LOAICHIPHI(MACHIPHI,TENLOAICHIPHI) values ('CP03',N'Chi phí quản lý phục vụ')

--Tính Số Lượng Khách Mỗi Đoàn
select COUNT(CHITIETDOAN.MAKH)
from (CHITIETDOAN inner join DOANDULICH on DOANDULICH.MADOAN = CHITIETDOAN.MADOAN inner join KHACH on KHACH.MAKH=CHITIETDOAN.MAKH)
group by DOANDULICH.MADOAN


SELECT MATOUR,TENGOI, DACDIEM, TENLOAIHINH FROM dbo.TOURDULICH TOUR, dbo.LOAIHINHDULICH LOAI WHERE TOUR.MALOAIHINH = LOAI.MALOAIHINH

SELECT MATOUR, TENDIADIEM, THUTU FROM dbo.CHITIETTOUR CTT, dbo.DIADIEM DD WHERE CTT.MADIADIEM = DD.MADIADIEM  AND MATOUR ='T001' 

select * from LOAIHINHDULICH

select * from TOURDULICH


