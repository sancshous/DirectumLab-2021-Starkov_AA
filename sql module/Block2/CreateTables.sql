create database Block2;

go
use Block2

create table dbo.Customers
(
	Id int identity primary key not null,
	LastName nvarchar(20) not null,
	FirstName nvarchar(20) not null,
	ThirdName nvarchar(20) not null,
	City nvarchar(20) not null
);

create table dbo.Sellers
(
	Id int identity primary key not null,
	LastName nvarchar(20) not null,
	FirstName nvarchar(20) not null,
	ThirdName nvarchar(20) not null,
	City nvarchar(20) not null,
	CommissionPercent numeric(3, 0) not null
);

create table dbo.Orders
(
	Id int identity primary key not null,
	Summary nvarchar(1000) not null,

	Amount money not null
		constraint CK_Order_Amount check(Amount > 0),

	OrderDateTime datetime not null,
	CustomerId int not null references Customers(Id),
	SellerId int not null references Sellers(Id)
);

create table dbo.OrdersHistory
(
	Id int identity primary key not null,
	OperationType nvarchar(50) not null,
	OperationDateTime datetime not null default getdate(),
	OrderDateTime datetime not null,
	OrderId int not null,
	CustomerId int not null,
	SellerId int not null
);
