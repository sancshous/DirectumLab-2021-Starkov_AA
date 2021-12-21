use AdventureWorksLT2016;

--4.	Какие компании заказывали продукт (ProductModel) «Racing Socks»?
go
select c.CompanyName company
from SalesLT.Customer c
	join SalesLT.SalesOrderHeader soh on c.CustomerID = soh.CustomerID
	join SalesLT.SalesOrderDetail sod on sod.SalesOrderID = soh.SalesOrderID
	join SalesLT.Product p on p.ProductID = sod.ProductID
	join SalesLT.ProductModel pm on pm.ProductModelID = p.ProductModelID
where	
	pm.[Name] = 'Racing Socks'
group by c.CompanyName