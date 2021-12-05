using PlanPoker.Domain.Contexts;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Infrastructure.Repositories
{
  public class CardRepository : BaseRepository<Card>
  {
    public CardRepository(CardContext context) : base(context)
    {
    }
  }
}
