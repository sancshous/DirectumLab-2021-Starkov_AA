use AdventureWorksLT2016;

--5.	Отобразить 25 товаров с наибольшим суммарным чеком (количество * стоимость товара).
go
select top 25 p.[Name], sum(sod.OrderQty * sod.UnitPrice) as [Sum]
from SalesLT.Product p
  join SalesLT.SalesOrderDetail sod on p.ProductID = sod.ProductID
where 
  sod.ProductID = p.ProductID
group by p.[Name], sod.OrderQty * sod.UnitPrice
order by
  sum(sod.OrderQty * sod.UnitPrice) desc

