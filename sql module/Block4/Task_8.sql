use AdventureWorksLT2016;

-- 8.	ќтобразите 10 наиболее важных дл€ продаж городов.
go
select top 10 a.City, sum(soh.TotalDue) as [sum]
from SalesLT.[Address] a
	join SalesLT.CustomerAddress ca on ca.AddressID = a.AddressID
	join SalesLT.SalesOrderHeader soh on soh.CustomerID = ca.CustomerID
where 
	a.City = a.City
group by a.City
order by sum(soh.TotalDue) desc