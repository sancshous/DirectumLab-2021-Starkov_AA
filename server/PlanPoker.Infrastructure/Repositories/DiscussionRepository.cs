using PlanPoker.Domain.Entities;
using PlanPoker.Infrastructure.Contexts;

namespace PlanPoker.Infrastructure.Repositories
{
  public class DiscussionRepository : BaseRepository<Discussion>
  {
    public DiscussionRepository(DiscussionContext context) : base(context)
    {
    }
  }
}
