create database InventorySystem
use InventorySystem

create table Users
(
Username varchar (50) primary key,
Full_Name varchar (50),
User_Password varchar (50),
Phone_Number varchar (50)
)

select * from Users
truncate table Users
insert into Users values('viper','Isuru Perera','wwe123','0767585795')
insert into Users values('admin','For All users','admin1234','0112641892')


create table Customers
(
Customer_ID int primary key,
Customer_Name varchar (50),
Phone_Number varchar (50)
)

select * from Customers
truncate table Customers
insert into Customers values('1','Abans(Dasun Shanaka)','0771098654')
insert into Customers values('2','Singhagiri(Kapila Silva)','0751998125')
insert into Customers values('3','Softlogic Max Moratuwa(Wannidu Hasaranga)','0720142876')
insert into Customers values('4','Singer(Lasith Malinga)','0777719654')




create table Categories
(
Category_ID int primary key,
Category_Name varchar (50)
)

select * from Categories
truncate table Categories
insert into Categories values('1','Mobile Phones')
insert into Categories values('2','Laptops')
insert into Categories values('3','TV')
insert into Categories values('4','Apple Products')
insert into Categories values('5','Refrigerators')
insert into Categories values('6','Audio')
insert into Categories values('7','Computers')
insert into Categories values('8','Home Appliances')
insert into Categories values('9','Watch')
insert into Categories values('10','Skechers')


create table Products
(
Product_ID int primary key,
Product_Name varchar (50),
Quantity int,
Price int,
Product_Description varchar (500),
Category varchar (50)
)

select * from Products
truncate table Products
insert into Products values('1000','Samsung A50','10','50000','Good Phone','Mobile Phones')
insert into Products values('1001','VIVO Mobile Y11 (Agate Red)','25','30000','Trendsetting Design 6.35 inch Halo FullView Display','Mobile Phones')
insert into Products values('2000','ASUS VivoBook 15 X512JP','5','170000','Core i7, 8GB, 1TB, Thin & Light, Finger Print','Laptops')
insert into Products values('2001','MSI-Notebook ','8','199000','15.6 FHD 60HZ, GTX16504GB, I5-9300H, 8GB,1TB7200 With Backpack','Laptops')
insert into Products values('3000','Samsung Smart LED TV','4','110000','43 Full HD, Resolution: 1920 x 1080, Fun Believable Features','TV')
insert into Products values('4000','Apple Mac Book Pro','2','695000','16 Space Gray, 2.3 GHZ Turbo 4.8GHz, i9, 9TH GEN, 16GB, 1TB SSD 2019','Apple Products')



create table Orders
(
Order_ID int primary key,
Customer_ID int,
Customer_Name varchar (50),
Order_Date datetime,
Total_Amount int
)

select * from Orders
truncate table Orders
