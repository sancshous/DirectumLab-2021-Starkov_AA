use AdventureWorksLT2016;

--6.	������������� ������ �� ��������� ���������: 0�99, 100...999, 1000�9999, ����� 10000. 
--    ��� ������� ��������� ���������� ���������� ������� � ����� ���������.
go
select 
  [Range], 
  count(*) as Amount, 
  sum(TotalDue) as [Sum] 
from
  (select TotalDue, [Range] =
    case
      when TotalDue between 0 and 99 then '0-99' 
      when TotalDue between 100 and 999 then '100-999' 
      when TotalDue between 1000 and 9999 then '1000-9999' 
      when TotalDue > 10000 then '10000+' 
    end
   from SalesLT.SalesOrderHeader
  ) tbl
group by [Range]

