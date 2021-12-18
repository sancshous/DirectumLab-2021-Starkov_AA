using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Services;

namespace PlanPoker.DTO.DTOBuilder
{
  public static class RoomDTOBuilder
  {
    public static RoomDTO Build(Room room, IEnumerable<Discussion> discussions, CardService cardService)
    {
      var users = UserDTOBuilder.BuildList(room.Users);
      var discussionsInRoom = DiscussionDTOBuilder.BuildList(discussions, cardService).Where(discussion => discussion.RoomID == room.Id);
      return new RoomDTO()
      {
        Id = room.Id,
        Title = room.Title,
        OwnerId = room.OwnerId,
        Users = users,
        Discussions = discussionsInRoom
      };
    }

    public static IEnumerable<RoomDTO> BuildList(IEnumerable<Room> rooms, IEnumerable<Discussion> discussions, CardService cardService)
    {
      return rooms.Select(room => Build(room, discussions, cardService)).ToList();
    }
  }
}
