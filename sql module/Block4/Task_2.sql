use AdventureWorksLT2016;

--2.	—колько товаров со стоимостью (ListPrice) выше 1000 было продано?
go
select sum(sod.OrderQty) as amount
from SalesLT.SalesOrderDetail sod
	join SalesLT.Product p on sod.ProductID = p.ProductID
where 
	p.ListPrice > 1000