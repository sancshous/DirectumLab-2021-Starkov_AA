using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanPoker.Domain.Services
{
  public class RoomService
  {
    private readonly IRepository<Room> repository;

    public RoomService(IRepository<Room> repository)
    {
      this.repository = repository;
    }

    public Room Create(string title, Guid ownerId)
    {
      var id = Guid.NewGuid();
      var room = new Room(id, title, ownerId);
      this.repository.Add(room);
      this.AddUser(id, ownerId);
      this.repository.Save();
      return room;
    }

    public void Delete(Guid roomId)
    {
      this.repository.Delete(roomId);
    }

    public void AddUser(Guid roomId, Guid userId)
    {
      this.repository.Get(roomId).Users.Add(userId);
    }

    public void RemoveUser(Guid roomId, Guid userId)
    {
      this.repository.Get(roomId).Users.Remove(userId);
    }

    public ICollection<Guid> GetUsers(Guid roomId)
    {
      return this.repository.Get(roomId).Users;
    }

    public Room GetRoom(Guid id)
    {
      return this.repository.Get(id);
    }

    public IEnumerable<Room> GetRooms()
    {
      return this.repository.GetAll();
    }
  }
}
