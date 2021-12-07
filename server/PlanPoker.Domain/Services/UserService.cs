using System;
using System.Linq;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Domain.Services
{
  public class UserService
  {
    private readonly UserRepository repository;

    public UserService(UserRepository repository)
    {
      this.repository = repository;
    }

    public User Create(string name)
    {
      var token = Guid.NewGuid().ToString();
      var id = Guid.NewGuid();
      this.repository.Create(id, name);
      return this.repository.Get(id);
    }

    public User Get(Guid id)
    {
      return this.repository.Get(id);
    } 

    public IQueryable<User> GetPlayers()
    {
      return this.repository.GetAll();
    }
  }
}
