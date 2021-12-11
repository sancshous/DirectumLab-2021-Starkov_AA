using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Services;

namespace PlanPoker.DTO.DTOBuilder
{
  public static class RoomDTOBuilder
  {
    public static RoomDTO Build(Room room, UserService userService)
    {
      var users = UserDTOBuilder.BuildList(room.Users.Select(item => userService.Get(item)));
      return new RoomDTO()
      {
        Id = room.Id,
        Title = room.Title,
        OwnerId = room.OwnerId,
        Users = users
      };
    }

    public static IEnumerable<RoomDTO> BuildList(IEnumerable<Room> rooms, UserService userService)
    {
      return rooms.Select(room => Build(room, userService));
    }
  }
}
