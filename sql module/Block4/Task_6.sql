use AdventureWorksLT2016;

--6.	������������� ������ �� ��������� ���������: 0�99, 100...999, 1000�9999, ����� 10000. 
--      ��� ������� ��������� ���������� ���������� ������� � ����� ���������.
go
select 
  [range], 
  count(*) as amount, 
  sum(TotalDue) as [sum] 
from
  (select *, '0-99' as [range]
  from SalesLT.SalesOrderHeader 
    where 
      TotalDue between 0 and 99
  union
  select *, '100-999' as [range] 
  from SalesLT.SalesOrderHeader 
    where 
      TotalDue between 100 and 999
  union
  select *, '1000-9999' as [range] 
  from SalesLT.SalesOrderHeader 
    where 
      TotalDue between 1000 and 9999
  union
  select *, '10000+' as [range] 
  from SalesLT.SalesOrderHeader 
    where 
      TotalDue > 10000) tbl
group by [range]