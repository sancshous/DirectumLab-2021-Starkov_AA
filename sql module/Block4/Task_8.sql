use AdventureWorksLT2016;

-- 8.	���������� 10 �������� ������ ��� ������ �������.
go
select top 10 a.City, sum(soh.TotalDue) as [Sum]
from SalesLT.[Address] a
	join SalesLT.SalesOrderHeader soh on soh.ShipToAddressID = a.AddressID
group by a.City
order by sum(soh.TotalDue) desc 
