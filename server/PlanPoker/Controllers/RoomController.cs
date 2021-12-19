using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Domain.Entities;
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
    public void AddUser(Guid roomId, Guid userId)
    {
      this.roomService.AddUser(roomId, userId);
    }

    [HttpPost]
    public void RemoveUser(Guid roomId, Guid userId)
    {
      this.roomService.RemoveUser(roomId, userId);
    }

    [HttpGet]
    public IEnumerable<UserDTO> GetUsers(Guid roomId)
    {
      var users = this.roomService.GetUsers(roomId);
      return UserDTOBuilder.BuildList(users);
    }

    [HttpGet]
    public RoomDTO GetRoomInfo(Guid roomId)
    {
      var room = this.roomService.GetRoom(roomId);
      var discussions = this.discussionService.GetDiscussions(roomId);
      return RoomDTOBuilder.Build(room, discussions, this.cardService, this.discussionService);
    }

    [HttpGet]
    public IEnumerable<RoomDTO> GetRooms(Guid roomId) // здесь roomId нужен чтоб получить все обсуждения одной комнаты
    {
      var rooms = this.roomService.GetRooms();
      var discussions = this.discussionService.GetDiscussions(roomId);
      return RoomDTOBuilder.BuildList(rooms, discussions, this.cardService, this.discussionService);
    }
  }
}
