use Block2;

go
create procedure dbo.OrdersByCity
  @City nvarchar(20)
as
select * from Orders join Sellers on (Orders.SellerId = Sellers.Id)
where
  City = @City
