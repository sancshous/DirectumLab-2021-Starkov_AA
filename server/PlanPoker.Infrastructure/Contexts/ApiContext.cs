using Microsoft.EntityFrameworkCore;

namespace PlanPoker.Infrastructure.Contexts
{
  public class ApiContext<T> : DbContext where T : class
  {
    public ApiContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<T> Elements { get; set; }
  }
}
