use Block2

go
create trigger dbo.OrdersDelete
on dbo.Orders
after delete
as
insert into dbo.OrdersHistory (OrderId, OperationType, OrderDateTime, CustomerId, SellerId)
select 
  Id,
  'DELETE', 
  OrderDateTime,
  CustomerId, 
  SellerId
from deleted

go
create trigger dbo.OrdersInsert
on dbo.Orders
after insert
as
insert into dbo.OrdersHistory (OrderId, OperationType, OrderDateTime, CustomerId, SellerId)
select
  Id,
  'INSERT',
  OrderDateTime,
  CustomerId, 
  SellerId
from inserted

go
create trigger dbo.OrdersUpdate
on dbo.Orders
after update
as
insert into dbo.OrdersHistory (OrderId, OperationType, OrderDateTime, CustomerId, SellerId)
select
  Id,
  'UPDATE', 
  OrderDateTime, 
  CustomerId, 
  SellerId
from inserted

go
create trigger dbo.OrdersCityInsert
on dbo.Orders
after insert
as
begin
if(select count(*) from inserted
  where exists
  (
  select * from 
    dbo.Customers
    join dbo.Sellers on Customers.Id = inserted.CustomerId and Sellers.Id = inserted.SellerId
  where 
	  Customers.City <> Sellers.City
  )) > 0
    Throw 50001, 'Failed to delete line.', 1;
end