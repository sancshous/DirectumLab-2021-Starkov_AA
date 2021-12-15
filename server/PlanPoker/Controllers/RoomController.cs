using System;
using System.Collections.Generic;
using System.Linq;
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

    private readonly UserService userService;

    public RoomController(RoomService roomService, UserService userService)
    {
      this.roomService = roomService;
      this.userService = userService;
    }

    [HttpGet]
    public RoomDTO Create(string name, Guid ownerId)
    {
      var room = this.roomService.Create(name, ownerId);
      return RoomDTOBuilder.Build(room, this.userService);
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
    public void RemoveUser(Guid roomId, User user)
    {
      this.roomService.RemoveUser(roomId, user);
    }

    [HttpGet]
    public IEnumerable<UserDTO> GetUsers(Guid roomId)
    {
      var users = this.roomService.GetUsers(roomId);
      return UserDTOBuilder.BuildList(users);
    }

    [HttpGet]
    public IEnumerable<RoomDTO> GetRooms()
    {
      var rooms = this.roomService.GetRooms();
      return RoomDTOBuilder.BuildList(rooms, this.userService);
    }
  }
}
