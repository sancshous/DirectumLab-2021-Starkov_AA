use Block2

go
create trigger dbo.OrdersDelete
on Orders
after delete
as
insert into OrdersHistory (OperationType, OrderDateTime, OrderId, CustomerId, SellerId)
select 
  'DELETE', 
  OrderDateTime,
  Id,
  CustomerId, 
  SellerId
from deleted

go
create trigger dbo.OrdersInsert
on Orders
after insert
as
insert into OrdersHistory (OperationType, OrderDateTime, OrderId, CustomerId, SellerId)
select
  'INSERT',
  OrderDateTime,
  Id,
  CustomerId, 
  SellerId
from inserted

go
create trigger dbo.OrdersUpdate
on Orders
after update
as
insert into OrdersHistory (OperationType, OrderDateTime, OrderId, CustomerId, SellerId)
select
  'UPDATE', 
  OrderDateTime, 
  Id,
  CustomerId, 
  SellerId
from inserted

go
create trigger dbo.OrdersCityInsert
on Orders
after insert
as
begin try
  delete Orders
  where
    Id in (select Id from inserted)
    and exists
    (
	  select * from Customers, Sellers
	  where 
	    Customers.Id = CustomerId
	    and Sellers.Id = SellerId
	    and Customers.City <> Sellers.City
    );
end try
begin catch
  Throw 11034, 'Failed to delete line.', 1;
end catch
