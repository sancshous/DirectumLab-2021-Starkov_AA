use AdventureWorksLT2016;

--2.	������� ������� �� ���������� (ListPrice) ���� 1000 ���� �������?
go
select sum(sod.OrderQty) as amount
from SalesLT.SalesOrderDetail sod
	join SalesLT.Product p on sod.ProductID = p.ProductID
where 
	p.ListPrice > 1000