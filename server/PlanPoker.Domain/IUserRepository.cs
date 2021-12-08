using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using System;

namespace PlanPoker.Domain
{
  public interface IUserRepository : IRepository<User>
  {
    public void Create(Guid id, string name, string token);
  }
}
