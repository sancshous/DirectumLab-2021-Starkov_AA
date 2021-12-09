using System;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  public class UserService
  {
    private readonly IRepository<User> repository;

    public UserService(IRepository<User> repository)
    {
      this.repository = repository;
    }

    public User Create(string name)
    {
      var id = Guid.NewGuid();
      var user = new User(id, name, id.ToString());
      this.repository.Create(user);
      this.repository.Save();
      return user;
    }

    public void DeleteUser(Guid userId)
    {
      this.repository.Delete(userId);
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
