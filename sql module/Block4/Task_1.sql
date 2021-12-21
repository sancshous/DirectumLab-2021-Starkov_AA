use AdventureWorksLT2016;

--1.	Отобразить названия организации всех покупателей из Торонто.
go
select c.CompanyName
from SalesLT.Customer c
	join SalesLT.CustomerAddress ca on c.CustomerID = ca.CustomerID
	join SalesLT.[Address] a on ca.AddressID = a.AddressID
where 
	a.City = 'Toronto'