use AdventureWorksLT2016;

--5.	Отобразить 25 товаров с наибольшим суммарным чеком (количество * стоимость товара).
go
select top 25 p.[Name] 
from SalesLT.Product p
  join SalesLT.SalesOrderDetail sod on p.ProductID = sod.ProductID
where 
  sod.ProductID = p.ProductID
group by p.ProductID, p.[Name]
order by
  sum(sod.LineTotal)

