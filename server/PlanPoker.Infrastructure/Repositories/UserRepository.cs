using PlanPoker.Domain.Entities;
using PlanPoker.Infrastructure.Contexts;

namespace PlanPoker.Infrastructure.Repositories
{
  /// <summary>
  /// Репозиторий участников.
  /// </summary>
  public class UserRepository : BaseRepository<User>
  {
    public UserRepository(UserContext context) : base(context)
    {
    }
  }
}
