use AdventureWorksLT2016;

--5.	���������� 25 ������� � ���������� ��������� ����� (���������� * ��������� ������).
go
select top 25 p.[Name] 
from SalesLT.Product p
  join SalesLT.SalesOrderDetail sod on p.ProductID = sod.ProductID
group by p.ProductID, p.[Name]
order by
  (select sum(sod.LineTotal)
  from SalesLT.SalesOrderDetail sod
    where 
      sod.ProductID = p.ProductID) 
