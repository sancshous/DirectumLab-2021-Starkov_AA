using PlanPoker.Domain.Entities;
using PlanPoker.Infrastructure.Contexts;

namespace PlanPoker.Infrastructure.Repositories
{
  public class VoteRepository : BaseRepository<Vote>
  {
    public VoteRepository(VoteContext context) : base(context)
    {
    }
  }
}
