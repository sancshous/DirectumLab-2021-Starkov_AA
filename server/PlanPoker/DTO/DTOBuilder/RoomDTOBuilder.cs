using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Services;

namespace PlanPoker.DTO.DTOBuilder
{
  public static class RoomDTOBuilder
  {
    public static RoomDTO Build(Room room, IEnumerable<Discussion> discussions, CardService cardService, DiscussionService discussionService)
    {
      var users = UserDTOBuilder.BuildList(room.Users);
      var discussionsInRoom = DiscussionDTOBuilder.BuildList(discussions, cardService, discussionService).Where(discussion => discussion.RoomID == room.Id);
      return new RoomDTO()
      {
        Id = room.Id,
        Title = room.Title,
        OwnerId = room.OwnerId,
        Users = users,
        Discussions = discussionsInRoom
      };
    }

    public static IEnumerable<RoomDTO> BuildList(IEnumerable<Room> rooms, IEnumerable<Discussion> discussions, CardService cardService, DiscussionService discussionService)
    {
      return rooms.Select(room => Build(room, discussions, cardService, discussionService)).ToList();
    }

    public static IEnumerable<RoomDTO> BuildListRoom(IEnumerable<Room> rooms)
    {
      RoomDTO BuildRoom(Room room)
      {
        var users = UserDTOBuilder.BuildList(room.Users);
        return new RoomDTO()
        {
          Id = room.Id,
          Title = room.Title,
          OwnerId = room.OwnerId,
          Users = users,
          Discussions = null
        };
      }
      return rooms.Select(room => BuildRoom(room)).ToList();
    }
  }
}
