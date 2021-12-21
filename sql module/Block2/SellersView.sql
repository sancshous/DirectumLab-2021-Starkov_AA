use Block2;

go
create view dbo.SellersView (Id, LastName, FirstName, ThirdName, CommissionPercent, CommissionSum) 
as
select 
  S.Id,
  S.LastName,
  S.FirstName,
  S.ThirdName,
  S.CommissionPercent,
  (sum(O.Amount) * S.CommissionPercent / 100)
from 
  dbo.Sellers as S 
  join dbo.Orders as O on S.Id = O.SellerId
group by
  S.Id, 
  S.LastName,
  S.FirstName,
  S.ThirdName,
  S.CommissionPercent
