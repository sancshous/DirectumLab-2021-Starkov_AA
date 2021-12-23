use AdventureWorksLT2016;

--3.	Отобразить названия организаций, суммарные покупки которых (включая налоги), превысили 50000.

go
select c1.CompanyName organization
from SalesLT.Customer c1
  join SalesLT.SalesOrderHeader soh on soh.CustomerID = c1.CustomerID
  join SalesLT.Customer c2 on soh.CustomerID = c2.CustomerID
where
  c2.CompanyName = c1.CompanyName
group by c1.CompanyName
having 
  sum(soh.TotalDue) > 50000
