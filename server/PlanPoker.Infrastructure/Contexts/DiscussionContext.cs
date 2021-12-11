using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Infrastructure.Contexts
{
  public class DiscussionContext : ApiContext<Discussion>
  {
    public DiscussionContext(DbContextOptions<DiscussionContext> options) : base(options)
    {
    }
  }
}
