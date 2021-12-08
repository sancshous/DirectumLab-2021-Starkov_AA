using System;
using System.Linq;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Domain.Services
{
  public class UserService
  {
    private readonly IUserRepository repository;

    public UserService(IUserRepository repository)
    {
      this.repository = repository;
    }

    public User Create(string name)
    {
      var id = Guid.NewGuid();
      this.repository.Create(id, name, id.ToString());
      return this.repository.Get(id);
    }

    public string GetToken(Guid id)
    {
      return this.Get(id).Token;
    }

    public User Get(Guid id)
    {
      return this.repository.Get(id);
    }

    public IQueryable<User> GetUsers()
    {
      return this.repository.GetAll();
    }
  }
}
