using System;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  public class UserService
  {
    private readonly IRepository<User> userRepository;

    public UserService(IRepository<User> exampleRepository)
    {
      this.userRepository = exampleRepository;
    }

    public int TestMethod(int num)
    {
      //this.userRepository.GetAll().Where
      return num;
    }

    public int ThrowException(int id)
    {
      throw new Exception($"Exception throwed {id}");
    }
  }
}
