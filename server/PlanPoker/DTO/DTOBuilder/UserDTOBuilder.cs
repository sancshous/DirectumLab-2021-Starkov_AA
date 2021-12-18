using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;

namespace PlanPoker.DTO.DTOBuilder
{
  public static class UserDTOBuilder
  {
    public static UserDTO Build(User user)
    {
      return new UserDTO()
      {
        Id = user.Id,
        Name = user.Name
      };
    }

    public static IEnumerable<UserDTO> BuildList(IEnumerable<User> users)
    {
      return users.Select(user => Build(user)).ToList();
    }
  }
}
