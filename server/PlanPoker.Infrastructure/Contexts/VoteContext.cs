using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Infrastructure.Contexts
{
  public class VoteContext : ApiContext<Vote>
  {
    public VoteContext(DbContextOptions<VoteContext> options) : base(options)
    {
    }
  }
}
