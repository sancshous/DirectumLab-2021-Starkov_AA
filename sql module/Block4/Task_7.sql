use AdventureWorksLT2016;

--7.	ќтобразить список компаний, содержащих УbikeФ или УcycleФ в названии. 
--      ќтсортировать выборку так, чтобы сначала отображались компании с Ђbikeї, а затем с Ђcycleї.
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