use AdventureWorksLT2016;

--7.	���������� ������ ��������, ���������� �bike� ��� �cycle� � ��������. 
--      ������������� ������� ���, ����� ������� ������������ �������� � �bike�, � ����� � �cycle�.
go
select distinct CompanyName company
from SalesLT.Customer c1
	where 
		c1.CompanyName like '%bike%'
union all
select distinct CompanyName company
from SalesLT.Customer c2
	where 
		c2.CompanyName like '%cycle%'