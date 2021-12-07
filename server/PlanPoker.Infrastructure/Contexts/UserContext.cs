using Microsoft.EntityFrameworkCore;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Infrastructure.Contexts
{
  public class UserContext : ApiContext<User>
  {
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }
  }
}
