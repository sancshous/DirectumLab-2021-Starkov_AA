using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Domain.Services;
using PlanPoker.DTO;
using PlanPoker.DTO.DTOBuilder;

namespace PlanPoker.Controllers
{
  [ApiController]
  [Route("/api/[controller]/[action]")]
  public class RoomController
  {
    private readonly RoomService roomService;

    private readonly DiscussionService discussionService;

    private readonly CardService cardService;

    public RoomController(RoomService roomService, DiscussionService discussionService, CardService cardService)
    {
      this.roomService = roomService;
      this.discussionService = discussionService;
      this.cardService = cardService;
    }

    [HttpGet]
    public RoomDTO Create(string name, Guid ownerId)
    {
      var room = this.roomService.Create(name, ownerId);
      var discussions = this.discussionService.GetDiscussions(room.Id);
      return RoomDTOBuilder.Build(room, discussions, this.cardService, this.discussionService);
    }

    [HttpPost]
    public void Delete(Guid roomId)
    {
      this.roomService.Delete(roomId);
    }

    [HttpPost]
    public RoomDTO AddUser(Guid roomId, Guid userId)
    {
      this.roomService.AddUser(roomId, userId);
      var room = this.roomService.GetRooms().First(room => room.Id == roomId);
      var discussions = this.discussionService.GetDiscussions(roomId);
      return RoomDTOBuilder.Build(room, discussions, this.cardService, this.discussionService);
    }

    [HttpPost]
    public UserDTO SearchUser(Guid userId, Guid roomId)
    {
      var user = this.roomService.SearchUser(userId, roomId);
      if (user == null)
        return null;
      return UserDTOBuilder.Build(user);
    }

    [HttpPost]
    public bool SearchRoom(Guid roomId)
    {
      var room = this.roomService.SearchRoom(roomId);
      if (room == null)
        return false;
      return true;
    }

    [HttpPost]
    public void RemoveUser(Guid roomId, Guid userId)
    {
      this.roomService.RemoveUser(roomId, userId);
    }

    [HttpPost]
    public RoomDTO DeleteDiscussion(Guid roomId, Guid discussionId)
    {
      this.roomService.DeleteDiscussion(roomId, discussionId);
      this.discussionService.Delete(discussionId);
      var room = this.roomService.GetRooms().First(room => room.Id == roomId);
      var discussions = this.discussionService.GetDiscussions(roomId);
      return RoomDTOBuilder.Build(room, discussions, this.cardService, this.discussionService);
    }

    [HttpGet]
    public RoomDTO GetRoomInfo(Guid roomId)
    {
      var room = this.roomService.GetRooms().First(room => room.Id == roomId);
      var discussions = this.discussionService.GetDiscussions(roomId);
      return RoomDTOBuilder.Build(room, discussions, this.cardService, this.discussionService);
    }

    [HttpGet]
    public IEnumerable<RoomDTO> GetRooms()
    {
      var rooms = this.roomService.GetRooms();
      return RoomDTOBuilder.BuildListRoom(rooms);
    }
  }
}
