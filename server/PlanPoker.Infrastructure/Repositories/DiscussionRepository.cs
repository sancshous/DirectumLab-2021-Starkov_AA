using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;
using PlanPoker.Infrastructure.Contexts;

namespace PlanPoker.Infrastructure.Repositories
{
  public class DiscussionRepository : BaseRepository<Discussion>
  {
    public DiscussionRepository(DiscussionContext context) : base(context)
    {
    }

    public override IQueryable<Discussion> GetAll()
    {
      return this.Context.Elements.Include(discus => discus.Votes);
    }
  }
}
