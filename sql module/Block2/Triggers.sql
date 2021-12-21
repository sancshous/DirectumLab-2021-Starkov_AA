use Block2

go
create trigger dbo.OrdersDelete
on dbo.Orders
after delete
as
insert into dbo.OrdersHistory (OperationType, OrderDateTime, OrderId, CustomerId, SellerId)
select 
  'DELETE', 
  OrderDateTime,
  Id,
  CustomerId, 
  SellerId
from deleted

go
create trigger dbo.OrdersInsert
on dbo.Orders
after insert
as
insert into dbo.OrdersHistory (OperationType, OrderDateTime, OrderId, CustomerId, SellerId)
select
  'INSERT',
  OrderDateTime,
  Id,
  CustomerId, 
  SellerId
from inserted

go
create trigger dbo.OrdersUpdate
on dbo.Orders
after update
as
insert into dbo.OrdersHistory (OperationType, OrderDateTime, OrderId, CustomerId, SellerId)
select
  'UPDATE', 
  OrderDateTime, 
  Id,
  CustomerId, 
  SellerId
from inserted

go
create trigger dbo.OrdersCityInsert
on dbo.Orders
after insert
as
begin
if (select count(*) from dbo.Orders
where
  Id in (select Id from inserted)
  and exists
  (
  select * from 
    dbo.Customers
    join dbo.Sellers on Customers.Id = Orders.CustomerId and Sellers.Id = Orders.SellerId
  where 
	  Customers.City <> Sellers.City
  )) > 0
	Throw 50001, 'Failed to delete line.', 1;
end