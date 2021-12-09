using PlanPoker.Domain.Entities;
using PlanPoker.Infrastructure.Contexts;

namespace PlanPoker.Infrastructure.Repositories
{
  public class CardRepository : BaseRepository<Card>
  {
    public CardRepository(CardContext context) : base(context)
    {
      this.Db.SaveChanges();
    }
  }
}
