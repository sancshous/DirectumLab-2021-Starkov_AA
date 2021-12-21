use AdventureWorksLT2016;

--3.	Отобразить названия организаций, суммарные покупки которых (включая налоги), превысили 50000.
go
select c1.CompanyName organization
from SalesLT.Customer c1
group by c1.CompanyName
having 
  (select sum(soh.TotalDue) 
  from SalesLT.SalesOrderHeader soh
    join SalesLT.Customer c2 on soh.CustomerID = c2.CustomerID
  where 
    c2.CompanyName = c1.CompanyName) > 50000 
