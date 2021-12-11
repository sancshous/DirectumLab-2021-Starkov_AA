using System;
using System.Collections.Generic;
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

    private readonly UserService userService;

    public RoomController(RoomService roomService, UserService userService)
    {
      this.roomService = roomService;
      this.userService = userService;
    }

    [HttpGet]
    public RoomDTO Create(string name, string ownerId)
    {
      var ownerIdGuid = Guid.Parse(ownerId.Replace(" ", string.Empty));
      var room = this.roomService.Create(name, ownerIdGuid);
      return RoomDTOBuilder.Build(room, this.userService);
    }

    [HttpPost]
    public void Delete(Guid roomId)
    {
      this.roomService.Delete(roomId);
    }

    [HttpPost]
    public void AddUser(string roomId, string userId)
    {
      var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
      var userGuid = Guid.Parse(userId.Replace(" ", string.Empty));
      this.roomService.AddUser(roomGuid, userGuid);
    }

    [HttpPost]
    public void RemoveUser(string roomId, string userId)
    {
      var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
      var userGuid = Guid.Parse(userId.Replace(" ", string.Empty));
      this.roomService.RemoveUser(roomGuid, userGuid);
    }

    [HttpGet]
    public void GetUsers(string roomId)
    {
      var roomGuid = Guid.Parse(roomId.Replace(" ", string.Empty));
      this.roomService.GetUsers(roomGuid);
    }

    [HttpGet]
    public IEnumerable<RoomDTO> GetRooms()
    {
      var rooms = this.roomService.GetRooms();
      return RoomDTOBuilder.BuildList(rooms, this.userService);
    }
  }
}
