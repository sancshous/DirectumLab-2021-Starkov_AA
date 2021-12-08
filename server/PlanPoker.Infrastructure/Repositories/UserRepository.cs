using System;
using PlanPoker.Domain;
using PlanPoker.Domain.Entities;
using PlanPoker.Infrastructure.Contexts;

namespace PlanPoker.Infrastructure.Repositories
{
  /// <summary>
  /// Репозиторий участников.
  /// </summary>
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(UserContext context) : base(context)
    {
    }

    public void Create(Guid id, string name, string token)
    {
      this.Db.Elements.Add(new User(id, name, token));
      this.Db.SaveChanges();
    }
  }
}
