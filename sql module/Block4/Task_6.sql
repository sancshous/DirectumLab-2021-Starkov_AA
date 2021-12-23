use AdventureWorksLT2016;

--6.	—группировать заказы по диапазону стоимости: 0Е99, 100...999, 1000Е9999, свыше 10000. 
--    ƒл€ каждого диапазона отобразить количество заказов и общую стоимость.
go
select 
  [range], 
  count(*) as amount, 
  sum(TotalDue) as [sum] 
from
  (select *, [range] =
    case
      when TotalDue between 0 and 99 then '0-99' 
      when TotalDue between 100 and 999 then '100-999' 
      when TotalDue between 1000 and 9999 then '1000-9999' 
      when TotalDue > 10000 then '10000+' 
    end
   from SalesLT.SalesOrderHeader
  ) tbl
group by [range]

